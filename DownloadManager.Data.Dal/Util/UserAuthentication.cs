using System;
using System.Collections.Generic;
using DownloadManager.Core;
using DownloadManager.Data.Dal.Repositories;
using DownloadManager.Domain.Entities;

namespace DownloadManager.Data.Dal.Util
{
	public static class UserAuthentication
	{
		#region Private fields

		// 5 Minutes seems a good time span to allow access for already verified users.
        private static readonly TimeSpan TimeSpanSkipVerificationForVerified = new TimeSpan(0, 5, 0);

        // 5 Seconds should be ok to reduce load by denial of service attacks, but not too long to wait when a password was fixed.
        private static readonly TimeSpan TimeSpanSkipVerificationForUnverified = new TimeSpan(0, 0, 5);

        // cache
        private static readonly Dictionary<string, VerificationInfo> UserInfos = new Dictionary<string, VerificationInfo>();

		#endregion

        public static bool CheckCredentials(string username, string password)
		{
			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
			{
				return false;
			}

			lock (UserInfos)
			{
				bool isUserCached = UserInfos.TryGetValue(username, out VerificationInfo userInfo);

				if (isUserCached)
				{
					if (userInfo.SkipVerificationUntil > DateTime.Now)
					{
						// We verified this user shortly. Skip verification for performance reasons. Give or deny access as cached.
						return userInfo.Verified;
					}
					else
					{
						// Cached but (positive or negative) verification outdated.
						// Remove from cache and proceed.
						UserInfos.Remove(username);
					}
				}
			}

            // User not cached (either from beginning or no more, because not verified).
            // Get data user info from DB.
            var userRepository = new UserRepository();
            User user = userRepository.GetByUsername(username);

			// User is verified if known in DB and has correct credentials.
			bool userIsVerified = null != user && PasswordHasher.VerifyPasswordHash(password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt));

			// Put user verification info into cache.
			lock (UserInfos)
			{
				DateTime skipVerificationUntil = DateTime.Now.Add(userIsVerified ? TimeSpanSkipVerificationForVerified : TimeSpanSkipVerificationForUnverified);
				UserInfos[username] = new VerificationInfo(userIsVerified, skipVerificationUntil);
			}

			return userIsVerified;
		}

		#region Nested class

		private class VerificationInfo
        {
            public readonly bool Verified;
            public readonly DateTime SkipVerificationUntil;

            public VerificationInfo(bool verified, DateTime skipVerificationUntil)
            {
                Verified = verified; 
                SkipVerificationUntil = skipVerificationUntil;
            }
        }

		#endregion
    }
}

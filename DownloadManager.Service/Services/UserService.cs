using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadManager.Core;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Domain.Entities;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Contract.Models.Input;

namespace DownloadManager.Service.Services
{
    public class UserService : IUserService
    {
        #region Private fields

        // 5 Minutes seems a good time span to allow access for already verified users.
        private static readonly TimeSpan TimeSpanSkipVerificationForVerified = new TimeSpan(0, 5, 0);

        // 5 Seconds should be ok to reduce load by denial of service attacks, but not too long to wait when a password was fixed.
        private static readonly TimeSpan TimeSpanSkipVerificationForUnverified = new TimeSpan(0, 0, 5);

        // cache
        private static readonly Dictionary<string, VerificationInfo> UserInfos = new Dictionary<string, VerificationInfo>();

        private readonly IUserRepository _userRepository;

        #endregion

        #region ctor

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        #endregion

        #region Public methods

        public void RegisterUser(IUserCredentialsModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrWhiteSpace(model.Username))
            {
                throw new ArgumentNullException(nameof(model.Username));
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                throw new ArgumentNullException(nameof(model.Username));
            }

            PasswordHasher.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            UserDto user = new UserDto()
            {
                Username = model.Username,
                PasswordHash = Convert.ToBase64String(passwordHash),
                PasswordSalt = Convert.ToBase64String(passwordSalt)
            };

            _userRepository.Add(user);

            lock (UserInfos)
            {
                DateTime skipVerificationUntil = DateTime.Now.Add(TimeSpanSkipVerificationForVerified);
                UserInfos[model.Username] = new VerificationInfo(true, skipVerificationUntil);
            }
        }

        public bool CheckCredentials(IUserCredentialsModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrWhiteSpace(model.Username))
            {
                throw new ArgumentNullException(nameof(model.Username));
            }

            if (string.IsNullOrWhiteSpace(model.Password))
            {
                throw new ArgumentNullException(nameof(model.Username));
            }

            lock (UserInfos)
            {
                bool isUserCached = UserInfos.TryGetValue(model.Username, out VerificationInfo userInfo);

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
                        UserInfos.Remove(model.Username);
                    }
                }
            }

            // User not cached (either from beginning or no more, because not verified).
            // Get data user info from DB.
            User user = _userRepository.GetByUsername(model.Username);

            // User is verified if known in DB and has correct credentials.
            bool userIsVerified = null != user && PasswordHasher.VerifyPasswordHash(model.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt));

            // Put user verification info into cache.
            lock (UserInfos)
            {
                DateTime skipVerificationUntil = DateTime.Now.Add(userIsVerified ? TimeSpanSkipVerificationForVerified : TimeSpanSkipVerificationForUnverified);
                UserInfos[model.Username] = new VerificationInfo(userIsVerified, skipVerificationUntil);
            }

            return userIsVerified;
        }

        public int GetUserIdByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            var user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                throw new InvalidOperationException($"User with name {username} was not found.");
            }

            return user.UserId;
        }

        #endregion

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

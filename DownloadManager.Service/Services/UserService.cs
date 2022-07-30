using System;
using System.Data.SqlClient;
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

            try
            {
                _userRepository.Add(user);
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Violation of UNIQUE KEY constraint \'UC_Username\'. Cannot insert duplicate key"))
                {
                    throw new InvalidOperationException(
                        $"User with name {model.Username} already exists.");
                }

                throw;
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

            // User not cached (either from beginning or no more, because not verified).
            // Get data user info from DB.
            User user = _userRepository.GetByUsername(model.Username);

            // User is verified if known in DB and has correct credentials.
            bool userIsVerified = null != user && PasswordHasher.VerifyPasswordHash(model.Password, Convert.FromBase64String(user.PasswordHash), Convert.FromBase64String(user.PasswordSalt));

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
    }
}

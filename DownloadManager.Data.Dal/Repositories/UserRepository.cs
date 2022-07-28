using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Data.Dal.Util;
using DownloadManager.Domain.Entities;

namespace DownloadManager.Data.Dal.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Public methods

        public IEnumerable<User> Get()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            string connString = ConnectionString.Get();

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new InvalidOperationException("Failed to obtain connection string.");
            }

            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand(_getUserByIdQueryString, sqlConnection, transaction))
                    {
                        command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = id;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read() && reader.FieldCount != 0)
                            {
                                var user = new User
                                {
                                    UserId = reader.GetFieldValue<int>(0),
                                    Username = reader.GetFieldValue<string>(1),
                                    PasswordHash = reader.GetFieldValue<string>(2),
                                    PasswordSalt = reader.GetFieldValue<string>(3),
                                };

                                reader.Close();
                                return user;
                            }

                            reader.Close();
                            return null;
                        }
                    }
                }
            }
        }

        public User GetByUsername(string username)
        {
            string connString = ConnectionString.Get();

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new InvalidOperationException("Failed to obtain connection string.");
            }

            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand(_getUserByNameQueryString, sqlConnection, transaction))
                    {
                        command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 256).Value = username;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read() && reader.FieldCount != 0)
                            {
                                var user = new User
                                {
                                    UserId = reader.GetFieldValue<int>(0),
                                    Username = reader.GetFieldValue<string>(1),
                                    PasswordHash = reader.GetFieldValue<string>(2),
                                    PasswordSalt = reader.GetFieldValue<string>(3),
                                };

                                reader.Close();
                                return user;
                            }

                            reader.Close();
                            return null;
                        }
                    }
                }
            }
        }

        public void Add(UserDto userDto)
        {
            string connString = ConnectionString.Get();

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new InvalidOperationException("Failed to obtain connection string.");
            }

            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand(_insertQueryString, sqlConnection, transaction))
                    {
                        command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 256).Value = userDto.Username;
                        command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarChar, -1).Value = userDto.PasswordHash;
                        command.Parameters.Add("@PasswordSalt", System.Data.SqlDbType.VarChar, -1).Value = userDto.PasswordSalt;

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public void Update(User user)
        {
            string connString = ConnectionString.Get();

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new InvalidOperationException("Failed to obtain connection string.");
            }

            using (var sqlConnection = new SqlConnection(connString))
            {
                sqlConnection.Open();

                using (var transaction = sqlConnection.BeginTransaction())
                {
                    using (var command = new SqlCommand(_updateUserQueryString, sqlConnection, transaction))
                    {
                        command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = user.UserId;
                        command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 256).Value = user.Username;
                        command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarChar, -1).Value = user.PasswordHash;
                        command.Parameters.Add("@PasswordSalt", System.Data.SqlDbType.VarChar, -1).Value = user.PasswordSalt;

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Query strings

        private static readonly string _getUserByIdQueryString =
            "SELECT TOP 1" + Environment.NewLine
                           + "     [UserId]" + Environment.NewLine
                           + "    ,[Username]" + Environment.NewLine
                           + "    ,[PasswordHash]" + Environment.NewLine
                           + "    ,[PasswordSalt]" + Environment.NewLine
                           + " FROM [dbo].[User]" + Environment.NewLine
                           + " WHERE [UserId] = @UserId";

        private static readonly string _getUserByNameQueryString =
            "SELECT TOP 1" + Environment.NewLine
                           + "     [UserId]" + Environment.NewLine
                           + "    ,[Username]" + Environment.NewLine
                           + "    ,[PasswordHash]" + Environment.NewLine
                           + "    ,[PasswordSalt]" + Environment.NewLine
                           + " FROM [dbo].[User]" + Environment.NewLine
                           + " WHERE [Username] = @Username";

        private static readonly string _updateUserQueryString =
            "UPDATE [dbo].[User] SET" + Environment.NewLine
                                      + "     [Username] = @Username" + Environment.NewLine
                                      + "    ,[PasswordHash] = @PasswordHash" + Environment.NewLine
                                      + "    ,[PasswordSalt] = @PasswordSalt" + Environment.NewLine
                                      + " WHERE [UserId] = @UserId";

        private static readonly string _insertQueryString =
            "INSERT INTO [dbo].[User] (" + Environment.NewLine
                                         + "    [Username]" + Environment.NewLine
                                         + "    ,[PasswordHash]" + Environment.NewLine
                                         + "    ,[PasswordSalt])" + Environment.NewLine
                                         + " VALUES (" + Environment.NewLine
                                         + "    @Username" + Environment.NewLine
                                         + "    ,@PasswordHash" + Environment.NewLine
                                         + "    ,@PasswordSalt)";

        #endregion
    }
}

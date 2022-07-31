using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using DownloadManager.Core.Enums;
using DownloadManager.Data.Dal.Contract.Dto;
using DownloadManager.Data.Dal.Contract.Repositories;
using DownloadManager.Data.Dal.Util;
using DownloadManager.Domain.Entities;

namespace DownloadManager.Data.Dal.Repositories
{
    public class FileRepository : IFileRepository
    {
        #region Public methods

        public IEnumerable<File> Get()
        {
            throw new NotImplementedException();
        }

        public File GetById(int id)
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
                    using (var command = new SqlCommand(_getFileByIdQueryString, sqlConnection, transaction))
                    {
                        command.Parameters.Add("@FileId", System.Data.SqlDbType.Int).Value = id;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read() && reader.FieldCount != 0)
                            {
                                var file = new File
                                {
                                    FileId = reader.GetFieldValue<int>(0),
                                    FileName = reader.GetFieldValue<string>(1),
                                    FileDownloadDirectory = reader.GetFieldValue<string>(2),
                                    FileDownloadMethod = (DownloadMethod)reader.GetFieldValue<int>(3),
                                    FileDownloadTime = reader.GetFieldValue<DateTime>(4),
                                    UserId = reader.GetFieldValue<int>(5)
                                };

                                reader.Close();
                                return file;
                            }

                            reader.Close();
                            return null;
                        }
                    }
                }
            }
        }

        public void Add(FileDto fileDto)
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
                        command.Parameters.Add("@FileName", System.Data.SqlDbType.NVarChar, 256).Value = fileDto.FileName;
                        command.Parameters.Add("@FileDownloadDirectory", System.Data.SqlDbType.NVarChar, -1).Value = fileDto.FileDownloadDirectory;
                        command.Parameters.Add("@FileDownloadMethod", System.Data.SqlDbType.Int).Value = (int)fileDto.FileDownloadMethod;
                        command.Parameters.Add("@FileDownloadTime", System.Data.SqlDbType.DateTime2, 7).Value = fileDto.FileDownloadTime;
                        command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = fileDto.UserId;

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
        }

        public void Update(File file)
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
                    using (var command = new SqlCommand(_updateFileQueryString, sqlConnection, transaction))
                    {
                        command.Parameters.Add("@FileId", System.Data.SqlDbType.Int).Value = file.FileId;
                        command.Parameters.Add("@FileName", System.Data.SqlDbType.NVarChar, 256).Value = file.FileName;
                        command.Parameters.Add("@FileDownloadDirectory", System.Data.SqlDbType.NVarChar, -1).Value = file.FileDownloadDirectory;
                        command.Parameters.Add("@FileDownloadMethod", System.Data.SqlDbType.Int).Value = (int)file.FileDownloadMethod;
                        command.Parameters.Add("@FileDownloadTime", System.Data.SqlDbType.DateTime2, 7).Value = file.FileDownloadTime;
                        command.Parameters.Add("@UserId", System.Data.SqlDbType.Int).Value = file.UserId;

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

        public IEnumerable<ReportDto> GetFiltered(FileFilterDto filterDto)
        {
            string connString = ConnectionString.Get();

            if (string.IsNullOrWhiteSpace(connString))
            {
                throw new InvalidOperationException("Failed to obtain connection string.");
            }

            DynamicParameters parameter = new DynamicParameters();

            var filterQuery = BuildFilterValuesQuery(filterDto, parameter);

            string sql = $@"SELECT f.[FileId]
                                  ,f.[FileName]
                                  ,f.[FileDownloadDirectory]
                                  ,f.[FileDownloadMethod]
                                  ,f.[FileDownloadTime]
                                  ,u.[Username]
                              FROM [dbo].[File] f
                              JOIN [dbo].[User] u on f.UserId = u.UserId
                              WHERE 1 = 1
                              {filterQuery}
                              ORDER BY f.[FileId] DESC";

            using (var connection = new SqlConnection(connString))
            {
                return connection.Query<ReportDto>(sql, parameter, commandTimeout: connection.ConnectionTimeout);
            }
        }

        #endregion

        #region Private methods

        private string BuildFilterValuesQuery(FileFilterDto filterDto, DynamicParameters parameter)
        {
            var query = new StringBuilder();

            if (filterDto.FileId.HasValue)
            {
                parameter.Add("@FileId", filterDto.FileId.Value, DbType.Int32);
                query.AppendLine($"AND f.[FileId] = @FileId");
            }

            if (!string.IsNullOrWhiteSpace(filterDto.FileName))
            {
                parameter.Add("@FileName", filterDto.FileName, DbType.StringFixedLength);
                query.AppendLine($"AND f.[FileName] = @FileName");
            }

            if (!string.IsNullOrWhiteSpace(filterDto.FileDownloadDirectory))
            {
                parameter.Add("@FileDownloadDirectory", filterDto.FileDownloadDirectory, DbType.String);
                query.AppendLine($"AND f.[FileDownloadDirectory] = @FileDownloadDirectory");
            }

            if (filterDto.FileDownloadMethod.HasValue)
            {
                parameter.Add("@FileDownloadMethod", (int)filterDto.FileDownloadMethod.Value, DbType.Int32);
                query.AppendLine($"AND f.[FileDownloadMethod] = @FileDownloadMethod");
            }

            if (filterDto.FileDownloadTimeStart.HasValue)
            {
                parameter.Add("@FileDownloadTimeStart", filterDto.FileDownloadTimeStart.Value, DbType.DateTimeOffset);
                query.AppendLine($"AND f.[FileDownloadTime] > @FileDownloadTimeStart");
            }

            if (filterDto.FileDownloadTimeEnd.HasValue)
            {
                parameter.Add("@FileDownloadTimeEnd", filterDto.FileDownloadTimeEnd.Value, DbType.DateTimeOffset);
                query.AppendLine($"AND f.[FileDownloadTime] < @FileDownloadTimeEnd");
            }

            if (!string.IsNullOrWhiteSpace(filterDto.Username))
            {
                parameter.Add("@Username", filterDto.Username, DbType.StringFixedLength);
                query.AppendLine($"AND u.[Username] = @Username");
            }

            return query.ToString();
        }

        #endregion

        #region Query strings

        private static readonly string _getFileByIdQueryString =
            "SELECT TOP 1" + Environment.NewLine
                           + "     [FileId]" + Environment.NewLine
                           + "    ,[FileName]" + Environment.NewLine
                           + "    ,[FileDownloadDirectory]" + Environment.NewLine
                           + "    ,[FileDownloadMethod]" + Environment.NewLine
                           + "    ,[FileDownloadTime]" + Environment.NewLine
                           + "    ,[UserId]" + Environment.NewLine
                           + " FROM [dbo].[File]" + Environment.NewLine
                           + " WHERE [FileId] = @FileId";

        private static readonly string _updateFileQueryString =
            "UPDATE [dbo].[File] SET" + Environment.NewLine
                                         + "     [FileName] = @FileName" + Environment.NewLine
                                         + "    ,[FileDownloadDirectory] = @FileDownloadDirectory" + Environment.NewLine
                                         + "    ,[FileDownloadMethod] = @FileDownloadMethod" + Environment.NewLine
                                         + "    ,[FileDownloadTime] = @FileDownloadTime" + Environment.NewLine
                                         + "    ,[UserId] = @UserId" + Environment.NewLine
                                         + " WHERE [FileId] = @FileId";

        private static readonly string _insertQueryString =
            "INSERT INTO [dbo].[File] (" + Environment.NewLine
                                         + "    [FileName]" + Environment.NewLine
                                            + "    ,[FileDownloadDirectory]" + Environment.NewLine
                                            + "    ,[FileDownloadMethod]" + Environment.NewLine
                                            + "    ,[FileDownloadTime]" + Environment.NewLine
                                            + "    ,[UserId])" + Environment.NewLine
                                            + " VALUES (" + Environment.NewLine
                                            + "    @FileName" + Environment.NewLine
                                            + "    ,@FileDownloadDirectory" + Environment.NewLine
                                            + "    ,@FileDownloadMethod" + Environment.NewLine
                                            + "    ,@FileDownloadTime" + Environment.NewLine
                                            + "    ,@UserId)";

        #endregion
    }
}

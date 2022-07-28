using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            throw new NotImplementedException();
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

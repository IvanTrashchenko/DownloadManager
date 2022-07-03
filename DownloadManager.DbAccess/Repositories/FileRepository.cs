﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadManager.DbAccess.Enums;
using DownloadManager.DbAccess.Models;

namespace DownloadManager.DbAccess.Repositories
{
    //TODO: make base or interface
    public class FileRepository 
    {
        #region Fields

        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;

        #endregion

        #region ctor

        public FileRepository(SqlConnection connection, SqlTransaction transaction)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        #endregion

        #region Public methods

        public IEnumerable<File> Get()
        {
            throw new NotImplementedException();
        }

        public File GetById(int id)
        {
            using (var command = new SqlCommand(_getFileByIdQueryString, _connection, _transaction))
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
                            FileDownloadTime = reader.GetFieldValue<DateTime>(4)
                        };

                        reader.Close();
                        return file;
                    }

                    reader.Close();
                    return null;
                }
            }
        }

        public void Add(FileDto fileDto)
        {
            using (var command = new SqlCommand(_insertQueryString, _connection, _transaction))
            {
                command.Parameters.Add("@FileName", System.Data.SqlDbType.NVarChar, 256).Value = fileDto.FileName;
                command.Parameters.Add("@FileDownloadDirectory", System.Data.SqlDbType.NVarChar, -1).Value = fileDto.FileDownloadDirectory;
                command.Parameters.Add("@FileDownloadMethod", System.Data.SqlDbType.Int).Value = (int)fileDto.FileDownloadMethod;
                command.Parameters.Add("@FileDownloadTime", System.Data.SqlDbType.DateTime2, 7).Value = fileDto.FileDownloadTime;

                command.ExecuteNonQuery();
            }
        }

        public void Update(File file)
        {
            using (var command = new SqlCommand(_insertQueryString, _connection, _transaction))
            {
                command.Parameters.Add("@FileId", System.Data.SqlDbType.Int).Value = file.FileId;
                command.Parameters.Add("@FileName", System.Data.SqlDbType.NVarChar, 256).Value = file.FileName;
                command.Parameters.Add("@FileDownloadDirectory", System.Data.SqlDbType.NVarChar, -1).Value = file.FileDownloadDirectory;
                command.Parameters.Add("@FileDownloadMethod", System.Data.SqlDbType.Int).Value = (int)file.FileDownloadMethod;
                command.Parameters.Add("@FileDownloadTime", System.Data.SqlDbType.DateTime2, 7).Value = file.FileDownloadTime;

                command.ExecuteNonQuery();
            }
        }

        public void Update(int id, FileDto fileDto)
        {
            using (var command = new SqlCommand(_insertQueryString, _connection, _transaction))
            {
                command.Parameters.Add("@FileId", System.Data.SqlDbType.Int).Value = id;
                command.Parameters.Add("@FileName", System.Data.SqlDbType.NVarChar, 256).Value = fileDto.FileName;
                command.Parameters.Add("@FileDownloadDirectory", System.Data.SqlDbType.NVarChar, -1).Value = fileDto.FileDownloadDirectory;
                command.Parameters.Add("@FileDownloadMethod", System.Data.SqlDbType.Int).Value = (int)fileDto.FileDownloadMethod;
                command.Parameters.Add("@FileDownloadTime", System.Data.SqlDbType.DateTime2, 7).Value = fileDto.FileDownloadTime;

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
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
                           + " FROM [dbo].[File]" + Environment.NewLine
                           + " WHERE [FileId] = @FileId";

        private static readonly string _updateFileQueryString =
            "UPDATE [dbo].[File] SET" + Environment.NewLine
                                         + "     [FileName] = @FileName" + Environment.NewLine
                                         + "    ,[FileDownloadDirectory] = @FileDownloadDirectory" + Environment.NewLine
                                         + "    ,[FileDownloadMethod] = @FileDownloadMethod" + Environment.NewLine
                                         + "    ,[FileDownloadTime] = @FileDownloadTime" + Environment.NewLine
                                         + " WHERE [FileId] = @FileId";

        private static readonly string _insertQueryString =
            "INSERT INTO [dbo].[File] (" + Environment.NewLine
                                         + "    [FileName]" + Environment.NewLine
                                            + "    ,[FileDownloadDirectory]" + Environment.NewLine
                                            + "    ,[FileDownloadMethod]" + Environment.NewLine
                                            + "    ,[FileDownloadTime])" + Environment.NewLine
                                            + " VALUES (" + Environment.NewLine
                                            + "    @FileName" + Environment.NewLine
                                            + "    ,@FileDownloadDirectory" + Environment.NewLine
                                            + "    ,@FileDownloadMethod" + Environment.NewLine
                                            + "    ,@FileDownloadTime)";

        #endregion
    }
}

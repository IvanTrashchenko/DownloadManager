using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DownloadManager.DbAccess.Models;
using DownloadManager.DbAccess.Repositories;
using DownloadManager.DbAccess.Util;

namespace DownloadManager.DbAccess.Services
{
    public static class FileService
    {
        public static void Add(FileDto fileDto)
        {
            if (fileDto == null)
            {
                throw new ArgumentNullException(nameof(fileDto));
            }

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
                    var repo = new FileRepository(sqlConnection, transaction);
                    repo.Add(fileDto);
                    transaction.Commit();
                }
            }
        }

        public static File GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

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
                    var repo = new FileRepository(sqlConnection, transaction);
                    return repo.GetById(id);
                }
            }
        }

        public static void Update(File file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

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
                    var repo = new FileRepository(sqlConnection, transaction);
                    repo.Update(file);
                    transaction.Commit();
                }
            }
        }

        public static void Update(int id, FileDto fileDto)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            if (fileDto == null)
            {
                throw new ArgumentNullException(nameof(fileDto));
            }

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
                    var repo = new FileRepository(sqlConnection, transaction);
                    repo.Update(id, fileDto);
                    transaction.Commit();
                }
            }
        }
    }
}

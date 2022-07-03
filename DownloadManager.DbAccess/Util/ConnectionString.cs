using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloadManager.DbAccess.Util
{
    public static class ConnectionString
    {
        private static string s_SqlConnString = GetConnectionStringInitial();

        private static string s_SqlConnStringError = null;

        private static string GetConnectionStringInitial()
        {
            try
            {
                const string connectionStringName = "DownloadManagerDb";
                const string connectionStringEnvVarName = "SQLCONNSTR_" + connectionStringName;

                string connectionString = Environment.GetEnvironmentVariable(connectionStringEnvVarName)
                                          ?? ConfigurationManager.ConnectionStrings[connectionStringName]?.ConnectionString;

                if (null == connectionString)
                {
                    s_SqlConnStringError = $"No ConnectionString found for '{connectionStringName}'.";
                }
                return connectionString;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static string Get()
        {
            if (null != s_SqlConnStringError)
                throw new ApplicationException(s_SqlConnStringError);

            return s_SqlConnString;
        }
	}
}

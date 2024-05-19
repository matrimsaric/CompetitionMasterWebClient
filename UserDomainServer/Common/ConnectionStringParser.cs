using Npgsql;
using ServerCommonModule.Model;
using System.Data.SqlClient;
using UserDomainServer.Settings;

namespace UserDomainServer.Common
{
    public static class ConnectionStringParser
    {
        private const string APPLICATION_NAME_PROFILER = "EvolveServices";
        private const string AZURE_POSTGRESQL_ROOT_CERTIFICATE_NAME = "DigiCertGlobalRootCA.crt.pem";

        public const string DATABASE_CONNECTION_STRING = "DatabaseConnectionString";

        public static string ParseDatabaseConnectionString(EnvironmentTypes environmentType, ConnectionType supportedDatabase, string databaseConnectionStringUnparsed)
        {
            if (string.IsNullOrEmpty(databaseConnectionStringUnparsed) == false)
            {
                switch (supportedDatabase)
                {
                    case ConnectionType.POSTGRESS:
                        NpgsqlConnectionStringBuilder postgresStringBuilder = new NpgsqlConnectionStringBuilder(databaseConnectionStringUnparsed);
                        postgresStringBuilder.ApplicationName = APPLICATION_NAME_PROFILER;

                        if (environmentType == EnvironmentTypes.Azure)
                        {
                            postgresStringBuilder.SslMode = SslMode.VerifyFull;
                            postgresStringBuilder.RootCertificate = AZURE_POSTGRESQL_ROOT_CERTIFICATE_NAME;
                        }

                        return postgresStringBuilder.ConnectionString;

                    case ConnectionType.MS_SQL:
                    default:
                        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(databaseConnectionStringUnparsed);
                        sqlConnectionStringBuilder.ApplicationName = APPLICATION_NAME_PROFILER;
                        return sqlConnectionStringBuilder.ConnectionString;
                }
            }
            return null;
        }

    }
}

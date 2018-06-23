using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;

namespace Polygon.Data.Factory
{
    public static class ConnectionFactory
    {
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=polygonpontoonline;UID=root;Pwd=!root;SslMode=none";

        public static IDbConnection GetConnection()
        {
            return new OracleConnection(ConnectionString);
        }
    }
}

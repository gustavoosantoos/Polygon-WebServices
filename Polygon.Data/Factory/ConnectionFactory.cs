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

        private const string OracleConnectionString =
            "Data Source=(DESCRIPTION =(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST = 000.00.0.00)(PORT = 0000)))(CONNECT_DATA =(SERVICE_NAME = database)));User ID=User/Schema;Password=password;Unicode=True";


        public static IDbConnection GetConnection()
        {
            return new OracleConnection(ConnectionString);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Polygon.Data.Factory
{
    public static class ConnectionFactory
    {
        private const string ConnectionString =
            "Server=localhost;Port=3306;Database=polygonpontoonline;UID=root;Pwd=!root;SslMode=none";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.Configuration;
namespace Master.DataBase
{
    public static class Database
    {
        public static string ConnectionString;
        public static SqlConnection CurrentCnn
        {
            get
            {
                //TODO: mirar como se manda el key de conexion para mo dejar eso quemado.
                return new SqlConnection(ConnectionString);
            }
        }
    }
}

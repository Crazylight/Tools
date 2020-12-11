using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace iCoder.Constant
{
    public class Constant
    {
        public static string DataBase;

        public static string TableName;

        public static string Server;

        public static string User;

        public static string Pwd;

        private static SqlConnection _conn;
        public static SqlConnection Conn
        {
            get
            {
                if (_conn == null || _conn.Database != DataBase)
                {
                    SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder();
                    conStr.Add("user", User);
                    conStr.Add("pwd", Pwd);
                    conStr.Add("database", DataBase);
                    conStr.Add("Data Source", Server);
                    _conn = new SqlConnection(conStr.ToString());
					LayersProductor.CommonPro.ConnectionString = conStr.ToString();
                }
                return _conn;
            }
        }
    }
}

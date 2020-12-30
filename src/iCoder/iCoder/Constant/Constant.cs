using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace iCoder.Constant
{
    public class Constant
    {
        public static string DataBase;

        public static string TableName;

        public static string Server;

        public static string User;

        public static string Pwd;

        private static SqlConnection _sqlConn;
        public static SqlConnection SqlConn
        {
            get
            {
                if (_sqlConn == null || _sqlConn.Database != DataBase)
                {
                    SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder();
                    conStr.Add("user", User);
                    conStr.Add("pwd", Pwd);
                    conStr.Add("database", DataBase);
                    conStr.Add("Data Source", Server);
                    _sqlConn = new SqlConnection(conStr.ToString());
					LayersProductor.CommonPro.ConnectionString = conStr.ToString();
                }
                return _sqlConn;
            }
        }


        private static MySqlConnection _mysqlConn;
        public static MySqlConnection MySqlConn
        {
            get
            {
                if (_mysqlConn == null || _mysqlConn.Database != DataBase)
                {
                    MySqlConnectionStringBuilder conStr = new MySqlConnectionStringBuilder();
                    conStr.Add("user", User);
                    conStr.Add("pwd", Pwd);
                    conStr.Add("database", DataBase);
                    conStr.Add("Data Source", Server);
                    _mysqlConn = new MySqlConnection(conStr.ToString());
                    LayersProductor.CommonPro.ConnectionString = conStr.ToString();
                }
                return _mysqlConn;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectProductor
{
    public class WizardProj
    {
        static WizardProj _wizard;
        private WizardProj()
        {

        }

        public static WizardProj getInstance()
        {
            if (_wizard == null)
            {
                _wizard = new WizardProj();
            }
            return _wizard;
        }

        public string CreateFile_IDataHelper(string nameSpace)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("using System;\r\n");
            sql.Append("using System.Data;\r\n");

            sql.Append("namespace WizardFramework.DataOper    \r\n");
            sql.Append("{    \r\n");
            sql.Append(" public interface IDataHelper   \r\n");
            sql.Append(" {   \r\n");
            sql.Append("    void Execute(string cmdCode); \r\n");
            sql.Append("    T Execute<T>(string cmdCode);\r\n");
            sql.Append("    DataTable GetDataTable(string cmdCode); \r\n");
            sql.Append("    DataTable GetDataTable(string cmdCode, int start_index, int count); \r\n");
            sql.Append("    \r\n");
            sql.Append("  }\r\n");
            sql.Append("}\r\n");

            return sql.ToString();
        }

        public string CreateFile_SqlHelper(string nameSpace)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("using System;\r\n");
            sql.Append("using System.Data;\r\n");
            sql.Append("using System.Data.SqlClient;\r\n");
            sql.Append("\r\n");
            sql.Append("namespace " + nameSpace + "\r\n");
            sql.Append("{\r\n");
            sql.Append(" public class SqlHelper : IDataHelper\r\n");
            sql.Append("   {\r\n");
            #region Constructor
            sql.Append("    SqlConnection _conn;\r\n");
            sql.Append("    public SqlHelper(string connStr)\r\n");
            sql.Append("   {\r\n");
            sql.Append("     _conn = new SqlConnection(connStr);\r\n ");
            sql.Append("   }\r\n");
            sql.Append("    public SqlHelper(SqlConnection conn)\r\n");
            sql.Append("   {\r\n");
            sql.Append("     _conn = conn;\r\n ");
            sql.Append("   }\r\n");
            #endregion

            #region Execute
            sql.Append(" public void Execute(string cmdCode)\r\n");
            sql.Append("{\r\n");
            sql.Append("    SqlCommand cmd = new SqlCommand() ;  \r\n");
            sql.Append("    cmd.Connection = _conn;\r\n");
            sql.Append("    cmd.CommandText = cmdCode;\r\n");
            sql.Append("       try\r\n");
            sql.Append("       {\r\n");
            sql.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sql.Append("           { \r\n");
            sql.Append("             _conn.Open();\r\n");
            sql.Append("            }\r\n\r\n");
            sql.Append("            cmd.ExecuteNonQuery();\r\n");
            sql.Append("           if (_conn != null && _conn.State != ConnectionState.Closed)\r\n");
            sql.Append("           {\r\n");
            sql.Append("             _conn.Close();\r\n");
            sql.Append("             cmd.Dispose();\r\n");
            sql.Append("           }\r\n");
            sql.Append("       } \r\n");
            sql.Append("   catch(Exception e) \r\n");
            sql.Append("   { \r\n");
            sql.Append("        throw e;\r\n");
            sql.Append("   }\r\n");
            sql.Append("}\r\n\r\n");
            sql.Append(" public T Execute<T>(string cmdCode)\r\n");
            sql.Append(" {\r\n");
            sql.Append("    T local; \r\n");
            sql.Append("    SqlCommand cmd = new SqlCommand() ;  \r\n");
            sql.Append("    cmd.Connection = _conn;\r\n");
            sql.Append("    cmd.CommandText = cmdCode;\r\n");
            sql.Append("     try\r\n");
            sql.Append("     {\r\n");
            sql.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sql.Append("           { \r\n");
            sql.Append("             _conn.Open();\r\n");
            sql.Append("            }\r\n\r\n");
            sql.Append("           object o = cmd.ExecuteScalar();\r\n");
            sql.Append("           if (_conn != null && _conn.State != ConnectionState.Closed)\r\n");
            sql.Append("           {\r\n");
            sql.Append("             _conn.Close();\r\n");
            sql.Append("             cmd.Dispose();\r\n");
            sql.Append("           }\r\n");
            sql.Append("        local = (T)Convert.ChangeType(o, typeof(T));\r\n");
            sql.Append("     } \r\n");
            sql.Append("   catch(Exception e) \r\n");
            sql.Append("   { \r\n");
            sql.Append("        throw e;\r\n");
            sql.Append("   }\r\n");
            sql.Append("   return local; \r\n");
            sql.Append("} \r\n");
            #endregion

            #region DataTable
            sql.Append("    public DataTable GetDataTable(string cmdCode) \r\n");
            sql.Append("    {\r\n");
            sql.Append("         DataTable dt = new DataTable();\r\n");
            sql.Append("       try\r\n");
            sql.Append("       {\r\n");
            sql.Append("         using (SqlDataAdapter da = new SqlDataAdapter(cmdCode, _conn)) \r\n");
            sql.Append("         { \r\n");
            sql.Append("            da.Fill(dt);\r\n");
            sql.Append("          }\r\n");
            sql.Append("       }\r\n");
            sql.Append("     catch(Exception e) \r\n");
            sql.Append("     { \r\n");
            sql.Append("        throw e;\r\n");
            sql.Append("     }\r\n");
            sql.Append("      return dt;\r\n");
            sql.Append("   } \r\n");

            sql.Append("    public DataTable GetDataTable(string cmdCode, int start_index, int count) \r\n");
            sql.Append("    {\r\n");
            sql.Append("         DataTable dt = new DataTable();\r\n");
            sql.Append("       try\r\n");
            sql.Append("       {\r\n");
            sql.Append("         using (SqlDataAdapter da = new SqlDataAdapter(cmdCode, _conn)) \r\n");
            sql.Append("         { \r\n");
            sql.Append("             da.Fill(start_index, count, dt);\r\n");
            sql.Append("          }\r\n");
            sql.Append("       }\r\n");
            sql.Append("     catch(Exception e) \r\n");
            sql.Append("     { \r\n");
            sql.Append("        throw e;\r\n");
            sql.Append("     }\r\n");
            sql.Append("      return dt;\r\n");
            sql.Append("   } \r\n");

            #endregion

            #region GetList
            sql.Append(" public string GetList(string cmdCode)\r\n");
            sql.Append("{\r\n");
            sql.Append("            string str = \"\";\r\n");
            sql.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sql.Append("           { \r\n");
            sql.Append("             _conn.Open();\r\n");
            sql.Append("            }\r\n\r\n");
            sql.Append("     using (SqlCommand command = new SqlCommand(cmdCode, this._conn)) \r\n");
            sql.Append("     { \r\n");
            sql.Append("           SqlDataReader reader = command.ExecuteReader() ;\r\n");
            sql.Append("             while (reader.Read())\r\n");
            sql.Append("             {\r\n");
            sql.Append("                str = str + \", \" + reader[0].ToString();\r\n");
            sql.Append("             }\r\n");
            sql.Append("            if (str.Length > 0)\r\n");
            sql.Append("            {\r\n");
            sql.Append("                str = str.Substring(1);\r\n");
            sql.Append("            }\r\n");
            sql.Append("            reader.Close();\r\n");
            sql.Append("            reader.Dispose();\r\n");
            sql.Append("     } \r\n");
            sql.Append("            this._conn.Close(); \r\n");
            sql.Append("           \r\n");
            sql.Append("           \r\n");
            sql.Append("          return str;  \r\n");
            sql.Append("}\r\n\r\n");
            #endregion

            #region GetDataReader
            sql.Append(" public SqlDataReader GetDataReader(string cmdCode)\r\n");
            sql.Append("{\r\n");
            sql.Append("    if (this._conn.State != ConnectionState.Open) \r\n");
            sql.Append("    {\r\n");
            sql.Append("       this._conn.Open();\r\n");
            sql.Append("    }\r\n");
            sql.Append("         SqlCommand command = new SqlCommand(cmdCode, this._conn);\r\n");
            sql.Append("      return command.ExecuteReader(CommandBehavior.CloseConnection);\r\n");
            sql.Append("}\r\n\r\n");
            #endregion
            sql.Append("    \r\n");
            sql.Append("    \r\n");
            sql.Append("  }\r\n");
            sql.Append("}\r\n");

            return sql.ToString();
        }

        public string CreateFile_OracleHelper(string nameSpace)
        {
            StringBuilder sqlite = new StringBuilder();
            sqlite.Append("using System;\r\n");
            sqlite.Append("using System.Data;\r\n");
            sqlite.Append("using System.Data.OracleClient;\r\n");
            sqlite.Append("\r\n");
            sqlite.Append("namespace " + nameSpace + "\r\n");
            sqlite.Append("{\r\n");
            sqlite.Append(" public class OracleHelper : IDataHelper\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("    OracleConnection _conn;");
            sqlite.Append("    public OracleHelper(string connStr)\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("     _conn = new OracleConnection(connStr);");
            sqlite.Append("   }\r\n");
            sqlite.Append("   /// <summary>\r\n");
            sqlite.Append("   ///需要用绝对地址\r\n");
            sqlite.Append("   /// </summary>\r\n");
            sqlite.Append("    public OracleHelper(string dataSource, string pwd)\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("    \r\n");
            sqlite.Append("       \r\n");
            sqlite.Append("      \r\n");
            sqlite.Append("      // _conn = new OracleConnection(sb.ToString());\r\n");
            sqlite.Append("   }\r\n");
            #region Execute
            sqlite.Append(" public void Execute(string cmdCode)\r\n");
            sqlite.Append("{\r\n");
            sqlite.Append("    OracleCommand cmd = new OracleCommand() ;  \r\n");
            sqlite.Append("    cmd.Connection = _conn;\r\n");
            sqlite.Append("    cmd.CommandText = cmdCode;\r\n");
            sqlite.Append("       try\r\n");
            sqlite.Append("       {\r\n");
            sqlite.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sqlite.Append("           { \r\n");
            sqlite.Append("             _conn.Open();\r\n");
            sqlite.Append("            }\r\n\r\n");
            sqlite.Append("            cmd.ExecuteNonQuery();\r\n");
            sqlite.Append("           if (_conn != null && _conn.State != ConnectionState.Closed)\r\n");
            sqlite.Append("           {\r\n");
            sqlite.Append("             _conn.Close();\r\n");
            sqlite.Append("             cmd.Dispose();\r\n");
            sqlite.Append("           }\r\n");
            sqlite.Append("       } \r\n");
            sqlite.Append("   catch(Exception e) \r\n");
            sqlite.Append("   { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("   }\r\n");
            sqlite.Append("}\r\n\r\n");
            sqlite.Append(" public T Execute<T>(string cmdCode)\r\n");
            sqlite.Append(" {\r\n");
            sqlite.Append("    T local; \r\n");
            sqlite.Append("    OracleCommand cmd = new OracleCommand() ;  \r\n");
            sqlite.Append("    cmd.Connection = _conn;\r\n");
            sqlite.Append("    cmd.CommandText = cmdCode;\r\n");
            sqlite.Append("     try\r\n");
            sqlite.Append("     {\r\n");
            sqlite.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sqlite.Append("           { \r\n");
            sqlite.Append("             _conn.Open();\r\n");
            sqlite.Append("            }\r\n\r\n");
            sqlite.Append("           object o = cmd.ExecuteScalar();\r\n");
            sqlite.Append("           if (_conn != null && _conn.State != ConnectionState.Closed)\r\n");
            sqlite.Append("           {\r\n");
            sqlite.Append("             _conn.Close();\r\n");
            sqlite.Append("             cmd.Dispose();\r\n");
            sqlite.Append("           }\r\n");
            sqlite.Append("        local = (T)Convert.ChangeType(o, typeof(T));\r\n");
            sqlite.Append("     } \r\n");
            sqlite.Append("   catch(Exception e) \r\n");
            sqlite.Append("   { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("   }\r\n");
            sqlite.Append("   return local; \r\n");
            sqlite.Append("} \r\n");
            #endregion

            #region DataTable
            sqlite.Append("    public DataTable GetDataTable(string cmdCode) \r\n");
            sqlite.Append("    {\r\n");
            sqlite.Append("         DataTable dt = new DataTable();\r\n");
            sqlite.Append("       try\r\n");
            sqlite.Append("       {\r\n");
            sqlite.Append("         using (OracleDataAdapter da = new OracleDataAdapter(cmdCode, _conn)) \r\n");
            sqlite.Append("         { \r\n");
            sqlite.Append("            da.Fill(dt);\r\n");
            sqlite.Append("          }\r\n");
            sqlite.Append("       }\r\n");
            sqlite.Append("     catch(Exception e) \r\n");
            sqlite.Append("     { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("     }\r\n");
            sqlite.Append("      return dt;\r\n");
            sqlite.Append("   } \r\n");

            sqlite.Append("    public DataTable GetDataTable(string cmdCode, int start_index, int count) \r\n");
            sqlite.Append("    {\r\n");
            sqlite.Append("         DataTable dt = new DataTable();\r\n");
            sqlite.Append("       try\r\n");
            sqlite.Append("       {\r\n");
            sqlite.Append("         using (OracleDataAdapter da = new OracleDataAdapter(cmdCode, _conn)) \r\n");
            sqlite.Append("         { \r\n");
            sqlite.Append("             da.Fill(start_index, count, dt);\r\n");
            sqlite.Append("          }\r\n");
            sqlite.Append("       }\r\n");
            sqlite.Append("     catch(Exception e) \r\n");
            sqlite.Append("     { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("     }\r\n");
            sqlite.Append("      return dt;\r\n");
            sqlite.Append("   } \r\n");
            sqlite.Append("   \r\n");

            #endregion
            sqlite.Append("  }\r\n");
            sqlite.Append("}\r\n");

            return sqlite.ToString();
        }

        public string CreateFile_SqliteHelper(string nameSpace)
        {
            StringBuilder sqlite = new StringBuilder();
            sqlite.Append("using System;\r\n");
            sqlite.Append("using System.Data;\r\n");
            sqlite.Append("using System.Data.SQLite;\r\n");
            sqlite.Append("\r\n");
            sqlite.Append("namespace " + nameSpace + "\r\n");
            sqlite.Append("{\r\n");
            sqlite.Append(" public class SqliteHelper : IDataHelper\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("    SQLiteConnection _conn;");
            #region Constructors
            sqlite.Append("    public SqliteHelper(string dataSource)\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("     SQLiteConnectionStringBuilder connStr = new SQLiteConnectionStringBuilder();\r\n");
            sqlite.Append("      connStr.DataSource = dataSource;\r\n");
            sqlite.Append("     _conn = new SQLiteConnection(connStr.ToString());\r\n");
            sqlite.Append("   }\r\n");
            sqlite.Append("    public SqliteHelper(SQLiteConnection conn)\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("     _conn = conn;\r\n");
            sqlite.Append("   }\r\n");
            sqlite.Append("   /// <summary>\r\n");
            sqlite.Append("   ///需要用绝对地址\r\n");
            sqlite.Append("   /// </summary>\r\n");
            sqlite.Append("    public SqliteHelper(string dataSource, string pwd)\r\n");
            sqlite.Append("   {\r\n");
            sqlite.Append("       SQLiteConnectionStringBuilder sb = new SQLiteConnectionStringBuilder();\r\n");
            sqlite.Append("       sb.DataSource = dataSource; \r\n");
            sqlite.Append("       sb.Password = pwd; \r\n");
            sqlite.Append("       _conn = new SQLiteConnection(sb.ToString());\r\n");
            sqlite.Append("   }\r\n");
            #endregion
            sqlite.Append(" public void CreateDataBase(string dbName)\r\n");
            sqlite.Append("{\r\n");
            sqlite.Append("   SQLiteConnection.CreateFile(dbName);  \r\n");
            sqlite.Append("}\r\n");

            sqlite.Append(" public void ChangePassword(string pwd)\r\n");
            sqlite.Append("{\r\n");
            sqlite.Append("     _conn.Open();\r\n");
            sqlite.Append("     _conn.ChangePassword(pwd);  \r\n");
            sqlite.Append("}\r\n");
            #region Execute
            sqlite.Append(" public void Execute(string cmdCode)\r\n");
            sqlite.Append("{\r\n");
            sqlite.Append("    SQLiteCommand cmd = new SQLiteCommand() ;  \r\n");
            sqlite.Append("    cmd.Connection = _conn;\r\n");
            sqlite.Append("    cmd.CommandText = cmdCode;\r\n");
            sqlite.Append("       try\r\n");
            sqlite.Append("       {\r\n");
            sqlite.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sqlite.Append("           { \r\n");
            sqlite.Append("             _conn.Open();\r\n");
            sqlite.Append("            }\r\n\r\n");
            sqlite.Append("            cmd.ExecuteNonQuery();\r\n");
            sqlite.Append("           if (_conn != null && _conn.State != ConnectionState.Closed)\r\n");
            sqlite.Append("           {\r\n");
            sqlite.Append("             _conn.Close();\r\n");
            sqlite.Append("             cmd.Dispose();\r\n");
            sqlite.Append("           }\r\n");
            sqlite.Append("       } \r\n");
            sqlite.Append("   catch(Exception e) \r\n");
            sqlite.Append("   { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("   }\r\n");
            sqlite.Append("}\r\n\r\n");
            sqlite.Append(" public T Execute<T>(string cmdCode)\r\n");
            sqlite.Append(" {\r\n");
            sqlite.Append("    T local; \r\n");
            sqlite.Append("    SQLiteCommand cmd = new SQLiteCommand() ;  \r\n");
            sqlite.Append("    cmd.Connection = _conn;\r\n");
            sqlite.Append("    cmd.CommandText = cmdCode;\r\n");
            sqlite.Append("     try\r\n");
            sqlite.Append("     {\r\n");
            sqlite.Append("           if(_conn.State != ConnectionState.Open)\r\n");
            sqlite.Append("           { \r\n");
            sqlite.Append("             _conn.Open();\r\n");
            sqlite.Append("            }\r\n\r\n");
            sqlite.Append("           object o = cmd.ExecuteScalar();\r\n");
            sqlite.Append("           if (_conn != null && _conn.State != ConnectionState.Closed)\r\n");
            sqlite.Append("           {\r\n");
            sqlite.Append("             _conn.Close();\r\n");
            sqlite.Append("             cmd.Dispose();\r\n");
            sqlite.Append("           }\r\n");
            sqlite.Append("        local = (T)Convert.ChangeType(o, typeof(T));\r\n");
            sqlite.Append("     } \r\n");
            sqlite.Append("   catch(Exception e) \r\n");
            sqlite.Append("   { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("   }\r\n");
            sqlite.Append("   return local; \r\n");
            sqlite.Append("} \r\n");
            #endregion

            #region DataTable
            sqlite.Append("    public DataTable GetDataTable(string cmdCode) \r\n");
            sqlite.Append("    {\r\n");
            sqlite.Append("         DataTable dt = new DataTable();\r\n");
            sqlite.Append("       try\r\n");
            sqlite.Append("       {\r\n");
            sqlite.Append("         using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmdCode, _conn)) \r\n");
            sqlite.Append("         { \r\n");
            sqlite.Append("            da.Fill(dt);\r\n");
            sqlite.Append("          }\r\n");
            sqlite.Append("       }\r\n");
            sqlite.Append("     catch(Exception e) \r\n");
            sqlite.Append("     { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("     }\r\n");
            sqlite.Append("      return dt;\r\n");
            sqlite.Append("   } \r\n");

            sqlite.Append("    public DataTable GetDataTable(string cmdCode, int start_index, int count) \r\n");
            sqlite.Append("    {\r\n");
            sqlite.Append("         DataTable dt = new DataTable();\r\n");
            sqlite.Append("       try\r\n");
            sqlite.Append("       {\r\n");
            sqlite.Append("         using (SQLiteDataAdapter da = new SQLiteDataAdapter(cmdCode, _conn)) \r\n");
            sqlite.Append("         { \r\n");
            sqlite.Append("             da.Fill(start_index, count, dt);\r\n");
            sqlite.Append("          }\r\n");
            sqlite.Append("       }\r\n");
            sqlite.Append("     catch(Exception e) \r\n");
            sqlite.Append("     { \r\n");
            sqlite.Append("        throw e;\r\n");
            sqlite.Append("     }\r\n");
            sqlite.Append("      return dt;\r\n");
            sqlite.Append("   } \r\n");

            #endregion
            sqlite.Append("  }\r\n");
            sqlite.Append("}\r\n");

            return sqlite.ToString();
        }

        public string CreateFile_LogHelper(string nameSpace)
        {
            StringBuilder entity = new StringBuilder();
            entity.Append("using System;\r\n");
            entity.Append("\r\n");
            entity.Append("namespace " + nameSpace + "\r\n");
            entity.Append("{\r\n");
            entity.Append("     public class LogHelper\r\n{\r\n");
            entity.Append("        string _className;\r\n");
            entity.Append("        public LogHelper(string className)\r\n");
            entity.Append("       {\r\n");
            entity.Append("          _className = className;\r\n");
            entity.Append("       }\r\n");
            entity.Append("\r\n");
            entity.Append("      public void WriteLog(string msg)\r\n");
            entity.Append("      {\r\n");
            entity.Append("     \r\n");
            entity.Append("     \r\n");
            entity.Append("     }\r\n");
            entity.Append("     \r\n");
            entity.Append("      public void WriteLog(Exception e)\r\n");
            entity.Append("      {\r\n");
            entity.Append("         try\r\n");
            entity.Append("          {\r\n");
            entity.Append("                System.Reflection.MethodBase method = System.Reflection.MethodInfo.GetCurrentMethod(); \r\n");
            entity.Append(@"               string sql = ""INSERT INTO ERR_LOG_INFO( [ADDER], [ADDTIME], [EXPMSG], [MSG], [PLATFORM], [PAGENAME], [METHODS], [ADDIP]) VALUES ( '"" + ""', GETDATE(), '"
                + @"+ e.Message.Replace('\'', '‘')"" + ""; StackTrace: "" + e.StackTrace.Replace(""\'"", ""‘"") + ""', '"" + e.Source + ""', '', '', '"" + method.Name + ""', '')"";");
            entity.Append("     \r\n");
            entity.Append("           }\r\n");
            entity.Append("         catch\r\n");
            entity.Append("          {\r\n");
            entity.Append("     \r\n");
            entity.Append("           }\r\n");
            entity.Append("     }\r\n");
            entity.Append("\r\n");
            entity.Append("      public void WriteLog(LogModel model)\r\n");
            entity.Append("      {\r\n");
            entity.Append("         try\r\n");
            entity.Append("          {\r\n");
            entity.Append("           }\r\n");
            entity.Append("         catch\r\n");
            entity.Append("          {\r\n");
            entity.Append("     \r\n");
            entity.Append("           }\r\n");
            entity.Append("     }\r\n");
            //entity.Append("      public void WriteLog(Exception e, string sqlStr, string className)\r\n");
            //entity.Append("      {\r\n");
            //entity.Append("         try\r\n");
            //entity.Append("          {\r\n");
            //entity.Append("                System.Reflection.MethodBase method = System.Reflection.MethodInfo.GetCurrentMethod(); \r\n");
            //entity.Append(@"               string sql = ""INSERT INTO ERR_LOG_INFO( [ADDER], [ADDTIME], [EXPMSG], [MSG], [PLATFORM], [PAGENAME], [METHODS], [ADDIP]) VALUES ( '"" + ""', GETDATE(), '"
            //    + @"+ e.Message.Replace('\'', '‘')"" + ""; StackTrace: "" + e.StackTrace.Replace(""\'"", ""‘"") + ""', '"" + e.Source + ""', '', '', '"" + method.Name + ""', '')"";");
            //entity.Append("     \r\n");
            //entity.Append("           }\r\n");
            //entity.Append("         catch\r\n");
            //entity.Append("          {\r\n");
            //entity.Append("     \r\n");
            //entity.Append("           }\r\n");
            //entity.Append("     }\r\n");
            entity.Append("  }\r\n");
            entity.Append("}\r\n");

            return entity.ToString();
        }

        public string CreateFile_LogModel(string nameSpace)
        {
            StringBuilder entity = new StringBuilder();
            entity.Append("using System;\r\n");
            entity.Append("\r\n");
            entity.Append("namespace " + nameSpace + "\r\n");
            entity.Append("{\r\n");
            entity.Append("     public class LogModel\r\n");
            entity.Append("       {\r\n");
            entity.Append("        public LogModel()\r\n");
            entity.Append("       {\r\n");
            entity.Append("       }\r\n");
            entity.Append("      public string Msg{get;set;}\r\n");
            entity.Append("   }\r\n");
            entity.Append("}\r\n");

            return entity.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor
{
    internal class DALProj
    {
        static DALProj _dal;
        private DALProj()
        {

        }

        public static DALProj GetInstance()
        {
            if (_dal == null)
            {
                _dal = new DALProj();
            }
            return _dal;
        }

        public string CreateBaseDAL(string nameSpace)
        {
            StringBuilder file = new StringBuilder();
            file.Append("using System;\r\n");
            file.Append("using WizardFramework.DataOper;\r\n");
            file.Append("using WizardFramework.LogMgr;\r\n");
            file.Append("using System.Data.SqlClient;\r\n");
            file.Append("using System.Data;\r\n");
            file.Append("\r\n");
            file.Append("\r\n");
            file.Append("namespace " + nameSpace + ".DAL\r\n");
            file.Append("{\r\n");
            #region BaseDAL
            file.Append("   public class BaseDAL\r\n");
            file.Append("   {\r\n");
            file.Append("        protected DataHelper _sqlH;\r\n");
            //file.Append("        LogHelper _logH;\r\n");
            file.Append("       protected DelegateLog _LogWrite;\r\n");
            file.Append("       public BaseDAL(string className)\r\n");
            file.Append("       {\r\n");
            file.Append("         LogHelper logH = new LogHelper(className);\r\n");
            file.Append("         _sqlH = new DataHelper(System.Configuration.ConfigurationSettings.AppSettings[\"connStr\"]);\r\n");
            file.Append("         _LogWrite = new DelegateLog(logH.WriteLog);\r\n");
            file.Append("\r\n");
            file.Append("\r\n");
            file.Append("       }\r\n");
            file.Append(" protected delegate void DelegateLog(Exception e);\r\n");
            file.Append("   }\r\n");

            #endregion

            #region DataHelper
            file.Append("#region DataHelper\r\n");
            file.Append("public class DataHelper\r\n");
            file.Append("{\r\n");
            file.Append("      private IDataHelper _dataHelper;\r\n");
            file.Append("      SqlConnection _conn;\r\n");
            file.Append("      public DataHelper(string connStr)\r\n");
            file.Append("     {\r\n");
            file.Append("        _conn = new SqlConnection(connStr);\r\n");
            file.Append("        _dataHelper = new SqlHelper(connStr);\r\n");
            file.Append("     }\r\n");
            file.Append("   public void Execute(string cmdCode) \r\n");
            file.Append("   { \r\n");
            file.Append("       _dataHelper.Execute(cmdCode); \r\n");
            file.Append("   }\r\n");
            file.Append("  \r\n");
            file.Append("   public T GetScalar<T>(string cmdCode) \r\n");
            file.Append("   {\r\n");
            file.Append("      return _dataHelper.Execute<T>(cmdCode);\r\n");
            file.Append("   }\r\n");
            file.Append("  \r\n");
            file.Append("   public DataTable GetDataTable(string cmdCode, int start_index, int count) \r\n");
            file.Append("  { \r\n");
            file.Append("    return _dataHelper.GetDataTable(cmdCode, start_index, count);\r\n");
            file.Append("  }\r\n");
            file.Append("  \r\n");
            file.Append("  \r\n");
            file.Append("   public DataTable GetDataTable(string cmdCode) \r\n");
            file.Append("  { \r\n");
            file.Append("    return _dataHelper.GetDataTable(cmdCode);\r\n");
            file.Append("  }\r\n");
            file.Append("}\r\n");
            file.Append("#endregion DataHelper\r\n");

            #endregion

            file.Append("}\r\n");


            return file.ToString();
        }

        public string CreateMainDAL(string nameSpace)
        {
            return (new DAL.MainDAL()).CreateMainDAL(nameSpace);
        }

    }
}

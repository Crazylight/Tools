using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.BLL
{
    public class MainBLL
    {
        public string CreateMainBLL(string nameSpace)
        {
            StringBuilder file = new StringBuilder();
            file.Append("using System;\r\n");
            file.Append("using System.Data.SqlClient;\r\n");
            file.Append("using System.Data;\r\n");
            file.Append("using " + nameSpace + ".DAL;\r\n");
            file.Append("using " + nameSpace + ".Entity;\r\n");
            file.Append("\r\n");
            file.Append("namespace " + nameSpace + ".BLL\r\n");
            file.Append("{\r\n");
            file.Append("   public class MainBLL\r\n");
            file.Append("   {\r\n");
            file.Append("      MainDAL _DAL;\r\n");
            file.Append("      public MainBLL()\r\n");
            file.Append("     {\r\n");
            file.Append("        _DAL = new MainDAL();\r\n");
            file.Append("      }\r\n");
            #region Login
            file.Append("         #region Login\r\n");
            file.Append("     public Result LogIn(string lognum, string pwd, string ip)\r\n");
            file.Append("    {\r\n");
            file.Append("      return _DAL.LogIn(lognum, pwd, ip);\r\n");
            file.Append("    }\r\n");

            file.Append("         #endregion Login\r\n");
            #endregion
            #region MainBLL
            file.Append("     public Result GetDtAllModule()\r\n");
            file.Append("     {\r\n");
            file.Append("          return _DAL.GetDtAllModule();\r\n");
            file.Append("     }\r\n");

            file.Append("     public Result GetMenuDtByModuleId(string moduleId)\r\n");
            file.Append("     {\r\n");
            file.Append("          return _DAL.GetMenuDtByModuleId(moduleId);\r\n");
            file.Append("     }\r\n");
            #endregion
            file.Append("   }\r\n");


            file.Append("}\r\n");


            return file.ToString();
        }
    }
}

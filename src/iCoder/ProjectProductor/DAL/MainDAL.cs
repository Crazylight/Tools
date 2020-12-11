using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.DAL
{
    public class MainDAL
    {
        public string CreateMainDAL(string nameSpace)
        {
            StringBuilder file = new StringBuilder();
            file.Append("using System;\r\n");
            file.Append("using System.Data;\r\n");
            file.Append("using " + nameSpace + ".Entity;\r\n");
            file.Append("\r\n");
            file.Append("namespace " + nameSpace + ".DAL\r\n");
            file.Append("{\r\n");
            file.Append("   public class MainDAL : BaseDAL\r\n");
            file.Append("   {\r\n");
            file.Append("      public MainDAL() : base(\"MainDAL\")\r\n");
            file.Append("     {\r\n");
            file.Append("      }\r\n");
            #region Login
            file.Append("         #region Login\r\n");
            file.Append("     public Result LogIn(string lognum, string pwd, string ip)\r\n");
            file.Append("    {\r\n");
            file.Append("       Result res = new Result(); \r\n");
            file.Append("       try\r\n");
            file.Append("       {\r\n");
            file.Append("             if (_sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM USERINFO WHERE LOGNUM = '\" + lognum + \"'\") > 0)");
            file.Append("             {\r\n");
            file.Append("                DataTable dt = _sqlH.GetDataTable(\"SELECT PWD FROM USERINFO WHERE STATUS > -1 AND LOGNUM = '\" + lognum + \"'\");\r\n");
            file.Append("                if (dt != null && dt.Rows.Count > 0)\r\n");
            file.Append("                {\r\n");
            file.Append("                    if (pwd.ToString().Trim().Equals(dt.Rows[0][\"PWD\"]))\r\n");
            file.Append("                    {\r\n");
            file.Append("                        res.Data = true;\r\n");
            file.Append("                        return res;\r\n");
            file.Append("                    }\r\n");
            file.Append("                   else\r\n");
            file.Append("                   {\r\n");
            file.Append("                        res.Msg = \"密码错误\";\r\n");
            file.Append("                   }\r\n");
            file.Append("                }\r\n");
            file.Append("             else\r\n");
            file.Append("             {\r\n");
            file.Append("               res.Msg = \"用户名被冻结\";\r\n");
            file.Append("             }\r\n");
            file.Append("             }\r\n");
            file.Append("            else\r\n");
            file.Append("            {\r\n");
            file.Append("               res.Msg = \"用户名不存在\";\r\n");
            file.Append("            }\r\n");
            file.Append("               res.Data = false; \r\n");
            file.Append("       }\r\n");
            file.Append("       catch(Exception e)\r\n");
            file.Append("       {\r\n");
            file.Append("          _LogWrite(e); \r\n");
            file.Append("            res.Msg = e.Message; \r\n");
            file.Append("            res.Status = -1; \r\n");
            file.Append("            \r\n");
            file.Append("       }\r\n");
            file.Append("       return res;\r\n");
            file.Append("    }\r\n");

            file.Append("     public void InsertLogIn(string lognum, string ip)\r\n");
            file.Append("    {\r\n");
            file.Append("       try\r\n");
            file.Append("       {\r\n");
            file.Append("            string sql = \"INSERT INTO LOG_INFO(U_ID, LOGIN_TIME, IP) VALUES('\" + lognum + \"', getdate(), '\" + ip + \"')\";\r\n");
            file.Append("            _sqlH.Execute(sql); \r\n");
            file.Append("       }\r\n");
            file.Append("       catch(Exception e)\r\n");
            file.Append("       {\r\n");
            file.Append("          _LogWrite(e); \r\n");
            file.Append("            \r\n");
            file.Append("       }\r\n");
            file.Append("    }\r\n");

            file.Append("         #endregion Login\r\n");
            #endregion
            #region MainDAL
            file.Append("     public Result GetDtAllModule()\r\n");
            file.Append("     {\r\n");
            file.Append("        Result res = new Result(); \r\n");
            file.Append("         string sql = \"SELECT [ID], [ORDERID], [PLATID], [ADDTIME], [MODULEDESC], [IMGADDR], [MODULENAME] FROM MODULE_INFO\";\r\n");
            file.Append("         try\r\n");
            file.Append("         {\r\n");
            file.Append("            res.Data = _sqlH.GetDataTable(sql); \r\n");
            file.Append("         }\r\n");
            file.Append("         catch (Exception e)\r\n");
            file.Append("         {\r\n");
            file.Append("            \r\n");
            file.Append("         }\r\n");
            file.Append("          return res;\r\n");
            file.Append("     }\r\n");

            file.Append("     public Result GetMenuDtByModuleId(string moduleId)\r\n");
            file.Append("     {\r\n");
            file.Append("          Result res = new Result(); \r\n");
            file.Append("          string sql = \"SELECT ID, ORDERID, MODULEID, MENUNAME, MENUDESC, IMGADDR FROM MENU_INFO WHERE MODULEID = \" + moduleId;\r\n");
            file.Append("         try\r\n");
            file.Append("         {\r\n");
            file.Append("            res.Data = _sqlH.GetDataTable(sql); \r\n");
            file.Append("         }\r\n");
            file.Append("         catch (Exception e)\r\n");
            file.Append("         {\r\n");
            file.Append("            \r\n");
            file.Append("         }\r\n");
            file.Append("          return res;\r\n");
            file.Append("     }\r\n");
            #endregion
            file.Append("   }\r\n");


            file.Append("}\r\n");


            return file.ToString();
        }
    }
}

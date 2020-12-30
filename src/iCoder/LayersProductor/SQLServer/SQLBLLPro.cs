using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LayersProductor.SQLServer
{
    public class SQLBLLPro : CommonPro
    {
        static SQLBLLPro _instance;
        private SQLBLLPro(DataTable dt, string projName, string entityName)
            : base(dt, projName, entityName)
        {
        }

        public static SQLBLLPro getInstance(DataTable dt, string projName, string entityName)
        {
            // if (_instance == null)
            {
                _instance = new SQLBLLPro(dt, projName, entityName);
            }
            return _instance;
        }

        public string CreateBLL()
        {
            StringBuilder sb = new StringBuilder();  //Header
            #region Head
            sb.Append(CreateHead(_entityName + "BLL"));

            sb.Append("using System;\r\n");
            sb.Append("using System.Data;\r\n");
            sb.Append("using System.Collections.ObjectModel;\r\n");
            sb.Append("using ");
            sb.Append(_projName + ".DAL;\r\n");
            sb.Append("using ");
            sb.Append(_projName + ".Entity;\r\n");

            sb.Append("\r\nnamespace " + _projName + ".BLL\r\n");
            sb.Append("{\r\n");
            sb.Append(" public class " + _entityName + "BLL\r\n");
            sb.Append(" {\r\n");
            #endregion

            #region Fields
            sb.Append("     #region Fields\r\n");
            sb.Append("     " + _entityName + "DAL _DAL;\r\n");
            sb.Append("     #endregion\r\n\r\n\r\n");
            #endregion

            #region Constructors
            sb.Append("     #region Constructors\r\n");
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public " + _entityName + "BLL()\r\n");
            sb.Append("     {\r\n");
            sb.Append("        _DAL = new " + _entityName + "DAL();\r\n");
            sb.Append("     }\r\n");
            sb.Append("     #endregion\r\n\r\n\r\n");
            #endregion

            sb.Append(CreateMethods());

            #region Foot
            sb.Append(" }\r\n");
            sb.Append("}");
            #endregion
            return sb.ToString();
        }

        private string CreateMethods()
        {
            StringBuilder sb = new StringBuilder();

            #region PublicMethods
            sb.Append("         #region Public Methods\r\n");

            #region GetDtAll
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 根据条件获取DataTable\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result GetDtAll" + _entityName + "()\r\n");
            sb.Append("         {\r\n");
            sb.Append("                 return _DAL.GetDtAll" + _entityName + "();\r\n");
            sb.Append("         }\r\n\r\n");

            #endregion
            #region GetConditions
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 获取条件\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public string Get" + _entityName + "Conditions(");
            #region Fields
            if (_dt.Rows.Count > 0)
                for (int i = 0; i < _dt.Rows.Count; i++)
                {
                    if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                        continue;
                    if (_dt.Rows[i]["type"].ToString().ToLower() == "date" ||
                        _dt.Rows[i]["type"].ToString().ToLower() == "datetime")
                    {
                        sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + "_start, ");
                        sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + "_end, ");
                    }
                    //else if (_dt.Rows[i]["type"].ToString().ToLower().Equals("int"))
                    //{
                    //    sb.Append("int " + _dt.Rows[i]["name"].ToString() + ", ");
                    //}
                    else
                        sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
                }
            sb.Remove(sb.Length - 2, 2);
            #endregion
            sb.Append(")\r\n");
            sb.Append("         {\r\n");
            sb.Append("return _DAL.Get" + _entityName + "Conditions(");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                if (_dt.Rows[i]["type"].ToString().ToLower() == "date" ||
                    _dt.Rows[i]["type"].ToString().ToLower() == "datetime")
                {
                    sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + "_start, ");
                    sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + "_end, ");
                }
                //else if (_dt.Rows[i]["type"].ToString().ToLower().Equals("int"))
                //{
                //    sb.Append(_dt.Rows[i]["name"].ToString() + ", ");
                //}
                else
                    sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(");\r\n\r\n");
            sb.Append("         }\r\n\r\n");


            #endregion

            #region GetDtbyID
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Get" + _entityName + "DtById(string Id)\r\n");
            sb.Append("     {\r\n");
            sb.Append("         return _DAL.Get" + _entityName + "DtById(Id);\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion


            #region GetDtbyIDS
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Get" + _entityName + "DtByIds(string ids)\r\n");
            sb.Append("     {\r\n");
            sb.Append("         return _DAL.Get" + _entityName + "DtByIds(ids);\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region GetDtByConditions
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 根据条件获取DataTable\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result Get" + _entityName + "DtByConditions(");
            sb.Append("string conditions, int startIndex, int pageSize)\r\n");
            sb.Append("         {\r\n");
            sb.Append("            return _DAL.Get" + _entityName + "DtByConditions(");
            sb.Append(" conditions, startIndex, pageSize");
            sb.Append(");\r\n");
            sb.Append("         }\r\n\r\n");
            #endregion

            #region GetExportDtByConditions
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 根据条件获取DataTable\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result GetExport" + _entityName + "DtByConditions(");
            sb.Append("string conditions)\r\n");
            sb.Append("         {\r\n");
            sb.Append("            return _DAL.GetExport" + _entityName + "DtByConditions(conditions);\r\n");
            sb.Append("         }\r\n\r\n");
            #endregion

            #region GetDtCountByCondition
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 获取所有的记录的总条数\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public int Get" + _entityName + "CountByConditions(string conditions");
            sb.Append(")\r\n         {\r\n");
            sb.Append("            return _DAL.Get" + _entityName + "CountByConditions(");
            sb.Append("conditions);\r\n");
            sb.Append("         }\r\n\r\n");
            #endregion

            #region JudgeRepeater
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public int Judge" + _entityName + "Repeater(string id, string name)\r\n");
            sb.Append("         {\r\n");
            sb.Append("                return _DAL.Judge" + _entityName + "Repeater(id, name);\r\n");
            sb.Append("         }\r\n");
            #endregion

            #region Insert
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 插入新的记录; 返回新纪录的ID；如果返回-1；表示插入失败；\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("public Result Insert" + _entityName + "(");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id")
                  || _dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
                  || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
                    continue;
                sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")\r\n");
            sb.Append(" {\r\n");
            sb.Append(" return _DAL.Insert" + _entityName + "(");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id")
                    || _dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
                    || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
                    continue;
                sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(");\r\n");
            sb.Append("  }\r\n\r\n");
            #endregion

            #region Update
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 更新记录\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("public Result Update" + _entityName + "(string id, ");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
                  || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate")
                  || _dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")\r\n");
            sb.Append(" {\r\n");
            sb.Append(" return _DAL.Update" + _entityName + "(id, ");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
                  || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate")
                  || _dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(");\r\n");
            sb.Append("  }\r\n\r\n");
            #endregion

            #region Delete
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 删除该记录\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Del" + _entityName + "ById(string id)\r\n");
            sb.Append("     {\r\n");
            sb.Append("         return _DAL.Del" + _entityName + "ById(id);\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region DeleteByIds
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 删除所有对应id的记录\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Del" + _entityName + "ByIds(string ids)\r\n");
            sb.Append("     {\r\n");
            sb.Append("         return _DAL.Del" + _entityName + "ByIds(ids);\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region Entities
            #region SelectEntityByID
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 选择对应ID的实体\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Get" + _entityName + "EntityByID(string id)\r\n");
            sb.Append("     {\r\n");
            sb.Append("         return _DAL.Get" + _entityName + "EntityById(id);\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region InsertDOL
            //Dol
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 插入新的记录; 返回新纪录的ID；如果返回-1；表示插入失败；\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("public Result Insert" + _entityName + "(" + _entityName + "Entity dol)\r\n");
            sb.Append("{\r\n");
            sb.Append("  return _DAL.Insert" + _entityName + "Entity(dol);\r\n");
            sb.Append("}\r\n\r\n");
            #endregion
            #region Update
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 更新实体\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Update" + _entityName + "Entity(" + _entityName + " dol)\r\n");
            sb.Append("     {\r\n");
            sb.Append("         return _DAL.Update" + _entityName + "Entity(dol);\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion
            #endregion

            sb.Append("         #endregion Public Methods\r\n");
            #endregion

            return sb.ToString();
        }
    }
}

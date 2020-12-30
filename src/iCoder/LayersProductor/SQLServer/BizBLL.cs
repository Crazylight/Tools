using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LayersProductor.SQLServer
{
    public class BizBLL : CommonPro
    {
        static BizBLL _instance;
        private BizBLL(DataTable dt, string projName, string entityName)
            : base(dt, projName, entityName)
        {
        }

        public static BizBLL getInstance(DataTable dt, string projName, string entityName)
        {
            // if (_instance == null)
            {
                _instance = new BizBLL(dt, projName, entityName);
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

            #region GetList
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 根据条件获取DataTable\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result GetList()\r\n");
            sb.Append("         {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("                 res.Data = _DAL.GetList();\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
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
                    if (IsContinue(_dt.Rows[i]["name"].ToString()))
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
            sb.Append("               string condition =\"\";\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("condition = _DAL.Get" + _entityName + "Conditions(");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (IsContinue(_dt.Rows[i]["name"].ToString()))
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
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return condition;\r\n");
            sb.Append("         }\r\n\r\n");


            #endregion

            #region GetDtbyID
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Get" + _entityName + "DtById(string Id)\r\n");
            sb.Append("     {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data =  _DAL.Get" + _entityName + "DtById(Id);\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region GetDtbyIDS
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Get" + _entityName + "DtByIds(string ids)\r\n");
            sb.Append("     {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data =_DAL.Get" + _entityName + "DtByIds(ids);\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region GetDtByConditions
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 根据条件获取DataTable\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result Get" + _entityName + "DtByConditions(");
            sb.Append("string conditions, int startIndex, int pageSize)\r\n");
            sb.Append("         {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data = _DAL.Get" + _entityName + "DtByConditions(");
            sb.Append(" conditions, startIndex, pageSize");
            sb.Append(");\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("         }\r\n\r\n");
            #endregion

            #region GetExportDtByConditions
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 根据条件获取DataTable\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result GetExportDtByConditions(");
            sb.Append("string conditions)\r\n");
            sb.Append("         {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data = _DAL.GetExportDtByConditions(conditions);\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("         }\r\n\r\n");
            #endregion

            #region GetDtCountByCondition
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 获取所有的记录的总条数\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public int GetCountByConditions(string conditions");
            sb.Append(")\r\n         {\r\n");
            sb.Append("                 int count = 0;\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 count = _DAL.GetCountByConditions(");
            sb.Append("conditions);\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return count;\r\n");
            sb.Append("         }\r\n\r\n");
            #endregion

            #region IsExist
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result IsExist(string id, string name)\r\n");
            sb.Append("         {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("                 res.Data =_DAL.IsExist(id, name);\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = 0;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("         }\r\n");
            #endregion


            #region SetStatus
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// \r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("         public Result SetStatus(string id, string status)\r\n");
            sb.Append("         {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("                 res.Data =_DAL.SetStatus(id, status);\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = 0;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("         }\r\n");
            #endregion

            #region Insert
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 插入新的记录; 返回新纪录的ID；如果返回-1；表示插入失败；\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("public Result Insert(");
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
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data = _DAL.Insert(");
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
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("  }\r\n\r\n");
            #endregion

            #region Update
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 更新记录\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("public Result Update(string id, ");
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
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _DAL.Update(id, ");
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
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("  }\r\n\r\n");
            #endregion

            #region Delete
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 删除该记录\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result DelById(string id)\r\n");
            sb.Append("     {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                  int intID = Convert.ToInt32(id);");
            sb.Append("                 if(_DAL.IsUsed(intID))\r\n");
            sb.Append("                 {");
            sb.Append("                       res.Status = 0;\r\n");
            sb.Append("                       res.Msg = \"正在使用，不能删除\";\r\n");
            sb.Append("                 }");
            sb.Append("                 else\r\n");
            sb.Append("                 {");
            sb.Append("                      _DAL.DelById(id);\r\n");
            sb.Append("                     res.Status = 1;\r\n");
            sb.Append("                 }");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region DeleteByIds
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 删除所有对应id的记录\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Del" + _entityName + "ByIds(string ids)\r\n");
            sb.Append("     {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data = _DAL.Del" + _entityName + "ByIds(ids);\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region Entities
            #region SelectEntityByID
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 选择对应ID的实体\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result GetEntityByID(string id)\r\n");
            sb.Append("     {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data = _DAL.GetEntityById(id);\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion

            #region InsertDOL
            //Dol
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 插入新的记录; 返回新纪录的ID；如果返回-1；表示插入失败；\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("public Result Insert(" + _entityName + "Entity dol)\r\n");
            sb.Append("{\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 res.Data = _DAL.Insert(dol);\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("}\r\n\r\n");
            #endregion
            #region Update
            sb.Append("          /// <summary>\r\n");
            sb.Append("          /// 更新实体\r\n");
            sb.Append("          /// </summary>\r\n");
            sb.Append("     public Result Update(" + _entityName + "Entity dol)\r\n");
            sb.Append("     {\r\n");
            sb.Append("                 Result res = new Result();\r\n");
            sb.Append("             try\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _DAL.Update(dol);\r\n");
            sb.Append("                 res.Status = 1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("             catch(Exception e)\r\n");
            sb.Append("             {\r\n");
            sb.Append("                 _LogWrite(e);\r\n");
            sb.Append("                 res.Msg = e.Message;\r\n");
            sb.Append("                 res.Status = -1;\r\n");
            sb.Append("             }\r\n");
            sb.Append("                 return res;\r\n");
            sb.Append("     }\r\n\r\n");
            #endregion
            #endregion

            sb.Append("         #endregion Public Methods\r\n");
            #endregion

            return sb.ToString();
        }
    }
}

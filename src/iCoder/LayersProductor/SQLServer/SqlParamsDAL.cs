using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LayersProductor.SQLServer
{
    public class SqlParamsDAL : CommonPro
    {
        static SqlParamsDAL instance;
        public SqlParamsDAL(DataTable dt, string spacename, string entityName)
            : base(dt, spacename, entityName)
        {

        }
        public static SqlParamsDAL getInstance(DataTable dt, string spacename, string classname, string entityName)
        {
            // if (instance == null)
            {
                instance = new SqlParamsDAL(dt, spacename, entityName);
            }
            return instance;
        }


        public string CreateDAL()
        {
            StringBuilder dal = new StringBuilder();
            #region Head
            //Header
            dal.Append(CreateHead(_entityName + "DAL"));
            dal.Append("using System;\r\n");
            dal.Append("using System.Data;\r\n");
            dal.Append("using System.Data.SqlClient;\r\n");
            dal.Append("using System.Collections.ObjectModel;\r\n");
            dal.Append("using System.Text;\r\n");
            dal.Append("using " + _projName + ".Entity;\r\n");
            dal.Append("\r\n");
            dal.Append("namespace ");
            dal.Append(_projName + ".DAL\r\n");
            dal.Append("{\r\n");
            //ClassDAL
            dal.Append("     public class " + _entityName + "DAL : BaseDAL\r\n");
            dal.Append("     {\r\n");
            #endregion

            #region Fields
            dal.Append("            #region Fields\r\n");
            dal.Append("             \r\n");
            dal.Append("            #endregion\r\n\r\n\r\n");
            #endregion

            #region Constructors
            dal.Append("            #region Constructors\r\n");
            dal.Append("             public " + _entityName + "DAL()\r\n");
            dal.Append("               :  base(\"" + _entityName + "\")\r\n");
            dal.Append("             {\r\n");
            // dal.Append("              //   _logH = new LogHelper(\"" + _entityName + "DAL\");\r\n");
            dal.Append("             }\r\n\r\n");
            dal.Append("            #endregion\r\n\r\n\r\n");
            #endregion

            #region Public Methods
            dal.Append("         #region Public Methods\r\n");
            dal.Append(CreateMethods());
            dal.Append("    #endregion\r\n");
            #endregion

            #region Foot
            //Foot
            dal.Append("     }\r\n");
            dal.Append("}");
            #endregion
            return dal.ToString();
        }



        private string CreateMethods()
        {
            StringBuilder methods = new StringBuilder();
            methods.Append("\r\n");
            methods.Append("\r\n");
            methods.Append("\r\n");
            methods.Append("\r\n");
            methods.Append("\r\n");
            methods.Append(Insert());
            methods.Append("\r\n");
            methods.Append(InsertDOL());
            methods.Append(Update());
            methods.Append("\r\n" + UpdateDol());
            methods.Append("\r\n");
            return methods.ToString();
        }

        private string Insert()
        {
            StringBuilder insert = new StringBuilder();
            #region Insert
            insert.Append("          /// <summary>\r\n");
            insert.Append("          /// 插入新的记录; 返回新纪录的ID；如果返回-2；表示插入失败；\r\n");
            insert.Append("          /// 如果返回-1；表示有重复数据；\r\n");
            insert.Append("          /// </summary>\r\n");
            insert.Append("public Result Insert" + _entityName + "(");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                insert.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            insert.Remove(insert.Length - 2, 2);
            insert.Append(")\r\n");
            insert.Append(" {\r\n");
            insert.Append("                 Result res = new Result();\r\n");
            //insert.Append("               //重复的不能插入\r\n");
            //insert.Append("             if(_sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM " + classname + " WHERE " + dt.Rows[1]["name"].ToString() + " = '\" + " + dt.Rows[1]["name"].ToString().ToLower() + " + \"'\") > 0)\r\n");
            //insert.Append("             {\r\n");
            //insert.Append("                return -1;\r\n");
            //insert.Append("             }\r\n");
            insert.Append("   string sql = \"INSERT INTO " + _dt.TableName + "( ");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                insert.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "], ");
            }
            insert.Remove(insert.Length - 2, 2);
            insert.Append(") VALUES (");

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime"))
                {
                    insert.Append("getdate(), ");
                    continue;
                }
                insert.Append("@" + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            insert.Remove(insert.Length - 2, 2);
            insert.Append("); SELECT @@identity; \";\r\n");
            insert.Append("          try\r\n");
            insert.Append("           {\r\n");
            insert.Append(InitParams(11));
            insert.Append("             res.Data = _sqlH.Execute<int>(sql, param);\r\n");
            insert.Append("           }\r\n");
            insert.Append("          catch(Exception e)\r\n");
            insert.Append("           {\r\n");
            insert.Append("              _LogWrite(e);\r\n");
            insert.Append("              res.Msg = e.Message;\r\n");
            insert.Append("              res.Status = -1;");
            insert.Append("           }\r\n");
            insert.Append("           return res;\r\n");

            insert.Append("  }\r\n\r\n");
            #endregion
            return insert.ToString();
        }

        private string Update()
        {
            StringBuilder update = new StringBuilder();
            #region Update
            update.Append("          /// <summary>\r\n");
            update.Append("          /// 更新记录\r\n");
            update.Append("          /// </summary>\r\n");
            update.Append("      public Result Update" + _entityName + " (");
            StringBuilder param = new StringBuilder();
            foreach (DataRow dr in _dt.Rows)
            {
                param.Append("string " + dr["name"].ToString().ToLower() + ", ");
            }

            if (param.Length >= 2)
            {
                update.Append(param.ToString().Remove(param.Length - 2, 2));
            }

            update.Append(")\r\n");
            update.Append("      {\r\n");
            update.Append("                 Result res = new Result();\r\n");
            update.Append("          try\r\n");
            update.Append("           {\r\n");
            //update.Append("               //重复的不能保存， 判断重复时，应该排除掉自己\r\n");
            //update.Append("             if(_sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM " + classname + " WHERE ID <> '\" + " + dt.Rows[0]["name"].ToString().ToLower() + "+ \"' AND " + dt.Rows[1]["name"].ToString() + " = '\" + " + dt.Rows[1]["name"].ToString().ToLower() + " + \"'\") > 0)\r\n");
            //update.Append("             {\r\n");
            //update.Append("                return -1;\r\n");
            //update.Append("             }\r\n");
            update.Append("          string sql =");
            StringBuilder updateStr = new StringBuilder();
            updateStr.Append("UPDATE " + _dt.TableName + " SET ");


            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                updateStr.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = @"
                    + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
            }
            updateStr.Remove(updateStr.Length - 2, 2);
            // updateStr.Append(" WHERE [" + _dt.Rows[0]["name"].ToString().ToUpper() + "] = @" + _dt.Rows[0]["name"].ToString().ToLower());
            updateStr.Append(" WHERE [id] = @id");

            update.Append("\"" + updateStr + "\";\r\n");
            update.Append(InitParams(12));
            update.Append("              _sqlH.Execute(sql, param);\r\n");
            update.Append("           }\r\n");
            update.Append("          catch(Exception e)\r\n");
            update.Append("           {\r\n");
            update.Append("              _LogWrite(e);\r\n");
            update.Append("              res.Msg = e.Message;\r\n");
            update.Append("              res.Status = -2;\r\n");
            update.Append("           }\r\n");

            update.Append("             res.Data = Convert.ToInt32(" + _dt.Rows[0]["name"].ToString().ToLower() + ");\r\n");
            update.Append("            return  res;\r\n");
            update.Append("        }\r\n\r\n");

            #endregion
            return update.ToString();
        }

        private string InsertDOL()
        {
            StringBuilder dal = new StringBuilder();

            dal.Append("          /// <summary>\r\n");
            dal.Append("          /// 插入实体\r\n");
            dal.Append("          /// </summary>\r\n");
            dal.Append("        public Result Insert" + _entityName + "(" + _entityName + " dol)\r\n");
            dal.Append("        {\r\n");
            dal.Append("           Result res = new Result();\r\n");
            dal.Append("         try\r\n");
            dal.Append("          {\r\n");
            dal.Append("               //重复的不能插入， 判断重复时\r\n");
            dal.Append("             if(_sqlH.Execute<int>(\"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE " + _dt.Rows[1]["name"].ToString() + " = '\" + dol." + _dt.Rows[1]["name"].ToString() + " + \"'\") > 0)\r\n");
            dal.Append("             {\r\n");
            dal.Append("                res.Status = -2;\r\n");
            dal.Append("             }\r\n");

            dal.Append("           string sql =");
            StringBuilder insert = new StringBuilder();
            StringBuilder values = new StringBuilder();
            insert.Append("\"INSERT INTO " + _dt.TableName + "(");
            values.Append(" values(");

            //foreach (DataRow dr in dt.Rows)
            //{
            //    insert.Append(dr["name"].ToString().ToUpper() + ", ");

            //    values.Append("\" + dol." + dr["name"].ToString()  + "+ \", ");
            //}

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                insert.Append(_dt.Rows[i]["name"].ToString().ToUpper() + ", ");
            }
            //Values
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                values.Append("@" + _dt.Rows[i]["name"].ToString() + ", ");
            }

            insert.Remove(insert.Length - 2, 2);
            values.Remove(values.Length - 2, 2);
            values.Append(");SELECT @@identity;\";\r\n");

            dal.Append(insert + ") " + values);
            dal.Append(InitParams(21));
            dal.Append("             res.Data = _sqlH.Execute<int>(sql, param);\r\n");
            dal.Append("          }\r\n");
            dal.Append("         catch(Exception e)\r\n");
            dal.Append("          {\r\n");
            dal.Append("              _LogWrite(e);\r\n");
            dal.Append("              res.Status = -1;\r\n");
            dal.Append("          }\r\n");
            dal.Append("          return res;\r\n");
            dal.Append("         }\r\n\r\n");

            return dal.ToString();
        }

        private string UpdateDol()
        {
            StringBuilder dal = new StringBuilder();
            dal.Append("          /// <summary>\r\n");
            dal.Append("          /// 更新记录\r\n");
            dal.Append("          /// </summary>\r\n");
            dal.Append("      public Result Update" + _entityName + " (" + _entityName + " dol)\r\n");
            dal.Append("      {\r\n");
            dal.Append("                 Result res = new Result();\r\n");
            dal.Append("          string sql =");
            StringBuilder update = new StringBuilder();
            update.Append("UPDATE " + _dt.TableName + " SET ");

            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                update.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = @" + _dt.Rows[i]["name"].ToString() + ", ");

            }
            update.Remove(update.Length - 2, 2);
            //update.Append(" WHERE [" + _dt.Rows[0]["name"].ToString().ToUpper() + "] = @" + _dt.Rows[0]["name"].ToString());
			update.Append(GetWhereCondition());

            dal.Append("\"" + update + "\";\r\n");

            dal.Append("          try\r\n");
            dal.Append("           {\r\n");
            dal.Append("               //重复的不能修改， 判断重复时，应该排除掉自己\r\n");
            dal.Append("             if(_sqlH.Execute<int>(\"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE ID <> '\" + dol." + _dt.Rows[0]["name"].ToString() + "+ \"' AND " + _dt.Rows[1]["name"].ToString() + " = '\" + dol." + _dt.Rows[1]["name"].ToString() + " + \"'\") > 0)\r\n");
            dal.Append("             {\r\n");
            dal.Append("                res.Status = -2;\r\n");
            dal.Append("             }\r\n");
            dal.Append(InitParams(22));
            dal.Append("              _sqlH.Execute(sql, param);\r\n");
            dal.Append("           }\r\n");
            dal.Append("          catch(Exception e)\r\n");
            dal.Append("           {\r\n");
            dal.Append("              _LogWrite(e);\r\n");
            dal.Append("              res.Status = -1;\r\n");
            dal.Append("           }\r\n");
            dal.Append("             res.Data = dol." + _dt.Rows[0]["name"].ToString() + ";\r\n");
            dal.Append("          return res;\r\n\r\n");
            dal.Append("        }\r\n\r\n");

            return dal.ToString();
        }


        /// <summary>
        /// 12 , 普通插入;
        /// 12，普通修改
        /// 21. 实体插入
        /// 22. 实体修改
        /// </summary>
        /// <param name="type"></param>
        /// 
        /// <returns></returns>
        private string InitParams(int type)
        {
            StringBuilder param = new StringBuilder();
            param.Append("                   SqlParameter[] param = new SqlParameter[] {\r\n");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {

                if ((type == 11 || type == 21) &&
                    _dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
                    continue;
                param.Append("                    new SqlParameter(\"@" + _dt.Rows[i]["name"].ToString().ToLower()
                    + "\", ");
                switch (type)
                {
                    case 11:
                    case 12:
                        param.Append(_dt.Rows[i]["name"].ToString().ToLower() + ")");
                        break;
                    case 21:
                    case 22:
                        param.Append("dol." + _dt.Rows[i]["name"].ToString().ToLower() + ")");
                        break;
                    default:
                        break;
                }
                if (i < _dt.Rows.Count - 1)
                {
                    param.Append(",\r\n");
                }
            }

            //for (int i = 0; i < _dt.Rows.Count; i++)
            //{
            //    if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
            //        continue;
            //    update.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = ");

            //    DataRow dr = _dt.Rows[i];
            //    switch (ConvertType(dr["type"].ToString()))
            //    {
            //        case "string":
            //            update.Append("'\" + dol." + _dt.Rows[i]["name"].ToString() + "+ \"', ");
            //            break;
            //        case "DateTime?":
            //            update.Append("\" + (dol." + _dt.Rows[i]["name"].ToString() + " == null ? \"null\":\"'\" + dol." + _dt.Rows[i]["name"].ToString() + ".Value.ToShortDateString() + \"'\") + \", ");
            //            // update.Append(" GETDATE(), ");
            //            break;
            //        default:
            //            update.Append("\" + dol." + _dt.Rows[i]["name"].ToString() + "+ \", ");
            //            break;
            //    }
            //}
            param.Append("};\r\n");
            return param.ToString();
        }
    }
}

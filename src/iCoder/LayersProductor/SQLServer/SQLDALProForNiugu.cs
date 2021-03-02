using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LayersProductor.SQLServer
{
	class SQLDALProForNiugu : CommonPro
	{
		static SQLDALProForNiugu instance;
		public SQLDALProForNiugu(DataTable dt, string projName, string entityName)
			: base(dt, projName, entityName)
		{

		}
		public static SQLDALProForNiugu getInstance(DataTable dt, string projName, string classname, string entityName)
		{
			// if (instance == null)
			{
				instance = new SQLDALProForNiugu(dt, projName, entityName);
			}
			return instance;
		}


		public string CreateDAL()
		{
			StringBuilder sb = new StringBuilder();
			#region Head
			//Header
			sb.Append(CreateHead(_entityName + "DAL"));
			sb.Append("using System;\r\n");
			sb.Append("using System.Data;\r\n");
			sb.Append("using System.Data.SqlClient;\r\n");
			sb.Append("using System.Collections.ObjectModel;\r\n");
			sb.Append("using System.Text;\r\n");
			sb.Append("using " + _projName + ".Entity;\r\n");
			sb.Append("\r\n");
			sb.Append("namespace ");
			sb.Append(_projName + ".DAL\r\n");
			sb.Append("{\r\n");
			//ClassDAL
			sb.Append("     public class " + _entityName + "DAL : BaseDAL\r\n");
			sb.Append("     {\r\n");
			#endregion

			#region Fields
			sb.Append("            #region Fields\r\n");
			sb.Append("             \r\n");
			sb.Append("            #endregion\r\n\r\n\r\n");
			#endregion

			#region Constructors
			sb.Append("            #region Constructors\r\n");
			sb.Append("             public " + _entityName + "DAL()\r\n");
			sb.Append("               :  base(\"" + _entityName + "\")\r\n");
			sb.Append("             {\r\n");
			// sb.Append("              //   _logH = new LogHelper(\"" + _entityName + "DAL\");\r\n");
			sb.Append("             }\r\n\r\n");
			sb.Append("            #endregion\r\n\r\n\r\n");
			#endregion

			#region Public Methods
			sb.Append("         #region Public Methods\r\n");
			sb.Append(CreateMethods());
			sb.Append("    #endregion\r\n");
			#endregion

			#region Foot
			//Foot
			sb.Append("     }\r\n");
			sb.Append("}");
			#endregion
			return sb.ToString();
		}

		private string CreateMethods()
		{
			StringBuilder sb = new StringBuilder();

			#region Get DataTable
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
					if (_dt.Rows[i]["type"].ToString().ToLower() == "datetime"
						|| _dt.Rows[i]["type"].ToString().ToLower().Equals("date"))
					{
						sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + "_start, ");
						sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + "_end, ");
					}
					//else if (dt.Rows[i]["type"].ToString().ToLower().Equals("int"))
					//{
					//    sb.Append("int " + dt.Rows[i]["name"].ToString() + ", ");
					//}
					else
						sb.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
				}
			sb.Remove(sb.Length - 2, 2);
			#endregion
			sb.Append(")\r\n");
			sb.Append("         {\r\n");
			sb.Append("          StringBuilder conditions = new StringBuilder();\r\n");
			#region Conditions
			sb.Append("#region Conditions\r\n");
			if (_dt.Rows.Count > 0)
				for (int i = 0; i < _dt.Rows.Count; i++)
				{
					if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
						continue;
					if (_dt.Rows[i]["type"].ToString().ToLower() == "datetime"
						|| _dt.Rows[i]["type"].ToString().ToLower().Equals("date"))
					{
						sb.Append("            #region " + _dt.Rows[i]["name"].ToString().ToUpper() + "_start\r\n");
						sb.Append("            if (!string.IsNullOrEmpty(");
						sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + "_start))\r\n");
						sb.Append("            {\r\n");
						// sb.Append("             sbSql.Append(\" AND " + dt.Rows[i]["name"].ToString().ToUpper() + " >= '\" + " + dt.Rows[i]["name"].ToString().ToLower() + "_start + \"' \");");
						sb.Append("             conditions.Append(\" AND DATEDIFF(DD, " + _dt.Rows[i]["name"].ToString().ToUpper() + ", '\" + " + _dt.Rows[i]["name"].ToString().ToLower() + "_start + \"')<=0 \");");
						sb.Append("\r\n            }\r\n");
						sb.Append("            #endregion\r\n");

						sb.Append("            #region " + _dt.Rows[i]["name"].ToString().ToUpper() + "_end\r\n");
						sb.Append("            if (!string.IsNullOrEmpty(");
						sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + "_end))\r\n");
						sb.Append("            {\r\n");
						//  sb.Append("            sbSql.Append(\" AND " + dt.Rows[i]["name"].ToString().ToUpper() + " <= '\" + " + dt.Rows[i]["name"].ToString().ToLower() + "_end + \" 23:59' \");");
						sb.Append("            conditions.Append(\" AND DATEDIFF(DD, " + _dt.Rows[i]["name"].ToString().ToUpper() + ", '\" + " + _dt.Rows[i]["name"].ToString().ToLower() + "_end + \"') >= 0 \");");
						sb.Append("\r\n            }\r\n");
						sb.Append("            #endregion\r\n");
					}
					//else if (dt.Rows[i]["type"].ToString().ToLower().Equals("int"))
					//{
					//    sb.Append("            #region " + dt.Rows[i]["name"].ToString().ToUpper() + "\r\n");
					//    sb.Append("            if (!string.IsNullOrEmpty(");
					//    sb.Append(dt.Rows[i]["name"].ToString().ToLower() + "))\r\n");
					//    sb.Append("            {\r\n");
					//    sb.Append("             sql+=\" AND " + dt.Rows[i]["name"].ToString().ToUpper() + " = '\" + " + dt.Rows[i]["name"].ToString().ToLower() + " + \"' \";");
					//    sb.Append("\r\n            }\r\n");
					//    sb.Append("            #endregion\r\n");
					//}
					else if (_dt.Rows[i]["type"].ToString().ToLower().Equals("ntext"))
					{
						sb.Append("            #region " + _dt.Rows[i]["name"].ToString().ToUpper() + "\r\n");
						sb.Append("            if (!string.IsNullOrEmpty(");
						sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + "))\r\n");
						sb.Append("            {\r\n");
						sb.Append("             conditions.Append(\" AND [" + _dt.Rows[i]["name"].ToString().ToUpper() + "] LIKE '%\" + " + _dt.Rows[i]["name"].ToString().ToLower() + " + \"%' \");");
						sb.Append("\r\n            }\r\n");
						sb.Append("            #endregion\r\n");
					}
					else
					{
						sb.Append("            #region " + _dt.Rows[i]["name"].ToString().ToUpper() + "\r\n");
						sb.Append("            if (!string.IsNullOrEmpty(");
						sb.Append(_dt.Rows[i]["name"].ToString().ToLower() + "))\r\n");
						sb.Append("            {\r\n");
						sb.Append("             conditions.Append(\" AND [" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = '\" + " + _dt.Rows[i]["name"].ToString().ToLower() + " + \"' \");");
						sb.Append("\r\n            }\r\n");
						sb.Append("            #endregion\r\n");
					}
				}
			sb.Append("#endregion Conditions\r\n\r\n");
			#endregion
			sb.Append("         return conditions.ToString();\r\n");
			sb.Append("         }\r\n\r\n");


			#endregion
			#region GetDtByConditions
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 根据条件获取DataTable\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("         public DataTable Get" + _entityName + "DtByConditions(string conditions");
			sb.Append(", int start_index, int count)\r\n");
			sb.Append("         {\r\n");
			sb.Append("                 string sql = \"SELECT ");
			foreach (DataRow dr in _dt.Rows)
			{
				if (dr["name"].ToString().ToLower() == "status")
				{
					sb.Append("CASE STATUS WHEN 0 THEN '未完成' WHEN 1 THEN '已完成' WHEN 2 THEN '已启用' END [" + dr["name"].ToString().ToUpper() + "], ");
				}
				else
				{
					sb.Append("[" + dr["name"].ToString().ToUpper() + "], ");
				}
			}
			sb.Remove(sb.Length - 2, 2);
			sb.Append(" FROM " + _dt.TableName + " WHERE 1=1 \" + conditions;\r\n");

			sb.Append("		DataTable dt;\r\n");
			sb.Append("		string msg;\r\n");
			sb.Append("		if (SQLCommon.ExecuteForFirstTable(sql, start_index, count, ConnectionString.NZ_Broker, out dt, out msg))\r\n");
			sb.Append("		{\r\n");
			sb.Append("			return dt;\r\n");
			sb.Append("		}\r\n");
			sb.Append("		else\r\n");
			sb.Append("		{\r\n");
			sb.Append("			return null;\r\n");
			sb.Append("		}\r\n");
			sb.Append("   }\r\n\r\n");

			#endregion
			#region GetExportDtByConditions
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 根据条件获取DataTable\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("         public DataTable GetExport" + _entityName + "DtByConditions(string conditions)\r\n");
			sb.Append("         {\r\n");
			sb.Append("                 string sql = \"SELECT ");
			foreach (DataRow dr in _dt.Rows)
			{
				if (dr["name"].ToString().ToLower() == "status")
				{
					sb.Append("CASE STATUS WHEN 0 THEN '未完成' WHEN 1 THEN '已完成' WHEN 2 THEN '已启用' END [" + _Lang.GetValueByKey(dr["name"].ToString()) + "], ");
				}
				else
				{
					sb.Append("[" + dr["name"].ToString().ToUpper() + "] '" + _Lang.GetValueByKey(dr["name"].ToString()) + "', ");
				}
			}
			sb.Remove(sb.Length - 2, 2);
			sb.Append(" FROM " + _dt.TableName + " WHERE 1=1 \" + conditions;\r\n");


			sb.Append("		DataTable dt = SQLCommon.ExecuteForFirstTable(sql, ConnectionString.NZ_Broker);\r\n");
			sb.Append("		return dt;\r\n");
			sb.Append("   }\r\n\r\n");
			#endregion
			#region GetDtCountByCondition
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 获取所有的记录的总条数\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("         public int Get" + _entityName + "CountByConditions(string conditions");
			sb.Append(")\r\n         {\r\n");
			sb.Append("                 string strCount = null;\r\n");
			sb.Append("					string sql = \"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE 1=1 \" + conditions;\r\n");
			sb.Append("					try\r\n");
			sb.Append("					{\r\n");
			sb.Append("						 strCount = SQLCommon.ExecuteForFirstField(sql, ConnectionString.NZ_Broker);\r\n");
			sb.Append("					 }\r\n");
			sb.Append("					catch(Exception e)\r\n");
			sb.Append("					{\r\n");
			//sb.Append("					    _LogWrite(e);\r\n");
			sb.Append("					}\r\n");
			sb.Append("                 return int.Parse(strCount ?? \"0\");\r\n");
			sb.Append("         }\r\n\r\n");
			#endregion
			#endregion

			#region Insert
			sb.Append(Insert());
			#endregion

			#region Update
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 更新记录\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("      public bool Update" + _entityName + " (string id, ");
			StringBuilder param = new StringBuilder();
			foreach (DataRow dr in _dt.Rows)
			{
				if (dr["is_identity"].ToString() == "1")
					continue;

				param.Append("string " + dr["name"].ToString().ToLower() + ", ");
			}

			if (param.Length >= 2)
			{
				sb.Append(param.ToString().Remove(param.Length - 2, 2));
			}

			sb.Append(")\r\n");
			sb.Append("      {\r\n");
			sb.Append("          string sql =");
			StringBuilder updateStr = new StringBuilder();
			updateStr.Append("UPDATE " + _dt.TableName + " SET ");


			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["is_identity"].ToString() == "1")
					continue;
				updateStr.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = '\" + " + _dt.Rows[i]["name"].ToString().ToLower() + " + \"', ");
			}
			updateStr.Remove(updateStr.Length - 2, 2);
			updateStr.Append(GetWhereCondition());

			sb.Append("\"" + updateStr + ";\r\n");

			sb.Append("          return SQLCommon.ExecuteNonQuery(sql, ConnectionString.NZ_Broker, out msg);;\r\n");
			sb.Append("        }\r\n\r\n");

			#endregion

			#region Delete
			#region DeleteById
			sb.Append("\t\t\t/// <summary>\r\n");
			sb.Append("\t\t\t/// 删除特定ID的记录\r\n");
			sb.Append("\t\t\t/// </summary>\r\n");
			sb.Append("\t\t\tpublic Result Del" + _entityName + "ById(string id)\r\n");
			sb.Append("\t\t\t{\r\n");
			sb.Append("\t\t\t\tResult res = new Result();\r\n");
			sb.Append("\t\t\t\t//string sql = \"DELETE FROM " + _dt.TableName + GetWhereCondition() + ";\r\n");
			sb.Append("\t\t\t\tstring sql = \"UPDATE " + _dt.TableName + " SET STATUS = -1 " + GetWhereCondition() + ";\r\n");

			sb.Append("\t\t\t\ttry\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("\t\t\t\t//已经在用的不能删除\r\n");
			sb.Append("\t\t\t\t_sqlH.Execute(sql);\r\n");
			sb.Append("\t\t\t\tres.Status = 0;\r\n");
			sb.Append("\t\t\t\t}\r\n");
			sb.Append("\t\t\t\tcatch(Exception e)\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("\t\t\t\t_LogWrite(e);\r\n");
			sb.Append("\t\t\t\tres.Status = -1;\r\n");
			sb.Append("\t\t\t\t}\r\n");
			sb.Append("\t\t\t return res;\r\n");
			sb.Append("\t\t\t}\r\n\r\n");
			#endregion

			#region DeleteByIds
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 删除所有id在ids中的记录\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("         public Result Del" + _entityName + "ByIds(string ids)\r\n");
			sb.Append("         {\r\n");
			sb.Append("             Result res = new Result();\r\n");
			sb.Append("             string sql = \"DELETE FROM " + _dt.TableName + " WHERE " + _dt.Rows[0]["name"].ToString().ToUpper() + " IN(\" + ids + \")\";\r\n");

			sb.Append("             try\r\n");
			sb.Append("             {\r\n");
			sb.Append("                 _sqlH.Execute(sql);\r\n");
			sb.Append("                 res.Status = 0;\r\n");
			sb.Append("             }\r\n");
			sb.Append("             catch(Exception e)\r\n");
			sb.Append("             {\r\n");
			sb.Append("                 _LogWrite(e);\r\n");
			sb.Append("                 res.Status = -1;\r\n");
			sb.Append("             }\r\n");
			sb.Append("             return res;\r\n");
			sb.Append("         }\r\n\r\n");
			#endregion
			#endregion

			#region EntityMethods

			#region Get Entity By ID
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 获取对应ID的实体\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("        public Result Get" + _entityName + "EntityById(string id)\r\n");
			sb.Append("        {\r\n");
			sb.Append("           Result res = new Result();\r\n");
			sb.Append("           string sql = \"SELECT ");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append(dr["name"].ToString().ToUpper() + ", ");
			}
			sb.Remove(sb.Length - 2, 2);
			sb.Append(" FROM " + _dt.TableName + " WHERE ID = \" + id;\r\n");
			sb.Append("        try\r\n");
			sb.Append("        {\r\n");
			sb.Append("            " + _entityName + " result = new " + _entityName + "();\r\n");
			sb.Append("           SqlDataReader dr = _sqlH.GetDataReader(sql);\r\n");
			sb.Append("           while(dr.Read())\r\n");
			sb.Append("           {\r\n");
			sb.Append("              ReadTo" + _entityName + "Entity(dr, result);\r\n");
			sb.Append("           }\r\n");
			sb.Append("             dr.Close();\r\n");
			sb.Append("             dr.Dispose();\r\n");
			sb.Append("             res.Data = result;\r\n");
			sb.Append("         }\r\n");
			sb.Append("         catch(Exception e)\r\n");
			sb.Append("         {\r\n");
			// sb.Append("             _logH.writeLog(e);\r\n");
			sb.Append("              _LogWrite(e);\r\n");
			sb.Append("             res.Msg = e.Message;\r\n");
			sb.Append("             res.Status = -1;\r\n");
			sb.Append("         }\r\n\r\n");

			sb.Append("             return res;\r\n");
			sb.Append("         }\r\n\r\n");
			#endregion

			#region Get EntityList
			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 获取所有实体的集合r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("        public Result Get" + _entityName + "EntityList()\r\n");
			sb.Append("        {\r\n");
			sb.Append("           Result res = new Result();\r\n");
			sb.Append("            ObservableCollection<" + _entityName + "> result = new ObservableCollection<" + _entityName + ">();\r\n");
			sb.Append("           string sql = \"SELECT ");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append(dr["name"].ToString().ToUpper() + ", ");
			}
			sb.Remove(sb.Length - 2, 2);
			sb.Append(" FROM " + _dt.TableName + "\";\r\n");
			sb.Append("            try\r\n");
			sb.Append("            {\r\n");
			sb.Append("               SqlDataReader dr = _sqlH.GetDataReader(sql);\r\n");
			sb.Append("               while(dr.Read())\r\n");
			sb.Append("               {\r\n");
			sb.Append("               " + _entityName + " dol = new " + _entityName + "();\r\n");
			sb.Append("                  ReadTo" + _entityName + "Entity(dr, dol);\r\n");
			sb.Append("                  result.Add(dol);\r\n");
			sb.Append("               }\r\n");
			sb.Append("                 dr.Close();\r\n");
			sb.Append("                 dr.Dispose();\r\n");
			sb.Append("              res.Data = result;\r\n");
			sb.Append("             }\r\n");
			sb.Append("            catch(Exception e)\r\n");
			sb.Append("            {\r\n");
			// sb.Append("                _logH.writeLog(e);\r\n");
			sb.Append("              _LogWrite(e);\r\n");
			sb.Append("             res.Msg = e.Message;\r\n");
			sb.Append("             res.Status = -1;\r\n");

			sb.Append("             }\r\n\r\n");

			sb.Append("             return res;\r\n");
			sb.Append("         }\r\n\r\n");
			#endregion

			#region Read To Entity
			//注释
			sb.Append("\t\t\t\t/// <summary>\r\n");
			sb.Append("\t\t\t\t/// Reads to entity.\r\n");
			sb.Append("\t\t\t\t/// </summary>\r\n");
			sb.Append("\t\t\t\t/// <param name=\"dr\">The dr.</param>\r\n");
			sb.Append("\t\t\t\t/// <param name=\"dol\">The dol.</param>\r\n");
			//函数体
			sb.Append("\t\t\t\tprivate void ReadTo" + _entityName + "Entity(SqlDataReader dr, " + _entityName + " dol)\r\n");
			sb.Append("\t\t\t\t{\r\n");

			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\t\t\t#region ");
				sb.Append(dr["name"].ToString() + "\r\n");
				sb.Append("             if(dr[\"" + dr["name"] + "\"] == null || dr[\"" + dr["name"] + "\"] == DBNull.Value)\r\n");
				sb.Append("             {\r\n");
				sb.Append("                 dol." + dr["name"].ToString());
				sb.Append("                  = " + dr["name"].ToString() + ";");
				sb.Append("\r\n             }\r\n");
				sb.Append("             else\r\n");
				sb.Append("             {\r\n");
				sb.Append("                dol." + dr["name"].ToString());
				sb.Append(" = " + ShowConvertMsSqlToDolType(dr) + ";");
				// sb.Append(" = dr[\"" + dr["name"] + "\"].ToString();");
				sb.Append("\r\n             }\r\n");
				sb.Append("            #endregion\r\n\r\n");
				//sb.Append("            #region ");

				//sb.Append("                 ");
				//sb.Append("\r\n            #endregion\r\n");
			}
			sb.Append("        }\r\n\r\n");
			#endregion

			#region Insert dol
			sb.Append(InsertDOL());
			#endregion

			#region Update dol
			sb.Append(UpdateDOL());
			#endregion

			#endregion

			return sb.ToString();
		}

		#region 方法
		private string JudgeRepeater()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// \r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("         public int Judge" + _entityName + "Repeater(string id, string name)\r\n");
			sb.Append("         {\r\n");
			sb.Append("             try\r\n");
			sb.Append("             {\r\n");
			sb.Append("               //重复的不能保存， 判断重复时，应该排除掉自己; \r\n");
			sb.Append("               //重复的不能保存， 判断重复如果是非物理删除，要去掉状态为-1的; \r\n");
			if (_dt.Rows[1]["type"].ToString() == "text")
			{
				sb.Append("            return _sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE ID <> '\" + id + \"' AND "
								   + _dt.Rows[1]["name"].ToString() + " LIKE '\" + name + \"' AND STATUS > -1\");\r\n");
			}
			else
			{
				sb.Append("            return _sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE ID <> '\" + id + \"' AND "
					+ _dt.Rows[1]["name"].ToString() + " = '\" + name + \"' AND STATUS > -1\");\r\n");
			}
			sb.Append("             }\r\n");
			sb.Append("             catch(Exception e)\r\n");
			sb.Append("             {\r\n");
			sb.Append("                return -1;\r\n");
			sb.Append("             }\r\n");
			sb.Append("         }\r\n");
			return sb.ToString();
		}
		#endregion

		private string Insert()
		{
			StringBuilder insert = new StringBuilder();
			#region Insert
			insert.Append("          /// <summary>\r\n");
			insert.Append("          /// 插入新的记录; 返回新纪录的ID；如果返回-2；表示插入失败；\r\n");
			insert.Append("          /// 如果返回-1；表示有重复数据；\r\n");
			insert.Append("          /// </summary>\r\n");
			insert.Append("public bool Insert" + _entityName + "(");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
					continue;
				insert.Append("string " + _dt.Rows[i]["name"].ToString().ToLower() + ", ");
			}
			insert.Remove(insert.Length - 2, 2);
			insert.Append(", out string msg)\r\n");
			insert.Append(" {\r\n");
			insert.Append("   string sql = \"INSERT INTO " + _dt.TableName + "( ");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
				{
					continue;
				}
				insert.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "], ");
			}
			insert.Remove(insert.Length - 2, 2);
			insert.Append(") VALUES (");

			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
				 || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					insert.Append("GETDATE(),");
					continue;
				}
				insert.Append("'\" + " + _dt.Rows[i]["name"].ToString().ToLower() + " + \"', ");
			}
			insert.Remove(insert.Length - 2, 2);
			insert.Append("); SELECT SCOPE_IDENTITY(); \";\r\n");

			insert.Append("           return  SQLCommon.ExecuteNonQuery(sql, ConnectionString.NZ_Broker, out msg);\r\n");

			insert.Append("  }\r\n\r\n");
			#endregion
			return insert.ToString();
		}

		private string InsertDOL()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append("          /// <summary>\r\n");
			sb.Append("          /// 插入实体\r\n");
			sb.Append("          /// </summary>\r\n");
			sb.Append("        public Result Insert" + _entityName + "Entity(" + _entityName + "Entity dol)\r\n");
			sb.Append("        {\r\n");
			sb.Append("           Result res = new Result();\r\n");
			sb.Append("         try\r\n");
			sb.Append("          {\r\n");
			sb.Append("               //重复的不能插入， 判断重复时\r\n");
			sb.Append("             if(_sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE " + _dt.Rows[1]["name"].ToString() + " = '\" + dol." + _dt.Rows[1]["name"].ToString() + " + \"'\") > 0)\r\n");
			sb.Append("             {\r\n");
			sb.Append("                res.Status = -2;\r\n");
			sb.Append("             }\r\n");
			sb.Append("             else\r\n");
			sb.Append("             {\r\n");
			sb.Append("           string sql =");
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
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
				 || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					values.Append("GETDATE(), ");
					continue;
				}
				DataRow dr = _dt.Rows[i];
				string type = ConvertMsSqlToDoNetTypeNotNull(dr);
				switch (type)
				{
					case "string":
					case "string?":
						values.Append("'\" + dol." + _dt.Rows[i]["name"].ToString() + "+ \"', ");
						break;
					case "DateTime?":
						values.Append("\" + (dol." + _dt.Rows[i]["name"].ToString() + " == null?\"null\":\"'\" + dol." + _dt.Rows[i]["name"].ToString() + ".Value.ToShortDateString())" + " + \"', ");

						break;
					default:
						values.Append("\" + dol." + _dt.Rows[i]["name"].ToString() + "+ \", ");
						break;
				}
			}

			insert.Remove(insert.Length - 2, 2);
			values.Remove(values.Length - 2, 2);
			values.Append(");SELECT SCOPE_IDENTITY();\";\r\n");

			sb.Append(insert + ") " + values);

			sb.Append("             res.Data = _sqlH.GetScalar<int>(sql);\r\n");
			sb.Append("            }\r\n");
			sb.Append("        }\r\n");
			sb.Append("         catch(Exception e)\r\n");
			sb.Append("          {\r\n");
			sb.Append("              _LogWrite(e);\r\n");
			sb.Append("              res.Status = -1;\r\n");
			sb.Append("          }\r\n");
			sb.Append("          return res;\r\n");
			sb.Append("         }\r\n\r\n");

			return sb.ToString();
		}

		private string UpdateDOL()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("\t\t\t\t/// <summary>\r\n");
			sb.Append("\t\t\t\t/// 更新记录\r\n");
			sb.Append("\t\t\t\t/// </summary>\r\n");
			sb.Append("\t\t\t\tpublic Result Update" + _entityName + "Entity(" + _entityName + "Entity dol)\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("                 Result res = new Result();\r\n");
			sb.Append("          string sql =");
			StringBuilder update = new StringBuilder();
			update.Append("UPDATE " + _dt.TableName + " SET ");

			//foreach (DataRow dr in dt.Rows)
			//{
			//    update.Append(dr["name"].ToString().ToUpper() + " = ");

			//    update.Append("\" + dol." + dr["name"].ToString()  + " + \",");
			//}
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
					continue;
				update.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = ");

				DataRow dr = _dt.Rows[i];
				switch (ConvertMsSqlToDoNetTypeNotNull(dr))
				{
					case "string":
						update.Append("'\" + dol." + _dt.Rows[i]["name"].ToString() + "+ \"', ");
						break;
					case "DateTime?":
						update.Append("\" + (dol." + _dt.Rows[i]["name"].ToString() + " == null ? \"null\":\"'\" + dol." + _dt.Rows[i]["name"].ToString() + ".Value.ToShortDateString() + \"'\") + \", ");
						// update.Append(" GETDATE(), ");
						break;
					default:
						update.Append("\" + dol." + _dt.Rows[i]["name"].ToString() + "+ \", ");
						break;
				}
			}
			update.Remove(update.Length - 2, 2);
			update.Append(" WHERE [" + _dt.Rows[0]["name"].ToString().ToUpper() + "] = " + "\" + dol.ID");

			sb.Append("\"" + update + ";\r\n");

			sb.Append("          try\r\n");
			sb.Append("           {\r\n");
			sb.Append("               //重复的不能修改， 判断重复时，应该排除掉自己\r\n");
			sb.Append("             if(_sqlH.GetScalar<int>(\"SELECT COUNT(1) FROM " + _dt.TableName + " WHERE ID <> '\" + dol." + _dt.Rows[0]["name"].ToString() + "+ \"' AND " + _dt.Rows[1]["name"].ToString() + " = '\" + dol." + _dt.Rows[1]["name"].ToString() + " + \"'\") > 0)\r\n");
			sb.Append("             {\r\n");
			sb.Append("                res.Status = -2;\r\n");
			sb.Append("             }\r\n");
			sb.Append("              _sqlH.Execute(sql);\r\n");
			sb.Append("           }\r\n");
			sb.Append("          catch(Exception e)\r\n");
			sb.Append("           {\r\n");
			sb.Append("              _LogWrite(e);\r\n");
			sb.Append("              res.Status = -1;\r\n");
			sb.Append("           }\r\n");
			sb.Append("             res.Data = dol.ID;\r\n");
			sb.Append("          return res;\r\n\r\n");
			sb.Append("        }\r\n\r\n");

			return sb.ToString();
		}
	}
}
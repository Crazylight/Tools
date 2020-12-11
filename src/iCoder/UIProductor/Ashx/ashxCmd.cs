using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Ashx
{
	public class ashxCmd
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string CreateAshx(ConditionModel model)
		{
			StringBuilder ashx = new StringBuilder();
			ashx.AppendFormat("<%@ WebHandler Language=\"C#\" Class=\"{0}\" %>\r\n\r\n", model.EntityName);

			ashx.Append("using System;\r\n");
			ashx.Append("using System.Web;\r\n\r\n");

			ashx.AppendFormat("public class api_{0} : IHttpHandler\r\n", model.EntityName);
			ashx.Append("{\r\n");
			ashx.AppendFormat("	private {0}Mgr _instance = new {0}Mgr();\r\n", model.EntityName);
			ashx.Append("	public void ProcessRequest(HttpContext context)\r\n");
			ashx.Append("	{\r\n");
			ashx.Append("	string cmdName = context.Request.QueryString[\"cmdName\"].ToString();\r\n");

			ashx.Append("	if (cmdName == \"query\")\r\n");
			ashx.Append("	{\r\n");
			ashx.Append("		Query(context);\r\n");
			ashx.Append("	}\r\n");
			ashx.Append("	else if (cmdName == \"insert\")\r\n");
			ashx.Append("	{\r\n");
			ashx.Append("		Insert(context);\r\n");
			ashx.Append("	}\r\n");
			ashx.Append("	else if (cmdName == \"update\")\r\n");
			ashx.Append("	{\r\n");
			ashx.Append("		Update(context);\r\n");
			ashx.Append("	}\r\n");
			ashx.Append("	}\r\n");

			ashx.Append(CreateQuery(model));

			ashx.Append(CreateInsert(model));

			ashx.Append(CreateUpdate(model));
			ashx.Append("	public bool IsReusable { get { return false; } }\r\n");

			ashx.Append("}\r\n");
			return ashx.ToString();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string CreateQuery(ConditionModel model)
		{
			StringBuilder ashx = new StringBuilder();
			ashx.Append("	public void Query(HttpContext context)\r\n");
			ashx.Append("	{\r\n");
			ashx.AppendFormat("	int start = Util.GetIntValue(context.Request.Form[\"start\"], 0);\r\n");
			ashx.AppendFormat("	int count = Util.GetIntValue(context.Request.Form[\"length\"], 20);\r\n");
			ashx.Append("DataTable dtData = _instance.GetDtByConditions(\"\", start, count);\r\n");
			ashx.Append("int recordTotal = _instance.GetCountByConditions(\"\");\r\n");
			ashx.Append("context.Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(new { code = 1, recordsTotal = recordTotal, recordsFiltered = recordTotal, data = dtData }));\r\n");
			ashx.Append("	}\r\n");

			return ashx.ToString();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		public static string CreateInsert(ConditionModel model)
		{
			StringBuilder ashx = new StringBuilder();
			ashx.Append("	public void Insert(HttpContext context)\r\n");
			ashx.Append("	{\r\n");

			foreach (DataRow dr in model.Table.Rows)
			{
				ashx.AppendFormat("	string {0} = context.Request.Form[\"{0}\"];\r\n", dr["name"].ToString());
			}

			ashx.AppendFormat("	 _instance.Insert(");
			foreach (DataRow dr in model.Table.Rows)
			{
				ashx.AppendFormat("{0},", dr["name"].ToString());
			}
			ashx.Remove(ashx.Length - 1, 1);
			ashx.Append(");\r\n");
			ashx.Append("	}\r\n");

			return ashx.ToString();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="tableName"></param>
		/// <returns></returns>
		static string CreateUpdate(ConditionModel model)
		{
			StringBuilder ashx = new StringBuilder();
			ashx.Append("	public void Update(HttpContext context)\r\n");
			ashx.Append("	{\r\n");

			foreach (DataRow dr in model.Table.Rows)
			{
				ashx.AppendFormat("	string {0} = context.Request.Form[\"{0}\"];\r\n", dr["name"].ToString());
			}

			ashx.AppendFormat("	 _instance.Update(");
			foreach (DataRow dr in model.Table.Rows)
			{
				ashx.AppendFormat("{0},", dr["name"].ToString());
			}
			ashx.Remove(ashx.Length - 1, 1);
			ashx.Append(");\r\n");
			ashx.Append("	}\r\n");

			return ashx.ToString();
		}



	}
}

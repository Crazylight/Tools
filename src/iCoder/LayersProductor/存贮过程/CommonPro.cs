using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LangHelper;

namespace LayersProductor
{
	public class CommonPro : TypeConvert
	{
		public static string ConnectionString;
		protected DataTable _dt;
		protected string _projName, _entityName;
		protected LanguageHelper _Lang;
		public CommonPro(DataTable dt, string projName, string entityName)
		{
			_dt = dt;

			_projName = projName;
			_entityName = entityName;
			_Lang = new LanguageHelper(LangHelper.eLanguageType.Chinese);
		}

		protected string CreateHeadV2(string fileName)
		{
			StringBuilder head = new StringBuilder();
			head.Append("#region Illustrator\r\n");
			head.Append("/**=========================================================================================================\r\n");
			head.Append("*\r\n");
			head.Append("*	Owner			:	\r\n");
			head.Append("* \r\n");
			head.Append("* Version			:		1.0.0.0\r\n");
			head.Append("* ───────────────────────────────────\r\n");
			head.Append("* \r\n");
			head.Append("*┌──────────────────────────────────┐\r\n");
			head.Append("*│　                                                                　│\r\n");
			head.Append("*│　                                                                　│\r\n");
			head.Append("*│　                                                                　│\r\n");
			head.Append("*│　Histroy:		" + DateTime.Now.ToString() + "   Created By LDQ    │\r\n");
			head.Append("*└──────────────────────────────────┘\r\n");
			head.Append("**/=========================================================================================================\r\n");
			head.Append("#endregion\r\n\r\n");

			return head.ToString();
		}
		protected string CreateHead(string fileName)
		{
			StringBuilder head = new StringBuilder();
			head.Append("#region Illustrator\r\n");
			head.Append("//=========================================================================================================\r\n");
			head.Append("//\r\n");
			head.Append(" //	Owner			:	\r\n");
			head.Append(" //\r\n");
			head.Append(" //	Project			:		\r\n");
			head.Append(" //	\r\n");
			head.Append(" //	Files			:	    " + fileName + "\r\n");
			head.Append(" //\r\n");
			head.Append(" //	Contents		:	\r\n");
			head.Append(" //\r\n");
			head.Append(" //	Version			:		1.0.0.0\r\n");
			head.Append(" //\r\n");
			head.Append(" //	CopyRight (C) . All Rights reserved.\r\n");
			head.Append(" //\r\n");
			head.Append("//=========================================================================================================\r\n");
			head.Append(" //\r\n");
			head.Append(" //	Histroy:		" + DateTime.Now.ToString() + "   Created By LDQ\r\n");
			head.Append(" //\r\n");
			head.Append("//=========================================================================================================\r\n");
			head.Append("#endregion\r\n\r\n");

			return head.ToString();
		}

		protected string InitDOL(DataRow dr)
		{
			switch (dr["type"].ToString())
			{
				case "tinyint":
				case "smallint":
				case "int":
					return "Convert.ToInt32(dr[\"" + dr["name"] + "\"].ToString())";
				case "float":
					//  return "(float)dr[\"" + dr["name"] + "\"].ToString()";
					return "Convert.ToDouble(dr[\"" + dr["name"] + "\"].ToString())";
				case "money":
				case "numberic":
					return "Convert.ToDouble(dr[\"" + dr["name"] + "\"].ToString())";
				case "char":
				case "text":
				case "ntext":
				case "nchar":
				case "nvarchar":
				case "varchar":
					return "dr[\"" + dr["name"] + "\"].ToString()";
				case "date":
				// return "Convert.ToDateTime(dr[\"" + dr["name"] + "\"]).ToShortDateString()";
				// return "dr[\"" + dr["name"] + "\"].ToString()";
				case "time":
				// return "Convert.ToDateTime(dr[\"" + dr["name"] + ".ToString()\"]).ToShortTimeString()";
				// return "dr[\"" + dr["name"] + "\"].ToString()";
				case "datetime":
				case "datetime2":
				case "smalldatetime":
					return "Convert.ToDateTime(dr[\"" + dr["name"] + "\"].ToString())";
				case "decimal":
					return "";////////////////////
				default:
					return
						dr["name"].ToString();
			}
		}
		protected bool IsContinue(string name)
		{
			if (name.ToLower().Equals("id") || name.ToLower().Equals("addtime")
					|| name.ToLower().Equals("adderid")
					|| name.ToLower().Equals("adder")
					|| name.ToLower().Equals("adderip")
					|| name.ToLower().Equals("addname")
					|| name.ToLower().Equals("addername")
					|| name.ToLower().Equals("lastsaverid")
					|| name.ToLower().Equals("lastsavername")
					|| name.ToLower().Equals("lastsavetime")
					|| name.ToLower().Equals("lastsaverip"))
			{
				return true;
			}
			return false;
		}


		protected string GetWhereCondition()
		{
			string sql = string.Format("SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where table_name = '{0}'", _dt.TableName);
			DataTable dt = new DataTable();
			SqlCommand comm = new SqlCommand();
			comm.Connection = new SqlConnection(ConnectionString);
			comm.CommandText = sql;
			using (SqlDataAdapter da = new SqlDataAdapter(comm))
			{
				da.Fill(dt);
			}
			StringBuilder condition = new StringBuilder();
			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					condition.Append(string.Format("{0} = '@{0}' and ", dr["column_name"].ToString()));
				}

			}
			string conditions = "";
			if (condition.Length > 0)
			{
				condition.Remove(condition.Length - 5, 5);
				conditions = " WHERE " + condition.ToString();
			}
			return conditions;
		}


		protected string GetWhereConditionInProc()
		{
			string sql = string.Format("SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where table_name = '{0}'", _dt.TableName);
			DataTable dt = new DataTable();
			SqlCommand comm = new SqlCommand();
			comm.Connection = new SqlConnection(ConnectionString);
			comm.CommandText = sql;
			using (SqlDataAdapter da = new SqlDataAdapter(comm))
			{
				da.Fill(dt);
			}
			StringBuilder condition = new StringBuilder();
			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					condition.Append(string.Format("{0} = @{0} and ", dr["column_name"].ToString()));
				}

			}
			string conditions = "";
			if (condition.Length > 0)
			{
				condition.Remove(condition.Length - 5, 5);
				conditions = " WHERE " + condition.ToString();
			}
			return conditions;
		}


		protected List<string> GetPrimaryKey()
		{
			List<string> list = new List<string>();
			string sql = string.Format("SELECT * FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE where table_name = '{0}'", _dt.TableName);
			DataTable dt = new DataTable();
			SqlCommand comm = new SqlCommand();
			comm.Connection = new SqlConnection(ConnectionString);
			comm.CommandText = sql;
			using (SqlDataAdapter da = new SqlDataAdapter(comm))
			{
				da.Fill(dt);
			}
			StringBuilder condition = new StringBuilder();
			if (dt != null && dt.Rows.Count > 0)
			{
				foreach (DataRow dr in dt.Rows)
				{
					list.Add(dr["column_name"].ToString());
				}

			}

			return list;
		}
	}
}

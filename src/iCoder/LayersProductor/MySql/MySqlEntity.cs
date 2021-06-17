using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersProductor.MySql
{
	public class MySqlEntity
	{
		/// <summary>
		/// __secretCount = 0  # 私有变量
		/// publicCount = 0    # 公开变量
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string CreatePublic(DataTable dt)
		{
			string entyName = dt.TableName;
			StringBuilder sb = new StringBuilder();
			sb.Append("#!/usr/bin/python\r\n\r\n");
			sb.Append("class " + entyName+ "Entity:\r\n");
			sb.Append("\tdef __init__(self, ");
			StringBuilder param = new StringBuilder();
			StringBuilder body = new StringBuilder();
			foreach (DataRow dr in dt.Rows)
			{
				string name = dr["Field"].ToString().ToLower();
				param.Append($"{name}, ");
				body.Append($"\t\tself.{name } = {name}\r\n");
			}

			sb.Append(param.ToString().Remove(param.Length - 2));
			sb.Append("):\r\n");
			sb.Append(body.ToString().Remove(body.Length - 2));

			return sb.ToString();

		}

		public static string CreatePublicEntity(DataTable dt)
		{
			string entyName = dt.TableName;
			StringBuilder sb = new StringBuilder();
			sb.Append("#!/usr/bin/python\r\n\r\n");
			sb.Append("class " + entyName + "Entity:\r\n");
			foreach (DataRow dr in dt.Rows)
			{
				string name = dr["Field"].ToString().ToLower();
				sb.Append($"\t\t{name}\r\n ");
			}
			sb.Append("\t\tdef __init__(self):\r\n");
			sb.Append("\t\t\tpass\r\n");

			return sb.ToString();

		}

	}
}

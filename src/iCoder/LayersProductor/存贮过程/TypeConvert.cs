﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LayersProductor
{
	public class TypeConvert
	{
		//protected string ConvertType(string sourceType, string is_nullable)
		//{
		//	string destType = "";
		//	switch (sourceType.ToLower())
		//	{
		//		case "tinyint":
		//		case "smallint":
		//		case "int":
		//			destType = "int";
		//			break;
		//		case "bigint":
		//			destType = "long";
		//			break;
		//		case "float":
		//			destType = "float";
		//			break;
		//		case "numeric":
		//			destType = "double";
		//			break;
		//		case "char":
		//		case "text":
		//		case "ntext":
		//		case "nchar":
		//		case "nvarchar":
		//		case "varchar":
		//		case "sysname":
		//			destType = "string";
		//			break;
		//		case "time":
		//			destType = "string";
		//			break;
		//		case "datetime":
		//		case "datetime2":
		//		case "date":
		//		case "smalldatetime":
		//			destType = "DateTime";
		//			break;
		//		case "decimal":
		//			destType = "decimal";
		//			break;
		//		case "money":
		//			destType = "double";
		//			break;
		//		default:
		//			destType =
		//				sourceType;
		//			break;
		//	}
		//	if (is_nullable == "1")
		//	{
		//		destType += "?";
		//	}
		//	return destType;
		//}

		internal static string ConvertMsSqlTypeDoNetType(DataRow dr)
		{
			string destType = "";
			switch (dr["type"].ToString().ToLower())
			{
				case "tinyint":
				case "smallint":
				case "int":
					destType = "int";
					break;
				case "bigint":
					destType = "long";
					break;
				case "float":
					destType = "float";
					break;
				case "numeric":
					destType = "double";
					break;
				case "char":
				case "text":
				case "ntext":
				case "nchar":
				case "nvarchar":
				case "varchar":
				case "sysname":
					destType = "string";
					break;
				case "time":
					destType = "string";
					break;
				case "datetime":
				case "datetime2":
				case "date":
				case "smalldatetime":
					destType = "DateTime";
					break;
				case "decimal":
					destType = "decimal";
					break;
				case "money":
					destType = "double";
					break;
				case "bit":
					destType = "bool";
					break;
				default:
					destType =
						dr["name"].ToString();
					break;
			}
			if (dr["is_nullable"].ToString().ToLower() == "true")
			{
				destType += "?";
			}
			return destType;
		}


		internal static string ConvertMsSqlToDoNetTypeNotNull(DataRow dr)
		{
			string destType = "";
			switch (dr["type"].ToString().ToLower())
			{
				case "tinyint":
				case "smallint":
				case "int":
					destType = "int";
					break;
				case "bigint":
					destType = "long";
					break;
				case "float":
					destType = "float";
					break;
				case "numeric":
					destType = "double";
					break;
				case "char":
				case "text":
				case "ntext":
				case "nchar":
				case "nvarchar":
				case "varchar":
				case "sysname":
					destType = "string";
					break;
				case "time":
					destType = "string";
					break;
				case "datetime":
				case "datetime2":
				case "date":
				case "smalldatetime":
					destType = "DateTime";
					break;
				case "decimal":
					destType = "decimal";
					break;
				case "money":
					destType = "double";
					break;
				case "bit":
					destType = "bool";
					break;
				default:
					destType =
						dr["name"].ToString();
					break;
			}
			return destType;
		}


		internal static string ConvertMySqlTypeDoNetType(DataRow dr)
		{
			string type = dr["type"].ToString().ToLower();
			if (type.StartsWith("int"))
			{
				return "int";
			}
			else if (type.StartsWith("double"))
			{
				return "double";
			}
			else if (type.StartsWith("date") || type.StartsWith("datetime"))
			{
				return "DateTime";
			}
			else
			{
				return "string";
			}
		}

		/// <summary>
		/// show， 展示转化过程
		/// </summary>
		/// <param name="dr"></param>
		/// <returns></returns>
		internal string ShowConvertMsSqlToDolType(DataRow dr)
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

		internal static string ShowConvertMySqlToDolType(DataRow dr)
		{
			string type = dr["type"].ToString();
			string field = dr["Field"].ToString();
			if (type.StartsWith("int"))
			{
				return "Convert.ToInt32(dr[\"" + field + "\"].ToString())";
			}
			else if (type.StartsWith("double"))
			{
				return "Convert.ToDouble(dr[\"" + field + "\"].ToString())";
			}
			else if (type.StartsWith("date"))
			{
				return "Convert.ToDateTime(dr[\"" + field + "\"].ToString())";
			}
			else
			{
				return "dr[\"" + field + "\"].ToString()";
			}
		}


	}
}

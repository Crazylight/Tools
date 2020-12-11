using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LayersProductor
{
	public class BasePro
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

		protected string ConvertDoNetType(DataRow dr)
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


        protected string ConvertDoNetTypeNotNull(DataRow dr)
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

    }
}

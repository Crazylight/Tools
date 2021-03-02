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

		public static string CreatePublicEntity(DataTable dt)
		{
			string entyName = dt.TableName;
			StringBuilder sb = new StringBuilder();
			sb.Append("\tpublic class " + entyName+ "Entity\r\n");
			sb.Append("\t{\r\n");

			#region Constructors
			sb.Append("\t\t#region Constructors\r\n");
			sb.Append("\t\tpublic " + entyName + "Entity()\r\n");
			sb.Append("\t\t{\r\n");

			sb.Append("\t\t}\r\n\r\n");

			sb.Append("\t\t#endregion\r\n\r\n");
			#endregion

			#region Properties
			sb.Append("\t\t#region  Public Properties\r\n");
			foreach (DataRow dr in dt.Rows)
			{
				string name = dr["Field"].ToString();
				sb.Append("\t\t/// <summary>\r\n");
				sb.Append("\t\t/// \r\n");
				sb.Append("\t\t/// </summary>\r\n");
				sb.Append("\t\tpublic " + TypeConvert.ConvertMySqlTypeDoNetType(dr) + " " + name + " { get; set; }");
				sb.Append("\r\n\r\n");
			}
			sb.Append("\t\t#endregion\r\n\r\n");
			#endregion


			#region Methods
			sb.Append("\t\t#region Methods\r\n");
			//注释
			sb.Append("\t\t\t\t/// <summary>\r\n");
			sb.Append("\t\t\t\t/// Reads to entity.\r\n");
			sb.Append("\t\t\t\t/// </summary>\r\n");
			sb.Append("\t\t\t\t/// <param name=\"dr\">The dr.</param>\r\n");
			sb.Append("\t\t\t\t/// <param name=\"dol\">The dol.</param>\r\n");
			//函数体
			sb.Append("\t\t\t\tpublic static " + entyName + "Entity ReadTo" + entyName + "Entity(DataRow dr)\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("	var dol = new " + entyName + "Entity();\r\n");
			foreach (DataRow dr in dt.Rows)
			{
				string field = dr["Field"].ToString();
				sb.Append("\t\t\t\t#region ");
				sb.Append(field + "\r\n");
				//sb.Append("             if(dr.Table.Columns.Contains(\"" + dr["name"] + "\"))\r\n");
				sb.Append("             if(dr.Table.Columns.Contains(\"" +field+ "\") && dr[\"" + field + "\"] != DBNull.Value)\r\n");
				sb.Append("             {\r\n");
				sb.Append("                dol." + field);
				sb.Append(" = " +TypeConvert.ShowConvertMySqlToDolType(dr) + ";");
				sb.Append("\r\n             }\r\n");
				sb.Append("            #endregion\r\n\r\n");
			}
			sb.Append("\t\t\t\t		return dol;\r\n");
			sb.Append("        }\r\n\r\n");

			//注释
			sb.Append("\t\t\t\t/// <summary>\r\n");
			sb.Append("\t\t\t\t/// Reads to entityList.\r\n");
			sb.Append("\t\t\t\t/// </summary>\r\n");
			//函数体
			sb.Append("\t\t\t\tpublic static  List<" + entyName + "Entity> ReadTo" + entyName + "EntityList(DataTable dt)\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("\t\t\t\t	var result = new List<" + entyName + "Entity>();\r\n");
			sb.Append("\t\t\t\t	if (dt == null)\r\n");
			sb.Append("\t\t\t\t {\r\n");
			sb.Append("\t\t\t\t		return result;\r\n");
			sb.Append("\t\t\t\t  }\r\n\r\n");
			sb.Append("\t\t\t\t foreach (DataRow row in dt.Rows)\r\n");
			sb.Append("\t\t\t\t {\r\n");
			sb.Append("\t\t\t\t		var entity = ReadTo" + entyName + "Entity(row);\r\n");
			sb.Append("\t\t\t\t		result.Add(entity);;\r\n");
			sb.Append("\t\t\t\t  }\r\n\r\n");
			sb.Append("\t\t\t\t		return result;\r\n");
			sb.Append("\t\t\t\t	}\r\n\r\n");

			sb.Append("\t\t#endregion\r\n");

			#endregion
			sb.Append("\t}");
			//Footer
			sb.Append("\r\n}");
			return sb.ToString();

		}

	}
}

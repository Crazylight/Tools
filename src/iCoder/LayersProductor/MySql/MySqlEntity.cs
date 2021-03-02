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
			StringBuilder sb = new StringBuilder();
			//Header
			//sb.Append(CreateHead(_entityName));
			//sb.Append("using System;\r\n");
			//sb.Append("using System.Runtime.Serialization;\r\n");
			//sb.Append("\r\n");
			//sb.Append("namespace ");
			//if (!_projName.Contains(".Entity"))
			//{
			//	_projName += ".Entity";
			//}
			//sb.Append(_projName + "\r\n");
			//sb.Append("{\r\n");
			sb.Append("\tpublic class " + dt.TableName + "Entity\r\n");
			sb.Append("\t{\r\n");

			#region Constructors
			sb.Append("\t\t#region Constructors\r\n");
			sb.Append("\t\tpublic " + dt.TableName + "Entity()\r\n");
			sb.Append("\t\t{\r\n");
			//#region 初始化
			//sb.Append("\t\t\t#region 初始化\r\n");
			//foreach (DataRow dr in _dt.Rows)
			//{
			//   // sb.Append("\t\t\t" + ConvertType(dr["type"].ToString()) + " _" + dr["name"].ToString() + ";\r\n");
			//}
			//sb.Append("\t\t\t#endregion\r\n\r\n");
			//#endregion

			sb.Append("\t\t}\r\n\r\n");

			sb.Append("\t\t#endregion\r\n\r\n");
			#endregion

			#region Properties
			foreach (DataRow dr in dt.Rows)
			{
				string name = dr["Field"].ToString();
				sb.Append("\t\t/// <summary>\r\n");
				sb.Append("\t\t/// \r\n");
				sb.Append("\t\t/// </summary>\r\n");
				sb.Append("\t\tpublic " + TypeConvert.ConvertMySqlTypeDoNetType(dr) + " " + name + " { get; set; }");
				sb.Append("\r\n\r\n");
			}

			#endregion
			sb.Append("\t}");
			//Footer
			sb.Append("\r\n}");
			return sb.ToString();

		}

	}
}

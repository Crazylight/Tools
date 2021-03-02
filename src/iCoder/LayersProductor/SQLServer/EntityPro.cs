using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LayersProductor.SQLServer
{
	internal class EntityPro : CommonPro
	{
		static EntityPro _instance;
		public static EntityPro getInstance(DataTable dt, string projName, string entityName)
		{
			// if (_instance == null)
			{
				_instance = new EntityPro(dt, projName, entityName);
			}
			return _instance;
		}
		private EntityPro(DataTable dt, string projName, string entityName)
			: base(dt, projName, entityName)
		{
		}
		public string CreatePropertyEntity()
		{
			StringBuilder sb = new StringBuilder();
			//Header
			sb.Append(CreateHead(_entityName));
			sb.Append("using System;\r\n");
			sb.Append("using System.Runtime.Serialization;\r\n");
			sb.Append("\r\n");
			sb.Append("namespace ");
			if (!_projName.Contains(".Entities"))
			{
				_projName += ".Entities";
			}
			sb.Append(_projName + "\r\n");
			sb.Append("{\r\n");
			//Content
			sb.Append("\t//[DataContract]\r\n");
			sb.Append("\tpublic class ");
			sb.Append(_entityName + "Entity\r\n");
			sb.Append("\t{\r\n");

			#region Constructors
			sb.Append("\t\t#region Constructors\r\n");
			sb.Append("\t\tpublic ");
			sb.Append(_entityName + "Entity()\r\n");
			sb.Append("\t\t\r\n");
			//#region 初始化
			//sb.Append("\t\t\t#region 初始化\r\n");
			//foreach (DataRow dr in _dt.Rows)
			//{
			//   // sb.Append("\t\t\t" + ConvertType(dr["type"].ToString()) + " _" + dr["name"].ToString() + ";\r\n");
			//}
			//sb.Append("\t\t\t#endregion\r\n\r\n");
			//#endregion

			sb.Append("\t\t}\r\n\r\n");

			sb.Append("\t\t public ");
			sb.Append(_entityName + "Entity(");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append(ConvertMsSqlTypeDoNetType(dr) + " " + dr["name"].ToString().ToLower() + ", ");
			}
			sb.Remove(sb.Length - 2, 2);
			sb.Append(" )\r\n");
			sb.Append("\t\t{\r\n");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\t\t_" + dr["name"].ToString() + "Field = " + dr["name"].ToString().ToLower() + ";\r\n");
			}
			sb.Remove(sb.Length - 1, 1);
			sb.Append("\t\t\t}\r\n\r\n");

			sb.Append("\t\t#endregion\r\n\r\n");
			#endregion

			#region Members
			sb.Append("\t\t#region Members\r\n");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\t\t/// <summary>\r\n");
				sb.Append("\t\t\t///" + _Lang.GetValueByKey(dr["name"].ToString()) + "\r\n");
				sb.Append("\t\t\t/// </summary>\r\n");
				sb.Append("\t\t\tprivate " + ConvertMsSqlTypeDoNetType(dr) + " _" + dr["name"].ToString() + "Field;\r\n");
			}
			sb.Append("\t\t#endregion\r\n\r\n");
			#endregion


			#region Properties
			sb.Append("\t\t\t#region Public Properties\r\n");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\t\t/// <summary>\r\n");
				sb.Append("\t\t\t///" + dr["name"].ToString() + "\r\n");
				sb.Append("\t\t\t/// </summary>\r\n");
				sb.Append("\t\t\t//[DataMember]\r\n");
				sb.Append("\t\t\tpublic " + ConvertMsSqlTypeDoNetType(dr) + " " + dr["name"].ToString() + "\r\n");
				sb.Append("\t\t\t{\r\n");
				sb.Append("\t\t\t     get{ return " + " _" + dr["name"].ToString() + "Field;}\r\n");
				sb.Append("\t\t\t     set\r\n");
				sb.Append("\t\t\t     {\r\n ");
				sb.Append("\t\t\t       _" + dr["name"].ToString() + "Field = value;\r\n");
				sb.Append("\t\t\t     }\r\n");
				sb.Append("\t\t\t}\r\n\r\n");
			}
			sb.Append("\t\t\t#endregion\r\n");
			#endregion
			sb.Append("\t}");
			//Footer
			sb.Append("\r\n}");
			return sb.ToString();
		}

		public string CreatePublicEntity()
		{
			StringBuilder sb = new StringBuilder();
			//Header
			sb.Append(CreateHead(_entityName));
			sb.Append("using System;\r\n");
			sb.Append("using System.Runtime.Serialization;\r\n");
			sb.Append("\r\n");
			sb.Append("namespace ");
			if (!_projName.Contains(".Entity"))
			{
				_projName += ".Entity";
			}
			sb.Append(_projName + "\r\n");
			sb.Append("{\r\n");
			sb.Append("\tpublic class " + _entityName + "Entity\r\n");
			sb.Append("\t{\r\n");

			#region Constructors
			sb.Append("\t\t#region Constructors\r\n");
			sb.Append("\t\tpublic " + _entityName + "Entity()\r\n");
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
			sb.Append("\t\t#region Public Properties\r\n");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\tpublic " + ConvertMsSqlTypeDoNetType(dr) + " " + dr["name"].ToString() + " { get; set; }\r\n");
			}
			sb.Append("\t\t#endregion\r\n");
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
			sb.Append("\t\t\t\tpublic static " + _entityName + "Entity ReadTo" + _entityName + "Entity(DataRow dr)\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("	var dol = new " + _entityName + "Entity();\r\n");
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\t\t\t#region ");
				sb.Append(dr["name"].ToString() + "\r\n");
				//sb.Append("             if(dr.Table.Columns.Contains(\"" + dr["name"] + "\"))\r\n");
				sb.Append("             if(dr.Table.Columns.Contains(\"" + dr["name"] + "\") && dr[\"" + dr["name"] + "\"] != DBNull.Value)\r\n");
				sb.Append("             {\r\n");
				sb.Append("                dol." + dr["name"].ToString());
				sb.Append(" = " + InitDOL(dr) + ";");
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
			sb.Append("\t\t\t\tpublic static  List<" + _entityName + "Entity> ReadTo" + _entityName + "EntityList(DataTable dt)\r\n");
			sb.Append("\t\t\t\t{\r\n");
			sb.Append("\t\t\t\t	var result = new List<" + _entityName + "Entity>();\r\n");
			sb.Append("\t\t\t\t	if (dt == null)\r\n");
			sb.Append("\t\t\t\t {\r\n");
			sb.Append("\t\t\t\t		return result;\r\n");
			sb.Append("\t\t\t\t  }\r\n\r\n");
			sb.Append("\t\t\t\t foreach (DataRow row in dt.Rows)\r\n");
			sb.Append("\t\t\t\t {\r\n");
			sb.Append("\t\t\t\t		var entity = ReadTo" + _entityName + "Entity(row);\r\n");
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

		/// <summary>
		/// 直接Get Set 方式
		/// </summary>
		/// <returns></returns>
		public string CreateMVCModel()
		{
			StringBuilder sb = new StringBuilder();
			//Header
			//sb.Append(CreateHead(_entityName));
			//sb.Append("using System;\r\n");
			//sb.Append("using System.Runtime.Serialization;\r\n");
			//sb.Append("\r\n");
			//sb.Append("namespace ");
			//if (!_projName.Contains(".Model"))
			//{
			//    _projName += ".Model";
			//}
			//sb.Append(_projName + "\r\n");
			//sb.Append("{\r\n");
			sb.Append(" [TableName(\"" + _dt.TableName + "\")]\r\n");
			sb.Append("[PrimaryKey(\"\", AutoIncrement = true)]\r\n");
			sb.Append(" [ExplicitColumns]\r\n");
			sb.Append("\tpublic class " + _entityName + "Model\r\n");
			sb.Append("\t{\r\n");

			#region Properties
			foreach (DataRow dr in _dt.Rows)
			{
				sb.Append("\t\t[Column]\r\n");
				sb.Append("\t\tpublic " + ConvertMsSqlToDoNetTypeNotNull(dr) + " " + dr["name"].ToString() + " { get; set; }\r\n");
			}
			#endregion
			sb.Append("\t}");
			//Footer
			//sb.Append("\r\n}");
			return sb.ToString();

		}
	}
}

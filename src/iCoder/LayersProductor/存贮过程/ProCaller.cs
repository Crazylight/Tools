using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LangHelper;

namespace LayersProductor
{
    public class ProCaller : BasePro
    {
        protected DataTable _dt;
        protected string _projName, _entityName;
        protected LanguageHelper _Lang;
        static ProCaller instance;
        private ProCaller(DataTable dt)
        {
            _dt = dt;

            _Lang = new LanguageHelper(LangHelper.eLanguageType.Chinese);
        }

        public static ProCaller getInstance(DataTable dt)
        {
            instance = new ProCaller(dt); //换了表的时候保证此处也跟着变化

            return instance;
        }

        public string CreateProCaller_Row()
        {
            StringBuilder pro = new StringBuilder();
            pro.Append("public void CallerAdd()\r\n");
            pro.Append("{\r\n");
            pro.Append("    try\r\n");
            pro.Append("    {\r\n");
            pro.Append("	TradeUtils.SpResult sr;\r\n");
            pro.Append("	List<SqlParameter> sps = new List<SqlParameter>();\r\n");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (_dt.Rows[i]["type"].ToString().ToLower() == "datetime" ||
                    _dt.Rows[i]["type"].ToString().ToLower() == "numberic")
                {
                    pro.Append("if(");
                    pro.Append(" row[\"" + _dt.Rows[i]["name"].ToString() + "\"].ToString().Length == 0");
                    pro.Append(")\r\n");
                    pro.Append("{\r\n");
                    pro.Append("sps.Add(new SqlParameter(\"" + _dt.Rows[i]["name"].ToString()
                        + "\", DBNull.Value));\r\n");
                    pro.Append("}\r\n");
                    pro.Append("else\r\n");
                    pro.Append("{\r\n");
                    pro.Append("sps.Add(new SqlParameter(\"" + _dt.Rows[i]["name"].ToString()
                        + "\", row[\"" + _dt.Rows[i]["name"].ToString() + "\"].ToString()));\r\n");
                    pro.Append("\r\n");
                    pro.Append("}\r\n");

                }
                else
                    pro.Append("sps.Add(new SqlParameter(\"" + _dt.Rows[i]["name"].ToString()
                        + "\", row[\"" + _dt.Rows[i]["name"].ToString() + "\"].ToString()));\r\n");
            }

            pro.Append("	if (TradeUtils.ExecSp(\"\", connstr, sps, out sr))\r\n");
            pro.Append("	{\r\n");
            pro.Append("		if (sr.ret == 0)\r\n");
            pro.Append("	    {\r\n");
            pro.Append("	    }\r\n");
            pro.Append("	}\r\n");
            pro.Append("	else\r\n");
            pro.Append("	{\r\n");
            pro.Append("	}\r\n");
            pro.Append(" }\r\n");
            pro.Append("catch(Exception e)\r\n");
            pro.Append("{\r\n");
            pro.Append("}\r\n");

            pro.Append("}\r\n");
            return pro.ToString();

        }

        public string CreateProCaller_Entity()
        {
            StringBuilder pro = new StringBuilder();
            pro.Append("public void CallerAdd()\r\n");
            pro.Append("{\r\n");
            pro.Append("    try\r\n");
            pro.Append("    {\r\n");

            pro.Append("TradeUtils.SpResult sr;\r\n");
            pro.Append("List<SqlParameter> sps = new List<SqlParameter>();\r\n");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                pro.Append("sps.Add(new SqlParameter(\"" + _dt.Rows[i]["name"].ToString()
                    + "\", dol." + _dt.Rows[i]["name"].ToString() + "));\r\n");
            }

            pro.Append("if (TradeUtils.ExecSp(\"\", connstr, sps, out sr))\r\n");
            pro.Append("{\r\n");
            pro.Append("	if (sr.ret == 0)\r\n");
            pro.Append("    {\r\n");
            pro.Append("    }\r\n");
            pro.Append("}\r\n");
            pro.Append("else\r\n");
            pro.Append("{\r\n");
            pro.Append("}\r\n");

            pro.Append("}\r\n");
            pro.Append("catch(Exception e)\r\n");
            pro.Append("{\r\n");
            pro.Append("}\r\n");

            pro.Append("}\r\n");

            return pro.ToString();

        }


        public string CreateProCaller_Parameter()
        {
            StringBuilder pro = new StringBuilder();
            pro.Append("public void CallerAdd(");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
				pro.Append(ConvertDoNetType(_dt.Rows[i]));
                pro.Append(" ");

                pro.Append(_dt.Rows[i]["name"].ToString());
                if (_dt.Rows.Count - 1 > i)
                {
                    pro.Append(",");
                }
            }
            pro.Append(")\r\n");
            pro.Append("{\r\n");
            pro.Append("    try\r\n");
            pro.Append("    {\r\n");
            pro.Append("    TradeUtils.SpResult sr;\r\n");
            pro.Append("    List<SqlParameter> sps = new List<SqlParameter>();\r\n");
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                pro.Append("sps.Add(new SqlParameter(\"" + _dt.Rows[i]["name"].ToString()
                    + "\"," + _dt.Rows[i]["name"].ToString() + "));\r\n");
            }

            pro.Append("if (TradeUtils.ExecSp(\"\", ConnectionString.DB_Name, sps, out sr))\r\n");
            pro.Append("{\r\n");
            pro.Append("	if (sr.ret == 0)\r\n");
            pro.Append("    {\r\n");
            pro.Append("    }\r\n");
            pro.Append("}\r\n");
            pro.Append("else\r\n");
            pro.Append("{\r\n");
            pro.Append("}\r\n");

            pro.Append("}\r\n");
            pro.Append("catch(Exception e)\r\n");
            pro.Append("{\r\n");
            pro.Append("}\r\n");
            pro.Append("}\r\n");

            return pro.ToString();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Units
{
	/// <summary>
	/// HTML
	/// </summary>
	public partial class UnitQuery : BaseUnit
	{
		public UnitQuery(ConditionModel model)
			: base(model)
		{

		}
		#region Table
		/// <summary>
		/// 很少用
		/// </summary>
		/// <returns></returns>
		public string GetConditionsDiv_Table()
		{
			StringBuilder div = new StringBuilder();
			div.Append("<div>\r\n");
			div.Append("<table>\r\n");
			div.Append("\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;

				#region 奇数列
				if (i % 2 == 1)
				{
					div.Append("<tr>\r\n");
					div.Append("<td>");
					div.Append("<span> " + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：</span>");
					if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime")
						|| _model.Table.Rows[i]["type"].ToString().ToLower().Equals("date"))
					{
						div.Append("<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',maxDate:'#F{$dp.$D(\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\"/>");
						div.Append("--<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',minDate:'#F{$dp.$D(\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\"/>");
					}
					else if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("int"))
					{
						div.Append("<asp:DropDownList runat=\"server\" ID=\"Ddl" + _model.Table.Rows[i]["name"].ToString() + "\"/>");
					}
					else
						div.Append("<asp:TextBox runat=\"server\" ID=\"Tb" + _model.Table.Rows[i]["name"].ToString() + "\"/>");
					div.Append("</td>\r\n");
				}

				#endregion
				#region 偶数列
				else
				{
					div.Append("<td>");
					div.Append("<span> " + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：</span>");
					if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime")
						|| _model.Table.Rows[i]["type"].ToString().ToLower().Equals("date"))
					{
						div.Append("<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',maxDate:'#F{$dp.$D(\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\"/>");
						div.Append("--<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',minDate:'#F{$dp.$D(\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\"/>");
					}
					else if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("int"))
					{
						div.Append("<asp:DropDownList runat=\"server\" ID=\"Ddl" + _model.Table.Rows[i]["name"].ToString() + "\"/>");
					}
					else
						div.Append("<asp:TextBox runat=\"server\" ID=\"Tb" + _model.Table.Rows[i]["name"].ToString() + "\"/>");
					div.Append("</td>\r\n");
					div.Append("</tr>\r\n");
				}
				#endregion
			}
			if (!div.ToString().EndsWith("</tr>\r\n"))
			{
				div.Append("<td>\r\n");
				div.Append("</td>\r\n");
				div.Append("</tr>\r\n");
			}
			div.Append("</table>\r\n");
			div.Append("</div>\r\n");

			return div.ToString();
		}
		#endregion

		#region dl dd
		/// <summary>
		/// 更容易被seo搜索到
		/// </summary>
		/// <returns></returns>
		public string GetDiv_DlDd()
		{
			StringBuilder div = new StringBuilder();
			div.Append("<div>\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;

				if (i % 2 == 0)
				{
					div.Append("<dl>\r\n");
				}
				#region DT DD
				div.Append("<dt>\r\n");
				div.Append(_Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString().ToUpper()) + "：");
				div.Append("</dt>\r\n");
				div.Append("<dd>\r\n");
				if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime")
					|| _model.Table.Rows[i]["type"].ToString().ToLower().Equals("date"))
				{
					div.Append("<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',maxDate:'#F{$dp.$D(\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\"/>");
					div.Append("--<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',minDate:'#F{$dp.$D(\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\"/>");
				}
				else
					div.Append("<asp:TextBox runat=\"server\" ID=\"TB" + _model.Table.Rows[i]["name"].ToString().ToUpper() + "\"/>\r\n");
				div.Append("</dd>\r\n");

				#endregion
				if (i % 2 == 1)
				{
					div.Append("</dl>");

				}
			}

			if (!div.ToString().EndsWith("</dl>"))
			{
				div.Append("\r\n<dt >\r\n");
				div.Append("");
				div.Append("</dt>\r\n");
				div.Append("<dd>");
				div.Append("");
				div.Append("</dd>");
				div.Append("");
				div.Append("</dl>");
			}

			div.Append("</div>\r\n");
			return div.ToString();
		}
		#endregion

		#region dl p
		/// <summary>
		/// Gets the div_ dl P.
		/// </summary>
		/// <returns></returns>
		public string GetConditionsDiv_DlP()
		{
			StringBuilder div = new StringBuilder();
			div.Append("<div class=div_condition>\r\n");
			for (int i = 0, index = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
					continue;
				index++;
				if (index % 2 == 0)
				{
					div.Append("<p>\r\n");
				}

				#region P content
				div.Append("<span> " + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：</span>");
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("status"))
				{
					div.Append("<asp:DropDownList runat=server ID=Ddl" + _model.Table.Rows[i]["name"] + " AutoPostBack=true  OnSelectedIndexChanged=PagePager_PageChanged>\r\n");
					div.Append("   <asp:ListItem Text=\"请选择状态\" Value=\"\" />\r\n");
					div.Append("   <asp:ListItem Text=\"未完成\" Value=\"0\" />\r\n");
					div.Append("   <asp:ListItem Text=\"已完成\" Value=\"1\" />\r\n");
					div.Append("   <asp:ListItem Text=\"已启用\" Value=\"2\" />\r\n");
					div.Append("</asp:DropDownList>\r\n");
				}
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("date") ||
					 _model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime"))
				{
					div.Append("<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',maxDate:'#F{$dp.$D(\\\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\\\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\"/>");
					div.Append("--<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn',minDate:'#F{$dp.$D(\\\'Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start\\\')}'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End\"/>");
				}
				else
					div.Append("<asp:TextBox runat=\"server\" ID=\"Tb" + _model.Table.Rows[i]["name"].ToString() + "\"/>\r\n");
				#endregion

				if (i % 2 == 1)
				{
					div.Append("</p>\r\n");
				}
			}

			if (!div.ToString().EndsWith("</p>\r\n"))
			{
				div.Append("</p>\r\n");
			}

			div.Append("</div>\r\n");
			return div.ToString();
		}
		#endregion
	}

	/// <summary>
	/// CS
	/// </summary>
	public partial class UnitQuery
	{

		/// <summary>
		/// 更容易被seo搜索到
		/// </summary>
		/// <returns></returns>
		public string GetCS_Conditions()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected string GetConditions()\r\n");
			cs.Append("{\r\n");
			cs.Append("	//return _mgr.GetConditions(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime")
					|| _model.Table.Rows[i]["type"].ToString().ToLower().Equals("date"))
				{
					cs.Append("Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start.Value,");
					cs.Append("Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End.Value,");
				}
				else
					cs.Append("TB" + _model.Table.Rows[i]["name"].ToString().ToUpper() + ".Text,");
			}
			cs.Remove(cs.Length - 1, 1);
			cs.Append("	);\r\n");
			cs.Append("}\r\n");
			return cs.ToString();
		}
	}
}

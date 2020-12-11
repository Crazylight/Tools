using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Units
{
	/// <summary>
	/// 列表模块
	/// </summary>
	public partial class UnitList : BaseUnit
	{
		public UnitList(ConditionModel model)
			: base(model)
		{
		}


		#region Create ListPage Repeater
		/// <summary>
		/// 显示列表
		/// </summary>
		/// <returns></returns>
		public string ListUI_Repeater()
		{
			StringBuilder repeater = new StringBuilder();
			repeater.Append("   <div>\r\n");
			repeater.Append("  <table width=100% class=list_table>\r\n");
			repeater.Append("<tr>\r\n");

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
					continue;
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime"))
				{
					repeater.Append("<th class=\"listTh \">\r\n");
					repeater.Append("<span class=\"up\" orderBy =\"" + _model.Table.Rows[i]["name"].ToString() + "\">");
					repeater.Append(_Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()));
					repeater.Append("</span>");
					repeater.Append("</th>\r\n");
				}
				else
					repeater.Append("<th>" + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "\r\n");
				repeater.Append("</th>\r\n");
			}
			repeater.Append("</tr>\r\n");

			repeater.Append("<asp:Repeater runat=\"server\" ID=\"RptList\">\r\n");
			repeater.Append("<ItemTemplate>\r\n");
			repeater.Append("<tr>\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
					continue;
				if (_model.Table.Rows[i]["type"].ToString().ToLower() == "date"
					|| _model.Table.Rows[i]["type"].ToString().ToLower() == "datetime")
				{
					repeater.Append("<td>\r\n <%# DataBinder.Eval(Container.DataItem, \""
					  + _model.Table.Rows[i]["name"].ToString().ToUpper() + "\", \"{0:yyyy-MM-dd}\")%>\r\n</td>");
				}
				else
					repeater.Append("<td>\r\n <%# DataBinder.Eval(Container.DataItem, \""
						+ _model.Table.Rows[i]["name"].ToString().ToUpper() + "\")%>\r\n</td>\r\n");
			}

			repeater.Append("</tr>\r\n");
			repeater.Append("</ItemTemplate>\r\n");
			repeater.Append("</asp:Repeater>\r\n");
			repeater.Append("</table>\r\n");
			repeater.Append("</div>\r\n");//把控件放到div的外面，这样可以减少就不会多一行空白栏
			repeater.Append(CreatePageIndex());

			return repeater.ToString();
		}

		/// <summary>
		/// 显示列表
		/// </summary>
		/// <returns></returns>
		public string ListUI_Api()
		{
			StringBuilder repeater = new StringBuilder();
			repeater.Append("<div>\r\n");
			repeater.Append("<table ID=\"datalist\"  class=\"table table-bordered table-striped table-hover\">\r\n");
			repeater.Append("\t<thead>\r\n");
			repeater.Append("\t\t<tr>\r\n");

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
					continue;

				repeater.Append("<th>" + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "\r\n");

				repeater.Append("</th>\r\n");
			}
			repeater.Append("\t\t</tr>\r\n");
			repeater.Append("\t</thead>\r\n");
			repeater.Append("\t<tbody>\r\n");
			repeater.Append("\t</tbody>\r\n");
			repeater.Append("</table>\r\n");
			repeater.Append("</div>\r\n");//把控件放到div的外面，这样可以减少就不会多一行空白栏

			return repeater.ToString();
		}

		//To Do: 
		private string ListAspx_GridView()
		{
			StringBuilder grid = new StringBuilder();
			grid.Append("<div>\r\n");
			grid.Append("<asp:GridView runat=\"server\" ID=\"GvSource\" AutoGenerateColumns=\"false\" Width=\"99%\" OnRowDataBound=\"Gv_OnRowDataBound\" >");
			grid.Append(" <columns>\r\n");
			#region Colomns
			grid.Append("<asp:TemplateField>\r\n");
			grid.Append(" <HeaderTemplate>\r\n");
			grid.Append("<input type='checkbox' onclick=\"SelectAll()\"/>");
			grid.Append("</HeaderTemplate>\r\n");
			grid.Append(" <ItemTemplate>\r\n");
			grid.Append("<input type='checkbox' id=\"IptSelected\"/>\r\n");
			grid.Append(" </ItemTemplate>\r\n");
			grid.Append(" </asp:TemplateField>");
			grid.Append("");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				grid.Append("<asp:BoundField DataField=\"" + _model.Table.Rows[i]["name"].ToString().ToUpper() + "\" HeaderText=\"" + _model.Table.Rows[i]["name"].ToString().ToUpper() + "\" />");
			}


			grid.Append("<asp:TemplateField HeaderText=\"操作\"><ItemTemplate>");
			grid.Append("<a href=\"Edit.aspx?id='" + _model.Table.Rows[1]["name"].ToString().ToUpper() + "'\">编辑</a>");
			grid.Append("</ItemTemplate></asp:TemplateField>\r\n");
			#endregion
			grid.Append("</columns>");
			#region Style
			grid.Append("<AlternatingRowStyle BackColor=\"lightgray\" />");
			grid.Append("<HeaderStyle HorizontalAlign=\"Center\" BackColor=\"#507CD1\" Font-Bold=\"True\" ForeColor=\"White\" />");
			grid.Append(" <SelectedRowStyle BackColor=\"#D1DDF1\" Font-Bold=\"True\" ForeColor=\"#333333\" />");
			grid.Append("");
			grid.Append("");
			grid.Append("");
			grid.Append("");
			grid.Append("");
			#endregion
			grid.Append("</asp:GridView>");
			////////////////////////////////////////////////////////////////
			grid.Append("<webdiyer:AspNetPager ID=\"Pager\" runat=\"server\" HorizontalAlign=\"Center\" OnPageChanged=\"PagePager_PageChanged\"");
			grid.Append(" OnPageChanging=\"PagePaging_PageChanging\" ");
			grid.Append("NumericButtonTextFormatString=\"{0}\" AlwaysShow=\"true\" UrlPaging=\"False\" CssClass=\"pages\"");
			grid.Append(" NextPageText=\"下一页\" FirstPageText=\"首页\" LastPageText=\"尾页\" PrevPageText=\"上一页\"");
			grid.Append("PagingButtonLayoutType=\"None\" ShowDisabledButtons=\"False\" ShowPageIndexBox=\"Never\"");
			grid.Append(" CurrentPageButtonPosition=\"Center\"");
			grid.Append(" PagingButtonSpacing=\"0px\" CurrentPageButtonClass=\"cpb\" ShowCustomInfoSection=\"Right\"");
			grid.Append("/>");
			////////////////////////////////////////////////////////////////
			grid.Append(" <h2 runat=\"server\" id=\"h2NoRecords\"  style=\"text-align:center;\">没有相关记录</h2>");
			grid.Append("</div>\r\n");
			grid.Append("");
			grid.Append("");
			return grid.ToString();
		}

		#endregion

		#region ListBox _ Combination
		public string CombinationUI_ListBox()
		{
			StringBuilder listBox = new StringBuilder();
			listBox.Append("<div class=\"tac\">\r\n");
			listBox.Append("    <div id=\"div_combination>\r\n");
			#region Div
			listBox.Append("            <div class=\"div_lr\">\r\n");
			listBox.Append("            <p>目标数据</p>\r\n");
			listBox.Append("              <asp:ListBox runat=\"server\" ID=\"LstbDesc\" CssClass=\"lstb\" Height=\"400\"/>");
			listBox.Append("        </div>\r\n");
			#endregion
			#region Div
			listBox.Append("        <div class=\"div_center\">\r\n");
			listBox.Append("            <asp:Button runat=\"server\" ID=\"BtnAdd\" Height=\"32px\" Width=\"80px\" Text=\">\" OnClick=\"BtnAdd_Click\" />\r\n");
			listBox.Append("        </div>\r\n");
			#endregion
			#region Div
			listBox.Append("            <div class=\"div_lr\">\r\n");
			listBox.Append("            <p>原数据</p>\r\n");
			listBox.Append("            <div class=\"div_query\">\r\n");
			listBox.Append("               <asp:TextBox runat=\"server\" ID=\"TbCondition\" CssClass=\"tbconditon\" Text=\"请输入条件\" />\r\n");
			listBox.Append("               <asp:Button runat=\"server\" ID=\"BtnQuery\" CssClass=\"btnQuery\" OnClick=\"BtnQuery_Click\"/>\r\n");
			listBox.Append("            </div>\r\n");
			listBox.Append("              <asp:ListBox runat=\"server\" ID=\"LstbSource\" CssClass=\"lstb\" Height=\"360\" AutoPostBack=\"true\">\r\n");
			listBox.Append("              </asp:ListBox>\r\n");
			listBox.Append("          </div>\r\n");
			#endregion
			listBox.Append("    </div>\r\n");
			listBox.Append("</div>\r\n");

			return listBox.ToString();
		}

		public string CombinationCS_ListBox()
		{
			StringBuilder listBox = new StringBuilder();
			listBox.Append("private void InitListBox()\r\n");
			listBox.Append("{\r\n");
			listBox.Append("  #region 初始化源数据\r\n");
			listBox.Append("    this.LstbSource.DataBind();\r\n");
			listBox.Append("   #endregion\r\n");
			listBox.Append("  #region 初始化目标数据\r\n");
			listBox.Append("    this.LstbDesc.DataBind();\r\n");
			listBox.Append("   #endregion\r\n");
			listBox.Append("\r\n");
			listBox.Append("}\r\n");
			listBox.Append(" protected void BtnAdd_Click(object sender, EventArgs e)\r\n");
			listBox.Append("{\r\n");
			listBox.Append("");
			listBox.Append("\r\n");
			listBox.Append("}\r\n");

			listBox.Append(" protected void BtnQuery_Click(object sender, EventArgs e)\r\n");
			listBox.Append("{\r\n");
			listBox.Append("    InitListBox();");
			listBox.Append("\r\n");
			listBox.Append("}\r\n");

			return listBox.ToString();
		}
		#endregion
	}

	public partial class UnitList
	{
		public string ListCS_GridView()
		{
			StringBuilder cs = new StringBuilder();
			#region LoadData
			cs.Append(" /// <summary>\r\n");
			cs.Append(" /// 获取所有的记录\r\n");
			cs.Append(" /// </summary>\r\n");
			cs.Append("private void LoadData()\r\n");
			cs.Append("{\r\n");
			cs.Append("    this.Pager.RecordCount = _mgr.GetDtAllCount();\r\n");
			cs.Append("    System.Data.DataTable dt = _mgr.GetDtByConditions(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (_model.Table.Rows[i]["type"].ToString().ToLower() == "datetime")
				{
					cs.Append("this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Value, ");
				}
				else
					cs.Append("this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Text, ");
			}

			cs.Remove(cs.Length - 2, 2);
			cs.Append(", (this.Pager.CurrentPageIndex - 1) * _pageSize, _pageSize);\r\n");

			cs.Append("   RptList.DataSource = dt;\r\n");
			cs.Append("   RptList.DataBind();\r\n");
			cs.Append("   this.Pager.TextAfterPageIndexBox = \"/\" + Pager.PageCount + \"页\"");
			cs.Append("   Pager.CustomInfoHTML = \"共有\" + Pager.RecordCount + \"条记录&nbsp;&nbsp;&nbsp;&nbsp;当前第\" + Pager.CurrentPageIndex + \"页/共有\" + Pager.PageCount + \"页\";");
			cs.Append(" }\r\n\r\n");
			#endregion
			#region  protected void PagePager_PageChanged(object sender, EventArgs e)
			cs.Append("          protected void PagePager_PageChanged(object sender, EventArgs e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("               LoadData();\r\n");
			cs.Append("          }\r\n\r\n");
			#endregion
			return cs.ToString();
		}

		#region ListPage Creater
		public string ListCS_Repeater()
		{
			StringBuilder cs = new StringBuilder();
			#region LoadData
			cs.Append(" /// <summary>\r\n");
			cs.Append(" /// 获取所有的记录\r\n");
			cs.Append(" /// </summary>\r\n");
			cs.Append("private void LoadData()\r\n");
			cs.Append("{\r\n");
			cs.Append("  Pager.PageSize = Convert.ToInt32(this.DdlPageCount.SelectedValue);\r\n");
			cs.Append("     string conditions = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "Conditions(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (_model.Table.Rows[i]["type"].ToString().ToLower() == "datetime")
				{
					cs.Append("this.Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start.Value, ");
					cs.Append("this.Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End.Value, ");
				}
				else
					cs.Append("this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Text, ");
			}

			cs.Remove(cs.Length - 2, 2);
			cs.Append(");\r\n");
			cs.Append("    this.Pager.RecordCount = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "CountByConditions(conditions);\r\n");
			cs.Append("    RptList.DataSource = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "DtByConditions( conditions, (this.Pager.CurrentPageIndex - 1) * Pager.PageSize, Pager.PageSize).Data;\r\n");
			cs.Append("    RptList.DataBind();\r\n");
			cs.Append("     this.LblPage.Text = \"共\" + this.Pager.RecordCount + \"条\";\r\n");

			cs.Append(" }\r\n\r\n");
			#endregion
			#region  protected void PagePager_PageChanged(object sender, EventArgs e)
			cs.Append("          protected void PagePager_PageChanged(object sender, EventArgs e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("               LoadData();\r\n");
			cs.Append("          }\r\n\r\n");
			#endregion

			return cs.ToString();
		}


		public string ListEditCS_GridView()
		{
			StringBuilder cs = new StringBuilder();
			#region GetDt
			cs.Append(" /// <summary>\r\n");
			cs.Append(" /// 获取所有的记录\r\n");
			cs.Append(" /// </summary>\r\n");
			cs.Append("private void LoadData()\r\n");
			cs.Append("{\r\n");
			cs.Append("    this.Pager.RecordCount = _mgr.GetDtAllCount();\r\n");
			cs.Append("    System.Data.DataTable dt = _mgr.GetDtByConditions(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (_model.Table.Rows[i]["type"].ToString().ToLower() == "datetime")
				{
					cs.Append("this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Value, ");
				}
				else
					cs.Append("this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Text, ");
			}

			cs.Remove(cs.Length - 2, 2);
			cs.Append(", (this.Pager.CurrentPageIndex - 1) * _pageSize, _pageSize);\r\n");

			cs.Append("   RptList.DataSource = dt;\r\n");
			cs.Append("   RptList.DataBind();\r\n");
			cs.Append("   Pager.CustomInfoHTML = \"共有\" + Pager.RecordCount + \"条记录&nbsp;&nbsp;&nbsp;&nbsp;当前第\" + Pager.CurrentPageIndex + \"页/共有\" + Pager.PageCount + \"页\";");
			cs.Append(" }\r\n\r\n");
			#endregion
			#region  protected void PagePager_PageChanged(object sender, EventArgs e)
			cs.Append("          protected void PagePager_PageChanged(object sender, EventArgs e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("               LoadData();\r\n");
			cs.Append("          }\r\n\r\n");
			#endregion
			return cs.ToString();
		}

		#endregion
	}
}

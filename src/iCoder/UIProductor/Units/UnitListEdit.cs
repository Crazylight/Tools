using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIProductor.Page;

namespace UIProductor.Units
{
	public partial class UnitListEdit : BaseUnit
	{

		static UnitListEdit _instance;
		public static UnitListEdit getInstance(ConditionModel model)
		{
			// if (_instance == null)
			{
				_instance = new UnitListEdit(model);
			}

			return _instance;
		}

		public UnitListEdit(ConditionModel model)
			: base(model)
		{
		}

		#region Create EditPage
		public string HtmlEditPageListBox()
		{
			StringBuilder listBox = new StringBuilder();
			#region ListBox
			listBox.Append("<table class=\"table\">\r\n");

			listBox.Append("<tr>\r\n");
			listBox.Append(" <td class=\"td_title\">");
			listBox.Append("<span> 列表：</span>");
			listBox.Append("</td>\r\n");
			listBox.Append("<td class=\"td_content\">");
			listBox.Append("<asp:ListBox runat=\"server\"  class=\"listbox\" ID=\"LbSource\"  AutoPostBack=\"true\"  OnSelectedIndexChanged=\"LbSource_SelectedIndexChanged\">\r\n");
			listBox.Append("");
			listBox.Append("</asp:ListBox>\r\n");
			listBox.Append("</td>\r\n");
			listBox.Append("</tr>\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime"))
					continue;
				listBox.Append("<tr>\r\n");
				listBox.Append(" <td class=\"td_title\">");
				listBox.Append("<span> " + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：</span>");
				listBox.Append("</td>\r\n");

				listBox.Append("<td class=\"td_content\">");
				if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime") ||
					 _model.Table.Rows[i]["type"].ToString().ToLower().Equals("date"))
				{
					listBox.Append("<input type=\"text\" onfocus=\"WdatePicker({lang:'zh-cn'})\" runat=\"server\" id=\"Ipt" + _model.Table.Rows[i]["name"].ToString() + "\" class=\"bgtb\" style=\"width: 36%\" />");
				}
				else
					listBox.Append("<asp:TextBox runat=\"server\" ID=\"Tb" + _model.Table.Rows[i]["name"].ToString() + "\"/>");
				listBox.Append("</td>\r\n");
				listBox.Append("</tr>\r\n");
			}

			listBox.Append("</table>\r\n");
			#endregion

			return listBox.ToString();
		}

		public string HtmlEditPageRepeater()
		{
			StringBuilder repeater = new StringBuilder();

			repeater.Append("<div>\r\n");
			repeater.Append("<table>\r\n");
			repeater.Append("<asp:Repeater runat=server id=RptList OnItemDataBound=RptList_DataBound OnItemCommand=RptList_Command>\r\n");
			repeater.Append(" <HeaderTemplate>\r\n");
			repeater.Append("<tr>\r\n");
			repeater.Append("<td>\r\n");
			repeater.Append("输入:\r\n");
			repeater.Append("</td>\r\n");
			repeater.Append("<td>\r\n");
			repeater.Append(" <asp:TextBox runat=server ID=TbName/>\r\n");
			repeater.Append(" <asp:HiddenField runat=server ID=HidId  Value=' <%# DataBinder.Eval(Container.DataItem, \"ID\") %>'/>\r\n");
			repeater.Append("</td>\r\n");
			repeater.Append("<td>\r\n");
			repeater.Append("<asp:ImageButton runat=server ID=ImgBtn ImageUrl='../img/add.png'  OnClientClick=\"if(confirm('您确定要删除？')) return confirm('您真的要删除？') ;else return false;\"\r\n");
			repeater.Append(" CommandName=Del CommandArgument='<%# Eval(\"ID\") %>'/> \r\n");
			repeater.Append("</td>\r\n");
			repeater.Append("\r\n");
			repeater.Append("</tr>\r\n");
			repeater.Append(" </HeaderTemplate>\r\n");
			repeater.Append(" <ItemTemplate>\r\n");
			repeater.Append("<tr>\r\n");
			repeater.Append("<td>\r\n");
			repeater.Append(" <asp:Label runat=server ID=LblNum/>\r\n");
			repeater.Append("</td>\r\n");
			repeater.Append("<td>\r\n");
			repeater.Append("\r\n");
			repeater.Append(" <asp:TextBox runat=server ID=TbName/>\r\n");
			repeater.Append("</td>\r\n");
			repeater.Append("<td>\r\n");
			repeater.Append("\r\n");
			repeater.Append("<asp:ImageButton runat=server ID=ImgBtn ImageUrl='../img/delete.png'  OnClientClick=\"if(confirm('您确定要删除？')) return confirm('您真的要删除？') ;else return false;\"\r\n");
			repeater.Append(" CommandName=Del CommandArgument='<%# Eval(\"ID\") %>'/> \r\n");
			repeater.Append("\r\n");
			repeater.Append("</td>\r\n");
			repeater.Append("</tr>\r\n");
			repeater.Append(" </ItemTemplate>\r\n");
			repeater.Append(" </asp:Repeater>\r\n");
			repeater.Append("</table>\r\n");
			repeater.Append("</div>\r\n");
			return repeater.ToString();
		}
		#endregion

		#region Create ListEditPage
		public string ListEditUI_Repeater()
		{
			StringBuilder repeater = new StringBuilder();
			repeater.Append(" <div>\r\n");
			repeater.Append("<table class=list_table>");
			repeater.Append("<tr>");

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				repeater.Append("<th>" + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString().ToUpper()) + "</th>");
			}
			repeater.Append("<th>操作</th>");
			repeater.Append("</tr>");

			repeater.Append("<asp:Repeater runat=\"server\" ID=\"RptList\"  OnItemCommand=\"RptList_OnItemCommand\" OnItemDataBound=\"RptList_OnItemDataBound\">");
			repeater.Append("<ItemTemplate>");
			repeater.Append("<tr>");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				repeater.Append("<td>\r\n ");
				repeater.Append("  <asp:Label ID=\"lbl" + _model.Table.Rows[i]["name"] + "\" runat=server Text = '<%# DataBinder.Eval(Container.DataItem, \""
					+ _model.Table.Rows[i]["name"].ToString().ToUpper() + "\")%>' ></asp:Label>\r\n");

				if (_model.Table.Rows[i]["type"].ToString().ToLower() == "datetime")
				{
					repeater.Append("<input runat=server id=Ipt" + _model.Table.Rows[i]["name"] + "  value = '<%# DataBinder.Eval(Container.DataItem, \""
					  + _model.Table.Rows[i]["name"].ToString().ToUpper() + "\", \"{0:yyyy-MM-dd}\")%>' Visible=false/> ");
				}
				else
				{
					repeater.Append("  <asp:TextBox ID=\"Txt" + _model.Table.Rows[i]["name"] + "\" runat=server Text = '<%# DataBinder.Eval(Container.DataItem, \""
						+ _model.Table.Rows[i]["name"].ToString().ToUpper() + "\")%>'   Visible=false></asp:TextBox>\r\n");
				}
				repeater.Append("</td>\r\n");
			}
			if (_model.Table.Rows.Count > 0)
			{
				repeater.Append("<td>\r\n");
				repeater.Append("<asp:LinkButton ID=lnkEdit runat=server CommandName=Edit CommandArgument='<%# DataBinder.Eval(Container.DataItem, \"ID\") %>'>编辑</asp:LinkButton>\r\n");
				repeater.Append("<asp:LinkButton ID=lnkUpdate Visible=false runat=server CommandName=Update CommandArgument='<%# DataBinder.Eval(Container.DataItem, \"ID\") %>'>保存</asp:LinkButton>\r\n");
				repeater.Append("<asp:LinkButton ID=lnkCancel Visible=false runat=server CommandName=Cancel CommandArgument='<%# DataBinder.Eval(Container.DataItem, \"ID\") %>'>取消</asp:LinkButton>\r\n");
				repeater.Append(@" <asp:LinkButton ID=lnkDel runat=server CommandName=Del OnClientClick='javascript:return confirm(""Are you sure you want to delete?"")' CommandArgument='<%# DataBinder.Eval(Container.DataItem, ""ID"") %>'>删除</asp:LinkButton>");
				repeater.Append("</td>\r\n");

			}

			repeater.Append("</tr>\r\n");
			repeater.Append("</ItemTemplate>\r\n");
			repeater.Append("</asp:Repeater>");
			repeater.Append("</table>");
			repeater.Append("</div>");//把控件放到div的外面，这样可以减少就不会多一行空白栏
			repeater.Append(CreatePageIndex());
			return repeater.ToString();
		}

		//To Do: 
		private string ListEditAspx_GridView()
		{
			StringBuilder grid = new StringBuilder();
			grid.Append("<div>\r\n");
			grid.Append("<asp:Button runat=\"server\" ID=\"BtnAdd\" Text=\"添加\" CssClass=\"btns\" OnClick=\"BtnAdd_Click\" />\r\n");
			//sb.Append(" BackColor=\"#dcdcdc\" onmouseover=\"this.style.borderColor='#75cd02'\" onmouseout=\"this.style.borderColor='#dcdcdc'\" />\r\n");
			grid.Append("<asp:Button runat=\"server\" ID=\"BtnDel\" Text=\"删除\" CssClass=\"btns\" OnClientClick=\"return confirm('你要删除该记录？')== true? confirm('你真的要删除该记录？') : false; \" OnClick=\"BtnDel_Click\" />\r\n");
			grid.Append("</div>\r\n");
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
			grid.Append("");
			grid.Append("");
			return grid.ToString();
		}

		#endregion

	}


	public partial class UnitListEdit : BaseUnit
	{
		#region ListCreater

		public string ListCS_Repeater()
		{
			StringBuilder cs = new StringBuilder();
			#region Repeater Commands
			cs.Append("          protected void RptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("                   if (e.CommandName == \"Edit\")  \r\n");
			cs.Append("                   {\r\n");
			cs.Append("                      ClientScript.RegisterClientScriptBlock(this.GetType(), \"\", \"<script>Edit" + _model.EntityName + "(\" + e.CommandArgument + \")</script>\");");
			cs.Append("                   } \r\n");
			cs.Append("                   else if (e.CommandName == \"Del\")  \r\n");
			cs.Append("                    { \r\n");
			cs.Append("                       DelById(e.CommandArgument.ToString()); \r\n");
			cs.Append("                    }\r\n");
			cs.Append("                     \r\n");
			cs.Append("               LoadData();\r\n");
			cs.Append("          }\r\n\r\n");
			#endregion
			#region  protected void PagePager_PageChanged(object sender, EventArgs e)
			cs.Append("          protected void PagePager_PageChanged(object sender, EventArgs e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("               LoadData();\r\n");
			cs.Append("          }\r\n\r\n");
			#endregion
			#region LoadData
			cs.Append("        #region  Private Methods\r\n");
			#region LoadData
			cs.Append(" /// <summary>\r\n");
			cs.Append(" /// 获取所有的记录\r\n");
			cs.Append(" /// </summary>\r\n");
			cs.Append("private void LoadData()\r\n");
			cs.Append("{\r\n");
			cs.Append("  Pager.PageSize = Convert.ToInt32(this.DdlPageCount.SelectedValue);\r\n");
			cs.Append("    this.Pager.RecordCount = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "CountByConditions(GetConditions());\r\n");
			cs.Append("    RptList.DataSource = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "DtByConditions( GetConditions() + GetOrderBy(), (this.Pager.CurrentPageIndex - 1) * Pager.PageSize, Pager.PageSize).Data;\r\n");

			cs.Append("    RptList.DataBind();\r\n");
			cs.Append("     this.LblPage.Text = \"共\" + this.Pager.RecordCount + \"条\";\r\n");
			cs.Append(" }\r\n\r\n");
			#endregion
			#region ExportData
			cs.Append(" /// <summary>\r\n");
			cs.Append(" /// 获取所有的记录\r\n");
			cs.Append(" /// </summary>\r\n");
			cs.Append("private void ExportData()\r\n");
			cs.Append("{\r\n");
			cs.Append("   HelperCommand.ExportExcel( _" + _model.EntityName + "Mgr.GetExport" + _model.EntityName + "DtByConditions( GetConditions()).Data as DataTable, \"" + _Language.GetValueByKey(_model.EntityName) + "列表\");\r\n");

			cs.Append(" }\r\n\r\n");
			#endregion
			#region DelById
			cs.Append("            private void DelById(string Id)\r\n");
			cs.Append("            {\r\n");
			cs.Append("                Result res = _" + _model.EntityName + "Mgr.Del" + _model.EntityName + "ById(Id);\r\n");
			cs.Append("                if(res.Status >=0)\r\n ");
			cs.Append("                { this.LblMsg.Text = \"删除成功\"; \r\n");
			cs.Append("            }\r\n");
			cs.Append("                 else\r\n");
			cs.Append("            {\r\n");
			cs.Append("                this.LblMsg.Text = \"删除失败\"; \r\n");
			cs.Append("            }\r\n");
			cs.Append("            }\r\n");
			#endregion
			#region GetConditions
			cs.Append(" /// <summary>\r\n");
			cs.Append(" /// 获取所有的记录\r\n");
			cs.Append(" /// </summary>\r\n");
			cs.Append("private string GetConditions()\r\n");
			cs.Append("{\r\n");
			cs.Append("     string conditions = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "Conditions(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
					continue;

				if (_model.Table.Rows[i]["name"].ToString().ToLower() == "status")
				{
					cs.Append("this.Ddl" + _model.Table.Rows[i]["name"].ToString() + ".SelectedValue, ");
				}
				else if (_model.Table.Rows[i]["type"].ToString().ToLower() == "date"
					|| _model.Table.Rows[i]["type"].ToString().ToLower() == "datetime")
				{
					cs.Append("this.Ipt" + _model.Table.Rows[i]["name"].ToString() + "_Start.Value, ");
					cs.Append("this.Ipt" + _model.Table.Rows[i]["name"].ToString() + "_End.Value, ");
				}
				else
					cs.Append("this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Text, ");
			}

			cs.Remove(cs.Length - 2, 2);
			cs.Append(");\r\n");
			cs.Append("     return conditions;\r\n");
			cs.Append(" }\r\n\r\n");
			#endregion
			#region GetOrderBy
			cs.Append("   private string GetOrderBy()\r\n");
			cs.Append("   {\r\n");
			cs.Append("     string orderby = \" ORDER BY \";");
			cs.Append("     if(this.HidOrderBy.Value.Trim().Length > 0)\r\n");
			cs.Append("     {\r\n");
			cs.Append("       orderby += this.HidOrderBy.Value;\r\n");
			cs.Append("     }\r\n");
			cs.Append("     else  ");
			cs.Append("     {\r\n");
			cs.Append("       orderby += \"ID DESC\";\r\n");
			cs.Append("     }\r\n");
			cs.Append("     return orderby;\r\n");
			cs.Append("}\r\n");
			#endregion
			cs.Append("        #endregion  Private Methods\r\n");
			#endregion
			return cs.ToString();
		}

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

		#endregion

		#region Edit Creater

		public string CSEditPage_ListBox()
		{
			StringBuilder listBox = new StringBuilder();
			listBox.Append("        /// <summary>\r\n");
			listBox.Append("        /// 初始化ListBox\r\n");
			listBox.Append("        /// </summary>\r\n");
			listBox.Append("private void InitListBox()\r\n");
			listBox.Append("{\r\n");
			listBox.Append("  System.Data.DataTable dt = _" + _model.EntityName + "Mgr.GetDtAll" + _model.EntityName + "().Data as System.Data.DataTable;\r\n");
			listBox.Append("  // for (int i = 0; i < dt.Rows.Count; i++)\r\n");
			listBox.Append("   //{\r\n");
			listBox.Append("   //   dt.Rows[i][\"" + _model.Table.Rows[1][0] + "\"] = System.Web.HttpUtility.HtmlDecode(dt.Rows[i][\"" + _model.Table.Rows[1][0] + "\"].ToString());;\r\n");
			listBox.Append(" //  };\r\n");
			listBox.Append("     this.LbSource.DataSource = dt;\r\n");
			listBox.Append("     this.LbSource.DataTextField = \"" + _model.Table.Rows[1][0] + "\";\r\n");
			listBox.Append("     this.LbSource.DataValueField =\"" + _model.Table.Rows[0][0] + "\";\r\n");
			listBox.Append("     this.LbSource.DataBind(); \r\n");
			listBox.Append("      if(dt == null || dt.Rows.Count == 0) \r\n");
			listBox.Append("      { \r\n");
			listBox.Append("       this.BtnModify.Enabled = this.BtnDel.Enabled = false;\r\n");
			listBox.Append("      }\r\n");
			listBox.Append("      else\r\n");
			listBox.Append("      { \r\n");
			listBox.Append("       this.BtnModify.Enabled = this.BtnDel.Enabled = true;\r\n");
			listBox.Append("      }\r\n");
			listBox.Append("}\r\n\r\n");
			listBox.Append("        /// <summary>\r\n");
			listBox.Append("        /// 显示选中的记录\r\n");
			listBox.Append("        /// </summary>\r\n");
			listBox.Append("  protected void LbSource_SelectedIndexChanged(object sender, EventArgs e)\r\n");
			listBox.Append("{\r\n");
			listBox.Append("   DataTable dt = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "DtById(this.LbSource.SelectedValue).Data as DataTable;\r\n");
			//  listBox.Append("    " +  _model.Table.TableName + " editDol = _" +  _model.EntityName + "Mgr.GetEntityByID(this.LbSource.SelectedValue);\r\n");
			//  listBox.Append("if(null == editDol)\r\n");
			listBox.Append(" if (dt != null && dt.Rows.Count > 0)\r\n");
			listBox.Append("{\r\n");
			listBox.Append("      ViewState[\"id\"] = dt.Rows[0][\"ID\"];\r\n");
			for (int i = 1; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder")
					 || _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					 || _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					continue;
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("name"))
				{
					listBox.Append("this.Tb" + _model.Table.Rows[i]["name"] + ".Text = dt.Rows[0][\"" + _model.Table.Rows[i]["name"].ToString() + "\"].ToString();\r\n ");
				}
				else if (_model.Table.Rows[i]["type"].ToString().Equals("datetime") ||
					   _model.Table.Rows[i]["type"].ToString().Equals("date"))
				{
					listBox.Append("this.Ipt" + _model.Table.Rows[i]["name"] + ".Value = dt.Rows[0][\"" + _model.Table.Rows[i]["name"].ToString() + "\"].ToString();\r\n");
				}
				else if (_model.Table.Rows[i]["type"].ToString().Equals("int"))
				{
					listBox.Append("this.Tb" + _model.Table.Rows[i]["name"] + ".Text = dt.Rows[0][\"" + _model.Table.Rows[i]["name"].ToString() + "\"].ToString();\r\n ");
				}
				else
					listBox.Append("this.Tb" + _model.Table.Rows[i]["name"] + ".Text = dt.Rows[0][\"" + _model.Table.Rows[i]["name"].ToString() + "\"].ToString();\r\n ");
			}
			listBox.Append(" }\r\n");
			listBox.Append("}\r\n\r\n");
			return listBox.ToString();
		}

		public string CSEditPage_Repeater()
		{
			StringBuilder repeater = new StringBuilder();
			repeater.Append(" protected void RptStore_Command(object sender, RepeaterCommandEventArgs e)\r\n");
			repeater.Append("{\r\n");
			repeater.Append(" if (e.CommandName == \"Save\")\r\n");
			repeater.Append(" {\r\n");
			repeater.Append("");
			repeater.Append(" }\r\n");
			repeater.Append(" else if (e.CommandName == \"Del\")\r\n");
			repeater.Append(" {\r\n");
			repeater.Append("    this.HidId.Value = e.CommandArgument.ToString();\r\n");
			repeater.Append(" }\r\n");
			repeater.Append("}\r\n\r\n");
			repeater.Append("  protected void RptStoreDataBound(object sender, RepeaterItemEventArgs e)\r\n");
			repeater.Append("  {\r\n");
			repeater.Append("    if (e.Item.ItemType == ListItemType.Item && e.Item.ItemIndex > -1)\r\n");
			repeater.Append("    {\r\n");
			repeater.Append("");
			repeater.Append("");
			repeater.Append("");
			repeater.Append("    }\r\n");
			repeater.Append("     if (e.Item.ItemType == ListItemType.Header)\r\n");
			repeater.Append("     {");
			repeater.Append("");
			repeater.Append("      }");
			repeater.Append("  }\r\n");
			repeater.Append("");
			return repeater.ToString();
		}

		#endregion

		#region ListEditPage Creater
		public string ListEditCS_Repeater()
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
			#region DataBound
			cs.Append("          protected void RptList_OnItemDataBound(object sender,RepeaterItemEventArgs  e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("              if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)\r\n");
			cs.Append("                {\r\n");
			cs.Append("                     LinkButton lbtnEdit = e.Item.FindControl(\"lnkEdit\") as LinkButton; \r\n");
			cs.Append("                     LinkButton lbtnDel = e.Item.FindControl(\"lnkDel\") as LinkButton;\r\n");
			cs.Append("                    if (e.Item.ItemIndex == EditIndex) \r\n");
			cs.Append("                    {\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
					continue;
				cs.Append("                        Label lbl" + _model.Table.Rows[i]["name"] + " = e.Item.FindControl(\"lbl" + _model.Table.Rows[i]["name"] + "\") as Label;\r\n");
				cs.Append("                        lbl" + _model.Table.Rows[i]["name"] + ".Visible = false; \r\n");
				cs.Append("                        TextBox txt" + _model.Table.Rows[i]["name"] + " = e.Item.FindControl(\"txt" + _model.Table.Rows[i]["name"] + "\") as TextBox; \r\n");
				cs.Append("                        txt" + _model.Table.Rows[i]["name"] + ".Visible = true; \r\n");
			}
			cs.Append("                       \r\n");
			cs.Append("                        LinkButton lbtnUpdate = e.Item.FindControl(\"lnkUpdate\") as LinkButton; \r\n");
			cs.Append("                        lbtnUpdate.Visible = true;\r\n");
			cs.Append("                       \r\n");
			cs.Append("                         LinkButton lbtnCancel = e.Item.FindControl(\"lnkCancel\") as LinkButton;\r\n");
			cs.Append("                         lbtnCancel.Visible = true;\r\n");
			cs.Append("                         lbtnEdit.Visible = false; \r\n");
			cs.Append("                         lbtnDel.Visible = false; \r\n");
			cs.Append("                       \r\n");
			cs.Append("                       \r\n");
			cs.Append("                       \r\n");
			cs.Append("                    }\r\n");
			cs.Append("               }\r\n");
			cs.Append("          }\r\n\r\n");

			#endregion
			#region Repeater Commands
			cs.Append("          protected void RptList_OnItemCommand(object sender, RepeaterCommandEventArgs e)\r\n");
			cs.Append("          {\r\n");
			cs.Append("                if (e.CommandName == \"Edit\")\r\n");
			cs.Append("                {\r\n");
			cs.Append("                  EditIndex = e.Item.ItemIndex;\r\n");
			cs.Append("                }\r\n");
			cs.Append("               else if (e.CommandName == \"Update\")\r\n");
			cs.Append("                {\r\n");
			#region                              Update
			cs.Append("                TextBox txtName = e.Item.FindControl(\"txtName\") as TextBox;\r\n");
			cs.Append("                if (_" + _model.EntityName + "Mgr.Judge" + _model.EntityName + "Repeater( e.CommandArgument.ToString(), txtName.Text) > 0)\r\n");
			cs.Append("                {\r\n");
			cs.Append("                 //  this.LblMsg.Text = \"不能重复\";\r\n");
			cs.Append("                   Command.ShowError(\"不能重复\");\r\n");
			cs.Append("                   return;\r\n");
			cs.Append("                }\r\n\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
					continue;
				cs.Append("      TextBox txt" + _model.Table.Rows[i]["name"] + " = e.Item.FindControl(\"txt" + _model.Table.Rows[i]["name"] + "\") as TextBox;\r\n");
			}
			cs.Append("              Result res = _" + _model.EntityName + "Mgr.Update" + _model.EntityName + "(e.CommandArgument.ToString(), ");

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
					continue;
				cs.Append("txt" + _model.Table.Rows[i]["name"] + ".Text, ");
			}
			cs.Remove(cs.Length - 2, 2);
			cs.Append(");\r\n");
			cs.Append("              if (res.Status >= 0)\r\n");
			cs.Append("               {\r\n");
			cs.Append("                 // this.LblMsg.Text = \"修改成功\";\r\n");
			cs.Append("                   Command.ShowSuccess(\"修改成功\");\r\n");
			cs.Append("               }\r\n");
			cs.Append("              else\r\n");
			cs.Append("               {\r\n");
			cs.Append("                 //  this.LblMsg.Text = \"修改失败\";\r\n");
			cs.Append("                 Command.ShowError(\"修改失败\");\r\n");
			cs.Append("               }\r\n");

			#endregion
			cs.Append("                }\r\n");
			cs.Append("              else if (e.CommandName == \"Del\")\r\n");
			cs.Append("                {\r\n\r\n");
			cs.Append("                      Del" + _model.EntityName + "ById(e.CommandArgument.ToString());\r\n");
			cs.Append("                }\r\n");
			cs.Append("               LoadData();\r\n");
			cs.Append("          }\r\n\r\n");

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

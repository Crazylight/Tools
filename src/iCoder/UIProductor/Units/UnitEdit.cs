using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Units
{
	internal partial class UnitEdit : BaseUnit
	{
		public UnitEdit(ConditionModel model)
			: base(model)
		{

		}

		#region AspClass


		public string AspxCreateEdit(UIProductor.Page.ePageType type)
		{
			StringBuilder Aspx = new StringBuilder();
			Aspx.Append("<div>\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
				{
					continue;
				}
				Aspx.Append("<div>\r\n");
				Aspx.Append("<span>");
				Aspx.Append(_Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：\r\n");
				Aspx.Append("</span>");
				Aspx.Append(CreateOneCell_Aspx(_model.Table.Rows[i], type));
				Aspx.Append("</div>\r\n");
			}
			Aspx.Append("\r\n");
			Aspx.Append("</div>\r\n");
			return Aspx.ToString();
		}

		public string AspxCreateView(UIProductor.Page.ePageType type)
		{
			StringBuilder Aspx = new StringBuilder();
			Aspx.Append("<div>\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
				{
					continue;
				}
				Aspx.Append("<div>\r\n");
				Aspx.Append("<span>");
				Aspx.Append(_Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：\r\n");
				Aspx.Append("</span>");
				Aspx.Append(CreateOneCell_Aspx(_model.Table.Rows[i], type));
				Aspx.Append("</div>\r\n");


			}
			Aspx.Append("\r\n");
			Aspx.Append("</div>\r\n");
			return Aspx.ToString();
		}


		public string AspxCreateEditTable()
		{
			StringBuilder Aspx = new StringBuilder();
			Aspx.Append("\r\n<table>\r\n");

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
				{
					continue;
				}

				Aspx.Append("<tr>\r\n");
				Aspx.Append("<td>\r\n");
				Aspx.Append(_Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "：\r\n");
				Aspx.Append("</td>\r\n");
				Aspx.Append("<td>\r\n");
				Aspx.Append(CreateOneCell_Aspx(_model.Table.Rows[i], Page.ePageType.ViewEditPageListBox));
				Aspx.Append("</td>\r\n");
				Aspx.Append("</tr>\r\n");
			}
			Aspx.Append("\r\n");
			Aspx.Append("</table>\r\n");
			return Aspx.ToString();
		}

		private string CreateOneCell_Aspx(DataRow dr, UIProductor.Page.ePageType type)
		{
			StringBuilder row = new StringBuilder();
			if (type == Page.ePageType.ViewPage)
			{
				//row.Append("<asp:Label runat=server ID=Lbl" + dr["name"] + "/>\r\n");
				if (dr["type"].ToString().ToLower().Contains("time") || dr["type"].ToString().ToLower().Contains("date"))
				{
					row.Append("<input runat=server ID=IptEdit" + dr["name"] + "Start onfocus=\"WdatePicker({lang:'zh-cn', dateFmt:'yyyy-MM-dd'})\" />\r\n");
					row.Append("<input runat=server ID=IptEdit" + dr["name"] + "End onfocus=\"WdatePicker({lang:'zh-cn', dateFmt:'yyyy-MM-dd'})\" />\r\n");
				}
				else
				{
					row.Append("<input runat=server ID=IptEdit" + dr["name"] + "/>\r\n");
				}
			}
			else if (type == Page.ePageType.ApiViewEditPage)
			{
				row.Append("<input type=text ID=IptEdit" + dr["name"] + "/>\r\n");
			}
			else
			{
				#region Name
				if (dr["name"].ToString().ToLower().Contains("status"))
				{
					row.Append("<asp:DropDownList runat=server ID=DdlEdit" + dr["name"] + ">\r\n");
					row.Append("   <asp:ListItem Text=\"未完成\" Value=\"0\" />\r\n");
					row.Append("   <asp:ListItem Text=\"已完成\" Value=\"1\" />\r\n");
					row.Append("   <asp:ListItem Text=\"已启用\" Value=\"2\" />\r\n");
					row.Append("</asp:DropDownList>\r\n");
				}
				else if (dr["name"].ToString().ToLower().Contains("type"))
				{
					row.Append("<asp:DropDownList runat=server ID=DdlEdit" + dr["name"] + ">\r\n");
					row.Append("    <asp:ListItem Text=\"请选择\" Value=\"\" />\r\n");
					row.Append("</asp:DropDownList>\r\n");
				}
				else if (dr["name"].ToString().ToLower().Contains("imgaddr"))
				{
					row.Append("<asp:Image runat=\"server\" Height=\"60\" Width=\"80\" ID=ImgEdit" + dr["name"].ToString().Replace("img", "") + " />\r\n");
					row.Append(" <asp:FileUpload runat=\"server\" ID=\"FileUploadImg\" Width=\"230\" />\r\n");
					row.Append(" <asp:Button runat=\"server\" CssClass=\"btn_auto\" ID=\"BtnUpload\" Text=\"上传\" OnClick=\"BtnUpload_Click\" />\r\n");
					row.Append(" <asp:HiddenField runat=\"server\" ID=\"HidImgAddr\" />\r\n");
					row.Append("\r\n");
				}
				else if (dr["name"].ToString().ToLower().Contains("id"))
				{
					row.Append("<asp:DropDownList runat=server ID=DdlEdit" + dr["name"] + "/>\r\n");
					row.Append("\r\n");
				}
				#endregion
				#region Type
				else if (dr["type"].ToString().ToLower().Contains("time") || dr["type"].ToString().ToLower().Contains("date"))
				{
					row.Append("<input runat=server ID=IptEdit" + dr["name"] + " onfocus=\"WdatePicker({lang:'zh-cn', dateFmt:'yyyy-MM-dd'})\" />\r\n");
				}
				#endregion
				else
				{
					if (dr["type"].ToString().ToLower().Contains("time") || dr["type"].ToString().ToLower().Contains("date"))
					{
						row.Append("<input runat=server ID=IptEdit" + dr["name"] + " onfocus=\"WdatePicker({lang:'zh-cn', dateFmt:'yyyy-MM-dd'})\" />\r\n");
					}
					else
					{
						row.Append("<asp:TextBox runat=server ID=TbEdit" + dr["name"] + "/>\r\n");
					}
				}
			}
			return row.ToString();
		}

		private string CreateTableTr_Html(DataRow dr)
		{
			StringBuilder tr = new StringBuilder();

			tr.Append("<tr>\r\n");
			tr.Append("<td>\r\n");
			tr.Append(_Language.GetValueByKey(dr["name"].ToString()) + "：\r\n");
			tr.Append("</td>\r\n");
			tr.Append("<td>\r\n");
			if (dr["type"].ToString().ToLower().Contains("time") || dr["type"].ToString().ToLower().Contains("date"))
			{
				tr.AppendFormat("<input  id=IptEdit{0} name={0}  type=\"text\" onfocus=\"WdatePicker({{lang:'zh-cn', dateFmt:'yyyy-MM-dd'}})\" />\r\n", dr["name"]);
			}
			else
			{
				tr.AppendFormat("<input id=IptEdit{0} name={0} type=\"text\" />\r\n", dr["name"]);
			}
			tr.Append("</td>\r\n");
			tr.Append("</tr>\r\n");

			return tr.ToString();
		}
		#endregion

		#region HTML
		public string HTMLCreateEditTable()
		{
			StringBuilder Aspx = new StringBuilder();
			Aspx.Append("\r\n<table style=\"width:90%;\">\r\n");

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
				{
					continue;
				}

				Aspx.Append(CreateTableTr_Html(_model.Table.Rows[i]));
			}
			Aspx.Append("\r\n");
			Aspx.Append("</table>\r\n");
			return Aspx.ToString();
		}

		#endregion
	}

	internal partial class UnitEdit
	{
		public string CSEditPageCommon(ConditionModel model)
		{
			StringBuilder cs = new StringBuilder();
			#region DoInit
			cs.Append("private void LoadData()\r\n");
			cs.Append("{\r\n");
			#region 一般参数初始化
			foreach (DataRow dr in _model.Table.Rows)
			{
				if (IsContinue(dr["name"].ToString()))
				{
					continue;
				}
				if (dr["name"].ToString().ToLower().Equals("imgaddr"))
				{
					cs.Append("ViewState[\"fileAddr\"] = \"~/resource/FUFiles/\";\r\n");
				}
				#region type
				if (dr["name"].ToString().ToLower().Contains("type"))
				{
					cs.Append(" #region  Init" + dr["name"].ToString() + "\r\n");
					cs.Append("// this.Ddl" + dr["name"] + ".DataSource = _" + _model.EntityName + "Mgr.Get" + dr["name"].ToString() + "DtAll().Data as DataTable;\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".DataTextField = \"" + dr["name"].ToString() + "Name\";\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".DataValueField = \"ID\";\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".DataBind();\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".Items.Insert(0, new ListItem(\"请选择\", \"\"));\r\n");
					cs.Append("#endregion \r\n");
				}
				else if (dr["name"].ToString().ToLower().Contains("type"))
				{
					cs.Append("Img" + dr["name"].ToString() + ".ImageUrl = \"../resource/FUFiles/ + dt.Rows[0][\"" + dr["name"].ToString() + "\"].ToString();\"\r\n");
					cs.Append("#endregion \r\n");
				}


				#endregion
				#region int
				else if (dr["name"].ToString().ToLower().Contains("id")
					&& !dr["name"].ToString().ToLower().Equals("status"))
				{
					cs.Append(" #region  Init" + dr["name"].ToString() + "\r\n");
					cs.Append("// this.Ddl" + dr["name"] + ".DataSource = _" + _model.EntityName + "Mgr.Get" + dr["name"].ToString() + "DtAll().Data as DataTable;\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".DataTextField = \"Name\";\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".DataValueField = \"ID\";\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".DataBind();\r\n");
					cs.Append(" this.Ddl" + dr["name"] + ".Items.Insert(0, new ListItem(\"请选择\", \"\"));\r\n");
					cs.Append("#endregion \r\n");
				}

				#endregion
			}

			#endregion
			cs.Append(" if( ViewState[\"id\"] == null ||  ViewState[\"id\"].ToString().Length == 0)\r\n");
			cs.Append("{\r\n");
			cs.Append("    return;\r\n");
			cs.Append("}\r\n");
			#region 先清空页面，然后赋值
			cs.Append("#region   初始化页面元素\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString().ToLower()))
				{
					continue;
				}

				if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("type")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Contains("status"))
				{
					cs.Append("DdlEdit" + _model.Table.Rows[i]["name"] + ".Items.Clear;\r\n");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("imgaddr"))
				{
					cs.Append("ImgAddr.ImageUrl = \"\";\r\n");
				}
				#region type
				else if (_model.Table.Rows[i]["type"].ToString().Contains("time"))
				{
					cs.Append("IptEdit" + _model.Table.Rows[i]["name"] + ".Value = \"\";\r\n");
				}
				#endregion
				else
					cs.Append("TbEdit" + _model.Table.Rows[i]["name"] + ".Text = \"\";\r\n");
			}
			cs.Append("\r\n");
			cs.Append("#endregion\r\n");

			#endregion
			#region 非DOL
			if (!model.IsDOL)
			{
				cs.Append("  DataTable dt = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "DtById( ViewState[\"id\"].ToString()).Data as DataTable;    \r\n");
				cs.Append("   if (dt != null && dt.Rows.Count > 0)\r\n");
				cs.Append("   {\r\n");
				cs.Append("#region   初始化页面元素\r\n");
				for (int i = 0; i < _model.Table.Rows.Count; i++)
				{
					if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adderid")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addername")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsaverid")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsavername")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsavetime"))
					{
						continue;
					}

					if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("type")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Contains("status"))
					{
						cs.Append("DdlEdit" + _model.Table.Rows[i]["name"] + ".SelectedValue = dt.Rows[0][\"" + _model.Table.Rows[i]["name"] + "\"].ToString();\r\n");
					}
					else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("imgaddr"))
					{
						cs.Append("ImgAddr.ImageUrl = ViewState[\"fileAddr\"] + dt.Rows[0][\"IMGADDR\"].ToString();\r\n");
					}
					#region type
					else if (_model.Table.Rows[i]["type"].ToString().Contains("time"))
					{
						cs.Append("IptEdit" + _model.Table.Rows[i]["name"] + ".Value = dt.Rows[0][\"" + _model.Table.Rows[i]["name"] + "\"].ToString().Length == 0 ?\"\": DateTime.Parse(dt.Rows[0][\"" + _model.Table.Rows[i]["name"] + "\"].ToString()).ToString(\"yyyy-MM-dd\");\r\n");
					}
					else if (_model.Table.Rows[i]["type"].ToString().Equals("int"))
					{
						cs.Append("TbEdit" + _model.Table.Rows[i]["name"] + ".Text =  _dol." + _model.Table.Rows[i]["name"] + ".ToString();\r\n");
					}
					#endregion
					else
						cs.Append("TbEdit" + _model.Table.Rows[i]["name"] + ".Text = dt.Rows[0][\"" + _model.Table.Rows[i]["name"] + "\"].ToString();\r\n");
				}
			}
			#endregion
			#region DOL
			else
			{
				cs.Append("   _dol = _" + _model.EntityName + "Mgr.Get" + _model.EntityName + "EntityById( ViewState[\"id\"].ToString()).Data as " + _model.EntityName + "Entity;    \r\n");
				cs.Append("   if (_dol != null)\r\n");
				cs.Append("   {\r\n");
				cs.Append("#region   初始化页面元素\r\n");
				for (int i = 0; i < _model.Table.Rows.Count; i++)
				{
					if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
					{
						continue;
					}

					if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("id")
						|| _model.Table.Rows[i]["name"].ToString().ToLower().Contains("status"))
					{
						cs.Append("Ddl" + _model.Table.Rows[i]["name"] + ".SelectedIndex = DdlEdit"
							+ _model.Table.Rows[i]["name"] + ".Items.IndexOf(Ddl"
							+ _model.Table.Rows[i]["name"] + ".Items.FindByValue(_dol." + _model.Table.Rows[i]["name"] + ".ToString()));\r\n");
					}
					else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("imgaddr"))
					{
						cs.Append("ImgAddr.ImageUrl = ViewState[\"fileAddr\"] + _dol." + _model.Table.Rows[i]["name"] + ";\r\n");
					}
					#region type
					else if (_model.Table.Rows[i]["type"].ToString().Contains("time") || _model.Table.Rows[i]["type"].ToString().Contains("date"))
					{
						cs.Append("IptEdit" + _model.Table.Rows[i]["name"] + ".Value =  _dol." + _model.Table.Rows[i]["name"] + ".ToString(\"yyyy-MM-dd\");\r\n");
					}
					else if (_model.Table.Rows[i]["type"].ToString().Equals("int"))
					{
						cs.Append("TbEdit" + _model.Table.Rows[i]["name"] + ".Text =  _dol." + _model.Table.Rows[i]["name"] + ".ToString();\r\n");
					}
					#endregion
					else
						cs.Append("TbEdit" + _model.Table.Rows[i]["name"] + ".Text =  _dol." + _model.Table.Rows[i]["name"] + ";\r\n");
				}
			}
			#endregion
			cs.Append("#endregion\r\n");
			cs.Append("\r\n");
			cs.Append("   }\r\n");
			cs.Append("}\r\n");
			#endregion
			#region Save
			cs.Append("private bool Save" + _model.EntityName + "()\r\n");
			cs.Append("{\r\n");
			cs.Append("");
			cs.Append("        if(!ValidateFields())\r\n");
			cs.Append("        {return false;}\r\n");
			cs.Append("         Result res;\r\n");
			if (model.IsDOL)
			{
				cs.Append(DolSaveContent());
			}
			else
				cs.Append(SaveContent());
			cs.Append("if(res.Status >= 0 )\r\n");
			cs.Append("{\r\n");
			cs.Append("   ViewState[\"id\"] = res.Data;\r\n");
			cs.Append(ShowMsg(model.MsgType, "保存成功"));
			cs.Append("   DoInit();\r\n");
			cs.Append("   return true;\r\n");
			cs.Append("}\r\n");
			cs.Append(" else if(res.Status == -2 )\r\n");
			cs.Append("{\r\n");
			cs.Append(ShowMsg(model.MsgType, "记录可能存在重复"));
			cs.Append("   return false;\r\n");
			cs.Append("}\r\n");
			cs.Append("else\r\n");
			cs.Append("{\r\n");
			cs.Append(ShowMsg(model.MsgType, "保存失败"));
			cs.Append("     return false;\r\n     ");
			cs.Append("}\r\n");
			cs.Append("}\r\n\r\n");

			#endregion
			if (model.IsDOL)
			{
				cs.Append(InitDol());
			}
			#region ValidateEntity
			cs.Append("private bool ValidateFields()\r\n");
			cs.Append("{\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (IsContinue(_model.Table.Rows[i]["name"].ToString()))
				{
					continue;
				}

				if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("type")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Contains("status")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Contains("id"))
				{
					cs.Append("if (this.DdlEdit" + _model.Table.Rows[i]["name"].ToString() + ".SelectedValue.Length == 0)\r\n");
					cs.Append("{\r\n");
					cs.Append(ShowMsg(model.MsgType, "请选择" + _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString())));
					cs.Append("         return false;\r\n");
					cs.Append(" }\r\n");
				}
				#region Type
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Contains("time")
					|| _model.Table.Rows[i]["type"].ToString().ToLower().Contains("date"))
				{
					cs.Append("if (this.IptEdit" + _model.Table.Rows[i]["name"].ToString() + ".Value.Length == 0)\r\n");
					cs.Append("{\r\n");
					cs.Append("     this.IptEdit" + _model.Table.Rows[i]["name"].ToString() + ".Focus();\r\n");
					cs.Append(ShowMsg(model.MsgType, _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "不能为空"));
					cs.Append("         return false;\r\n");
					cs.Append(" }\r\n");
				}
				#endregion
				else
				{
					cs.Append("if (this.TbEdit" + _model.Table.Rows[i]["name"].ToString() + ".Text.Length == 0)\r\n");
					cs.Append("  {\r\n");
					cs.Append("     this.TbEdit" + _model.Table.Rows[i]["name"].ToString() + ".Focus();\r\n");
					cs.Append(ShowMsg(model.MsgType, _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "不能为空"));
					cs.Append("         return false;\r\n");
					cs.Append("}\r\n");
					cs.Append("if (this.TbEdit" + _model.Table.Rows[i]["name"].ToString() + ".Text.Length > " + _model.Table.Rows[i]["length"].ToString() + ")\r\n");
					cs.Append("  {\r\n");
					cs.Append("     this.TbEdit" + _model.Table.Rows[i]["name"].ToString() + ".Focus();\r\n");
					cs.Append(ShowMsg(model.MsgType, _Language.GetValueByKey(_model.Table.Rows[i]["name"].ToString()) + "不能超过" + _model.Table.Rows[i]["length"].ToString() + "字符"));
					cs.Append("         return false;\r\n");
					cs.Append("}\r\n");
				}
			}

			cs.Append("     \r\n");
			cs.Append("\r\n");
			if (model.IsDOL)
			{
				cs.Append(" if(!InitDol())\r\n");
				cs.Append("  { ");
				if (model.MsgType == Page.eShowMsg.LblErr)
				{
					cs.Append("       this.LblMsg.Text = \"页面元素不合法\";\r\n");
				}
				else
				{
					cs.Append("        Command.ShowError(\"页面元素不合法\");\r\n");
				}
				cs.Append("       return false;\r\n");
				cs.Append(" }\r\n\r\n");
			}
			cs.Append("     return true;\r\n");
			cs.Append("}\r\n");

			#endregion
			cs.Append(CSEditPageByType());
			return cs.ToString();
		}

		public string CSEditPageByType()
		{
			StringBuilder cs = new StringBuilder();
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("imgaddr"))
				{
					cs.Append(" protected void BtnUpload_Click(object sender, EventArgs e)\r\n");
					cs.Append("{\r\n");
					cs.Append("  if (this.FileUploadImg.FileName.Length == 0)\r\n");
					cs.Append("  {\r\n");
					cs.Append("     return;\r\n");
					cs.Append("  }\r\n");
					cs.Append("   this.FileUploadImg.SaveAs(MapPath(ViewState[\"fileAddr\"] + this.FileUploadImg.FileName));\r\n");
					cs.Append("   ImgAddr.ImageUrl = ViewState[\"fileAddr\"] + this.FileUploadImg.FileName;\r\n");
					cs.Append("   this.HidImgAddr.Value = this.FileUploadImg.FileName;\r\n");
					cs.Append("\r\n");
					cs.Append("}\r\n");
				}
			}
			return cs.ToString();
		}

		public string CSEditPageRepeater()
		{
			StringBuilder btnCs = new StringBuilder();
			btnCs.Append("private void LoadData()\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append("}\r\n\r\n");
			btnCs.Append("private bool Save" + _model.EntityName + "()\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append("//if(res.Status >= 0 )\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append("  // ViewState[\"id\"] = res.Data;\r\n");
			btnCs.Append("   this.LblMsg.Text = \"保存成功\";\r\n");
			btnCs.Append("   DoInit();\r\n");
			btnCs.Append("   return true;\r\n");
			btnCs.Append("}\r\n");
			btnCs.Append("//else\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append("     this.LblMsg.Text = \"保存失败\";\r\n");
			btnCs.Append("     return false;\r\n     ");
			btnCs.Append("}\r\n");
			btnCs.Append("}\r\n\r\n");
			return btnCs.ToString();
		}

		public string CSEditPage_Repeater()
		{
			StringBuilder btnCs = new StringBuilder();
			btnCs.Append("  #region Save\r\n");
			btnCs.Append("private bool Save" + _model.EntityName + "()\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append("    //if (Save())\r\n");
			btnCs.Append("    {\r\n");
			btnCs.Append("        foreach (RepeaterItem item in RptList.Items)\r\n");
			btnCs.Append("        {\r\n");
			btnCs.Append("");
			btnCs.Append("");
			btnCs.Append("      }\r\n");
			btnCs.Append("        foreach (RepeaterItem item in RptList.Controls)\r\n");
			btnCs.Append("        {\r\n");
			btnCs.Append("            if (item.ItemType == ListItemType.Header)\r\n");
			btnCs.Append("              {\r\n");
			btnCs.Append("              }\r\n");
			btnCs.Append("      }\r\n");
			btnCs.Append("}\r\n");
			btnCs.Append("}\r\n");
			btnCs.Append("  #endregion Save\r\n\r\n");
			return btnCs.ToString();

		}

		public string CS_Del(ConditionModel model)
		{
			StringBuilder btnCs = new StringBuilder();
			btnCs.Append("private void Del" + _model.EntityName + "ById(string Id)\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append("  Result res = _" + _model.EntityName + "Mgr.Del" + _model.EntityName + "ById(Id);\r\n");
			btnCs.Append("    if (res.Status >= 0)\r\n");
			btnCs.Append("    {\r\n");

			btnCs.Append(ShowMsg(model.MsgType, "删除成功"));
			btnCs.Append("    }\r\n");
			btnCs.Append("    else if (res.Status == -2)\r\n");
			btnCs.Append("     {\r\n");
			btnCs.Append(ShowMsg(model.MsgType, "正在使用，不能删除"));
			btnCs.Append("     }\r\n");
			btnCs.Append("   else\r\n");
			btnCs.Append("{\r\n");
			btnCs.Append(ShowMsg(model.MsgType, "删除失败"));
			btnCs.Append("}\r\n");
			btnCs.Append("}\r\n");
			return btnCs.ToString();
		}

		#region SaveContent
		private string SaveContent()
		{
			StringBuilder save = new StringBuilder();
			save.Append("       if (ViewState[\"id\"] == null || string.IsNullOrEmpty(ViewState[\"id\"].ToString())) \r\n");
			save.Append("        {\r\n");
			#region Insert
			save.Append("             _" + _model.EntityName + "Mgr.Insert" + _model.EntityName + "(" + CreateParams() + ");\r\n");
			save.Append("         }\r\n");
			#endregion
			save.Append("else\r\n");
			save.Append("{");
			#region Update
			save.Append("             _" + _model.EntityName + "Mgr.Update" + _model.EntityName + "(");
			save.Append("ViewState[\"id\"].ToString(), " + CreateParams() + " );\r\n");
			#endregion
			save.Append("}\r\n");
			return save.ToString();
		}
		private string DolSaveContent()
		{
			StringBuilder save = new StringBuilder();
			save.Append("       if (ViewState[\"id\"] == null || string.IsNullOrEmpty(ViewState[\"id\"].ToString())) \r\n");
			save.Append("        {\r\n");
			#region Insert
			save.Append("             _" + _model.EntityName + "Mgr.Insert" + _model.EntityName + "(_dol);\r\n");
			save.Append("         }\r\n");
			#endregion
			save.Append("else\r\n");
			save.Append("{");
			#region Update
			save.Append("             _" + _model.EntityName + "Mgr.Update" + _model.EntityName + "(_dol);\r\n");
			#endregion
			save.Append("}\r\n");
			return save.ToString();
		}
		private string InitDol()
		{
			StringBuilder edit = new StringBuilder();
			#region InitDol
			edit.Append(" /// <summary>\r\n");
			edit.Append(" /// 初始化Dol\r\n");
			edit.Append(" /// </summary>\r\n");
			edit.Append("private bool InitDol()\r\n");
			edit.Append("{\r\n");
			edit.Append("   _dol = new " + _model.EntityName + "Entity();\r\n");
			edit.Append("   try\r\n");
			edit.Append("   {\r\n");
			edit.Append("      if(!string.IsNullOrEmpty(ViewState[\"id\"].ToString()))\r\n");
			edit.Append("        _dol.ID = Convert.ToInt32(ViewState[\"id\"].ToString());\r\n");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsavetime"))
					continue;

				if (_model.Table.Rows[i]["name"].ToString().Contains("IP"))
				{
					edit.Append(" _dol." + _model.Table.Rows[i]["name"].ToString() + " = Request.UserHostAddress;\r\n ");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder") ||
					  _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adderid") ||
					  _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsaver") ||
					  _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsaverid"))
				{
					edit.Append("    _dol." + _model.Table.Rows[i]["name"].ToString() + " = Convert.ToInt32( Session[\"staffid\"].ToString());\r\n");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("addname") ||
					_model.Table.Rows[i]["name"].ToString().ToLower().Equals("addername") ||
					_model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsavername"))
				{
					edit.Append("    _dol." + _model.Table.Rows[i]["name"].ToString() + " = Session[\"staffname\"].ToString();\r\n");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("id"))
				{
					edit.Append(" _dol." + _model.Table.Rows[i]["name"].ToString() + " = Convert.ToInt32(this.DdlEdit" + _model.Table.Rows[i]["name"].ToString() + ".SelectedValue.Length == 0? \"0\":this.Ddl" + _model.Table.Rows[i]["name"].ToString() + ".SelectedValue);\r\n ");
				}
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("int"))
				{
					edit.Append("    _dol." + _model.Table.Rows[i]["name"].ToString() + " =  Convert.ToInt32(this.TbEdit" + _model.Table.Rows[i]["name"].ToString() + ".Text.Length == 0? \"0\" : this.Tb" + _model.Table.Rows[i]["name"].ToString() + ".Text );\r\n");
				}
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Equals("datetime") ||
					   _model.Table.Rows[i]["type"].ToString().ToLower().Equals("date"))
				{
					edit.Append("if(!string.IsNullOrEmpty(this.IptEdit" + _model.Table.Rows[i]["name"].ToString() + ".Value))\r\n");
					edit.Append("{\r\n");
					edit.Append("    _dol." + _model.Table.Rows[i]["name"].ToString() + " = DateTime.Parse(this.IptEdit" + _model.Table.Rows[i]["name"].ToString() + ".Value);\r\n");
					edit.Append("}\r\n");
				}
				else
					edit.Append(" _dol." + _model.Table.Rows[i]["name"].ToString() + " = this.TbEdit" + _model.Table.Rows[i]["name"].ToString() + ".Text.Trim();\r\n ");
			}
			edit.Append("   return true;\r\n");
			edit.Append(" }\r\n");
			edit.Append(" catch (Exception e)\r\n");
			edit.Append("{\r\n");
			edit.Append("   return false;\r\n");
			edit.Append(" }\r\n");
			edit.Append("}\r\n\r\n");
			#endregion

			return edit.ToString();
		}

		private string CreateParams()
		{
			StringBuilder save = new StringBuilder();

			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime"))
					continue;

				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("adderid")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
				{
					save.Append("Session[\"staffid\"] == null ? \"\" : Session[\"staffid\"].ToString(),");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("addername")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("lastsavername"))
				{
					save.Append("Session[\"staffname\"] == null ? \"\" : Session[\"staffname\"].ToString(),");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("imgaddr"))
				{
					save.Append("this.Hid" + _model.Table.Rows[i]["name"].ToString() + ".Value,");
				}
				else if (_model.Table.Rows[i]["name"].ToString().ToLower().Contains("type")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Contains("status"))
				{
					save.Append("DdlEdit" + _model.Table.Rows[i]["name"] + ".SelectedValue, ");
				}
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Contains("time"))
				{
					save.Append("IptEdit" + _model.Table.Rows[i]["name"] + ".Value, ");
				}
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Contains("int"))
				{
					save.Append("DdlEdit" + _model.Table.Rows[i]["name"] + ".SelectedValue, ");
				}
				else
				{
					save.Append("Command.Encode(TbEdit" + _model.Table.Rows[i]["name"] + ".Text), ");
				}
			}
			save.Remove(save.Length - 2, 2);
			return save.ToString();
		}
		#endregion
	}
}

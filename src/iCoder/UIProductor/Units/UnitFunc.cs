using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Units
{
	internal partial class UnitFunc : BaseUnit
	{
		public UnitFunc(ConditionModel model)
			: base(model)
		{

		}

		public string AspxCreateQueryBtn()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<asp:Button runat=server id=BtnQuery CssClass=btn_auto Text=查询 OnClick=BtnQuery_Click ");
			btn.Append("/>\r\n");
			return btn.ToString();
		}

		public string AspxCreateExportBtn()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<asp:Button runat=server id=BtnExport CssClass=btn_auto Text=导出 OnClick=BtnExport_Click ");
			btn.Append("/>\r\n");
			return btn.ToString();
		}

		public string AspxCreateAdd(string btnText = null)
		{
			StringBuilder btn = new StringBuilder();
			if (btnText == null)
			{
				btnText = "新增";
			}
			//btn.Append("<asp:Button runat=server id=BtnAdd  CssClass=btn_auto Text=" + btnText + " OnClick=BtnAdd_Click />");
			//btn.Append("\r\n");
			btn.Append("<input id=IptAdd  CssClass=btn_auto >" + btnText + "</input>");
			btn.Append("\r\n");
			return btn.ToString();
		}
		public string AspxCreateDel()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<asp:Button runat=server id=BtnDel Text=删除  OnClientClick='javascript:return confirm(\"您确定要删除吗?\")'  CssClass=btn_auto OnClick=BtnDel_Click />");
			btn.Append("\r\n");

			return btn.ToString();
		}
		public string AspxCreateModify()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<asp:Button runat=server id=BtnModify Text=修改  CssClass=btn_auto OnClick=BtnModify_Click />");
			btn.Append("\r\n");

			return btn.ToString();
		}

		public string AspxCreateSave()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<asp:Button runat=server id=BtnSave Text=保存  CssClass=btn_auto OnClick=BtnSave_Click ");
			btn.Append("/>\r\n");

			return btn.ToString();
		}
		public string HTMLCreateSave()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<input type=button id=BtnSave value=保存  class=btn_auto ");
			btn.Append("/>\r\n");

			return btn.ToString();
		}

		public string HTMLCreateBack()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("<input type=button id=BtnBack value=返回  class=btn_auto onclick=\"window.location.href='" + _model.EntityName.Trim() + "List.aspx'\"");
			btn.Append("/>\r\n");

			return btn.ToString();
		}


	}

	internal partial class UnitFunc
	{
		public string CSCreateQueryBtn()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected void BtnQuery_Click(object sender, EventArgs e)\r\n");
			cs.Append("{\r\n");
			cs.Append("      LoadData();\r\n");
			cs.Append(ShowMsg(_model.MsgType, "查询成功"));
			cs.Append("}\r\n");

			return cs.ToString();
		}


		public string CSCreateExportBtn()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected void BtnExport_Click(object sender, EventArgs e)\r\n");
			cs.Append("{\r\n");
			cs.Append("      ExportData();\r\n");
			cs.Append(ShowMsg(_model.MsgType, "导出成功"));
			cs.Append("}\r\n");

			cs.Append("protected void ExportData()\r\n");
			cs.Append("{\r\n");
			cs.Append("		//DataTable dt = _Mgr.GetDtByConditions(GetConditions());	\r\n");
			cs.Append("		//HelperCommand.ExportExcel((dt, \"\");\r\n");
			cs.Append("}\r\n");
			return cs.ToString();
		}

		public string CSCreateAddList()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected void BtnAdd_Click(object sender, EventArgs e)\r\n");
			cs.Append("{\r\n");
			cs.Append(AddListBox() + "    \r\n");
			cs.Append("}\r\n");

			return cs.ToString();
		}

		public string CSCreateAddCommon()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected void BtnAdd_Click(object sender, EventArgs e)\r\n");
			cs.Append("{\r\n");
			cs.Append(AddCommonInsert() + "    \r\n");
			cs.Append("}\r\n");

			return cs.ToString();
		}

		public string CSCreateModify()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected void BtnModify_Click(object sender, EventArgs e)\r\n");
			cs.Append("{\r\n");
			cs.Append(Update());
			cs.Append("   \r\n");
			cs.Append("}\r\n");

			return cs.ToString();
		}

		public string CSCreateDel()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("protected void BtnDel_Click(object sender, EventArgs e)\r\n");
			cs.Append("{\r\n");
			cs.Append(Del());
			cs.Append("   \r\n");
			cs.Append("}\r\n");

			return cs.ToString();
		}

		public string CSCreateSave()
		{
			StringBuilder btn = new StringBuilder();
			btn.Append("   protected void BtnSave_Click(object sender, EventArgs e)\r\n");
			btn.Append("  {\r\n");
			btn.Append("     Save" + _model.EntityName + "();\r\n");
			//            ViewState["id"] = "";
			btn.Append("  }\r\n");

			return btn.ToString();
		}

		#region Methods
		private string AddCommonInsert()
		{
			StringBuilder add = new StringBuilder();
			add.Append("     Result res = _" + _model.EntityName + "Mgr.Insert" + _model.EntityName + "(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
					continue;

				#region Type
				else if (_model.Table.Rows[i]["type"].ToString().ToLower().Contains("int"))
				{
					add.Append("Ddl" + _model.Table.Rows[i]["name"] + ".SelectedValue, ");
				}
				#endregion
				else
					add.Append("Ipt" + _model.Table.Rows[i]["name"] + ".Value, ");
			}
			add.Remove(add.Length - 2, 2); ;
			add.Append("); \r\n\r\n");
			add.Append("      if (res.Status == 0)\r\n");
			add.Append("      {\r\n");
			add.Append(ShowMsg(_model.MsgType, "新增成功"));
			add.Append("        ViewState[\"id\"] = res.Data.ToString();\r\n");
			add.Append("     }\r\n");
			add.Append("    else\r\n");
			add.Append("{\r\n");
			add.Append(ShowMsg(_model.MsgType, "新增出错"));
			add.Append("}\r\n");
			add.Append("\r\n");

			return add.ToString();
		}
		private string AddListBox()
		{
			StringBuilder add = new StringBuilder();
			add.Append("     Result res = _" + _model.EntityName + "Mgr.Insert" + _model.EntityName + "(");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{

				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					continue;
				}
				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
				{
					add.Append("Session[\"UserId\"].ToString(), ");

					continue;
				}
				add.Append("Tb" + _model.Table.Rows[i]["name"] + ".Text, ");
			}
			add.Remove(add.Length - 2, 2);
			add.Append(");\r\n");
			add.Append("      if (res.Status == 0)\r\n");
			add.Append("      {\r\n");
			add.Append(ShowMsg(_model.MsgType, "新增成功"));
			add.Append("        ViewState[\"id\"] = res.Data.ToString();\r\n");
			add.Append("     InitListBox();\r\n");
			add.Append("     this.LbSource.SelectedValue = res.Data.ToString();\r\n");
			add.Append("     }\r\n");
			add.Append("    else  if (res.Status == -2)\r\n");
			add.Append("{\r\n");
			add.Append(ShowMsg(_model.MsgType, "名称重复"));
			add.Append("}\r\n");
			add.Append("    else\r\n");
			add.Append("{\r\n");
			add.Append(ShowMsg(_model.MsgType, "新增出错"));
			add.Append("}\r\n");
			add.Append("\r\n");

			return add.ToString();
		}

		private string Update()
		{
			StringBuilder update = new StringBuilder();
			//update.Append("  if (this.TbName.Text.Length == 0)\r\n");
			//update.Append("{\r\n");
			//update.Append("  LblMsg.Text = \"名称不能为空\";\r\n");
			//update.Append("  return;\r\n");
			//update.Append("}\r\n");
			//update.Append("  if (this.LbSource.SelectedValue.Length == 0)\r\n");
			//update.Append("{\r\n");
			//update.Append("  LblMsg.Text = \"选择要修改的记录\";\r\n");
			//update.Append("  return;\r\n");
			//update.Append("}\r\n");
			//update.Append("  int count = _" +  _model.EntityName + "Mgr.Judge" +  _model.EntityName + "Repeater(ViewState[\"id\"].ToString(), this.TbName.Text); \r\n");
			//update.Append("  if (count > 0)\r\n");
			//update.Append("  {\r\n");
			//update.Append("      LblMsg.Text = \"名称不能重复\";\r\n");
			//update.Append("       return;\r\n");
			//update.Append("  }\r\n");
			update.Append("     Result res = _" + _model.EntityName + "Mgr.Update" + _model.EntityName + "(ViewState[\"id\"].ToString(),");
			for (int i = 0; i < _model.Table.Rows.Count; i++)
			{

				if (_model.Table.Rows[i]["name"].ToString().ToLower().Equals("id")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("addtime")
					|| _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					continue;
				}
				//if ( _model.Table.Rows[i]["name"].ToString().ToLower().Equals("adder"))
				//{
				//    update.Append("Session[\"UserId\"].ToString(), ");

				//    continue;
				//}
				update.Append("Tb" + _model.Table.Rows[i]["name"] + ".Text, ");
			}
			update.Remove(update.Length - 2, 2);
			update.Append(");\r\n");
			update.Append("      if (res.Status == 0)\r\n");
			update.Append("      {\r\n");
			update.Append(ShowMsg(_model.MsgType, "修改成功"));
			update.Append("        ViewState[\"id\"] = res.Data.ToString();\r\n");
			update.Append("        InitListBox();\r\n");
			update.Append("        this.LbSource.SelectedValue = res.Data.ToString();\r\n");
			update.Append("     }\r\n");
			update.Append("    else  if (res.Status == -2)\r\n");
			update.Append("{\r\n");
			update.Append(ShowMsg(_model.MsgType, "名称重复"));
			update.Append("}\r\n");
			update.Append("    else\r\n");
			update.Append("{\r\n");
			update.Append(ShowMsg(_model.MsgType, "修改出错"));
			update.Append("}\r\n");
			update.Append("\r\n");
			update.Append("\r\n");
			update.Append("\r\n");

			return update.ToString();
		}

		private string Del()
		{
			StringBuilder del = new StringBuilder();
			del.Append("  if (this.LbSource.SelectedValue.Length == 0)\r\n");
			del.Append("  {\r\n");
			del.Append(ShowMsg(_model.MsgType, "请选择要删除的记录"));
			del.Append("    return;\r\n");
			del.Append("  }\r\n");
			del.Append("  if (this.LbSource.SelectedValue.Length > 0)\r\n");
			del.Append("  {\r\n");
			del.Append("     Result res = _" + _model.EntityName + "Mgr.Del" + _model.EntityName + "ById(this.LbSource.SelectedValue);\r\n");
			del.Append("     if (res.Status == 0)\r\n");
			del.Append("     {\r\n");
			del.Append(ShowMsg(_model.MsgType, "删除成功"));
			del.Append("      //  this.TbName.Text = \"\"; \r\n");
			del.Append("        InitListBox();\r\n");
			del.Append("     }\r\n");
			del.Append("     else if (res.Status == 1)\r\n");
			del.Append("     {\r\n");
			del.Append(ShowMsg(_model.MsgType, "正在使用，不能删除"));
			del.Append("     }\r\n");
			del.Append("      else\r\n");
			del.Append("     {\r\n");
			del.Append(ShowMsg(_model.MsgType, "删除出错"));
			del.Append("     }\r\n");
			del.Append("     \r\n");
			del.Append("  }\r\n");

			return del.ToString();
		}
		#endregion
	}
}

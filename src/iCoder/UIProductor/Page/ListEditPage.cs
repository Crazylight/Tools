using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Page
{
	internal partial class ListEditPage : BasePage
	{
		static ListEditPage _instance;
		public static ListEditPage getInstance(ConditionModel model)
		{
			// if (_instance == null)
			{
				_instance = new ListEditPage(model);
			}

			return _instance;
		}

		public ListEditPage(ConditionModel model)
			: base(model)
		{
		}



		/// <summary>
		/// 1, repeater
		/// </summary>
		/// <returns></returns>
		internal string CreateRepeaterHtml()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.EntityName + "List.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "List\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
			page.Append(CreatePageHead(ePageType.ViewEditPageRepeater));
			page.Append("<body>\r\n");
			page.Append(" <form id=\"form1\" runat=\"server\">\r\n");
			page.Append("<div class=\"div_main\">\r\n");
			page.Append( CreateMsgHTML());
			page.Append(_unitQuery.GetConditionsDiv_DlP());
			page.Append("<div>\r\n");
			page.Append(_unitFunc.AspxCreateQueryBtn());
			page.Append("<div>\r\n");
			page.Append("<div class=tar>");
			page.Append("<input type=button runat=server  class=btn_auto id=IptAdd value=新增 onclick=Add()/>\r\n");
			page.Append(_unitFunc.AspxCreateAdd("保存"));
			page.Append(_unitEdit.AspxCreateEdit(UIProductor.Page.ePageType.ViewEditPageRepeater));
			page.Append("\r\n");
			page.Append("\r\n");
			page.Append("</div>\r\n");
			page.Append("</div>\r\n");
			page.Append(_unitListEdit.ListEditUI_Repeater());
			page.Append("</div>\r\n");
			page.Append(" </form>\r\n");
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}


		/// <summary>
		/// 1, repeater
		/// </summary>
		/// <returns></returns>
		internal string CreateHtml_API()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.EntityName + "List.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "List\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
			page.Append(CreatePageHead(ePageType.ViewEditPageRepeater));
			page.Append("<body>\r\n");
			page.Append(" <form id=\"form1\" runat=\"server\">\r\n");
			page.Append("<div class=\"div_main\">\r\n");
			page.Append(CreateMsgHTML());
			page.Append(_unitQuery.GetConditionsDiv_DlP());
			page.Append("\t<div>\r\n");
			page.Append(_unitFunc.AspxCreateQueryBtn());
			page.Append("\t</div>\r\n");
			page.Append("\t<div class=tal>");
			page.Append("\r\n");
			page.Append("<input type=button  class=btn_auto id=IptAdd value=新增 onclick=Add()/>\r\n");
			page.Append(_unitEdit.AspxCreateEdit(UIProductor.Page.ePageType.ApiViewEditPage));
			page.Append("\r\n");
			page.Append("\t</div>\r\n");
			page.Append(_unitList.ListUI_Api());
			page.Append("</div>\r\n");
			page.Append(_unitScript.Create(ePageType.ApiViewEditPage));
			page.Append(" </form>\r\n");
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}


		/// <summary>
		/// 2, listbox
		/// </summary>
		/// <returns></returns>
		public string CreateListBoxHtml()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.NameSpace + _model.EntityName + "Edit.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "Edit\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");

			page.Append(CreatePageHead(ePageType.EditPage));
			page.Append("<body>\r\n");
			page.Append(" <form id=\"form1\" runat=\"server\">\r\n");
			page.Append("<div>\r\n");
			page.Append("<div class=div_bg>\r\n");
			page.Append(" <asp:Label runat=server ID=LblMsg ForeColor=Red />\r\n");
			page.Append("</div>\r\n");
			page.Append("\r\n<div>\r\n");
			page.Append(_unitListEdit.HtmlEditPageListBox());
			page.Append("<div class=div_bg>\r\n");
			page.Append(_unitFunc.AspxCreateAdd());
			page.Append(_unitFunc.AspxCreateModify());
			page.Append(_unitFunc.AspxCreateDel());
			page.Append("</div>\r\n");
			page.Append("\r\n</div>\r\n");
			page.Append("\r\n</div>\r\n");
			page.Append(" </form>\r\n");
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}

	}

	internal partial class ListEditPage
	{

		internal string CreateRepeaterCS(ConditionModel model)
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("using System;\r\n");
			if (_model.NameSpace.ToLower().Contains("web."))
			{
				cs.Append("using Command = " + _model.NameSpace.Substring(_model.NameSpace.ToLower().IndexOf("web.")) + ".Commands.HelperCommand;");
			}
			else
				cs.Append("using Command = " + _model.NameSpace + ".Commands.HelperCommand;");
			cs.Append("");
			cs.Append("\r\n\r\n");
			cs.Append(" namespace " + _model.NameSpace + "\r\n");
			cs.Append("{\r\n");
			cs.Append(" public partial class " + _model.EntityName + "List : System.Web.UI.Page\r\n");
			cs.Append("{\r\n");
			cs.Append(" #region Fields\r\n");
			cs.Append(" private " + _model.EntityName + "BLL _" + _model.EntityName + "Mgr = new " + _model.EntityName + "BLL();\r\n");
			cs.Append(" int EditIndex = -1;\r\n");
			cs.Append(" #endregion \r\n");
			cs.Append("  protected void Page_Load(object sender, EventArgs e)\r\n");
			cs.Append("  {\r\n");
			cs.Append("       if(!IsPostBack)\r\n");
			cs.Append("       {\r\n");
			cs.Append("            LoadData();\r\n");
			cs.Append("       }\r\n");
			cs.Append("  }\r\n");
			cs.Append(_unitFunc.CSCreateQueryBtn());
			cs.Append("\r\n");
			cs.Append(_unitFunc.CSCreateAddCommon());
			cs.Append("\r\n");
			cs.Append(_unitListEdit.ListEditCS_Repeater());
			cs.Append(_unitEdit.CS_Del(model));
			cs.Append(" #region  Private Methods \r\n");
			cs.Append(" private void DoInit()\r\n");
			cs.Append(" {\r\n");
			cs.Append(" }\r\n\r\n");
			cs.Append(" #endregion \r\n");
			cs.Append("}\r\n");
			cs.Append("}\r\n");
			return cs.ToString();
		}


		internal string CSCreateListBox()
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("using System;\r\n");
			cs.Append("");
			cs.Append("");
			cs.Append("\r\n\r\n");
			cs.Append(" namespace " + _model.NameSpace + "\r\n");
			cs.Append("{\r\n");
			cs.Append(" public partial class " + _model.EntityName + "List : System.Web.UI.Page\r\n");
			cs.Append("{\r\n");
			cs.Append(" #region Fields\r\n");
			cs.Append(" private " + _model.EntityName + "BLL _" + _model.EntityName + "Mgr = new " + _model.EntityName + "BLL();\r\n");
			cs.Append(" #endregion \r\n");
			cs.Append("  protected void Page_Load(object sender, EventArgs e)\r\n");
			cs.Append("  {\r\n");
			cs.Append("       if(!IsPostBack)\r\n");
			cs.Append("       {\r\n");
			cs.Append("            DoInit();\r\n");
			cs.Append("       }\r\n");
			cs.Append("  }\r\n");
			cs.Append(_unitListEdit.CSEditPage_ListBox());
			cs.Append(_unitFunc.CSCreateAddList());
			cs.Append(_unitFunc.CSCreateModify());
			cs.Append(_unitFunc.CSCreateDel());

			cs.Append(" #region  Private Methods \r\n");
			cs.Append(" private void DoInit()\r\n");
			cs.Append(" {\r\n");
			cs.Append(" }\r\n\r\n");
			cs.Append(" #endregion \r\n");
			cs.Append("}\r\n");
			cs.Append("}\r\n");
			return cs.ToString();
		}

	}
}

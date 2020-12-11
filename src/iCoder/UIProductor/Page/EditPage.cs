using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Page
{
	internal partial class EditPage : BasePage
	{
		static EditPage _instance;
		public static EditPage getInstance(ConditionModel model)
		{
			//if (_instance == null)
			{
				_instance = new EditPage(model);
			}

			return _instance;
		}

		public EditPage(ConditionModel model)
			: base(model)
		{
		}


		/// <summary>
		/// 2, EasyType
		/// </summary>
		/// <returns></returns>
		public string CreateEditPageAspx()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.NameSpace + _model.EntityName + "Edit.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "Edit\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");

			page.Append(CreatePageHead(ePageType.EditPage));
			page.Append("<body>\r\n");
			page.Append(" <form id=\"form1\" runat=\"server\">\r\n");
			page.Append("<div>\r\n");
			page.Append(CreateMsg_Aspx());
			page.Append(_unitFunc.AspxCreateSave());
			page.Append(_unitFunc.HTMLCreateBack());
			page.Append(_unitEdit.AspxCreateEdit(UIProductor.Page.ePageType.EditPage));
			page.Append("\r\n</div>\r\n");
			page.Append(" </form>\r\n");
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}

		/// <summary>
		/// 2, EasyType
		/// </summary>
		/// <returns></returns>
		public string CreateEditPageHtml()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.NameSpace + _model.EntityName + "Edit.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "Edit\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");

			page.Append(CreatePageHead(ePageType.ApiEditPage));
			page.Append("<body>\r\n");
			page.Append("<div>\r\n");
			page.Append(CreateMsgHTML());
			page.Append(_unitFunc.HTMLCreateSave());
			page.Append(_unitFunc.HTMLCreateBack());
			page.Append(" <form id=\"form1\" runat=\"server\"  action=\"api_" + _model.EntityName + ".ashx\" method=\"post\">\r\n");
			page.Append(_unitEdit.HTMLCreateEditTable());
			page.Append(" </form>\r\n");
			page.Append("\r\n</div>\r\n");
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}

		/********************************创建各种类型的前台元素****************************************************/

	}

	internal partial class EditPage
	{

		/// <summary>
		/// 1, EasyType
		/// </summary>
		/// <returns></returns>
		public string CreateEditPageCs(ConditionModel model)
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("using System;\r\n");
			cs.Append("");
			cs.Append("");
			cs.Append("\r\n\r\n");
			cs.Append("namespace " + _model.NameSpace + "\r\n");
			cs.Append("{\r\n");
			cs.Append(" public partial class " + _model.EntityName + "Edit : System.Web.UI.Page\r\n");
			cs.Append(" {\r\n");
			cs.Append("");
			cs.Append(" #region Fields\r\n");
			if (model.IsDOL)
			{
				cs.Append(" private " + _model.EntityName + "Entity  _dol = new " + _model.EntityName + "Entity();\r\n");
			}
			cs.Append(" private " + _model.EntityName + "BLL  _" + _model.EntityName + "Mgr = new " + _model.EntityName + "BLL();\r\n");
			cs.Append(" #endregion \r\n");
			cs.Append("  protected void Page_Load(object sender, EventArgs e)\r\n");
			cs.Append("  {\r\n");
			if (model.MsgType == eShowMsg.LblErr)
			{
				cs.Append("       this.LblMsg.Text = \"\";\r\n");
			}
			cs.Append("       if(!IsPostBack)\r\n");
			cs.Append("       {\r\n");
			cs.Append("            ViewState[\"id\"] = Request.QueryString[\"id\"];\r\n");
			cs.Append(" if( ViewState[\"id\"] == null ||  ViewState[\"id\"].ToString().Length == 0)\r\n");
			cs.Append("{\r\n");
			cs.Append("            ViewState[\"id\"] = \"\";\r\n");
			cs.Append("}\r\n");
			cs.Append("            DoInit();     \r\n");
			cs.Append("       }\r\n");
			cs.Append("  }\r\n");
			cs.Append(CreateMethods(model));
			cs.Append(" }\r\n");
			cs.Append("}\r\n");
			return cs.ToString();
		}

		/********************************创建各种类型的后台方法****************************************************/
		private string CreateMethods(ConditionModel model)
		{
			StringBuilder cs = new StringBuilder();
			cs.Append(_unitFunc.CSCreateSave());
			cs.Append(" #region Private Methods\r\n");
			cs.Append(_unitEdit.CSEditPageCommon(model));
			cs.Append(" #endregion \r\n");
			return cs.ToString();
		}

	}
}

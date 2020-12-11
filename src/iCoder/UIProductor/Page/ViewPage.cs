using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Page
{
	/// <summary>
	/// 列表页面
	/// </summary>
	internal partial class ViewPage : BasePage
	{
		static ViewPage _instance;
		public static ViewPage getInstance(ConditionModel model)
		{
			//if (_instance == null)
			{
				_instance = new ViewPage(model);
			}

			return _instance;
		}

		public ViewPage(ConditionModel model)
			: base(model)
		{
		}


		/// <summary>
		/// 2, EasyType
		/// </summary>
		/// <returns></returns>
		public string CreateViewPageAspx()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.NameSpace + _model.EntityName + "View.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "View\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");

			page.Append(CreatePageHead(ePageType.ViewPage));
			page.Append("<body>\r\n");
			page.Append(CreateViewPageBody_Aspx());
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}


		/// <summary>
		/// ashx用的
		/// </summary>
		/// <returns></returns>
		public string CreateViewPage_Api()
		{
			StringBuilder page = new StringBuilder();
			page.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + _model.NameSpace + _model.EntityName + "View.aspx.cs\" Inherits=\"" + _model.NameSpace + "." + _model.EntityName + "View\" %>\r\n\r\n");
			page.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");

			page.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");

			page.Append(CreatePageHead(ePageType.ApiViewPage));
			page.Append("<body>\r\n");

			page.Append("<div>\r\n");
			page.Append(_unitList.ListUI_Api());
			page.Append("\r\n</div>\r\n");
			page.Append(_unitScript.Create(ePageType.ApiViewPage));
			page.Append("</body>\r\n");
			page.Append("</html>\r\n");
			return page.ToString();
		}


		public string CreateViewPageBody_Aspx()
		{
			StringBuilder body = new StringBuilder();
			body.Append(" <form id=\"form1\" runat=\"server\">\r\n");
			body.Append("<div>\r\n");
			body.Append(CreateMsg_Aspx());
			body.Append(_unitFunc.AspxCreateAdd());
			body.Append(_unitQuery.GetConditionsDiv_DlP());
			body.Append("\r\n<div  style=\"text-align: right; margin: 2px;\">\r\n");
			body.Append(_unitFunc.AspxCreateQueryBtn());
			body.Append("&nbsp;&nbsp;\r\n");
			body.Append(_unitFunc.AspxCreateExportBtn());
			body.Append("&nbsp;&nbsp;&nbsp;&nbsp;\r\n");
			body.Append("\r\n</div>\r\n");
			body.Append(_unitList.ListUI_Repeater());
			body.Append("\r\n</div>\r\n");
			body.Append(" </form>\r\n");
			return body.ToString();
		}

		/********************************创建各种类型的前台元素****************************************************/

	}

	internal partial class ViewPage
	{

		/// <summary>
		/// 1, EasyType
		/// </summary>
		/// <returns></returns>
		public string CreateViewPageCs(ConditionModel model)
		{
			StringBuilder cs = new StringBuilder();
			cs.Append("using System;\r\n");
			cs.Append("");
			cs.Append("");
			cs.Append("\r\n\r\n");
			cs.Append("namespace " + _model.NameSpace + "\r\n");
			cs.Append("{\r\n");
			cs.Append(" public partial class " + _model.EntityName + "View : System.Web.UI.Page\r\n");
			cs.Append(" {\r\n");
			cs.Append("");
			cs.Append(" #region Fields\r\n");
			if (model.IsDOL)
			{
				cs.Append("// private " + _model.EntityName + "Entity  _dol = new " + _model.EntityName + "Entity();\r\n");
			}
			cs.Append("// private " + _model.EntityName + "BLL  _" + _model.EntityName + "Mgr = new " + _model.EntityName + "BLL();\r\n");
			cs.Append(" #endregion \r\n");
			cs.Append("  protected void Page_Load(object sender, EventArgs e)\r\n");
			cs.Append("  {\r\n");
			if (model.MsgType == eShowMsg.LblErr)
			{
				cs.Append("       this.LblMsg.Text = \"\";\r\n");
			}
			cs.Append("       if(!IsPostBack)\r\n");
			cs.Append("       {\r\n");
			cs.Append("            LoadData();     \r\n");
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
			cs.Append(" #region Commands\r\n");
			cs.Append(_unitList.ListCS_Repeater());
			cs.Append(" #endregion \r\n");
			cs.Append(_unitFunc.CSCreateQueryBtn());
			cs.Append(_unitFunc.CSCreateExportBtn());
			cs.Append(_unitQuery.GetCS_Conditions());
			return cs.ToString();
		}

	}
}


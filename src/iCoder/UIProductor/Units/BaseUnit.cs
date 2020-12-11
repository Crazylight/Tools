using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace UIProductor.Units
{
	public partial class BaseUnit
	{
		protected ConditionModel _model;
		protected LangHelper.LanguageHelper _Language;
		public BaseUnit(ConditionModel model)
		{
			_model = model;
			_Language = new LangHelper.LanguageHelper(LangHelper.eLanguageType.Chinese);
		}

		protected string CreatePageIndex()
		{
			StringBuilder index = new StringBuilder();
			////////////////////////////////翻页控件////////////////////////////////
			index.Append("<div class=footerPage>\r\n");
			index.Append("<div class=footerPageRight>\r\n");
			index.Append(" <asp:Label runat=server ID=LblPage />");
			index.Append(" &nbsp; &nbsp;每页\r\n");
			index.Append(" <asp:DropDownList runat=server ID=DdlPageCount AutoPostBack=true OnSelectedIndexChanged=PagePager_PageChanged>\r\n");
			index.Append("  <asp:ListItem Text=20 Value=20 />\r\n");
			index.Append(" <asp:ListItem Text=50 Value=50 />\r\n");
			index.Append(" <asp:ListItem Text=100 Value=100 />\r\n");
			index.Append(" <asp:ListItem Text=200 Value=200 />\r\n");
			index.Append("\r\n");
			index.Append("\r\n");
			index.Append("  </asp:DropDownList>\r\n");
			index.Append("条\r\n");
			index.Append("</div>\r\n");
			index.Append("  <div class=footerPageLeft>");
			index.Append("<asp:AspNetPager ID=\"Pager\" runat=\"server\" HorizontalAlign=\"Center\" OnPageChanged=\"PagePager_PageChanged\"");
			index.Append(" TextBeforePageIndexBox=第&nbsp; NumericButtonTextFormatString=\"{0}\" AlwaysShow=\"false\" UrlPaging=\"False\" CssClass=\"pages\"");
			index.Append(" NextPageText=\"下一页\" FirstPageText=\"首页\" LastPageText=\"尾页\" PrevPageText=\"上一页\"");
			index.Append("PagingButtonLayoutType=\"None\" ShowDisabledButtons=\"False\" ShowPageIndexBox=\"Always\"");
			index.Append(" CurrentPageButtonPosition=\"Center\"  SubmitButtonClass=subBtn  SubmitButtonText=跳转");
			index.Append(" PagingButtonSpacing=\"0px\" CurrentPageButtonClass=\"cpb\" ShowCustomInfoSection=\"Never\"  OnPageChanging=\"Pager_PageChanging\"");
			index.Append("/>\r\n");
			index.Append("</div>\r\n");
			index.Append("</div>\r\n");

			////////////////////////////////////////////////////////////////
			return index.ToString();
		}

		protected bool IsContinue(string name)
		{
			if (name.ToLower().Equals("id")
					|| name.ToLower().Equals("adderid")
					|| name.ToLower().Equals("adder")
					|| name.ToLower().Equals("adderip")
					|| name.ToLower().Equals("addname")
					|| name.ToLower().Equals("addername")
					|| name.ToLower().Equals("lastsaverid")
					|| name.ToLower().Equals("lastsavername")
					|| name.ToLower().Equals("lastsaverip"))
			{
				return true;
			}
			return false;
		}
	}


	public partial class BaseUnit
	{
		protected string ShowMsg(Page.eShowMsg showMsg, string msgContent)
		{
			string msg = "";
			if (showMsg == Page.eShowMsg.LblErr)
			{
				msg = "         this.LblMsg.Text = \"" + msgContent + "\";\r\n";
			}
			else
			{
				msg = "        Command.ShowError(\"" + msgContent + "\");\r\n";
			}
			return msg;
		}
	}
}

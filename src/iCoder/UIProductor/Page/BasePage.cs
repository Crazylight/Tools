using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using UIProductor.Units;

namespace UIProductor.Page
{
	internal class BasePage
	{
		protected ConditionModel _model;
		protected UnitQuery _unitQuery;
		protected UnitFunc _unitFunc;
		protected UnitList _unitList;
		protected UnitListEdit _unitListEdit;
		protected UnitEdit _unitEdit;
		protected UnitScript _unitScript;
		protected BasePage(ConditionModel model)
		{
			_model = model;
			_unitQuery = new UnitQuery(model);
			_unitFunc = new UnitFunc(model);
			_unitList = new UnitList(model);
			_unitListEdit = new UnitListEdit(model);
			_unitEdit = new UnitEdit(model);
			_unitScript = new UnitScript(model);
		}

		protected string CreatePageHead(ePageType pageType)
		{
			StringBuilder head = new StringBuilder();
			head.Append("<head runat=\"server\">\r\n");
			//css引用的顺序会有影响
			#region 组合页面
			if (pageType == ePageType.UICombination)
			{
				head.Append("<title>");
				head.Append("Combination");
				head.Append("</title>");
			}

			#endregion
			#region 编辑页面
			else if (pageType == ePageType.EditPage || pageType == ePageType.ApiEditPage)
			{
				head.Append(" <script src=\"../js/global/jquery.min.js\" type=\"text/javascript\"></script>\r\n");
				head.Append(" <link href=\"../artDialog/skins/default.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				head.Append(" <script src=\"../My97DatePicker/WdatePicker.js\" type=\"text/javascript\"></script>\r\n");
				head.Append(" <script src=\"../artDialog/artDialog.min.js\" type=\"text/javascript\"></script>\r\n");
				head.Append("<title>");
				head.Append("编辑页面");
				head.Append("</title>");
			}
			#endregion
			#region 预览页面
			else if (pageType == ePageType.ViewPage)
			{
				head.Append("<title>");
				head.Append("预览页面");
				head.Append("</title>");
			}
			#endregion
			#region 简单编辑页面
			else if (pageType == ePageType.ViewEditPageListBox)
			{
				head.Append(" <script src=\"../js/global/jquery.min.js\" type=\"text/javascript\"></script>\r\n");
				head.Append(" <script src=\"../My97DatePicker/WdatePicker.js\" type=\"text/javascript\"></script>\r\n");
				head.Append("<title>");
				head.Append("简单编辑页面");
				head.Append("</title>");
			}
			#endregion
			#region API列表页面
			else if (pageType == ePageType.ApiViewPage)
			{
				head.Append("<title>");
				head.Append("列表页面");
				head.Append("</title>\r\n");
				head.Append(" <link href=\"../css/global/list_default.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				head.Append(" <link href=\"../css/global/control_default.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				head.Append(" <script src=\"../js/global/jquery.min.js\" type=\"text/javascript\"></script>\r\n");
				head.Append(" <script src=\"../js/datatables/jquery.dataTables.js\" type=\"text/javascript\"></script>\r\n");
				head.Append(" <script src=\"../js/datatables/dataTables.bootstrap.min.js\" type=\"text/javascript\"></script>\r\n");
			}

			#endregion
			#region 列表页面
			else
			{
				head.Append("<title>");
				head.Append("列表页面");
				head.Append("</title>");
				head.Append(" <link href=\"../css/global/list_default.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				head.Append(" <link href=\"../css/global/control_default.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
				head.Append(" <script src=\"../js/global/jquery.min.js\" type=\"text/javascript\"></script>\r\n");
				head.Append(" <script src=\"../js/global/ListPage.js\" type=\"text/javascript\"></script>\r\n");
			}

			#endregion

			head.Append("</head>\r\n");

			return head.ToString();
		}

		protected string CreateMsgHTML()
		{
			StringBuilder Aspx = new StringBuilder();
			Aspx.Append("<div class=tac>\r\n");
			Aspx.Append("<label id=LblMsg style=color: red />\r\n");
			Aspx.Append("</div>\r\n");
			return Aspx.ToString();
		}

		protected string CreateMsg_Aspx()
		{
			StringBuilder Aspx = new StringBuilder();
			Aspx.Append("<div class=tac>\r\n");
			Aspx.Append("<asp:Label runat=server ID=LblMsg ForeColor = Red/>\r\n");
			Aspx.Append("</div>\r\n");
			return Aspx.ToString();
		}
		
		protected string CreateHidFoot()
		{

			StringBuilder foot = new StringBuilder();
			foot.Append("\r\n");
			foot.Append("<div class=hide>\r\n");
			foot.Append(" <asp:Button runat=server ID=BtnRpt OnClick=BtnRpt_Click />\r\n");
			foot.Append(" <asp:HiddenField ID=\"HidOrderBy\" runat=\"server\" Value=\"\" />\r\n");
			foot.Append("\r\n");
			foot.Append("\r\n");
			foot.Append("\r\n");
			foot.Append("\r\n");
			foot.Append("\r\n");
			foot.Append("</div>\r\n");
			return foot.ToString();
		}
	}
	#region Enums
	/// <summary>
	/// 6种基本的页面模型
	/// </summary>
	public enum ePageType
	{
		///// <summary>
		///// 列表模型
		///// </summary>
		//ListPage,

		/// <summary>
		/// 编辑页面-一般性编辑
		/// </summary>
		EditPage,

		/// <summary>
		/// 预览页面
		/// </summary>
		ViewPage,

		/// <summary>
		/// 列表编辑页面 - listbox类型编辑
		/// </summary>
		ViewEditPageListBox,

		/// <summary>
		/// 列表编辑页面 - repeater类型编辑
		/// </summary>
		ViewEditPageRepeater,

		/// <summary>
		/// 树形模型
		/// </summary>
		TreePage,

		/// <summary>
		/// 关系模型
		/// </summary>
		UIRelation,

		/// <summary>
		/// 组合模型
		/// </summary>
		UICombination,

		ApiViewPage,
		ApiEditPage,
		ApiViewEditPage,
		Ashx
	}

	internal enum eControlType
	{
		ListBox,

		Repeater,

		GridView
	}

	public enum eShowMsg
	{
		LblErr,
		Command,
		CommandSuccess,
		CommandErr
	}
	#endregion
}

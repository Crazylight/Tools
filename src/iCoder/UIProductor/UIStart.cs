using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using UIProductor.Page;

namespace UIProductor
{
	public class UIStart
	{
		static UIStart _instance;
		private UIStart(ConditionModel model)
		{

		}
		public static UIStart getInstance(ConditionModel model)
		{
			// if (_instance == null)
			{
				_instance = new UIStart(model);
			}
			return _instance;
		}

		public string CreatePageUIByType(ConditionModel model)
		{
			if (model.PageType == ePageType.ViewPage)
			{
				return Page.ViewPage.getInstance(model).CreateViewPageAspx();
			}
			else if (model.PageType == ePageType.EditPage)
			{
				return Page.EditPage.getInstance(model).CreateEditPageAspx();
			}
			else if (model.PageType == ePageType.ApiEditPage)
			{
				return Page.EditPage.getInstance(model).CreateEditPageHtml();
			}
			else if (model.PageType == ePageType.ViewEditPageListBox)
			{
				return Page.ListEditPage.getInstance(model).CreateListBoxHtml();
			}
			else if (model.PageType == ePageType.ViewEditPageRepeater)
			{
				return Page.ListEditPage.getInstance(model).CreateRepeaterHtml();
			}
			else if (model.PageType == ePageType.ApiViewPage)
			{
				return Page.ViewPage.getInstance(model).CreateViewPage_Api();
			}
			else if (model.PageType == ePageType.ApiViewEditPage)
			{
				return Page.ListEditPage.getInstance(model).CreateHtml_API();
			}
			else
			{
				return "";
			}
		}

		public string CreatePageCSByType(ConditionModel model)
		{
			if (model.PageType == ePageType.EditPage)
			{
				return Page.EditPage.getInstance(model).CreateEditPageCs(model);
			}
			else if (model.PageType == ePageType.ViewPage)
			{
				return Page.ViewPage.getInstance(model).CreateViewPageCs(model);
			}
			else if (model.PageType == ePageType.ViewEditPageListBox)
			{
				return Page.ListEditPage.getInstance(model).CSCreateListBox();
			}
			else if (model.PageType == ePageType.ViewEditPageRepeater)
			{
				return Page.ListEditPage.getInstance(model).CreateRepeaterCS(model);
			}
			else if (model.PageType == ePageType.Ashx)
			{
				return Ashx.ashxCmd.CreateAshx(model);
			}
			else
			{
				return "";
			}
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.WebPages
{
    public partial class Index : BasePage
    {
        public string CreatePageHtml(string nameSpace)
        {
            StringBuilder page = new StringBuilder();
            string[] js = new string[] { };
            string[] cs = new string[] { "global/global.css", "global/frame.css" };

            page.Append(CreatePageHtml_Head(nameSpace, "Index", "主页", js, cs));
            page.Append("<div>\r\n");
            page.Append("   <!--Head-->\r\n");
            page.Append(" <asp:Header runat=server/>\r\n");
            page.Append("   <!--/Head-->\r\n");
            page.Append("    <!--Main-->\r\n");
            page.Append("    <div>\r\n");
            page.Append("       <div id=main_left  class=left>\r\n");
            page.Append("          <asp:Literal runat=server id=Ltl></asp:Literal> \r\n");
            page.Append("       </div>\r\n");
            page.Append("\r\n");
            page.Append("       <div>\r\n");
            page.Append("          <iframe id=main src=Desk.aspx></frame>\r\n");
            page.Append("       </div>\r\n");
            page.Append("    </div>\r\n");
            page.Append("    <!--/Main-->\r\n");
            page.Append("\r\n");
            page.Append("</div>\r\n");
            page.Append(CreatePageHtml_Foot());
            return page.ToString();
        }
    }

    public partial class Index
    {
        public string CreatePage_CS(string projName, string pageName)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("using System;\r\n");
            cs.Append("using System.Data;\r\n");
            cs.Append("using System.Text;\r\n");
            cs.Append("using " + projName + ".BLL;\r\n");
            cs.Append(" \r\n");
            cs.Append("namespace " + projName + ".Web.Main\r\n");
            cs.Append("{\r\n");
            cs.Append("   public partial class " + pageName + " : System.Web.UI.Page\r\n");
            cs.Append("   {\r\n");
            cs.Append("       #region Fields\r\n");
            cs.Append("       MainBLL _mainBLL = new MainBLL();\r\n");
            cs.Append("       #endregion\r\n");
            cs.Append("       protected void Page_Load(object sender, EventArgs e)\r\n");
            cs.Append("       {\r\n");
            cs.Append("          if(!IsPostBack)\r\n");
            cs.Append("         {\r\n");
            cs.Append("           DoInit();\r\n");
            cs.Append("         }\r\n");
            cs.Append("       }\r\n");
            cs.Append(CreateDoInit());
            cs.Append("  }\r\n");
            cs.Append("}\r\n");
            return cs.ToString();
        }
        #region DoInit
        private string CreateDoInit()
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("      private void DoInit()\r\n");
            cs.Append("      {\r\n");
            cs.Append("          DataTable dt = _mainBLL.GetDtAllModule().Data as DataTable;\r\n");
            cs.Append("           StringBuilder module = new StringBuilder();\r\n");
            cs.Append("          if(dt == null) return;\r\n");
            cs.Append("          foreach (DataRow dr in dt.Rows)\r\n");
            cs.Append("         {\r\n");
            cs.Append("              module.Append(\" <div > \");   \r\n");
            cs.Append("              module.Append(\"<div class=nav_title>\");  \r\n");
            cs.Append("              module.Append(dr[\"MODULENAME\"]); \r\n");
            cs.Append("              module.Append(\"</div>\"); \r\n");
            cs.Append("              System.Data.DataTable dtMenu = _mainBLL.GetMenuDtByModuleId(dr[\"id\"].ToString()).Data as System.Data.DataTable;  \r\n");
            cs.Append("              module.Append(\" <ul > \"); \r\n");
            cs.Append("               foreach (DataRow drMenu in dtMenu.Rows)  \r\n");
            cs.Append("               { \r\n");
            cs.Append("                  module.Append(\" <li > \"); \r\n");
            cs.Append("                  module.Append(\"<a href=\\\"\" + drMenu[\"MENUDESC\"] + \"\\\" target=\\\"desk\\\" class=\\\"ui-side-item-link\\\">\");\r\n");
            cs.Append("                  module.Append(\"<i class=\\\"fn-left ui-icon-mid index\\\"></i>\");\r\n");
            cs.Append("                 module.Append(drMenu[\"MENUNAME\"]);\r\n");
            cs.Append("                 module.Append(\"</a>\");\r\n");
            cs.Append("                 module.Append(\"</li>\");\r\n");
            cs.Append("                }\r\n");
            cs.Append("                  module.Append(\"</ul>\");\r\n");
            cs.Append("                  module.Append(\"</div>\");\r\n");
            cs.Append("         }\r\n");
            cs.Append("            Ltl.Text = module.ToString();\r\n ");
            cs.Append("      }\r\n");
            return cs.ToString();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.WebPages
{
    public class UserControl
    {

        public string CreateUC_Header(string webDir)
        {
            StringBuilder head = new StringBuilder();
            head.Append("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"Header.ascx.cs\" Inherits=\"" + webDir + ".UserControls.Header\" %>\r\n");
            head.Append("<div id=head>\r\n");
            head.Append("  <div class=head_bg>\r\n");
            head.Append("  <div style=\"width:980px;\">\r\n");
            head.Append("     <a href=\"Main.aspx\" target=\"main\">首页</a>\r\n");
            head.Append("      <a href=\"Login.aspx?action=logout\" target=\"_self\">退出</a>\r\n");
            head.Append("\r\n");
            head.Append("   </div>\r\n");
            head.Append("  </div>\r\n");
            head.Append("  <div class=show>\r\n");
            head.Append("  </div>\r\n");
            head.Append("</div>\r\n");
            return head.ToString();
        }
        public string CreateUC_HeaderCs(string webDir)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("using System;\r\n");
            cs.Append("");
            cs.Append("");
            cs.Append("\r\nnamespace " + webDir + ".UserControls\r\n");
            cs.Append("{\r\n");
            cs.Append("    public partial class Header : System.Web.UI.UserControl\r\n");
            cs.Append("    {\r\n");
            cs.Append("        protected void Page_Load(object sender, EventArgs e)\r\n");
            cs.Append("        {\r\n");
            cs.Append("             if(!IsPostBack)\r\n");
            cs.Append("        {\r\n");
            cs.Append("            \r\n");
            cs.Append("        }\r\n");
            cs.Append("        }\r\n");
            cs.Append("     }\r\n");
            cs.Append("}\r\n");
            return cs.ToString();
        }
        public string CreateUC_HeaderDesigner(string webDir)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("//------------------------------------------------------------------------------\r\n");
            cs.Append(" // <自动生成>\r\n");
            cs.Append("//     此代码由工具生成。\r\n");
            cs.Append("//\r\n");
            cs.Append("//     对此文件的更改可能会导致不正确的行为，并且如果\r\n");
            cs.Append("//     重新生成代码，这些更改将会丢失。 \r\n");
            cs.Append("// </自动生成>\r\n");
            cs.Append("//------------------------------------------------------------------------------\r\n");
            cs.Append("");
            cs.Append("\r\nnamespace " + webDir + ".UserControls\r\n");
            cs.Append("{\r\n");
            cs.Append("    public partial class Header\r\n");
            cs.Append("    {");
            cs.Append("    }\r\n");
            cs.Append("}\r\n");
            return cs.ToString();
        }


        public string CreateUC_Nav(string webDir)
        {
            StringBuilder head = new StringBuilder();
            head.Append("<%@ Control Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"Navigator.ascx.cs\" Inherits=\"" + webDir + ".UserControls.Navigator\" %>\r\n");
            head.Append("<div>\r\n");
            head.Append("  <ul runat=server id=ul_nav class=\"nav_ul\">\r\n");
            head.Append("  </ul>\r\n");
            head.Append("</div>\r\n");
            return head.ToString();
        }
        public string CreateUC_NavCs(string webDir)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("using System;\r\n");
            cs.Append("using System.Text;\r\n");
            cs.Append("using System.Web.UI.HtmlControls;\r\n");
            cs.Append("using System.Data;\r\n");
            cs.Append("using CommandClass = " + webDir + ".Commands.HelperCommand;\r\n");
            cs.Append("\r\n");
            cs.Append("\r\nnamespace " + webDir + ".UserControls\r\n");
            cs.Append("{\r\n");
            cs.Append("    public partial class Navigator : System.Web.UI.UserControl\r\n");
            cs.Append("    {\r\n");
            cs.Append("        protected void Page_Load(object sender, EventArgs e)\r\n");
            cs.Append("        {\r\n");
            cs.Append("            if(!IsPostBack)\r\n");
            cs.Append("            {\r\n");
            cs.Append("                LoadResource();\r\n");
            cs.Append("                LoadTabs();\r\n");
            cs.Append("            }\r\n");
            cs.Append("        }\r\n");
            #region Load
            cs.Append("        private void LoadResource()\r\n");
            cs.Append("        {\r\n");
            cs.Append("           HtmlLink link = new HtmlLink() { Href = \"../css/page/navcss.css\" };\r\n");
            cs.Append("           link.Attributes.Add(\"rel\", \"stylesheet\");\r\n");
            cs.Append("           link.Attributes.Add(\"type\", \"text/css\");\r\n");
            cs.Append("           Page.Header.Controls.Add(link);\r\n");
            cs.Append("        }\r\n\r\n");
            cs.Append("        private void LoadTabs()\r\n");
            cs.Append("        {\r\n");
            cs.Append("           DataTable dt = (new SysPageBLL()).GetPagesByUrl(CommandClass.GetRequestPath()).Data as DataTable;\r\n");
            #region 初始化页面
            cs.Append("           if (dt != null && dt.Rows.Count > 0)\r\n");
            cs.Append("           {\r\n");
            cs.Append("              StringBuilder tabs = new StringBuilder(); \r\n");
            cs.Append("              foreach (DataRow dr in dt.Rows)\r\n");
            cs.Append("             { \r\n");
            cs.Append("                 if (dr[\"PAGEURL\"].ToString() == CommandClass.GetRequestPath())\r\n");
            cs.Append("                 { \r\n");
            cs.Append("                      tabs.Append(\"<li  class=\\\"selected\\\">\");\r\n");
            cs.Append("                 }\r\n");
            cs.Append("                 else\r\n");
            cs.Append("                 { \r\n");
            cs.Append("                     tabs.Append(\" < li > \"); \r\n");
            cs.Append("                     tabs.Append(\"<a\");\r\n");
            cs.Append("                     tabs.Append(\" href=\\\"\" + dr[\"PAGEURL\"] + \"\\\"\");\r\n");
            cs.Append("                     tabs.Append(\"\");\r\n");
            cs.Append("                     tabs.Append(\">\");\r\n");
            cs.Append("                     tabs.Append(dr[\"PAGECNAME\"]);\r\n");
            cs.Append("                     tabs.Append(\"</a>\");\r\n");
            cs.Append("                     tabs.Append(\"</li>\");\r\n");
            cs.Append("                  }\r\n");
            cs.Append("               }\r\n");

            cs.Append("             this.ul_nav.InnerHtml = tabs.ToString();\r\n");
            cs.Append("            }\r\n");
            #endregion
            cs.Append("         }\r\n");

            #endregion
            cs.Append("     }\r\n");
            cs.Append("}\r\n");
            return cs.ToString();
        }
        public string CreateUC_NavDesigner(string webDir)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("//------------------------------------------------------------------------------\r\n");
            cs.Append(" // <自动生成>\r\n");
            cs.Append("//     此代码由工具生成。\r\n");
            cs.Append("//\r\n");
            cs.Append("//     对此文件的更改可能会导致不正确的行为，并且如果\r\n");
            cs.Append("//     重新生成代码，这些更改将会丢失。 \r\n");
            cs.Append("// </自动生成>\r\n");
            cs.Append("//------------------------------------------------------------------------------\r\n");
            cs.Append("");
            cs.Append("\r\nnamespace " + webDir + ".UserControls\r\n");
            cs.Append("{\r\n");
            cs.Append("    public partial class Navigator\r\n");
            cs.Append("    {");
            cs.Append("      protected global::System.Web.UI.HtmlControls.HtmlGenericControl ul_nav;\r\n");
            cs.Append("    }\r\n");
            cs.Append("}\r\n");
            return cs.ToString();
        }

    }
}

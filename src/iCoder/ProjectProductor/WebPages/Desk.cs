using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.WebPages
{
    /*
     * 后台管理系统
     */
    public partial class Desk : BasePage
    {
        public Desk()
        {

        }
        public string CreatePageHtml(string nameSpace)
        {
            StringBuilder page = new StringBuilder();
            string[] js = new string[] { };
            string[] cs = new string[] { };

            page.Append(CreatePageHtml_Head(nameSpace, "Desk", "主页", js, cs));
            page.Append("<div>\r\n");
            page.Append("<h1>欢迎使用系统</h1>\r\n");
            page.Append("</div>\r\n");
            page.Append(CreatePageHtml_Foot());
            return page.ToString();
        }
    }
    public partial class Desk
    {
        public string CreatePage_CS(string projectName, string pageName)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("using System;\r\n");
            cs.Append("\r\n");
            cs.Append("namespace " + projectName + ".Web.Main\r\n");
            cs.Append("{\r\n");
            cs.Append("   public partial class " + pageName + " : System.Web.UI.Page\r\n");
            cs.Append("   {\r\n");
            cs.Append("       protected void Page_Load(object sender, EventArgs e)\r\n");
            cs.Append("       {\r\n");
            cs.Append("\r\n");
            cs.Append("\r\n");
            cs.Append("\r\n");
            cs.Append("       }\r\n");
            cs.Append("  }\r\n");
            cs.Append("}\r\n");
            return cs.ToString();
        }

        private string CreateDeskCs()
        {
            StringBuilder cs = new StringBuilder();

            return cs.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.WebPages
{
    public class LoginPage : BasePage
    {
        public string CreatePage_Html(string nameSpace)
        {
            StringBuilder html = new StringBuilder();
            string[] js = new string[] { "global/jquery.min.js" };
            string[] css = new string[] { "page/login.css" };

            html.Append(CreatePageHtml_Head(nameSpace, "Login", "用户登录", js, css));
            html.Append("<div class=\"loginWrap\">\r\n");
            html.Append("  <div class=\"login\">\r\n");
            html.Append("    <div class=\"loginFont\">\r\n");
            html.Append("         <h3>-管理信息系统- </h3>\r\n");
            html.Append("         <div class=loginContainer>\r\n");
            html.Append("            <div class=\"loginContent\">\r\n");
            html.Append("                <p>后台管理系统</p>\r\n");
            html.Append("                <h5>Management System</h5>\r\n");
            html.Append("               <div class=\"loginbar\">\r\n");
            html.Append("                   <input runat=\"server\" type=\"text\" id=\"txtUserId\" />\r\n");
            html.Append("               </div>\r\n");
            html.Append("               <div class=\"loginPassword\">\r\n");
            html.Append("                 <input runat=\"server\" type=\"password\" id=\"txtPwd\" />\r\n");
            html.Append("              </div>\r\n");
            html.Append("               <asp:Label runat=\"server\" CssClass=\"login_btn\" ID=\"LblMsg\"  ForeColor=\"Red\" />\r\n");
            html.Append("               <asp:Button runat=\"server\" CssClass=\"login_btn\" ID=\"BtnLogin\" Text=\"登录\" OnClick=\"BtnLogin_Click\" />\r\n");
            html.Append("           </div>\r\n");
            html.Append("        </div>\r\n");
            html.Append("    </div>\r\n");
            html.Append("  </div>\r\n");
            html.Append("</div>\r\n");

            html.Append(CreatePageHtml_Foot());

            return html.ToString();
        }

        public string CreatePage_CS(string nameSpace, string pageName)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("	using System;	\r\n");
            cs.Append("	using System.Collections.Generic;	\r\n");
            cs.Append("	using System.Linq;	\r\n");
            cs.Append("	using System.Web;	\r\n");
            cs.Append("	using System.Web.UI;	\r\n");
            cs.Append("	using System.Web.UI.WebControls;	\r\n");
            cs.Append("	using " + nameSpace.Remove(nameSpace.IndexOf(".Web")) + ".BLL;	\r\n");
            cs.Append("		\r\n");
            cs.Append("	namespace " + nameSpace + "	\r\n");
            cs.Append("	{	\r\n");
            cs.Append("	    public partial class " + pageName + " : System.Web.UI.Page	\r\n");
            cs.Append("	    {	\r\n");
            cs.Append("	        protected void Page_Load(object sender, EventArgs e)	\r\n");
            cs.Append("	        {	\r\n");
            cs.Append("		        if (Request.QueryString[\"action\"] == \"logout\")\r\n");
            cs.Append("		        {\r\n");
            cs.Append("		            Session.RemoveAll();\r\n");
            cs.Append("		        }\r\n");
            cs.Append("	        }	\r\n\r\n");
            cs.Append("        protected void BtnLogin_Click(object sender, EventArgs e)\r\n");
            cs.Append("        {\r\n");
            cs.Append("            MainBLL mgr = new MainBLL();\r\n ");
            cs.Append("             " + nameSpace.Remove(nameSpace.IndexOf(".Web")) + ".Entity.Result res = mgr.LogIn(this.txtUserId.Value, this.txtPwd.Value, Request.UserHostAddress);");
            cs.Append("	            Boolean canLog = Convert.ToBoolean(res.Data); \r\n");
            cs.Append("            if(canLog)\r\n");
            cs.Append("	           {\r\n");
            cs.Append("	                  Session[\"UserId\"] = this.txtUserId.Value; \r\n");
            cs.Append("	                  Response.Redirect(\"Index.aspx\"); \r\n");
            cs.Append("	           } \r\n");
            cs.Append("	          else \r\n");
            cs.Append("	          { \r\n");
            cs.Append("	            this.LblMsg.Text = res.Msg; \r\n");
            cs.Append("	           \r\n");
            cs.Append("	          } \r\n");
            cs.Append("        }	\r\n");
            cs.Append("	    }	\r\n");
            cs.Append("	}	\r\n");

            return cs.ToString();
        }

    }
}

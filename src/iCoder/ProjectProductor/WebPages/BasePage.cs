using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.WebPages
{
    public abstract class BasePage
    {
        public BasePage()
        {

        }

        protected string CreatePageHtml_Head(string nameSpace, string pageName, string title, string[] js, params string[] styles)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"" + pageName + ".aspx.cs\" Inherits=\"" + nameSpace + "." + pageName + "\" %>\r\n");
            // html.Append("<%@ Register Assembly=\"AspNetPager\" Namespace=\"Wuqi.Webdiyer\" TagPrefix=\"webdiyer\" %>");
            html.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            html.Append("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            html.Append("<head runat=\"server\">\r\n");
            foreach (string j in js)
            {
                html.Append("<script src=\"../js/" + j + "\" type=\"text/javascript\"></script>\r\n");
            }
            foreach (string str in styles)
            {
                html.Append("<link href=\"../css/" + str + "\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            html.Append("<title>" + title + "</title>\r\n");
            html.Append("</head>\r\n");
            html.Append("<body>\r\n");
            html.Append(" <form id=\"form1\" runat=\"server\">\r\n");

            return html.ToString();
        }
        protected string CreatePageHtml_Foot()
        {
            StringBuilder html = new StringBuilder();
            html.Append(" </form>\r\n");
            html.Append("</body>\r\n");
            html.Append("</html>\r\n");

            return html.ToString();
        }

        protected string CreateCommanCS_Head(string nameSpace, string pageName)
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("	using System;	\r\n");
            cs.Append("	using System.Collections.Generic;	\r\n");
            cs.Append("	using System.Linq;	\r\n");
            cs.Append("	using System.Web;	\r\n");
            cs.Append("	using System.Web.UI;	\r\n");
            cs.Append("	using System.Web.UI.WebControls;	\r\n");
            cs.Append("		\r\n");
            cs.Append("	namespace " + nameSpace + "	\r\n");
            cs.Append("	{	\r\n");
            cs.Append("	    public partial class " + pageName + " : System.Web.UI.Page	\r\n");
            cs.Append("	    {	\r\n");
            cs.Append("	        protected void Page_Load(object sender, EventArgs e)	\r\n");
            cs.Append("	        {	\r\n");
            cs.Append("		\r\n");
            cs.Append("	        }	\r\n");
            return cs.ToString();
        }
        protected string CreateCommonCS_Foot()
        {
            StringBuilder cs = new StringBuilder();
            cs.Append("	    }	\r\n");
            cs.Append("	}	\r\n");
            return cs.ToString();
        }

    
    }
}

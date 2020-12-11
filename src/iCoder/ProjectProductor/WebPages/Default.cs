using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor.WebPages
{
    public class Default
    {
        public string CreateDefault_Html(string nameSpace)
        {
            StringBuilder html = new StringBuilder();
            html.Append("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"Default.aspx.cs\" Inherits=\"" + nameSpace + ".Default\" %>\r\n");
            // html.Append("<%@ Register Assembly=\"AspNetPager\" Namespace=\"Wuqi.Webdiyer\" TagPrefix=\"webdiyer\" %>");
            html.Append("\r\n<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
            html.Append("\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
            html.Append("<head runat=\"server\">\r\n");
            html.Append("<title>Default</title>\r\n");
            html.Append("</head>\r\n");
            html.Append("<body>\r\n");
            html.Append(" <form id=\"form1\" runat=\"server\">\r\n");
            html.Append(" <div>\r\n\r\n");
            html.Append(" </div>\r\n");
            html.Append(" </form>\r\n");
            html.Append("</body>\r\n");
            html.Append("</html>\r\n");

            return html.ToString();
        }
        public string CreateDefault_CS(string nameSpace)
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
            cs.Append("	    public partial class Default : System.Web.UI.Page	\r\n");
            cs.Append("	    {	\r\n");
            cs.Append("	        protected void Page_Load(object sender, EventArgs e)	\r\n");
            cs.Append("	        {	\r\n");
            cs.Append("		\r\n");
            cs.Append("	        }	\r\n");
            cs.Append("	    }	\r\n");
            cs.Append("	}	\r\n");

            return cs.ToString();
        }
    }
}

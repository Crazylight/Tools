using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectProductor
{
    internal class WebProj : BaseProj
    {
        static WebProj instance;
        private WebProj()
        {

        }

        public static WebProj getInstance()
        {
            if (null == instance)
            {
                instance = new WebProj();
            }
            return instance;
        }
        #region Dirs
        public void CreateDir(string rootDirPath, string projName)
        {
            string dirWeb = rootDirPath + "//" + projName + ".Web";

            #region WebConfig
            string fileWebconfig = dirWeb + "//Web.config";
            _CreateFile(fileWebconfig, CreateWebConfig());
            #endregion

            //#region csproj   VSEmpty.csproj.user
            //string fileCsproj = dirWeb + "//" + _ProjectName + ".Web.csproj";
            //CreateFile(fileCsproj, WebProj.CreateProject_Web_csproj(_ProjectHash));

            //string fileUser = dirWeb + "//" + _ProjectName + ".csproj.user";
            //CreateFile(fileUser, WebProj.CreateProject_Web_user());
            //#endregion

            //#region Web.Debug.config and Web.Release.config
            //string fileDebugConfig = dirWeb + "//Web.Debug.config";
            //CreateFile(fileDebugConfig, WebProj.CreateWebDebugConfig);

            //string fileReleaseConfig = dirWeb + "//Web.Release.config";
            //CreateFile(fileReleaseConfig, WebProj.CrateWebReleaseConfig());
            //#endregion
            /***************************** *Create Dirs ***************************************************/
            //#region Main
            //string dirMain = dirWeb + "/Main";
            //_CreateDir(dirMain);
            //#endregion

            //#region Commands
            //string dirCommands = dirWeb + "/Commands";
            //_CreateDir(dirCommands);
            //#endregion

            //#region Common
            //string dirCommon = dirWeb + "/Common";
            //_CreateDir(dirCommon);
            //#endregion

            //#region Css
            //string dirCss = dirWeb + "/css";
            //_CreateDir(dirCss);
            //#endregion

            //#region js
            //string dirJs = dirWeb + "/js";
            //_CreateDir(dirJs);
            //#endregion

            //string dirUc = dirWeb + "/UserControl";
            //_CreateDir(dirUc);
            ///******************************Create Files ***************************************************/
            //#region Imgs
            //string dirImgs = dirWeb + "/imgs"; //静态图片
            //_CreateDir(dirImgs);

            //string dirImagegs = dirWeb + "/images"; //静态图片
            //_CreateDir(dirImagegs);
            //#endregion

            #region Create Files
            //CreatePageWeb_DefaultPage(dirWeb);
            //CreatePageWeb_LoginPage(dirWeb);
            //CreateCss(dirWeb);
            //CreateJS(dirWeb);
            //CreateDirWeb_CommandHelper(dirCommands);
            //CreateDirWeb_CommandSession(dirCommands);


            #endregion

            #region UserControls
            // CreateDriWeb_UserControl_Head(dirWeb);
            #endregion
        }
        #endregion

        #region WebProjectConfig
        public string CreateProject_Web_user()
        {
            StringBuilder user = new StringBuilder();
            user.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            user.Append("<Project ToolsVersion=\"4.0\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n");
            user.Append("<ProjectExtensions>\r\n");
            user.Append("  <VisualStudio>\r\n");
            user.Append("   <FlavorProperties GUID=\"{" + Guid.NewGuid() + "}\">\r\n");
            user.Append("     <WebProjectProperties>\r\n");
            user.Append("       <StartPageUrl>\r\n");
            user.Append("      </StartPageUrl>\r\n");
            user.Append("      <StartAction>CurrentPage</StartAction>\r\n");
            user.Append("      <AspNetDebugging>True</AspNetDebugging>\r\n");
            user.Append("      <SilverlightDebugging>False</SilverlightDebugging>\r\n");
            user.Append("     <NativeDebugging>False</NativeDebugging>\r\n");
            user.Append("      <SQLDebugging>False</SQLDebugging>\r\n");
            user.Append("      <ExternalProgram>\r\n");
            user.Append("         </ExternalProgram>\r\n");
            user.Append("        <StartExternalURL>\r\n");
            user.Append("        </StartExternalURL>\r\n");
            user.Append("        <StartCmdLineArguments>\r\n");
            user.Append("         </StartCmdLineArguments>\r\n");
            user.Append("        <StartWorkingDirectory>\r\n");
            user.Append("        </StartWorkingDirectory>\r\n");
            user.Append("       <EnableENC>False</EnableENC>\r\n");
            user.Append("       <AlwaysStartWebServerOnDebug>True</AlwaysStartWebServerOnDebug>\r\n");
            user.Append("     </WebProjectProperties>\r\n");
            user.Append("     </FlavorProperties>\r\n");
            user.Append("  </VisualStudio>\r\n");
            user.Append(" </ProjectExtensions>\r\n");
            user.Append("</Project>\r\n");
            return user.ToString();
        }

        public string CreateWebDebugConfig()
        {
            StringBuilder debug = new StringBuilder();
            debug.Append("<?xml version=\"1.0\"?>\r\n");

            debug.Append("<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->\r\n");

            debug.Append("<configuration xmlns:xdt=\"http://schemas.microsoft.com/XML-Document-Transform\">\r\n");
            debug.Append("  <!--\r\n");
            debug.Append("   In the example below, the \"SetAttributes\" transform will change the value of \r\n");
            debug.Append("   \"connectionStrin\\g\" to use \"ReleaseSQLServer\" only when the \"Match\" locator \r\n");
            debug.Append("   finds an atrribute \"name\" that has a value of \"MyDB\".\r\n");

            debug.Append("    <connectionStrings>\r\n");
            debug.Append("    <add name=\"MyDB\" \r\n");
            debug.Append("      connectionString=\"Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True\" \r\n");
            debug.Append("      xdt:Transform=\"SetAttributes\" xdt:Locator=\"Match(name)\"/>\r\n");
            debug.Append("   </connectionStrings>\r\n");
            debug.Append(" -->\r\n");
            debug.Append(" <system.web>\r\n");
            debug.Append("  <!--\r\n");
            debug.Append("    In the example below, the \"Replace\" transform will replace the entire \r\n");
            debug.Append("    <customErrors> section of your web.config file.\r\n");
            debug.Append("   Note that because there is only one customErrors section under the \r\n");
            debug.Append("     <system.web> node, there is no need to use the \"xdt:Locator\" attribute.\r\n");
            debug.Append("     \r\n");
            debug.Append("   <customErrors defaultRedirect=\"GenericError.htm\"\r\n");
            debug.Append("     mode=\"RemoteOnly\" xdt:Transform=\"Replace\">\r\n");
            debug.Append("    <error statusCode=\"500\" redirect=\"InternalError.htm\"/>\r\n");
            debug.Append("</customErrors>\r\n");
            debug.Append("  -->\r\n");
            debug.Append(" </system.web>\r\n");
            debug.Append("</configuration>");

            return debug.ToString();
        }

        public string CrateWebReleaseConfig()
        {
            StringBuilder release = new StringBuilder();
            release.Append("<?xml version=\"1.0\"?>\r\n");

            release.Append("<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->\r\n");

            release.Append("<configuration xmlns:xdt=\"http://schemas.microsoft.com/XML-Document-Transform\">\r\n");
            release.Append("  <!--\r\n");

            release.Append("   In the example below, the \"SetAttributes\" transform will change the value of \r\n");
            release.Append("   \"connectionStrin\\g\" to use \"ReleaseSQLServer\" only when the \"Match\" locator \r\n");
            release.Append("   finds an atrribute \"name\" that has a value of \"MyDB\".\r\n");

            release.Append("    <connectionStrings>\r\n");
            release.Append("    <add name=\"MyDB\" \r\n");
            release.Append("      connectionString=\"Data Source=ReleaseSQLServer;Initial Catalog=MyReleaseDB;Integrated Security=True\" \r\n");
            release.Append("      xdt:Transform=\"SetAttributes\" xdt:Locator=\"Match(name)\"/>\r\n");
            release.Append("   </connectionStrings>\r\n");
            release.Append(" -->\r\n");
            release.Append(" <system.web>\r\n");
            release.Append("<compilation xdt:Transform=\"RemoveAttributes(debug)\" />");
            release.Append("  <!--\r\n");
            release.Append("    In the example below, the \"Replace\" transform will replace the entire \r\n");
            release.Append("    <customErrors> section of your web.config file.\r\n");
            release.Append("   Note that because there is only one customErrors section under the \r\n");
            release.Append("     <system.web> node, there is no need to use the \"xdt:Locator\" attribute.\r\n\r\n");
            release.Append("     \r\n");
            release.Append("   <customErrors defaultRedirect=\"GenericError.htm\"\r\n");
            release.Append("     mode=\"RemoteOnly\" xdt:Transform=\"Replace\">\r\n");
            release.Append("    <error statusCode=\"500\" redirect=\"InternalError.htm\"/>\r\n");
            release.Append("</customErrors>\r\n");
            release.Append("  -->\r\n");
            release.Append(" </system.web>\r\n");

            release.Append("</configuration>");
            return release.ToString();
        }
        #endregion

        #region Commands
        public string CreateWebCommand_Helper(string nameSpace)
        {
            StringBuilder command = new StringBuilder();
            command.Append("using System;\r\n");
            command.Append("using System.Data;\r\n");
            command.Append("using System.Web.UI.WebControls;\r\n");
            command.Append("using System.Web;\r\n");
            command.Append("using System.IO;\r\n");
            command.Append("using System.Web.UI;\r\n\r\n");
            command.Append("\r\nnamespace " + nameSpace + " \r\n");
            command.Append("{\r\n");
            command.Append("     public partial class HelperCommand\r\n");
            command.Append("    {\r\n");
            command.Append("        \r\n");
            #region ExportExcel
            command.Append(" public static void ExportExcel(DataTable dt, string fileName, string code = null)\r\n");
            command.Append("    {\r\n");
            command.Append("	 GridView gv1 = new GridView();	\r\n");
            command.Append("	 gv1.HeaderStyle.Height = 72;\r\n");
            command.Append("     gv1.RowStyle.Height = 23;\r\n");
            command.Append("	 gv1.AlternatingRowStyle.BackColor = System.Drawing.ColorTranslator.FromHtml(\"#DAEEF3\");\r\n");
            command.Append("      gv1.RowStyle.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;\r\n");
            command.Append("     gv1.RowStyle.VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Middle;\r\n");
            command.Append("			\r\n");
            command.Append("	            gv1.DataSource = dt;		\r\n");
            command.Append("	            gv1.DataBind();		\r\n");
            command.Append("            if (!string.IsNullOrEmpty(fileName))\r\n");
            command.Append("            {\r\n");
            command.Append("	            fileName = fileName + \".xls\";		\r\n");
            command.Append("             }\r\n");
			command.Append("             else\r\n");
			command.Append("            {\r\n");
			command.Append("	            fileName = DateTime.Now.ToString(\"yyyyMMddHHmmss\") + \".xls\";		\r\n");
			command.Append("             }\r\n");
            command.Append("            if (string.IsNullOrEmpty(code))\r\n");
            command.Append("            {\r\n");
            command.Append("	            code = \"GB2312\";		\r\n");
			command.Append("             }\r\n");
            command.Append("	            HttpContext.Current.Response.Clear();		\r\n");
            command.Append("	            HttpContext.Current.Response.Buffer = true;		\r\n");
            command.Append("	            HttpContext.Current.Response.Charset = code;		\r\n");
			command.Append("	            //HttpContext.Current.Response.AppendHeader(\"Content-Disposition\", \"attachment;filename=\" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.GetEncoding(\"GB2312\")));		\r\n");
			command.Append("	            HttpContext.Current.Response.AppendHeader(\"Content-Disposition\", \"attachment;filename=\" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));		\r\n");
            command.Append("	            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding(code);		\r\n");
            command.Append("	            HttpContext.Current.Response.ContentType = \"application/vnd.ms-excel\";		\r\n");
            command.Append("	            StringWriter sw = new StringWriter();		\r\n");
            command.Append("	            HtmlTextWriter htw = new HtmlTextWriter(sw);		\r\n");
            command.Append("	            gv1.RenderControl(htw);		\r\n");
            command.Append("                 //可以添加CSS\r\n");
            command.Append("	            HttpContext.Current.Response.Write(\"<html><head><meta http-equiv=Content-Type content=\\\"text/html; charset=\"+code+\"\\\"></head><body>\"); \r\n");
            command.Append("	            HttpContext.Current.Response.Write(sw.ToString());		\r\n");
            command.Append("	            HttpContext.Current.Response.Write(\"</body></html>\");\r\n");
            command.Append("	            HttpContext.Current.Response.End();		\r\n");
            command.Append("    }\r\n");
            #endregion
            command.Append("    }\r\n");
            command.Append("     public partial class HelperCommand\r\n");
            command.Append("    {\r\n");
            command.Append("        public static string Encode(string str) \r\n ");
            command.Append("        {\r\n");
            command.Append("          return  HttpUtility.HtmlEncode(str);\r\n");
            command.Append("        }\r\n");
            command.Append("        public static string Decode(string str) \r\n ");
            command.Append("        {\r\n");
            command.Append("          return  HttpUtility.HtmlDecode(str);\r\n");
            command.Append("        }\r\n");
            command.Append("        public static string GetRequestPath()\r\n");
            command.Append("        {\r\n");
            command.Append("          return HttpContext.Current.Request.Path;\r\n");
            command.Append("        }\r\n");
            command.Append("    }\r\n");
            command.Append("}\r\n");
            return command.ToString();
        }
        public static string CreateWebCommand_Session(string nameSpace)
        {
            StringBuilder command = new StringBuilder();
            command.Append("using System;\r\n");
            command.Append("using System.Data;\r\n");
            command.Append("using System.Web.UI.WebControls;\r\n");
            command.Append("using System.Web;\r\n");
            command.Append("using System.IO;\r\n");
            command.Append("using System.Web.UI;\r\n\r\n");
            command.Append("\r\nnamespace " + nameSpace + " \r\n");
            command.Append("{\r\n");
            command.Append("    public class SessionCommand\r\n");
            command.Append("    {\r\n");
            #region Session
            command.Append("      public static void CheckSession()\r\n");
            command.Append("      {  \r\n");
            command.Append("         if (HttpContext.Current.Session[\"userid\"] == null)\r\n");
            command.Append("          {  \r\n");
            command.Append("      // HttpContext.Current.Response.Redirect(\"\", false);\r\n");

            command.Append("          } \r\n");
            command.Append("       } \r\n");
            #endregion
            command.Append("");
            command.Append("    }\r\n");
            command.Append("}\r\n");
            return command.ToString();
        }
        #endregion

        #region Default
        public string CreateDefault_Html(string nameSpace)
        {
            return (new WebPages.Default()).CreateDefault_Html(nameSpace);
        }
        public string CreateDefault_CS(string nameSpace)
        {
            return (new WebPages.Default()).CreateDefault_CS(nameSpace);
        }
        #endregion

        #region Main
        public string CreateLogin_Html(string nameSpace)
        {
            return (new WebPages.LoginPage()).CreatePage_Html(nameSpace);
        }
        public string CreateLogin_CS(string nameSpace, string pageName)
        {
            return (new WebPages.LoginPage()).CreatePage_CS(nameSpace, pageName);
        }


        public string CreateIndex_Html(string nameSpace)
        {
            return (new WebPages.Index()).CreatePageHtml(nameSpace);
        }
        public string CreateIndex_CS(string projName, string pageName)
        {
            return (new WebPages.Index()).CreatePage_CS(projName, pageName);
        }


        public string CreateDesk_Html(string nameSpace)
        {
            return (new WebPages.Desk()).CreatePageHtml(nameSpace);
        }
        public string CreateDesk_CS(string nameSpace, string pageName)
        {
            return (new WebPages.Desk()).CreatePage_CS(nameSpace, pageName);
        }

        #endregion

        #region JS
        public string CreateJs_jquery()
        {
            return System.IO.File.ReadAllText(System.IO.Path.GetFullPath("../../../ProjectProductor/resource/js/jquery.min.js"));
        }
        public string CreateJs_ListPage()
        {
            return System.IO.File.ReadAllText(System.IO.Path.GetFullPath("../../../ProjectProductor/resource/js/listpage.js"));
        }
        #endregion

        #region CSS
        public string CreateCssLogin()
        {
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/login.css");

            return System.IO.File.ReadAllText(sql);
        }
        public string CreateCssListStyle()
        {
            //相对路劲
            // return System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/resource/style.css");
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/css/list_default.css");

            return System.IO.File.ReadAllText(sql);
        }
        public string CreateCssControlCss()
        {
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/css/control_default.css");

            return System.IO.File.ReadAllText(sql);
        }
        public string CreateCssGlobal()
        {
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/css/global.css");

            return System.IO.File.ReadAllText(sql);
        }
        public string CreateCssNav()
        {
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/css/navcss.css");

            return System.IO.File.ReadAllText(sql);
        }

        public string CreateCssUIGloble()
        {
            //相对路劲
            // return System.IO.File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "/resource/style.css");
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/css/global.css");

            return System.IO.File.ReadAllText(sql);
        }
        public string CreateCssUIStyle()
        {
            string sql = System.IO.Path.GetFullPath("../../../ProjectProductor/resource/css/style.css");

            return System.IO.File.ReadAllText(sql);
        }
        #endregion

        #region UserControls
        public string CreateUC_Header(string webDir)
        {
            return (new WebPages.UserControl()).CreateUC_Header(webDir);
        }
        public string CreateUC_HeaderCs(string webDir)
        {
            return (new WebPages.UserControl()).CreateUC_HeaderCs(webDir);
        }
        public string CreateUC_HeaderDesigner(string webDir)
        {
            return (new WebPages.UserControl()).CreateUC_HeaderDesigner(webDir);
        }

        public string CreateUC_Nav(string webDir, string ucName)
        {
            return (new WebPages.UserControl()).CreateUC_Nav(webDir);
        }
        public string CreateUC_NavCs(string webDir)
        {
            return (new WebPages.UserControl()).CreateUC_NavCs(webDir);
        }
        public string CreateUC_NavDesigner(string webDir)
        {
            return (new WebPages.UserControl()).CreateUC_NavDesigner(webDir);
        }

        #endregion

        #region Create_DesignerCS
        public string Create_DesignerCS(string nameSpace, string pageName)
        {
            return WebPages.DesignerCS.Create_DesignerCS(nameSpace, pageName);
        }
        #endregion

        #region WebConfig
        /// <summary>
        /// Creates the web config.
        /// </summary>
        /// <returns></returns>
        public string CreateWebConfig()
        {
            StringBuilder web = new StringBuilder();
            web.Append("<?xml version=\"1.0\"?>\r\n");

            web.Append("<!--\r\n  For more information on how to configure your ASP.NET application, please visit\r\n");
            web.Append(" http://go.microsoft.com/fwlink/?LinkId=169433 \r\n  -->\r\n\r\n");

            web.Append("<configuration>\r\n");
            web.Append("  <appSettings>\r\n");
            web.Append("  <add key=\"ConnStr\" value=\"Data Source=LDQ-PC\\SQLEXPRESS;Initial Catalog=WorkInfo;UID=Biz001;PWD=biz121;\"/>\r\n");
            web.Append("  </appSettings>\r\n\r\n");
            web.Append(" <system.web>\r\n");
            web.Append("     <httpRuntime requestValidationMode=\"2.0\" />");
            web.Append("     <compilation debug=\"true\" targetFramework=\"4.0\" />\r\n");
            web.Append("     <pages validateRequest=\"false\">\r\n");
            web.Append("        <controls>\r\n");
            web.Append("        <add src=\"~/UserControl/Header.ascx\" tagName=\"Header\" tagPrefix=\"asp\"/>\r\n");
            web.Append("        <add src=\"~/UserControl/Navigator.ascx\" tagName=\"Navigator\" tagPrefix=\"asp\"/>\r\n");
            web.Append("        <add assembly=\"AspNetPager\" namespace=\"Wuqi.Webdiyer\" tagPrefix=\"asp\"/>\r\n");
            //web.Append("\r\n");
            //web.Append("\r\n");
            //web.Append("\r\n");
            web.Append("\r\n        </controls>\r\n");
            web.Append("    </pages>\r\n");
            web.Append(" </system.web>\r\n\r\n");
            web.Append("</configuration>\r\n");

            return web.ToString();
        }
        #endregion
    }
}

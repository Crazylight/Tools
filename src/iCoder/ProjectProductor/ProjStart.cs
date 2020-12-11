using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace ProjectProductor
{
    internal class ProjStart : BaseProj
    {
        public ProjStart(string rootDirPath, string projName)
            : base()
        {
            _rootDirPath = rootDirPath;
            _projectName = projName;
            DoInit();
        }

        private void DoInit()
        {

            #region Init RootDirPath  and _projectName
            if (null == _rootDirPath || _rootDirPath.Length == 0)
            {
                DirectoryInfo rootDir = new DirectoryInfo(".");
                _rootDirPath = rootDir.FullName + "//" + _projectName;
            }
            else
            {
                _rootDirPath = _rootDirPath + "//" + _projectName;
            }
            #endregion

            #region Init Guid
            _projectHash = new Hashtable();
            _projectHash["projGuid"] = Guid.NewGuid().ToString();
            _projectHash["webGuid"] = Guid.NewGuid().ToString();
            _projectHash["bllGuid"] = Guid.NewGuid().ToString();
            _projectHash["dalGuid"] = Guid.NewGuid().ToString();
            _projectHash["entityGuid"] = Guid.NewGuid().ToString();
            _projectHash["wizardGuid"] = Guid.NewGuid().ToString();
            #endregion

            #region Init ProjNames
            _projectHash["projName"] = _projectName;
            _projectHash["webName"] = _projectName + ".Web";
            _projectHash["bllName"] = _projectName + ".BLL";
            _projectHash["dalName"] = _projectName + ".DAL";
            _projectHash["entityName"] = _projectName + ".Entity";
            _projectHash["wizardName"] = "WizardFramework";// _projectName + ".Entity";
            #endregion

        }

        /// <summary>
        /// Creates the project dirs.
        /// </summary>
        public void CreateProjectDirs()
        {
            _CreateDir(_rootDirPath);
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString());
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//Properties");
            _CreateDir(_rootDirPath + "//" + _projectHash["bllName"].ToString() + "//Properties");
            _CreateDir(_rootDirPath + "//" + _projectHash["dalName"].ToString() + "//Properties");
            _CreateDir(_rootDirPath + "//" + _projectHash["entityName"].ToString() + "//Properties");
            _CreateDir(_rootDirPath + "//" + _projectHash["wizardName"].ToString() + "//Properties");

            //Create Dirs Web
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//Commands");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//Main");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//UserControl");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//css");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//css//global//");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//css//page//");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//cssui");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//cssui//global//");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//cssui//page//");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//js");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//js//global");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//js//page");
            _CreateDir(_rootDirPath + "//" + _projectHash["webName"].ToString() + "//Config");

            //Wizard
            _CreateDir(_rootDirPath + "//" + _projectHash["wizardName"].ToString() + "//LogMgr");

        }

        /// <summary>
        /// Creates the proj config files.
        /// </summary>
        public void CreateProjConfigFiles()
        {
            //string projSln = _rootDirPath + "//" + _projectName + ".sln";
            _CreateFile(_rootDirPath + "//" + _projectHash["projName"] + ".sln", ProjConfig.CreateProject_sln(_projectHash));
            _CreateFile(_rootDirPath + "//" + _projectHash["webName"] + "//" + _projectHash["webName"] + ".csproj", ProjConfig.CreateProject_Web_csproj(_projectHash));
            _CreateFile(_rootDirPath + "//" + _projectHash["bllName"] + "//" + _projectHash["bllName"] + ".csproj", ProjConfig.CreateProject_BLL_csproj(_projectHash));
            _CreateFile(_rootDirPath + "//" + _projectHash["dalName"] + "//" + _projectHash["dalName"] + ".csproj", ProjConfig.CreateProject_DAL_csproj(_projectHash));
            _CreateFile(_rootDirPath + "//" + _projectHash["entityName"] + "//" + _projectHash["entityName"] + ".csproj", ProjConfig.CreateProject_Entity_csproj(_projectHash));
            _CreateFile(_rootDirPath + "//" + _projectHash["wizardName"] + "//" + _projectHash["wizardName"] + ".csproj", ProjConfig.CreateProject_Wizard_csproj(_projectHash));

            _CreateFile(_rootDirPath + "//" + _projectHash["webName"] + "//Properties//AssemblyInfo.cs", ProjConfig.CreateAssemblyInfo(_projectHash["webName"].ToString()));
            _CreateFile(_rootDirPath + "//" + _projectHash["bllName"] + "//Properties//AssemblyInfo.cs", ProjConfig.CreateAssemblyInfo(_projectHash["webName"].ToString()));
            _CreateFile(_rootDirPath + "//" + _projectHash["dalName"] + "//Properties//AssemblyInfo.cs", ProjConfig.CreateAssemblyInfo(_projectHash["webName"].ToString()));
            _CreateFile(_rootDirPath + "//" + _projectHash["entityName"] + "//Properties//AssemblyInfo.cs", ProjConfig.CreateAssemblyInfo(_projectHash["webName"].ToString()));
            _CreateFile(_rootDirPath + "//" + _projectHash["wizardName"] + "//Properties//AssemblyInfo.cs", ProjConfig.CreateAssemblyInfo(_projectHash["webName"].ToString()));

        }

        /// <summary>
        /// Creates the web files.
        /// </summary>
        public void CreateWebFiles()
        {
            WebProj web = WebProj.getInstance();

            string webPath = _rootDirPath + "//" + _projectHash["webName"] + "//";

            //Create Files
            _CreateFile(webPath + _projectHash["webName"] + ".csproj.user", web.CreateProject_Web_user());
            _CreateFile(webPath + "Web.Debug.config", web.CreateWebDebugConfig());
            _CreateFile(webPath + "Web.Release.config", web.CrateWebReleaseConfig());
            _CreateFile(webPath + "Web.config", web.CreateWebConfig());
            _CreateFile(webPath + "Default.aspx", web.CreateDefault_Html(_projectHash["webName"].ToString()));
            _CreateFile(webPath + "Default.aspx.cs", web.CreateDefault_CS(_projectHash["webName"].ToString()));
            _CreateFile(webPath + "Default.aspx.designer.cs", web.Create_DesignerCS(_projectHash["webName"].ToString(), "Default"));

            #region MainDir
            string nameSpace = _projectHash["webName"].ToString() + ".Main";
            _CreateFile(webPath + "Main/Desk.aspx", web.CreateDesk_Html(nameSpace));
            _CreateFile(webPath + "Main/Desk.aspx.cs", web.CreateDesk_CS(_projectName, "Desk"));
            _CreateFile(webPath + "Main/Desk.aspx.designer.cs", web.Create_DesignerCS(nameSpace, "Desk"));

            _CreateFile(webPath + "Main/Index.aspx", web.CreateIndex_Html(nameSpace));
            _CreateFile(webPath + "Main/Index.aspx.cs", web.CreateIndex_CS(_projectName, "Index"));
            _CreateFile(webPath + "Main/Index.aspx.designer.cs", web.Create_DesignerCS(nameSpace, "Index"));

            _CreateFile(webPath + "Main/Login.aspx", web.CreateLogin_Html(nameSpace));
            _CreateFile(webPath + "Main/Login.aspx.cs", web.CreateLogin_CS(nameSpace, "Login"));
            _CreateFile(webPath + "Main/Login.aspx.designer.cs", web.Create_DesignerCS(nameSpace, "Login"));
            #endregion

            #region Create UserControls
            _CreateFile(webPath + "UserControl/Header.ascx", web.CreateUC_Header(_projectHash["webName"].ToString()));
            _CreateFile(webPath + "UserControl/Header.ascx.cs", web.CreateUC_HeaderCs(_projectHash["webName"].ToString()));
            _CreateFile(webPath + "UserControl/Header.ascx.designer.cs", web.CreateUC_HeaderDesigner(_projectHash["webName"].ToString() + ".Header"));

            _CreateFile(webPath + "UserControl/Navigator.ascx", web.CreateUC_Nav(_projectHash["webName"].ToString(), "Navigator"));
            _CreateFile(webPath + "UserControl/Navigator.ascx.cs", web.CreateUC_NavCs(_projectHash["webName"].ToString()));
            _CreateFile(webPath + "UserControl/Navigator.ascx.designer.cs", web.CreateUC_NavDesigner(_projectHash["webName"].ToString() + ".Navigator"));
            
            #endregion

            _CreateFile(webPath + "Commands/HelperCommand.cs", web.CreateWebCommand_Helper(_projectHash["webName"].ToString() + ".Commands"));

            #region Create JS
            _CreateFile(webPath + "js/global/jquery.min.js", web.CreateJs_jquery());
            _CreateFile(webPath + "js/global/ListPage.js", web.CreateJs_ListPage());
            _CreateFile(webPath + "js/page/Login.js", "");
            #endregion
            #region 创建CSS文件
            _CreateFile(webPath + "css/global/list_default.css", web.CreateCssListStyle());
            _CreateFile(webPath + "css/global/control_default.css", web.CreateCssControlCss());
            _CreateFile(webPath + "css/global/global.css", web.CreateCssGlobal());
            _CreateFile(webPath + "css/page/login.css", web.CreateCssLogin());
            _CreateFile(webPath + "css/page/navcss.css", web.CreateCssNav());

            _CreateFile(webPath + "cssui/global/global.css", web.CreateCssUIGloble());
            _CreateFile(webPath + "cssui/global/style.css", web.CreateCssUIStyle());
            #endregion

        }

        public void CreateBLLFiles()
        {
            string dirBLL = _rootDirPath + "//" + _projectName + ".BLL";
            //Hashtable projNames = new Hashtable();
            //projNames["bll"] = _projectName + ".BLL";
            //projNames["dalName"] = _projectName + ".DAL";
            //projNames["dalPath"] = "";
            //_CreateDir(dirBLL);

            //CreateProjectDir(dirBLL);

            #region CS
            string fileMainBll = dirBLL + "//MainBLL.cs";
            _CreateFile(fileMainBll, (new BLL.MainBLL()).CreateMainBLL(_projectHash["projName"].ToString()));
            #endregion

            //#region csproj
            //string fileCsproj = dirBLL + "//" + _projectName + ".BLL.csproj";
            //CreateFile(fileCsproj, BuilderContentBLL.CreateProject_BLL_csproj(_ProjectHash));
            //#endregion

        }

        public void CreateDALFiles()
        {
            DALProj dal = DALProj.GetInstance();

            string dirDAL = _rootDirPath + "//" + _projectHash["dalName"];

            _CreateDir(dirDAL);

            #region BaseDAL
            string baseFilePath = dirDAL + "//BaseDAL.cs";
            _CreateFile(baseFilePath, dal.CreateBaseDAL(_projectHash["projName"].ToString()));
            #endregion

            #region MainDAL
            string mainDAL = dirDAL + "//MainDAL.cs";
            _CreateFile(mainDAL, dal.CreateMainDAL(_projectHash["projName"].ToString()));
            #endregion

        }

        public void CreateEntityFiles()
        {
            EntityProj entity = EntityProj.getInstance();

            string dirEntity = _rootDirPath + "//" + _projectHash["entityName"];
            _CreateDir(dirEntity);

            #region BaseEntity
            string baseFilePath = dirEntity + "//BaseEntity.cs";
            _CreateFile(baseFilePath, entity.CreateBaseEntity(_projectHash["entityName"].ToString()));
            #endregion

            #region Result
            string resultFilePath = dirEntity + "//Result.cs";
            _CreateFile(resultFilePath, entity.CreateResultEntity(_projectHash["entityName"].ToString()));
            #endregion
        }

        public void CreateWizardFiles()
        {
            WizardProj wizard = WizardProj.getInstance();

            string dirWizardFramework = _rootDirPath + "//" + _projectHash["wizardName"];
            _CreateDir(dirWizardFramework);

            _CreateDir(dirWizardFramework + "//DataOper");

            #region DataOper
            string iFile = dirWizardFramework + "//DataOper//IDataHelper.cs";
            _CreateFile(iFile, wizard.CreateFile_IDataHelper(_projectHash["wizardName"] + ".DataOper"));

            string filePath = dirWizardFramework + "//DataOper//SqlHelper.cs";
            _CreateFile(filePath, wizard.CreateFile_SqlHelper(_projectHash["wizardName"] + ".DataOper"));

            string oracle = dirWizardFramework + "//DataOper//OracleHelper.cs";
            _CreateFile(oracle, wizard.CreateFile_OracleHelper(_projectHash["wizardName"] + ".DataOper"));

            string sqlite = dirWizardFramework + "//DataOper//SqliteHelper.cs";
            _CreateFile(sqlite, wizard.CreateFile_SqliteHelper(_projectHash["wizardName"] + ".DataOper"));

            #endregion

            #region LogOper
            string logFile = dirWizardFramework + "//LogMgr//LogHelper.cs";
            _CreateFile(logFile, wizard.CreateFile_LogHelper(_projectHash["wizardName"] + ".LogMgr"));

            string logModel = dirWizardFramework + "//LogMgr//LogModel.cs";
            _CreateFile(logModel, wizard.CreateFile_LogModel(_projectHash["wizardName"] + ".LogMgr"));


            #endregion


        }

        //private static void CreateProjectDir(string dir)
        //{
        //    #region bin
        //    string dirBin = dir + "//" + "bin";
        //    _CreateDir(dirBin);
        //    #endregion

        //    #region obj
        //    string dirObj = dir + "//" + "obj"; ;
        //    _CreateDir(dirObj);
        //    #endregion

        //    #region Properties
        //    string dirProperties = dir + "//" + "Properties"; ;
        //    _CreateDir(dirProperties);

        //    string fileAssemblyInfo = dirProperties + "//" + "AssemblyInfo.cs";
        //    CreateFile(fileAssemblyInfo, BuilderContentProject.CreateAssemblyInfo(_projectName));
        //    #endregion
        //}


        //#region CreateFiles
        //private static void CreateDirWeb_CommandHelper(string nameSpace)
        //{
        //    string HelperCommand = nameSpace + "/HelperCommand.cs";
        //    CreateFile(HelperCommand, WebProj.CreateWebCommand_Helper(_projectName + ".Web.Commands"));

        //}
        //private static void CreateDirWeb_CommandSession(string nameSpace)
        //{
        //    string sessionHelper = nameSpace + "/SessionCommand.cs";
        //    CreateFile(sessionHelper, WebProj.CreateWebCommand_Helper(_projectName + ".Web.Commands"));

        //}

        //private static void CreateDriWeb_UserControl_Head(string nameSpace)
        //{
        //    string ucHeader = nameSpace + "/UserControl/Header.ascx";
        //    CreateFile(ucHeader, WebProj.CreateUC_Header(_projectName + ".Web"));

        //    string ucHeaderCS = nameSpace + "/UserControl/Header.ascx.cs";
        //    CreateFile(ucHeaderCS, WebProj.CreateUC_HeaderCs(_projectName + ".Web"));

        //    string ucHeaderDesignerCS = nameSpace + "/UserControl/Header.ascx.designer.cs";
        //    CreateFile(ucHeaderDesignerCS, WebProj.CreateUC_HeaderDesigner(_projectName + ".Web"));

        //}

        //private static void CreateCss(string nameSpace)
        //{
        //    string css = nameSpace + "/css/style.css";
        //    CreateFile(css, WebProj.CreateCss());

        //    CreateFile(nameSpace + "/css/login.css", WebProj.CreateCssLogin());
        //}
        //private static void CreateJS(string nameSpace)
        //{
        //    string css = nameSpace + "/js/jquery-1.8.3.min.js";
        //    CreateFile(css, "");
        //    CreateFile(nameSpace + "/js/Login.js", "");
        //}
        //#endregion

        //#region CreatePages

        //private static void CreatePageWeb_DefaultPage(string nameSpace)
        //{
        //    string defaultHtml = nameSpace + "/Default.aspx";
        //    CreateFile(defaultHtml, WebProj.CreateDefault_Html(_projectName + ".Web"));

        //    string defaultCS = nameSpace + "/Default.aspx.cs";
        //    if (!File.Exists(defaultCS))
        //    {
        //        // Func<string> func = () => FileContent.CreateDefault_CS(_projectName + ".Web");

        //        CreateFile(defaultCS, WebProj.CreateDefault_CS(_projectName + ".Web"));
        //    }
        //    string defaultDesignerCS = nameSpace + "/Default.aspx.designer.cs";
        //    if (!File.Exists(defaultDesignerCS))
        //    {
        //        Func<string> func = () => WebProj.Create_DesignerCS(_projectName + ".Web", "Default");
        //        CreateFile(defaultDesignerCS, func);

        //        //  CreateFile(defaultDesignerCS, FileContent.CreateDefault_DesignerCS(_projectName + ".Web"));
        //    }
        //}
        //private static void CreatePageWeb_LoginPage(string nameSpace)
        //{
        //    string loginHtml = nameSpace + "/Main/Login.aspx";
        //    CreateFile(loginHtml, WebProj.CreateLogin_Html(_projectName + ".Web.Main"));

        //    string loginCS = nameSpace + "/Main/Login.aspx.cs";
        //    if (!File.Exists(loginCS))
        //    {
        //        // Func<string> func = () => FileContent.CreateDefault_CS(_projectName + ".Web");

        //        CreateFile(loginCS, WebProj.CreateLogin_CS(_projectName + ".Web.Main", "Login"));
        //    }
        //    string loginDesignerCS = nameSpace + "/Main/Login.aspx.designer.cs";
        //    if (!File.Exists(loginDesignerCS))
        //    {
        //        Func<string> func = () => WebProj.Create_DesignerCS(_projectName + ".Web.Main", "Login");
        //        CreateFile(loginDesignerCS, func);

        //        //  CreateFile(loginDesignerCS, FileContent.CreateDefault_DesignerCS(_projectName + ".Web"));
        //    }
        //}

        //private static void CreatePageWeb_Common_ItemSelect(string nameSpace)
        //{

        //    string ItemSelect = nameSpace + "/Common/ItemSelect.aspx";
        //    CreateFile(ItemSelect, WebProj.CreatePageCommon_SelectItems(_projectName + ".Web.Common"));

        //    string itemSelectCs = nameSpace + "/Common/ItemSelect.aspx.cs";
        //    if (!File.Exists(itemSelectCs))
        //    {
        //        // Func<string> func = () => FileContent.CreateDefault_CS(_projectName + ".Web");

        //        CreateFile(itemSelectCs, WebProj.CreateLogin_CS(_projectName + ".Web.Main", "ItemSelect"));
        //    }
        //    string loginDesignerCS = nameSpace + "/Main/Login.aspx.designer.cs";
        //    if (!File.Exists(loginDesignerCS))
        //    {
        //        Func<string> func = () => WebProj.Create_DesignerCS(_projectName + ".Web.Main", "Login");
        //        CreateFile(loginDesignerCS, func);

        //        //  CreateFile(loginDesignerCS, FileContent.CreateDefault_DesignerCS(_projectName + ".Web"));
        //    }
        //}
        //#endregion

    }

}

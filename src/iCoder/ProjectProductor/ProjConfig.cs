using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProjectProductor
{
    internal partial class ProjConfig
    {
        public static string CreateProject_sln(Hashtable hash)
        {
            StringBuilder proj = new StringBuilder();

            proj.Append("Microsoft Visual Studio Solution File, Format Version 11.00\r\n");
            proj.Append("# Visual Studio 2010\r\n");
            //Project  Web
            proj.Append("Project(\"{" + hash["projGuid"] + "}\") = \"" + hash["webName"] + "\", \"" + hash["webName"]
             + "\\" + hash["webName"] + ".csproj\", \"{" + hash["webGuid"] + "}\"\r\n");
            proj.Append("EndProject\r\n");
            //Project  Entity
            proj.Append("Project(\"{" + hash["projGuid"] + "}\") = \"" + hash["entityName"] + "\", \"" + hash["entityName"]
             + "\\" + hash["entityName"] + ".csproj\", \"{" + hash["entityGuid"] + "}\"\r\n");
            proj.Append("EndProject\r\n");
            //Project  DAL
            proj.Append("Project(\"{" + hash["projGuid"] + "}\") = \"" + hash["dalName"] + "\", \"" + hash["dalName"]
             + "\\" + hash["dalName"] + ".csproj\", \"{" + hash["dalName"] + "}\"\r\n");
            proj.Append("EndProject\r\n");
            //Project  BLL
            proj.Append("Project(\"{" + hash["projGuid"] + "}\") = \"" + hash["bllName"] + "\", \"" + hash["bllName"]
             + "\\" + hash["bllName"] + ".csproj\", \"{" + hash["bllName"] + "}\"\r\n");
            proj.Append("EndProject\r\n");

            //Project  wizardName
            proj.Append("Project(\"{" + hash["projGuid"] + "}\") = \"" + hash["wizardName"] + "\", \"" + hash["wizardName"]
             + "\\" + hash["wizardName"] + ".csproj\", \"{" + hash["wizardName"] + "}\"\r\n");
            proj.Append("EndProject\r\n");

            proj.Append("Global\r\n");
            proj.Append("GlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n");
            proj.Append("	Debug|Any CPU = Debug|Any CPU\r\n");
            proj.Append("		Release|Any CPU = Release|Any CPU\r\n");
            proj.Append("	EndGlobalSection\r\n");
            proj.Append("	GlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n");
            //Web
            proj.Append("		{" + hash["webGuid"] + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["webGuid"] + "}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["webGuid"] + "}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
            proj.Append("		{" + hash["webGuid"] + "}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
            //Entity
            proj.Append("		{" + hash["entityGuid"] + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["entityGuid"] + "}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["entityGuid"] + "}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
            proj.Append("		{" + hash["entityGuid"] + "}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
            //DAL
            proj.Append("		{" + hash["dalGuid"] + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["dalGuid"] + "}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["dalGuid"] + "}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
            proj.Append("		{" + hash["dalGuid"] + "}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");
            //BLL
            proj.Append("		{" + hash["bllGuid"] + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["bllGuid"] + "}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["bllGuid"] + "}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
            proj.Append("		{" + hash["bllGuid"] + "}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");

            //WizardFramework
            proj.Append("		{" + hash["wizardGuid"] + "}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["wizardGuid"] + "}.Debug|Any CPU.Build.0 = Debug|Any CPU\r\n");
            proj.Append("		{" + hash["wizardGuid"] + "}.Release|Any CPU.ActiveCfg = Release|Any CPU\r\n");
            proj.Append("		{" + hash["wizardGuid"] + "}.Release|Any CPU.Build.0 = Release|Any CPU\r\n");


            proj.Append("	EndGlobalSection\r\n");
            proj.Append("	GlobalSection(SolutionProperties) = preSolution\r\n");
            proj.Append("		HideSolutionNode = FALSE\r\n");
            proj.Append("	EndGlobalSection\r\n");
            proj.Append("EndGlobal");
            return proj.ToString();
        }

        public static string CreateAssemblyInfo(string projName)
        {
            StringBuilder info = new StringBuilder();
            info.Append("using System.Reflection;\r\n");
            info.Append("using System.Runtime.CompilerServices;\r\n");
            info.Append("using System.Runtime.InteropServices;\r\n\r\n");

            info.Append("// General Information about an assembly is controlled through the following \r\n");
            info.Append("// set of attributes. Change these attribute values to modify the information\r\n");
            info.Append("// associated with an assembly.\r\n");
            info.Append("[assembly: AssemblyTitle(\"" + projName + "\")]\r\n");
            info.Append("[assembly: AssemblyDescription(\"\")]\r\n");
            info.Append("[assembly: AssemblyConfiguration(\"\")]\r\n");
            info.Append("[assembly: AssemblyCompany(\"\")]\r\n");
            info.Append("[assembly: AssemblyProduct(\"" + projName + "\")]\r\n");
            info.Append("[assembly: AssemblyCopyright(\"Copyright ©  2013\")]\r\n");
            info.Append("[assembly: AssemblyTrademark(\"\")]\r\n");
            info.Append("[assembly: AssemblyCulture(\"\")]\r\n\r\n");

            info.Append("// Setting ComVisible to false makes the types in this assembly not visible \r\n");
            info.Append("// to COM components.  If you need to access a type in this assembly from  \r\n");
            info.Append("// COM, set the ComVisible attribute to true on that type. \r\n");
            info.Append("[assembly: ComVisible(false)] \r\n\r\n");

            info.Append("// The following GUID is for the ID of the typelib if this project is exposed to COM \r\n");
            //info.Append("[assembly: Guid("8cd44d37-da8a-4c56-a8d0-82c7db1574f2")] \r\n");
            info.Append("[assembly: Guid(\"" + Guid.NewGuid() + "\")] \r\n\r\n");

            info.Append("// Version information for an assembly consists of the following four values: \r\n");
            info.Append("// \r\n");
            info.Append("//      Major Version \r\n");
            info.Append("//      Minor Version  \r\n");
            info.Append("//      Build Number \r\n");
            info.Append("//      Revision \r\n");
            info.Append("// \r\n");
            info.Append("// You can specify all the values or you can default the Revision and Build Numbers  \r\n");
            info.Append("// by using the '*' as shown below: \r\n");
            info.Append("[assembly: AssemblyVersion(\"1.0.0.0\")] \r\n");
            info.Append("[assembly: AssemblyFileVersion(\"1.0.0.0\")] \r\n");

            return info.ToString();
        }

        public static string CreateProject_Web_csproj(Hashtable hash)
        {
            StringBuilder webProj = new StringBuilder();
            #region Common
            webProj.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            webProj.Append("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n");
            webProj.Append("<PropertyGroup>\r\n");
            webProj.Append("  <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n");
            webProj.Append("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>\r\n");
            webProj.Append("    <ProductVersion>\r\n");
            webProj.Append("    </ProductVersion>\r\n");
            webProj.Append("    <SchemaVersion>2.0</SchemaVersion>\r\n");
            webProj.Append("    <ProjectGuid>{" + hash["webGuid"] + "}</ProjectGuid>\r\n");
            webProj.Append("    <ProjectTypeGuids>{349c5851-65df-11da-9384-00065b846f21};{fae04ec0-301f-11d3-bf4b-00c04f79efbc}</ProjectTypeGuids>\r\n");
            webProj.Append("    <OutputType>Library</OutputType>\r\n");
            webProj.Append("    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n");
            webProj.Append("    <RootNamespace>" + hash["webName"] + "</RootNamespace>\r\n");
            webProj.Append("    <AssemblyName>" + hash["webName"] + "</AssemblyName>\r\n");
            webProj.Append("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>\r\n");
            webProj.Append("    <UseIISExpress>false</UseIISExpress>\r\n");
            webProj.Append("  </PropertyGroup>\r\n");
            webProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\r\n");
            webProj.Append("    <DebugSymbols>true</DebugSymbols>\r\n");
            webProj.Append("    <DebugType>full</DebugType>\r\n");
            webProj.Append("    <Optimize>false</Optimize>\r\n");
            webProj.Append("    <OutputPath>bin\\</OutputPath>\r\n");
            webProj.Append("    <DefineConstants>DEBUG;TRACE</DefineConstants>\r\n");
            webProj.Append("    <ErrorReport>prompt</ErrorReport>\r\n");
            webProj.Append("    <WarningLevel>4</WarningLevel>\r\n");
            webProj.Append("  </PropertyGroup>\r\n");
            webProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">\r\n");
            webProj.Append("    <DebugType>pdbonly</DebugType>\r\n");
            webProj.Append("    <Optimize>true</Optimize>\r\n");
            webProj.Append("   <OutputPath>bin\\</OutputPath>\r\n");
            webProj.Append("   <DefineConstants>TRACE</DefineConstants>\r\n");
            webProj.Append("    <ErrorReport>prompt</ErrorReport>\r\n");
            webProj.Append("    <WarningLevel>4</WarningLevel>\r\n");
            webProj.Append("  </PropertyGroup>\r\n");
            #endregion
            #region Reference
            webProj.Append("  <ItemGroup>\r\n");
            webProj.Append("   <Reference Include=\"AspNetPager\" />\r\n");
            webProj.Append("   <Reference Include=\"System\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Data\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Core\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Configuration\" />\r\n");
            webProj.Append("   <Reference Include=\"Microsoft.CSharp\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Web.DynamicData\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Web.Entity\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Web.ApplicationServices\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Data.DataSetExtensions\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Web.Extensions\"/> \r\n");
            webProj.Append("   <Reference Include=\"System.Xml.Linq\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Drawing\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Web\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Xml\" />\r\n");
            webProj.Append("   <Reference Include=\"System.Web.Services\" />\r\n");
            webProj.Append("   <Reference Include=\"System.EnterpriseServices\" />\r\n");
            webProj.Append(" </ItemGroup>\r\n");
            #endregion
            #region Folder
            webProj.Append(CreateFolder());
            #endregion
            #region 添加对页面的引用
            webProj.Append(CreatePage());
            #endregion
            #region 关联aspx  cs  designer
            webProj.Append("<ItemGroup>\r\n");
            webProj.Append("    <Compile Include=\"Properties\\AssemblyInfo.cs\" />\r\n");
            //ASPXCodeBehind Cs Begin
            //添加新的类，在这里面引用，如果再content里面用， 项目中不能取到对应的类名，命名空间等
            webProj.Append("    <Compile Include=\"Commands\\HelperCommand.cs\" />\r\n");
            webProj.Append("    <Compile Include=\"Default.aspx.cs\">\r\n");
            webProj.Append("       <DependentUpon>Default.aspx</DependentUpon>\r\n");
            webProj.Append("       <SubType>ASPXCodeBehind</SubType>\r\n");
            webProj.Append("    </Compile>\r\n");
            webProj.Append("    <Compile Include=\"Default.aspx.designer.cs\">\r\n");
            webProj.Append("        <DependentUpon>Default.aspx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");
            #region MainDir
            webProj.Append("    <Compile Include=\"Main\\Login.aspx.cs\">\r\n");
            webProj.Append("          <DependentUpon>Login.aspx</DependentUpon>\r\n");
            webProj.Append("          <SubType>ASPXCodeBehind</SubType>\r\n");
            webProj.Append("    </Compile>\r\n");
            webProj.Append("    <Compile Include=\"Main\\Login.aspx.designer.cs\">\r\n");
            webProj.Append("      <DependentUpon>Login.aspx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");

            webProj.Append("    <Compile Include=\"Main\\Index.aspx.cs\">\r\n");
            webProj.Append("          <DependentUpon>Index.aspx</DependentUpon>\r\n");
            webProj.Append("          <SubType>ASPXCodeBehind</SubType>\r\n");
            webProj.Append("    </Compile>\r\n");
            webProj.Append("    <Compile Include=\"Main\\Index.aspx.designer.cs\">\r\n");
            webProj.Append("      <DependentUpon>Index.aspx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");

            webProj.Append("    <Compile Include=\"Main\\Desk.aspx.cs\">\r\n");
            webProj.Append("          <DependentUpon>Desk.aspx</DependentUpon>\r\n");
            webProj.Append("          <SubType>ASPXCodeBehind</SubType>\r\n");
            webProj.Append("    </Compile>\r\n");
            webProj.Append("    <Compile Include=\"Main\\Desk.aspx.designer.cs\">\r\n");
            webProj.Append("      <DependentUpon>Desk.aspx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");
            #endregion
            #region UserControls
            webProj.Append("    <Compile Include=\"UserControl\\Header.ascx.designer.cs\">\r\n");
            webProj.Append("      <DependentUpon>Header.ascx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");
            webProj.Append("    <Compile Include=\"UserControl\\Header.ascx.cs\">\r\n");
            webProj.Append("      <DependentUpon>Header.ascx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");

            webProj.Append("    <Compile Include=\"UserControl\\Navigator.ascx.cs\">\r\n");
            webProj.Append("       <DependentUpon>Navigator.ascx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");
            webProj.Append("    <Compile Include=\"UserControl\\Navigator.ascx.designer.cs\">\r\n");
            webProj.Append("        <DependentUpon>Navigator.ascx</DependentUpon>\r\n");
            webProj.Append("    </Compile>\r\n");
            #endregion
            //ASPXCodeBehind CS End
            webProj.Append(" </ItemGroup>\r\n");
            #endregion

            #region ProjectReference
            webProj.Append(" <ItemGroup>\r\n");
            webProj.Append("  <ProjectReference Include=\"..\\" + hash["bllGuid"] + ".csproj\">\r\n");
            webProj.Append("    <Project>{" + hash["bllGuid"] + "}</Project>\r\n");
            webProj.Append("    <Name>" + hash["bllName"] + "</Name>\r\n");
            webProj.Append("  </ProjectReference>\r\n");
            webProj.Append("  <ProjectReference Include=\"..\\" + hash["entityName"] + ".csproj\">\r\n");
            webProj.Append("  <Project>{" + hash["entityGuid"] + "}</Project>\r\n");
            webProj.Append("   <Name>" + hash["entityName"] + "</Name>\r\n");
            webProj.Append("  </ProjectReference>\r\n");

            webProj.Append("  </ItemGroup>\r\n");
            #endregion
            #region End
            webProj.Append(" <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n");
            webProj.Append(" <Import Project=\"$(MSBuildExtensionsPath32)\\Microsoft\\VisualStudio\\v10.0\\WebApplications\\Microsoft.WebApplication.targets\" />\r\n");
            webProj.Append(" <ProjectExtensions>\r\n");
            webProj.Append("   <VisualStudio>\r\n");
            webProj.Append("     <FlavorProperties GUID=\"{" + Guid.NewGuid() + "}\">\r\n");
            webProj.Append("      <WebProjectProperties>\r\n");
            webProj.Append("         <UseIIS>False</UseIIS>\r\n");
            webProj.Append("         <AutoAssignPort>True</AutoAssignPort>\r\n");
            webProj.Append("         <DevelopmentServerPort>8819</DevelopmentServerPort>\r\n");
            webProj.Append("        <DevelopmentServerVPath>/</DevelopmentServerVPath>\r\n");
            webProj.Append("        <IISUrl>\r\n");
            webProj.Append("        </IISUrl>\r\n");
            webProj.Append("          <NTLMAuthentication>False</NTLMAuthentication>\r\n");
            webProj.Append("          <UseCustomServer>False</UseCustomServer>\r\n");
            webProj.Append("          <CustomServerUrl>\r\n");
            webProj.Append("          </CustomServerUrl>\r\n");
            webProj.Append("          <SaveServerSettingsInUserFile>False</SaveServerSettingsInUserFile>\r\n");
            webProj.Append("       </WebProjectProperties>\r\n");
            webProj.Append("      </FlavorProperties>\r\n");
            webProj.Append("    </VisualStudio>\r\n");
            webProj.Append("  </ProjectExtensions>\r\n");
            webProj.Append(" <!-- To modify your build process, add your task inside one of the targets below and uncomment it. \r\n");
            webProj.Append("      Other similar extension points exist, see Microsoft.Common.targets.\r\n");
            webProj.Append("  <Target Name=\"BeforeBuild\">\r\n");
            webProj.Append("  </Target>\r\n");
            webProj.Append(" <Target Name=\"AfterBuild\">\r\n");
            webProj.Append(" </Target>\r\n");
            webProj.Append(" -->\r\n");
            #endregion

            webProj.Append("</Project>");
            return webProj.ToString();
        }

        public static string CreateProject_Wizard_csproj(Hashtable hash)
        {
            StringBuilder entityProj = new StringBuilder();
            #region Start
            entityProj.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            entityProj.Append("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n");
            entityProj.Append("<PropertyGroup>\r\n");
            entityProj.Append("  <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n");
            entityProj.Append("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>\r\n");
            entityProj.Append("    <ProductVersion>8.0.30703</ProductVersion>\r\n");
            entityProj.Append("    <SchemaVersion>2.0</SchemaVersion>\r\n");
            entityProj.Append("    <ProjectGuid>{" + hash["wizardGuid"] + "}</ProjectGuid>\r\n");
            entityProj.Append("    <OutputType>Library</OutputType>\r\n");
            entityProj.Append("    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n");
            entityProj.Append("    <RootNamespace>" + hash["wizardName"] + "</RootNamespace>\r\n");
            entityProj.Append("    <AssemblyName>" + hash["wizardName"] + "</AssemblyName>\r\n");
            entityProj.Append("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>\r\n");
            entityProj.Append("    <FileAlignment>512</FileAlignment>\r\n");
            //entityProj.Append("    <SccProjectName>SAK</SccProjectName>\r\n"); //VSS绑定
            //entityProj.Append("    <SccLocalPath>SAK</SccLocalPath>\r\n");
            //entityProj.Append("    <SccAuxPath>SAK</SccAuxPath>\r\n");
            //entityProj.Append("    <SccProvider>SAK</SccProvider>");
            entityProj.Append("  </PropertyGroup>\r\n");
            entityProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\r\n");
            entityProj.Append("     <DebugSymbols>true</DebugSymbols>\r\n");
            entityProj.Append("     <DebugType>full</DebugType>\r\n");
            entityProj.Append("     <Optimize>false</Optimize>\r\n");
            entityProj.Append("     <OutputPath>bin\\</OutputPath>\r\n");
            entityProj.Append("     <DefineConstants>DEBUG;TRACE</DefineConstants>\r\n");
            entityProj.Append("     <ErrorReport>prompt</ErrorReport>\r\n");
            entityProj.Append("     <WarningLevel>4</WarningLevel>\r\n");
            entityProj.Append("  </PropertyGroup>\r\n");
            entityProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">\r\n");
            entityProj.Append("    <DebugType>pdbonly</DebugType>\r\n");
            entityProj.Append("    <Optimize>true</Optimize>\r\n");
            entityProj.Append("   <OutputPath>bin\\</OutputPath>\r\n");
            entityProj.Append("   <DefineConstants>TRACE</DefineConstants>\r\n");
            entityProj.Append("    <ErrorReport>prompt</ErrorReport>\r\n");
            entityProj.Append("    <WarningLevel>4</WarningLevel>\r\n");
            entityProj.Append("  </PropertyGroup>\r\n");
            #endregion

            #region References
            entityProj.Append("  <ItemGroup>\r\n");
            entityProj.Append("   <Reference Include=\"System\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Data\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Core\" />\r\n");
            entityProj.Append("   <Reference Include=\"Microsoft.CSharp\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Data.DataSetExtensions\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Xml.Linq\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Data.OracleClient\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Data.SQLite\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Xml\" />\r\n");
            entityProj.Append(" </ItemGroup>\r\n");
            #endregion

            #region Content
            entityProj.Append(" <ItemGroup>\r\n");
            entityProj.Append("   <Compile Include=\"DataOper\\IDataHelper.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"DataOper\\SqlHelper.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"DataOper\\OracleHelper.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"DataOper\\SqliteHelper.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"LogMgr\\LogHelper.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"LogMgr\\LogModel.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"Properties\\AssemblyInfo.cs\" />\r\n");
            entityProj.Append("  </ItemGroup>\r\n");
            #endregion

            #region End
            entityProj.Append(" <ItemGroup>\r\n");
            entityProj.Append("  </ItemGroup>\r\n");
            entityProj.Append(" <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n");


            entityProj.Append(" <!-- To modify your build process, add your task inside one of the targets below and uncomment it. \r\n");
            entityProj.Append("      Other similar extension points exist, see Microsoft.Common.targets.\r\n");
            entityProj.Append("  <Target Name=\"BeforeBuild\">\r\n");
            entityProj.Append("  </Target>\r\n");
            entityProj.Append(" <Target Name=\"AfterBuild\">\r\n");
            entityProj.Append(" </Target>\r\n");
            entityProj.Append(" -->\r\n");
            entityProj.Append("</Project>\r\n");
            #endregion

            return entityProj.ToString();
        }

        public static string CreateProject_BLL_csproj(Hashtable hash)
        {
            StringBuilder bllProj = new StringBuilder();
            #region Common
            bllProj.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            bllProj.Append("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n");
            bllProj.Append("<PropertyGroup>\r\n");
            bllProj.Append("  <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n");
            bllProj.Append("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>\r\n");
            bllProj.Append("    <ProductVersion>8.0.30703</ProductVersion>\r\n");
            bllProj.Append("    <SchemaVersion>2.0</SchemaVersion>\r\n");
            bllProj.Append("    <ProjectGuid>{" + hash["bllGuid"] + "}</ProjectGuid>\r\n");
            bllProj.Append("    <OutputType>Library</OutputType>\r\n");
            bllProj.Append("    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n");
            bllProj.Append("    <RootNamespace>" + hash["bllName"] + "</RootNamespace>\r\n");
            bllProj.Append("    <AssemblyName>" + hash["bllName"] + "</AssemblyName>\r\n");
            bllProj.Append("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>\r\n");
            bllProj.Append("    <FileAlignment>512</FileAlignment>\r\n");
            //entityProj.Append("    <SccProjectName>SAK</SccProjectName>\r\n"); //VSS绑定
            //entityProj.Append("    <SccLocalPath>SAK</SccLocalPath>\r\n");
            //entityProj.Append("    <SccAuxPath>SAK</SccAuxPath>\r\n");
            //entityProj.Append("    <SccProvider>SAK</SccProvider>");
            bllProj.Append("  </PropertyGroup>\r\n");
            bllProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\r\n");
            bllProj.Append("     <DebugSymbols>true</DebugSymbols>\r\n");
            bllProj.Append("     <DebugType>full</DebugType>\r\n");
            bllProj.Append("     <Optimize>false</Optimize>\r\n");
            bllProj.Append("     <OutputPath>bin\\</OutputPath>\r\n");
            bllProj.Append("     <DefineConstants>DEBUG;TRACE</DefineConstants>\r\n");
            bllProj.Append("     <ErrorReport>prompt</ErrorReport>\r\n");
            bllProj.Append("     <WarningLevel>4</WarningLevel>\r\n");
            bllProj.Append("  </PropertyGroup>\r\n");
            bllProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">\r\n");
            bllProj.Append("    <DebugType>pdbonly</DebugType>\r\n");
            bllProj.Append("    <Optimize>true</Optimize>\r\n");
            bllProj.Append("   <OutputPath>bin\\</OutputPath>\r\n");
            bllProj.Append("   <DefineConstants>TRACE</DefineConstants>\r\n");
            bllProj.Append("    <ErrorReport>prompt</ErrorReport>\r\n");
            bllProj.Append("    <WarningLevel>4</WarningLevel>\r\n");
            bllProj.Append("  </PropertyGroup>\r\n");
            #endregion
            #region Reference
            bllProj.Append("  <ItemGroup>\r\n");
            bllProj.Append("   <Reference Include=\"System\" />\r\n");
            bllProj.Append("   <Reference Include=\"System.Data\" />\r\n");
            bllProj.Append("   <Reference Include=\"System.Core\" />\r\n");
            bllProj.Append("   <Reference Include=\"Microsoft.CSharp\" />\r\n");
            bllProj.Append("   <Reference Include=\"System.Data.DataSetExtensions\" />\r\n");
            bllProj.Append("   <Reference Include=\"System.Xml.Linq\" />\r\n");
            bllProj.Append("   <Reference Include=\"System.Xml\" />\r\n");
            bllProj.Append(" </ItemGroup>\r\n");
            #endregion
            #region Compile
            bllProj.Append(" <ItemGroup>\r\n");
            //Cs Begin
            bllProj.Append("   <Compile Include=\"Properties\\AssemblyInfo.cs\" />\r\n");
            bllProj.Append("   <Compile Include=\"MainBLL.cs\" />\r\n");
            //End
            bllProj.Append("  </ItemGroup>\r\n");
            #endregion



            #region ProjectReference
            bllProj.Append(" <ItemGroup>\r\n");
            bllProj.Append("  <ProjectReference Include=\"..\\" + hash["dalName"] + ".csproj\">\r\n");
            bllProj.Append("    <Project>{" + hash["dalGuid"] + "}</Project>\r\n");
            bllProj.Append("    <Name>" + hash["dalName"] + "</Name>\r\n");
            bllProj.Append("  </ProjectReference>\r\n");
            bllProj.Append("  <ProjectReference Include=\"..\\" + hash["entityName"] + ".csproj\">\r\n");
            bllProj.Append("  <Project>{" + hash["entityGuid"] + "}</Project>\r\n");
            bllProj.Append("   <Name>" + hash["entityName"] + "</Name>\r\n");
            bllProj.Append("  </ProjectReference>\r\n");

            bllProj.Append("  </ItemGroup>\r\n");
            #endregion



            bllProj.Append(" <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n");

            #region Foot
            bllProj.Append(" <!-- To modify your build process, add your task inside one of the targets below and uncomment it. \r\n");
            bllProj.Append("      Other similar extension points exist, see Microsoft.Common.targets.\r\n");
            bllProj.Append("  <Target Name=\"BeforeBuild\">\r\n");
            bllProj.Append("  </Target>\r\n");
            bllProj.Append(" <Target Name=\"AfterBuild\">\r\n");
            bllProj.Append(" </Target>\r\n");
            bllProj.Append(" -->\r\n");
            bllProj.Append("</Project>\r\n");
            #endregion

            return bllProj.ToString();
        }

        public static string CreateProject_DAL_csproj(Hashtable hash)
        {
            StringBuilder dalProj = new StringBuilder();
            #region Head
            dalProj.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            dalProj.Append("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n");
            dalProj.Append("<PropertyGroup>\r\n");
            dalProj.Append("  <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n");
            dalProj.Append("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>\r\n");
            dalProj.Append("    <ProductVersion>8.0.30703</ProductVersion>\r\n");
            dalProj.Append("    <SchemaVersion>2.0</SchemaVersion>\r\n");
            dalProj.Append("    <ProjectGuid>{" + hash["dalGuid"] + "}</ProjectGuid>\r\n");
            dalProj.Append("    <OutputType>Library</OutputType>\r\n");
            dalProj.Append("    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n");
            dalProj.Append("    <RootNamespace>" + hash["dalName"] + "</RootNamespace>\r\n");
            dalProj.Append("    <AssemblyName>" + hash["dalName"] + "</AssemblyName>\r\n");
            dalProj.Append("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>\r\n");
            dalProj.Append("    <FileAlignment>512</FileAlignment>\r\n");
            //entityProj.Append("    <SccProjectName>SAK</SccProjectName>\r\n"); //VSS绑定
            //entityProj.Append("    <SccLocalPath>SAK</SccLocalPath>\r\n");
            //entityProj.Append("    <SccAuxPath>SAK</SccAuxPath>\r\n");
            //entityProj.Append("    <SccProvider>SAK</SccProvider>");
            dalProj.Append("  </PropertyGroup>\r\n");
            dalProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\r\n");
            dalProj.Append("     <DebugSymbols>true</DebugSymbols>\r\n");
            dalProj.Append("     <DebugType>full</DebugType>\r\n");
            dalProj.Append("     <Optimize>false</Optimize>\r\n");
            dalProj.Append("     <OutputPath>bin\\</OutputPath>\r\n");
            dalProj.Append("     <DefineConstants>DEBUG;TRACE</DefineConstants>\r\n");
            dalProj.Append("     <ErrorReport>prompt</ErrorReport>\r\n");
            dalProj.Append("     <WarningLevel>4</WarningLevel>\r\n");
            dalProj.Append("  </PropertyGroup>\r\n");
            dalProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">\r\n");
            dalProj.Append("    <DebugType>pdbonly</DebugType>\r\n");
            dalProj.Append("    <Optimize>true</Optimize>\r\n");
            dalProj.Append("   <OutputPath>bin\\</OutputPath>\r\n");
            dalProj.Append("   <DefineConstants>TRACE</DefineConstants>\r\n");
            dalProj.Append("    <ErrorReport>prompt</ErrorReport>\r\n");
            dalProj.Append("    <WarningLevel>4</WarningLevel>\r\n");
            dalProj.Append("  </PropertyGroup>\r\n");
            dalProj.Append("  <ItemGroup>\r\n");
            //entityProj.Append("   <Reference Include=\"" + hash["entityName"] + "\" />\r\n");
            dalProj.Append("   <Reference Include=\"System\" />\r\n");
            dalProj.Append("   <Reference Include=\"System.Data\" />\r\n");
            dalProj.Append("   <Reference Include=\"System.Core\" />\r\n");
            dalProj.Append("   <Reference Include=\"Microsoft.CSharp\" />\r\n");
            dalProj.Append("   <Reference Include=\"System.Data.DataSetExtensions\" />\r\n");
            dalProj.Append("   <Reference Include=\"System.Xml.Linq\" />\r\n");
            dalProj.Append("   <Reference Include=\"System.Xml\" />\r\n");
            dalProj.Append(" </ItemGroup>\r\n");
            #endregion
            dalProj.Append(" <ItemGroup>\r\n");
            //类 Begin
            dalProj.Append("   <Compile Include=\"Properties\\AssemblyInfo.cs\" />\r\n");
            dalProj.Append("    <Compile Include=\"BaseDAL.cs\" />\r\n");
            dalProj.Append("    <Compile Include=\"MainDAL.cs\" />\r\n");
            //end
            dalProj.Append(" </ItemGroup>\r\n");
            dalProj.Append(" <ItemGroup>\r\n");
            dalProj.Append("  <ProjectReference Include=\"..\\" + hash["entityName"] + ".csproj\">\r\n");
            dalProj.Append("  <Project>{" + hash["entityGuid"] + "}</Project>\r\n");
            dalProj.Append("   <Name>" + hash["entityName"] + "</Name>\r\n");
            dalProj.Append("  </ProjectReference>\r\n");

            dalProj.Append("  <ProjectReference Include=\"..\\" + hash["wizardName"] + ".csproj\">\r\n");
            dalProj.Append("  <Project>{" + hash["wizardGuid"] + "}</Project>\r\n");
            dalProj.Append("   <Name>" + hash["wizardName"] + "</Name>\r\n");
            dalProj.Append("  </ProjectReference>\r\n");
            dalProj.Append("  </ItemGroup>\r\n");
            dalProj.Append(" <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n");

            #region Foot
            dalProj.Append(" <!-- To modify your build process, add your task inside one of the targets below and uncomment it. \r\n");
            dalProj.Append("      Other similar extension points exist, see Microsoft.Common.targets.\r\n");
            dalProj.Append("  <Target Name=\"BeforeBuild\">\r\n");
            dalProj.Append("  </Target>\r\n");
            dalProj.Append(" <Target Name=\"AfterBuild\">\r\n");
            dalProj.Append(" </Target>\r\n");
            dalProj.Append(" -->\r\n");
            dalProj.Append("</Project>\r\n");
            #endregion

            return dalProj.ToString();
        }

        public static string CreateProject_Entity_csproj(Hashtable hash)
        {
            StringBuilder entityProj = new StringBuilder();
            entityProj.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n");
            entityProj.Append("<Project ToolsVersion=\"4.0\" DefaultTargets=\"Build\" xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">\r\n");
            #region PropertyGroup
            entityProj.Append("<PropertyGroup>\r\n");
            entityProj.Append("  <Configuration Condition=\" '$(Configuration)' == '' \">Debug</Configuration>\r\n");
            entityProj.Append("    <Platform Condition=\" '$(Platform)' == '' \">AnyCPU</Platform>\r\n");
            entityProj.Append("    <ProductVersion>8.0.30703</ProductVersion>\r\n");
            entityProj.Append("    <SchemaVersion>2.0</SchemaVersion>\r\n");
            entityProj.Append("    <ProjectGuid>{" + hash["entityGuid"] + "}</ProjectGuid>\r\n");
            entityProj.Append("    <OutputType>Library</OutputType>\r\n");
            entityProj.Append("    <AppDesignerFolder>Properties</AppDesignerFolder>\r\n");
            entityProj.Append("    <RootNamespace>" + hash["entityName"] + "</RootNamespace>\r\n");
            entityProj.Append("    <AssemblyName>" + hash["entityName"] + "</AssemblyName>\r\n");
            entityProj.Append("    <TargetFrameworkVersion>v4.0</TargetFrameworkVersion>\r\n");
            entityProj.Append("    <FileAlignment>512</FileAlignment>\r\n");
            //entityProj.Append("    <SccProjectName>SAK</SccProjectName>\r\n"); //VSS绑定
            //entityProj.Append("    <SccLocalPath>SAK</SccLocalPath>\r\n");
            //entityProj.Append("    <SccAuxPath>SAK</SccAuxPath>\r\n");
            //entityProj.Append("    <SccProvider>SAK</SccProvider>");
            entityProj.Append("  </PropertyGroup>\r\n");
            #endregion
            #region PropertyGroup
            entityProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' \">\r\n");
            entityProj.Append("     <DebugSymbols>true</DebugSymbols>\r\n");
            entityProj.Append("     <DebugType>full</DebugType>\r\n");
            entityProj.Append("     <Optimize>false</Optimize>\r\n");
            entityProj.Append("     <OutputPath>bin\\</OutputPath>\r\n");
            entityProj.Append("     <DefineConstants>DEBUG;TRACE</DefineConstants>\r\n");
            entityProj.Append("     <ErrorReport>prompt</ErrorReport>\r\n");
            entityProj.Append("     <WarningLevel>4</WarningLevel>\r\n");
            entityProj.Append("  </PropertyGroup>\r\n");
            #endregion
            #region PropertyGroup
            entityProj.Append("  <PropertyGroup Condition=\" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' \">\r\n");
            entityProj.Append("    <DebugType>pdbonly</DebugType>\r\n");
            entityProj.Append("    <Optimize>true</Optimize>\r\n");
            entityProj.Append("   <OutputPath>bin\\</OutputPath>\r\n");
            entityProj.Append("   <DefineConstants>TRACE</DefineConstants>\r\n");
            entityProj.Append("    <ErrorReport>prompt</ErrorReport>\r\n");
            entityProj.Append("    <WarningLevel>4</WarningLevel>\r\n");
            entityProj.Append("  </PropertyGroup>\r\n");
            #endregion
            #region ItemGroup
            entityProj.Append("  <ItemGroup>\r\n");
            entityProj.Append("   <Reference Include=\"System\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Data\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Core\" />\r\n");
            entityProj.Append("   <Reference Include=\"Microsoft.CSharp\" />\r\n");
            entityProj.Append("  <Reference Include=\"System.Data.DataSetExtensions\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Xml.Linq\" />\r\n");
            entityProj.Append("   <Reference Include=\"System.Xml\" />\r\n");
            entityProj.Append(" </ItemGroup>\r\n");

            #endregion
            #region ItemGroup
            entityProj.Append(" <ItemGroup>\r\n");
            entityProj.Append("  <Compile Include=\"BaseEntity.cs\" />\r\n");
            entityProj.Append("  <Compile Include=\"Result.cs\" />\r\n");
            entityProj.Append("   <Compile Include=\"Properties\\AssemblyInfo.cs\" />\r\n");
            entityProj.Append("  </ItemGroup>\r\n");
            #endregion
            entityProj.Append(" <ItemGroup>\r\n");
            entityProj.Append("  </ItemGroup>\r\n");
            entityProj.Append(" <Import Project=\"$(MSBuildBinPath)\\Microsoft.CSharp.targets\" />\r\n");


            entityProj.Append(" <!-- To modify your build process, add your task inside one of the targets below and uncomment it. \r\n");
            entityProj.Append("      Other similar extension points exist, see Microsoft.Common.targets.\r\n");
            entityProj.Append("  <Target Name=\"BeforeBuild\">\r\n");
            entityProj.Append("  </Target>\r\n");
            entityProj.Append(" <Target Name=\"AfterBuild\">\r\n");
            entityProj.Append(" </Target>\r\n");
            entityProj.Append(" -->\r\n");
            entityProj.Append("</Project>\r\n");
            return entityProj.ToString();
        }

    }
    internal partial class ProjConfig
    {
        private static string CreateFolder()
        {
            StringBuilder folder = new StringBuilder();
            folder.Append("<ItemGroup>\r\n");
            folder.Append("  <Folder Include=\"resource\\images\\\" />");
            folder.Append("  <Folder Include=\"resource\\imgs\\\" />");
            folder.Append("  <Folder Include=\"resource\\FUFiles\\\" />");
            folder.Append("  <Folder Include=\"Config\\\" />");
            folder.Append("</ItemGroup>\r\n");
            return folder.ToString();
        }

        private static string CreatePage()
        {
            StringBuilder page = new StringBuilder();
            page.Append("<ItemGroup>\r\n");

            page.Append("<Content Include=\"Main\\Index.aspx\" />\r\n");
            page.Append("<Content Include=\"Main\\Desk.aspx\" />\r\n");
            page.Append("    <Content Include=\"Main\\Login.aspx\" />\r\n");
            page.Append(CreateCSS());
            page.Append(CreateJS());
            page.Append("    <Content Include=\"UserControl\\Header.ascx\" />\r\n");
            page.Append("    <Content Include=\"UserControl\\Navigator.ascx\" />\r\n");

            page.Append("    <Content Include=\"Default.aspx\" />\r\n");
            //End Pages
            page.Append("    <Content Include=\"Web.config\" />\r\n");
            page.Append("    <Content Include=\"Web.Debug.config\">\r\n");
            page.Append("      <DependentUpon>Web.config</DependentUpon>\r\n");
            page.Append("    </Content>\r\n");
            page.Append("    <Content Include=\"Web.Release.config\">\r\n");
            page.Append("     <DependentUpon>Web.config</DependentUpon>\r\n");
            page.Append("   </Content>\r\n");
            page.Append("</ItemGroup>\r\n");
            return page.ToString();
        }

        private static string CreateCSS()
        {
            StringBuilder css = new StringBuilder();

            //配置端页面
            css.Append("    <Content Include=\"css\\global\\list_default.css\" />\r\n");
            css.Append("    <Content Include=\"css\\global\\control_default.css\" />\r\n");
            css.Append("    <Content Include=\"css\\page\\navcss.css\" />\r\n");
            css.Append("    <Content Include=\"css\\page\\login.css\" />\r\n");

            //前端页面
            css.Append("    <Content Include=\"cssui\\global\\style.css\" />\r\n");
            css.Append("    <Content Include=\"cssui\\global\\global.css\" />\r\n");


            return css.ToString();
        }

        private static string CreateJS()
        {
            StringBuilder js = new StringBuilder();
            js.Append("    <Content Include=\"js\\global\\jquery.min.js\" />\r\n");
            js.Append("    <Content Include=\"js\\global\\listpage.js\" />\r\n");
            js.Append("    <Content Include=\"js\\page\\login.js\" />\r\n");

            return js.ToString();
        }
    }
}

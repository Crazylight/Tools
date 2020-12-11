using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using LayersProductor;
using UIProductor;
using UIProductor.Page;
using System.Collections.ObjectModel;
using System.IO;

namespace iCoder.Views
{
    class TreeViewNode
    {
        public string Name { get; set; }

        //  public ObservableCollection<TreeViewNode
    }
    /// <summary>
    /// Interaction logic for LaywersCreater.xaml
    /// </summary>
    public partial class LaywersCreater : Window
    {
        public LaywersCreater()
        {
            InitializeComponent();
            this.RBtnLay.Checked += new RoutedEventHandler(RBtnLay_Checked);
            this.RBtnUI.Checked += new RoutedEventHandler(RBtnUI_Checked);
            DoInit();
        }

        private void RBtnLay_Checked(object sender, RoutedEventArgs e)
        {
            StackPageType.Visibility = System.Windows.Visibility.Hidden;
        }

        private void RBtnUI_Checked(object sender, RoutedEventArgs e)
        {
            StackPageType.Visibility = System.Windows.Visibility.Visible;
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TcControls.Items.Clear();

                CreateAllLayers(CreateModel());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Private Methods
        /// <summary>
        /// Does the init.
        /// </summary>
        private void DoInit()
        {
            SqlCommand comm = new SqlCommand();
            comm.Connection = Constant.Constant.Conn;

            comm.CommandText = "select name from sys.tables ORDER BY NAME";

            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                ObservableCollection<TreeViewNode> nodes = new System.Collections.ObjectModel.ObservableCollection<TreeViewNode>();

                TreeViewItem item = new TreeViewItem()
                {
                    Header = comm.Connection.Database,
                    DisplayMemberPath = "Name",
                    ToolTip = comm.Connection.Database,
                    IsExpanded = true
                }; //Header显示出来的值； DisplayMemberPath子集合显示的属性； tooltip鼠标移上显示的值

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TreeViewNode node = new TreeViewNode();
                    node.Name = dt.Rows[i]["name"].ToString();
                    nodes.Add(node);

                }

                item.ItemsSource = nodes;
                TvTables.Items.Add(item);
            }
        }

        /// <summary>
        /// Gets the dt.
        /// </summary>
        /// <returns></returns>
        private DataTable GetDtFields(string tableName)
        {
            DataTable dt = new DataTable();
            SqlCommand comm = new SqlCommand();
            comm.Connection = Constant.Constant.Conn;
            comm.CommandText = "SELECT A.NAME NAME , B.NAME TYPE, is_identity,A.is_nullable,  A.MAX_LENGTH LENGTH FROM SYS.COLUMNS A, SYS.TYPES B WHERE A.SYSTEM_TYPE_ID = B.SYSTEM_TYPE_ID AND B.NAME != 'SYSNAME' AND A.OBJECT_ID = (SELECT OBJECT_ID FROM SYS.TABLES WHERE NAME = '" + tableName + "')  ORDER BY A.COLUMN_ID";
            using (SqlDataAdapter da = new SqlDataAdapter(comm))
            {
                da.Fill(dt);
            }
            dt.TableName = tableName;

            return dt;
        }

        private void CreateAllLayers(ConditionModel model)
        {
            TreeViewItem item = TvTables.SelectedItem as TreeViewItem;

            if (item != null)
            {
                model.Table = GetDtFields(Constant.Constant.TableName);

                ObservableCollection<TreeViewNode> source = item.ItemsSource as ObservableCollection<TreeViewNode>;
                foreach (TreeViewNode node in source)
                {
                    model.EntityName = node.Name.Trim();
                    if (TbEntityName.Text.Length > 0)
                    {
                        model.EntityName = this.TbEntityName.Text;
                    }
                    if (TbNameSpace.Text.Length > 0)
                    {
                        model.NameSpace = TbNameSpace.Text;
                    }
                    else
                    {

                        model.NameSpace = Constant.Constant.DataBase + ".Web";
                    }

                    if (RBtnLay.IsChecked == true)
                    {
                        CreateLayersTabItem(model);
                    }
                    else if (RBtnMvc.IsChecked == true)
                    {
                    }
                    else if (RBtnProc.IsChecked == true)
                    {
                        CreateProcTabItem();
                    }
                    else if (RBtnProcCaller.IsChecked == true)
                    {
                        CreateProcCallerTabItem();
                    }
                    else
                    {
                        CreateUI(model);
                    }
                }
            }
            else
            {
                TreeViewNode node = TvTables.SelectedItem as TreeViewNode;
                CreateOneLayer(node, model);
            }
        }

        private void CreateOneLayer(TreeViewNode node, ConditionModel model)
        {
            Constant.Constant.TableName = node.Name;

            model.EntityName = node.Name;
            model.Table = GetDtFields(node.Name);
            if (TbEntityName.Text.Length > 0)
            {
                model.EntityName = this.TbEntityName.Text;
            }
            if (TbNameSpace.Text.Length > 0)
            {
                model.NameSpace = TbNameSpace.Text;
            }

            if (RBtnLay.IsChecked == true)
            {
                CreateLayersTabItem(model);
            }
            else if (RBtnProc.IsChecked == true)
            {
                CreateProcTabItem();
            }
            else if (RBtnMvc.IsChecked == true)
            {
                CreateProcTabMVC(model);
            }
            else if (RBtnProcCaller.IsChecked == true)
            {
                CreateProcCallerTabItem();
            }
            else if (this.RBtnAPIUI.IsChecked == true)
            {
                Func<ConditionModel, string> funHtml = UIStart.getInstance(model).CreatePageUIByType;
                Func<ConditionModel, string> funCs = UIStart.getInstance(model).CreatePageCSByType;

                TcControls.Items.Clear();
                TcControls.Items.Add(CreateUITabItem("列表页面", model, ePageType.ApiViewPage, funHtml));
                TcControls.Items.Add(CreateUITabItem("编辑页面", model, ePageType.ApiEditPage, funHtml));
                TcControls.Items.Add(CreateUITabItem("列表编辑页面", model, ePageType.ApiViewEditPage, funHtml));

                TcControls.Items.Add(CreateUITabItem("ashx", model, ePageType.Ashx, funCs));

            }
            else
            {
                CreateUI(model);
            }
        }
        #endregion

        #region 创建Tab
        private void CreateLayersTabItem(ConditionModel model)
        {
            // TcControls.Items.Add(CreateUITabItem("DAL", Facade.GenerateDAL(GetDt(), nameSpace, entityName)));

            TcControls.Items.Add(CreateUITabItem(model.EntityName + "Entity", Facade.GenerateEntity(GetDtFields(Constant.Constant.TableName), model.EntityName + ".Entity", model.EntityName)));
            TcControls.Items.Add(CreateUITabItem(model.EntityName + "DAL", Facade.GenerateDAL(GetDtFields(Constant.Constant.TableName), model.NameSpace, model.EntityName)));
            TcControls.Items.Add(CreateUITabItem(model.EntityName + "BLL", Facade.GenerateBLL(GetDtFields(Constant.Constant.TableName), model.NameSpace, model.EntityName)));

        }

        private void CreateUI(ConditionModel model)
        {
            Func<ConditionModel, string> funHtml = UIStart.getInstance(model).CreatePageUIByType;
            Func<ConditionModel, string> funCs = UIStart.getInstance(model).CreatePageCSByType;

            #region TCControls
            if (RbtnListAndEdit.IsChecked == true)
            {
                TcControls.Items.Clear();
                TcControls.Items.Add(CreateUITabItem("ViewPageHtml", model, ePageType.ViewPage, funHtml));
                TcControls.Items.Add(CreateUITabItem("VIewPageCs", model, ePageType.ViewPage, funCs));
                TcControls.Items.Add(CreateUITabItem("EditPageHtml", model, ePageType.EditPage, funHtml));
                TcControls.Items.Add(CreateUITabItem("EditPageCs", model, ePageType.EditPage, funCs));

            }
            else if (RbtnListEditListBox.IsChecked == true)
            {
                TcControls.Items.Clear();
                TcControls.Items.Add(CreateUITabItem("简单编辑页面HTML", model, ePageType.ViewEditPageListBox, funHtml));
                TcControls.Items.Add(CreateUITabItem("简单编辑页面CS", model, ePageType.ViewEditPageListBox, funCs));


            }
            else if (RbtnListEditRepeater.IsChecked == true)
            {
                TcControls.Items.Clear();
                TcControls.Items.Add(CreateUITabItem("编辑页面HTML", model, ePageType.ViewEditPageRepeater, funHtml));
                TcControls.Items.Add(CreateUITabItem("编辑页面CS", model, ePageType.ViewEditPageRepeater, funCs));

            }
            #endregion
        }

        private TabItem CreateUITabItem(string tabItemTitle, ConditionModel model, ePageType type, Func<ConditionModel, string> fun)
        {
            model.PageType = type;

            TabItem tabItem = new TabItem();
            tabItem.Header = tabItemTitle;
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Height = 450;
            richTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            richTextBox.AppendText(fun.Invoke(model));
            tabItem.Content = richTextBox;

            return tabItem;
        }

        private TabItem CreateUITabItem(string tabItemTitle, string content)
        {
            TabItem tabItem = new TabItem();
            tabItem.Header = tabItemTitle;
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.Height = 450;
            richTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            richTextBox.AppendText(content);
            tabItem.Content = richTextBox;

            return tabItem;
        }

        private void CreateProcTabItem()
        {
            TcControls.Items.Add(CreateUITabItem("procAdd" + Constant.Constant.TableName, Facade.GenerateProcAdd(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procAddOrUpdate" + Constant.Constant.TableName, Facade.GenerateProcAddOrUpdate(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procUpdate" + Constant.Constant.TableName, Facade.GenerateProcUpdate(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procGetAll" + Constant.Constant.TableName, Facade.GenerateProcGetAll(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procGetByID" + Constant.Constant.TableName, Facade.GenerateProcGetByID(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procDelByID" + Constant.Constant.TableName, Facade.GenerateProcDelByID(GetDtFields(Constant.Constant.TableName))));

        }


        private void CreateProcTabMVC(ConditionModel model)
        {
            TcControls.Items.Add(CreateUITabItem(model.EntityName + "Model", Facade.CreateMVCModel(GetDtFields(Constant.Constant.TableName), model.EntityName + ".Model", model.EntityName)));
        }
        private void CreateProcCallerTabItem()
        {
            TcControls.Items.Add(CreateUITabItem("procCallerRow" + Constant.Constant.TableName, Facade.GenerateProcCaller_Row(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procCallerEntity" + Constant.Constant.TableName, Facade.GenerateProcCaller_Entity(GetDtFields(Constant.Constant.TableName))));
            TcControls.Items.Add(CreateUITabItem("procCallerParameter" + Constant.Constant.TableName, Facade.GenerateProcCaller_Parameter(GetDtFields(Constant.Constant.TableName))));
        }
        #endregion

        #region 创建文件
        private void CreateLayersFiles(ConditionModel model)
        {

            Func<ConditionModel, string> funHtml = UIStart.getInstance(model).CreatePageUIByType;
            Func<ConditionModel, string> funCs = UIStart.getInstance(model).CreatePageCSByType;
            string dicPath = AppDomain.CurrentDomain.BaseDirectory; ;
            #region TCControls
            if (RbtnListAndEdit.IsChecked == true)
            {
                CreateFile(dicPath, "ListPageHtml", ePageType.ViewPage, funHtml);
                CreateFile(dicPath, "ListPageCs", ePageType.ViewPage, funCs);
                CreateFile(dicPath, "EditPageHtml", ePageType.EditPage, funHtml);
                CreateFile(dicPath, "EditPageCs", ePageType.EditPage, funCs);

            }
            else if (RbtnListEditListBox.IsChecked == true)
            {
                CreateFile(dicPath, "简单编辑页面HTML", ePageType.ViewEditPageListBox, funHtml);
                CreateFile(dicPath, "简单编辑页面", ePageType.ViewEditPageListBox, funCs);


            }
            else if (RbtnListEditRepeater.IsChecked == true)
            {
                CreateFile(dicPath, "简单编辑页面HTML", ePageType.ViewEditPageRepeater, funHtml);
                CreateFile(dicPath, "简单编辑页面", ePageType.ViewEditPageRepeater, funCs);
            }
            #endregion
        }
        private void CreateFile(string dicPath, string fileName, ePageType type, Func<ConditionModel, string> fun)
        {
            if (dicPath.Length == 0 || fileName.Length == 0)
            {
                return;
            }
            ConditionModel model = new ConditionModel() { PageType = type };
            StreamWriter sw = File.CreateText(dicPath + "//" + fileName);
            sw.Write(fun.Invoke(model));
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        private void CreateFile(string dicPath, string fileName, string content)
        {
            if (dicPath.Length == 0 || fileName.Length == 0)
            {
                return;
            }
            StreamWriter sw = File.CreateText(dicPath + "//" + fileName);
            sw.Write(content);
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }
        #endregion

        private ConditionModel CreateModel()
        {

            return new ConditionModel()
            {
                NameSpace = Constant.Constant.DataBase,
                IsDOL = false
            };
        }

        private void BtnCreateExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

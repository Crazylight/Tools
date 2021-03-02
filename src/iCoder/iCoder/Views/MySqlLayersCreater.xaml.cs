using DataOper;
using LayersProductor.MySql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UIProductor;

namespace iCoder.Views
{
	/// <summary>
	/// MySqlLayersCreater.xaml 的交互逻辑
	/// </summary>
	public partial class MySqlLayersCreater : Window
	{
		public MySqlLayersCreater()
		{
			InitializeComponent();
			DoInit();
		}

		private void BtnCreate_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				TcControls.Items.Clear();

				CreateAllLayers(new ConditionModel() { NameSpace = Constant.Constant.DataBase });
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

			ObservableCollection<TreeViewNode> nodes = new System.Collections.ObjectModel.ObservableCollection<TreeViewNode>();
			var dt = MySqlHelper.GetDtNames(Constant.Constant.MySqlConn);
			TreeViewItem item = new TreeViewItem()
			{
				Header = Constant.Constant.MySqlConn.Database,
				DisplayMemberPath = "Name",
				ToolTip = Constant.Constant.MySqlConn.Database,
				IsExpanded = true
			}; //Header显示出来的值； DisplayMemberPath子集合显示的属性； tooltip鼠标移上显示的值

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				TreeViewNode node = new TreeViewNode();
				node.Name = dt.Rows[i]["Tables_in_" + Constant.Constant.MySqlConn.Database].ToString();
				nodes.Add(node);

			}

			item.ItemsSource = nodes;
			TvTables.Items.Add(item);
		}

		private void CreateAllLayers(ConditionModel model)
		{
			TreeViewItem item = TvTables.SelectedItem as TreeViewItem;

			if (item != null)
			{
				#region 整个库
				model.Table = MySqlHelper.GetDtFields(Constant.Constant.MySqlConn, Constant.Constant.TableName);

				ObservableCollection<TreeViewNode> source = item.ItemsSource as ObservableCollection<TreeViewNode>;
				foreach (TreeViewNode node in source)
				{
					model.EntityName = node.Name.Trim();
					//if (TbEntityName.Text.Length > 0)
					//{
					//	model.EntityName = this.TbEntityName.Text;
					//}
					//if (TbNameSpace.Text.Length > 0)
					//{
					//	model.NameSpace = TbNameSpace.Text;
					//}
					//else
					//{

					//	model.NameSpace = Constant.Constant.DataBase + ".Web";
					//}

					//if (RBtnLay.IsChecked == true)
					//{
					//	CreateLayersTabItem(model);
					//}
					//else if (RBtnMvc.IsChecked == true)
					//{
					//}
					//else if (RBtnProc.IsChecked == true)
					//{
					//	CreateProcTabItem();
					//}
					//else if (RBtnProcCaller.IsChecked == true)
					//{
					//	CreateProcCallerTabItem();
					//}
					//else
					//{
					//	CreateUI(model);
					//}
				}
				#endregion
			}
			else
			{
				#region 单个表
				TreeViewNode node = TvTables.SelectedItem as TreeViewNode;
				model.EntityName = node.Name;
				model.Table = MySqlHelper.GetDtFields(Constant.Constant.MySqlConn, node.Name);


				#region Entity
				TabItem tabItemEntity = new TabItem() { Header="Entity"};
				RichTextBox rtbEntity = new RichTextBox();
				rtbEntity.Height = 450;
				rtbEntity.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
				rtbEntity.VerticalAlignment = VerticalAlignment.Stretch;
				rtbEntity.AppendText(MySqlEntity.CreatePublicEntity(model.Table));
				tabItemEntity.Content = rtbEntity;
				TcControls.Items.Add(tabItemEntity);


				#endregion

				#region Add

				TabItem tabItemProc = new TabItem();
				tabItemProc.Header = "存贮过程";
				RichTextBox rtbProc = new RichTextBox();
				rtbProc.Height = 450;
				rtbProc.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
				rtbProc.VerticalAlignment = VerticalAlignment.Stretch;

				rtbProc.AppendText(MySqlProc.CreateProc(model.Table));
				tabItemProc.Content = rtbProc;
				TcControls.Items.Add(tabItemProc);

				#endregion


				#endregion

				//CreateOneLayer(node, model);
			}
		}

		#endregion
	}
}

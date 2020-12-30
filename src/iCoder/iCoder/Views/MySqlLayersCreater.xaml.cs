using DataOper;
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

				#region Add
				StringBuilder sb = new StringBuilder();
				sb.Append($"create database {node.Name}( \r\n ");

				for (int i = 0; i < model.Table.Rows.Count; i++)
				{
					if (i == model.Table.Rows.Count -1)
					{
						sb.Append($"IN p_in_{ model.Table.Rows[i][0].ToString()} { model.Table.Rows[i][1].ToString()} )");
					}
					else
					{
						//sb.Append($"IN p_in_{ model.Table.Rows[i][0].ToString()} { model.Table.Rows[i][1].ToString()},\r\n");
						sb.Append($"IN p_in_{ model.Table.Rows[i][0].ToString()} { model.Table.Rows[i][1].ToString()},");
					}
				}

				TabItem tabItem = new TabItem();
				tabItem.Header = "存贮过程";
				RichTextBox richTextBox = new RichTextBox();
				richTextBox.Height = 450;
				richTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
				richTextBox.VerticalAlignment = VerticalAlignment.Stretch;
				richTextBox.AppendText(sb.ToString());
				tabItem.Content = richTextBox;

				TcControls.Items.Add(tabItem);
				#endregion
				#endregion
				//CreateOneLayer(node, model);
			}
		}

		#endregion
	}
}

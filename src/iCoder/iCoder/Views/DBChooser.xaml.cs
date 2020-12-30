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
using System.Data.SqlClient;
using System.ComponentModel;
using System.Xml;
using System.Data;
using MySql.Data.MySqlClient;

namespace iCoder.Views
{
	/// <summary>
	/// Interaction logic for DBChooser.xaml
	/// </summary>
	public partial class DBChooser : Window
	{
		SqlConnection _conn = new SqlConnection();
		public DBChooser()
		{
			InitializeComponent();
			this.Closed += new EventHandler(DBChooser_Closed);
			// DoInit();
		}

		private void BtnConnect_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (true)
				{

				}
				GetDtConn();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void CmbServer_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.CmbServer.SelectedIndex == 1)
			{
				this.TbUser.Text = "sa";
				this.Pwd.Password = "taotao778899!";
			}
			else if (this.CmbServer.SelectedIndex == 2)
			{
				this.TbUser.Text = "gmghk";
				this.Pwd.Password = "G7gIVYB9Xk^7";
			}
			else if (this.CmbServer.SelectedIndex == 0)
			{
				if (this.TbUser != null)
				{
					this.TbUser.Text = "biz001";
				}
				if (this.Pwd != null)
				{
					this.Pwd.Password = "biz121";
				}
			}
		}

		#region Private Methods

		private void GetDtConn()
		{
			Constant.Constant.Server = this.CmbServer.Text;
			Constant.Constant.User = this.TbUser.Text;
			Constant.Constant.Pwd = Pwd.Password;

			SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
			if (CmbDBType.SelectedIndex < 0)
			{

			}
			else
			{
				//sb.DataSource = "LDQ-PC\\SQLEXPRESS";
				sb.DataSource = this.CmbServer.Text;
				sb.Password = Pwd.Password;
				sb.UserID = this.TbUser.Text;
			}

			try
			{
				if (this.CmbDataBases.Items.Count > 0)
				{
					this.CmbDataBases.ItemsSource = null;
					this.CmbDataBases.Items.Clear();
				}
				if (CmbDBType.SelectedIndex == 1)
				{
					SqlConnection conn = new SqlConnection(sb.ToString());
					this.CmbDataBases.ItemsSource = DataOper.SqlHelper.GetDataBases(conn).DefaultView;
					this.CmbDataBases.DisplayMemberPath = "name";
					this.CmbDataBases.SelectedIndex = 0;
				}
				else
				{
					MySqlConnection conn = new MySqlConnection(sb.ToString());
					this.CmbDataBases.ItemsSource = DataOper.MySqlHelper.GetDataBases(conn).DefaultView;
					this.CmbDataBases.DisplayMemberPath = "Database";
					this.CmbDataBases.SelectedIndex = 0;
				}


			}
			catch (Exception e)
			{
				MessageBox.Show("出错\r\n" + e.Message);
			}
		}
		void DBChooser_Closed(object sender, EventArgs e)
		{
			Application.Current.Shutdown();
		}
		#endregion

		private void BtnCreate_Click(object sender, RoutedEventArgs e)
		{
			if (this.CmbDataBases.SelectedIndex < 0)
			{
				MessageBox.Show("请先选择数据库");
				return;
			}
			Constant.Constant.DataBase = this.CmbDataBases.Text;
			if (CmbDBType.SelectedIndex == 1)
			{
				(new SqlServerLaywersCreater() { WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen }).Show();
			}
			else
			{
				(new MySqlLayersCreater() { WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen }).Show();
			}
		}
	}
}

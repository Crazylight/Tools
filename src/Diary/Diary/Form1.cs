using Diary.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.TbYear.Text = DateTime.Today.ToShortDateString();
		}

		private void BtnCreateDiay_Click(object sender, EventArgs e)
		{
			DateTime date = DateTime.Now;
			if (this.TbYear.Text.Length > 0)
			{
				try
				{
					date = DateTime.Parse(this.TbYear.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show("请输入正确的日期");
					return;
				}
			}

			string filename = $"{ConfigHelper.GetAppSettingString("FilePath")}{date.Year}.xlsx";
			Data.ExcelCreater.GetInstance(date).CreateExcel(filename);

			MessageBox.Show("创建成功", "结果", MessageBoxButtons.OK);
			//FileDialog file = new OpenFileDialog();


		}

		private void BtnPlan_Click(object sender, EventArgs e)
		{

		}

	}
}

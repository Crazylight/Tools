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
using System.Windows.Forms;

namespace iCoder.Views
{
    /// <summary>
    /// Interaction logic for SolutionCreater.xaml
    /// </summary>
    public partial class SolutionCreater : Window
    {
        public SolutionCreater()
        {
            InitializeComponent();
            this.Closed += new EventHandler(SolutionCreater_Closed);
        }

        void SolutionCreater_Closed(object sender, EventArgs e)
        {
            App.Current.MainWindow.Show();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            this.RunPro.Text = "";
            if (TbProjectName.Text.Length == 0)
            {
                this.RunPro.Text = "项目名称不能为空";
                this.RunPro.FontFamily = new FontFamily();
                this.RunPro.FontSize = 16;
                this.RunPro.Foreground = new SolidColorBrush(Colors.Red);
                return;
            }
            CreateProj();
        }

        private void CreateProj()
        {
            string dicPath = "", projName = "";
            projName = string.IsNullOrEmpty(this.TbProjectName.Text) ? "MyApp" : this.TbProjectName.Text; ;

            FolderBrowserDialog dic = new FolderBrowserDialog();
            dic.RootFolder = Environment.SpecialFolder.Desktop;
            dic.ShowNewFolderButton = false;
            dic.Description = "能不能输入选择";
            if (TbAddr.Text.Length > 0)
            {
                dic.SelectedPath = TbAddr.Text;
            }

            if (dic.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dicPath = dic.SelectedPath;

                try
                {
                    this.RunPro.Text = "开始创建……\r\n";
                    ProjectProductor.ProjFacade.getInstance(dicPath, projName).CreateProject();

                    //  ProjectProductor.ProjStart.CreateProjectDirs(this.TbProjectName.Text, dicPath);
                    //  ProjectHelper.CreateProjectDirs(projName, dicPath);
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show("创建出错\r\n" + e.Message, "Warning");
                    return;
                }
                this.RunPro.Text += "创建成功";
            }
            else
            {
                this.RunPro.Text = "创建取消";
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

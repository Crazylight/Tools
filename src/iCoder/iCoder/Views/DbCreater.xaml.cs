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
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace iCoder.Views
{
    /// <summary>
    /// Interaction logic for DbCreater.xaml
    /// </summary>
    public partial class DbCreater : Window
    {
        public DbCreater()
        {
            InitializeComponent();
            this.Closed += new EventHandler(DbCreater_Closed);
        }

        void DbCreater_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = "g:/";

            //  file.Filter = "网页文件(*.htm)|*.htm|*.html|(*.html)|文本文件(*.txt)|*.txt|所有文件(*.*)|*.* ";

            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.LblName.Content = (System.IO.Path.GetFileNameWithoutExtension(file.FileName).ToString());

                //  this.DgV.DataContext = GetDt(file.FileName);
                this.RichTb.Document.Blocks.Clear();

                this.RichTb.AppendText(CreateDataTable(GetSqlDt(file.FileName, this.TbSheet.Text)));
            }
        }

        private string CreateDataTable(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            #region Methods
            try
            {
                int rowIndex = 0;
                string tableName = "";
                while (rowIndex < dt.Rows.Count)
                {
                    string indexTableName = "";
                    if (dt.Columns.Contains("表名称"))
                    {
                        indexTableName = dt.Rows[rowIndex]["表名称"].ToString();
                    }
                    else if (rowIndex == 0)
                    {
                        sb.Append(" CREATE TABLE " + this.TbSheet.Text + "(\r\n");
                        sb.Append("[" + dt.Rows[rowIndex]["字段名称"] + "]");
                        sb.Append("  ");
                        sb.Append(dt.Rows[rowIndex]["类型"]);
                        sb.Append("  IDENTITY(1000,1) PRIMARY KEY");
                        rowIndex++;
                        continue;
                    }

                    if (tableName != indexTableName)
                    {
                        tableName = indexTableName;
                        if (rowIndex > 0)
                        {
                            sb.Append("\r\n);\r\n");
                        }
                        sb.Append(" CREATE TABLE " + tableName + "(\r\n");
                        sb.Append("[" + dt.Rows[rowIndex]["字段名称"] + "]");
                        sb.Append("  ");
                        sb.Append(dt.Rows[rowIndex]["类型"]);
                        sb.Append("  IDENTITY(1000,1) PRIMARY KEY");

                    }
                    else
                    {
                        sb.Append(", \r\n  ");
                        sb.Append("[" + dt.Rows[rowIndex]["字段名称"] + "]");
                        sb.Append("  ");
                        sb.Append(dt.Rows[rowIndex]["类型"]);

                    }
                    rowIndex++;
                }
                sb.Append("\r\n);\r\n");
            }
            catch (Exception e)
            {
				Console.Write(e.ToString());
            }
            #endregion
            return sb.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog file = new SaveFileDialog();
                file.Filter = "文本文件(*.txt)|*.txt|所有文件(*.sql)|*.sql";
                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = file.FileName;
                    if (path.Length > 0)
                    {
                        if (!File.Exists(path))
                        {
                            StreamWriter sw;
                            sw = File.CreateText(path);

                            TextRange textRange = new TextRange(RichTb.Document.ContentStart, RichTb.Document.ContentEnd);

                            sw.WriteLine(textRange.Text);
                            sw.Flush();

                        }
                        else
                        {
                            TextRange textRange = new TextRange(RichTb.Document.ContentStart, RichTb.Document.ContentEnd);

                            File.WriteAllText(path, textRange.Text);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
				Console.Write(ex.ToString());
            }
        }

        private void BtnRead_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.InitialDirectory = "g:/";

                //  file.Filter = "网页文件(*.htm)|*.htm|*.html|(*.html)|文本文件(*.txt)|*.txt|所有文件(*.*)|*.* ";

                if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.LblName.Content = (System.IO.Path.GetFileNameWithoutExtension(file.FileName).ToString());

                    //  this.DgV.DataContext = GetDt(file.FileName);
                    this.RichTb.Document.Blocks.Clear();
                    this.RichTb.AppendText(GetExcleSheet(file.FileName));
                }
            }
            catch (Exception ex)
            {
				Console.Write(ex.ToString());
            }
        }

        #region Private Methods

        private DataTable GetSqlDt(string filename, string sheetName)
        {
            try
            {
                if (sheetName.Length == 0)
                {
                    sheetName = "Sheet1";
                }
                string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + filename + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
                OleDbConnection olecon = new OleDbConnection();
                OleDbDataAdapter myda = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", strConn);
                DataTable table = new DataTable();

                myda.Fill(table);
                return table;
            }
            catch (Exception e)
            {
				System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }

        }
        private string GetExcleSheet(string filename)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + filename + ";Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
                OleDbConnection olecon = new OleDbConnection(strConn);
                olecon.Open();

                DataTable table = olecon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                olecon.Close();
                foreach (DataRow dr in table.Rows)
                {
                    sb.Append(dr[2].ToString() + "\r\n");
                }
            }
            catch (Exception e)
            {
				Console.Write(e.ToString());
                return null;
            }
            return sb.ToString();
        }
        #endregion
    }
}

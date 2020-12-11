using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Diary.Helpers;

namespace Diary.Data
{
	public class ExcelCreaterStudy
	{
		static string filename = ConfigHelper.GetAppSettingString("FilePath");
		public ExcelCreaterStudy()
		{

		}

		public static void CreateExcel()
		{
			if (!File.Exists(filename))
			{
				File.Create(filename);
			}
			Excel.Application xapp = new Excel.ApplicationClass();
			Excel.Workbook book = xapp.Workbooks.Open(filename);

			Excel.Worksheet sheet = new Excel.Worksheet();
			sheet.Cells.AddComment("Comment");
			book.Sheets.Add(sheet);

			book.SaveAs(filename);

		}
		/*
		  Range对象表示一个单元格、一行、一列、包含一个或多个单元格块（可以连续，也可以不连续）的单元格选定范围，甚至多个工作表中的一组单元格。
		 */
		public static void Create()
		{
			object Nothing = System.Reflection.Missing.Value;
			var app = new Excel.Application();
			app.Visible = false;
			Excel.Workbook workBook = app.Workbooks.Add(Nothing);
			Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
			worksheet.Name = "Work";
			worksheet.Cells.ColumnWidth = 168;
			worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 5]).MergeCells = true;//合并单元格
																								//headline  
																								//worksheet.Cells[1, 1] = "FileName";
																								//worksheet.Cells[1, 2] = "FindString";
																								//worksheet.Cells[1, 3] = "ReplaceString";

			Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
			//worksheet.Columns[0]
			rng.Font.Size = 16;//设置单元格字体大小
			rng.Font.Bold = true;//设置单元格字体为粗体
			rng.RowHeight = 40;//设置单元格行高
			rng.Font.Name = "微软雅黑";//设置单元格字体
			rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
			rng.ColumnWidth = 20;//设置单元格列宽
			rng.Borders.ColorIndex = 1;//设置单元格字体颜色。

			DateTime dt = DateTime.Parse("2016-01-01");

			for (int i = 2; i < 31; i++, dt = dt.AddDays(1))
			{
				worksheet.Cells[i, 1] = dt.ToLocalTime().ToShortDateString();
			}

			worksheet.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
			//worksheet.SaveAs(filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
			workBook.Close(false, Type.Missing, Type.Missing);
			app.Quit();
		}

		static void CreateSheet()
		{

		}


		/// <summary>  
		/// open an excel file,then write the content to file  
		/// </summary>  
		/// <param name="FileName">file name</param>  
		/// <param name="findString">first cloumn</param>  
		/// <param name="replaceString">second cloumn</param>  
		private void WriteToExcel(string excelName, string filename, string findString, string replaceString)
		{
			//open  
			object Nothing = System.Reflection.Missing.Value;
			var app = new Excel.Application();
			app.Visible = false;
			Excel.Workbook mybook = app.Workbooks.Open(excelName, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
			Excel.Worksheet mysheet = (Excel.Worksheet)mybook.Worksheets[1];
			mysheet.Activate();
			//get activate sheet max row count  
			int maxrow = mysheet.UsedRange.Rows.Count + 1;
			mysheet.Cells[maxrow, 1] = filename;
			mysheet.Cells[maxrow, 2] = findString;
			mysheet.Cells[maxrow, 3] = replaceString;
			mybook.Save();
			mybook.Close(false, Type.Missing, Type.Missing);
			mybook = null;
			//quit excel app  
			app.Quit();
		}
		//#region Excel定义
		//public static Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
		//public static Microsoft.Office.Interop.Excel._Workbook xBk;
		//public static Microsoft.Office.Interop.Excel._Worksheet xSt = null;
		//public static Microsoft.Office.Interop.Excel.Range rng = null;
		//#endregion
		//public static void Study()
		//{

		//	//冻结前两行
		//	rng = xSt.get_Range("A3", "B5");
		//	rng.Select();
		//	ExcelApp.ActiveWindow.FreezePanes = true;

		//	ExcelApp.Cells[1, 1] = "单元格赋值";
		//	rng = (Microsoft.Office.Interop.Excel.Range)xSt.Cells[1, 1];
		//	xSt.get_Range(ExcelApp.Cells[1, 1], ExcelApp.Cells[2, 1]).MergeCells = true;//合并单元格
		//	rng.Font.Size = 16;//设置单元格字体大小
		//	rng.Font.Bold = true;//设置单元格字体为粗体
		//	rng.RowHeight = 40;//设置单元格行高
		//	rng.Font.Name = "微软雅黑";//设置单元格字体
		//	rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
		//	rng.ColumnWidth = 20;//设置单元格列宽
		//	rng.Borders.ColorIndex = 1;//设置单元格字体颜色。



		//	//设置单元格字体竖直显示
		//	rng = xSt.get_Range("A3", "A5");
		//	rng.Orientation = -4166;
		//	rng.HorizontalAlignment = Constants.xlCenter;

		//	//设置单元格内容某个字符的颜色（格式）
		//	rng.get_Characters(6, 11).Font.ColorIndex = 3;//胶原批号为红色
		//}
		//#region 保存Excel 释放Excel资源
		//public static void saveExcel()
		//{
		//	try
		//	{
		//		xBk.SaveCopyAs(filename);
		//		xBk.Close(false, null, null);

		//		MessageBox.Show("完成导入！");
		//		//得到所有打开的进程
		//		ExcelApp.Quit();//退出EXCEL

		//		System.Runtime.InteropServices.Marshal.ReleaseComObject(xBk);
		//		System.Runtime.InteropServices.Marshal.ReleaseComObject(xSt);
		//		System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp);

		//		xBk = null;
		//		xSt = null;
		//		ExcelApp = null;
		//		GC.Collect();

		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show(ex.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
		//	}

		//}
		//#endregion



		public static void Study1()
		{
			//Excel.Application xpp = new Excel.ApplicationClass();


		}
	}
}

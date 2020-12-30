using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Diary.Data
{
	public class ExcelCreater
	{
		private ExcelCreater()
		{

		}
		static ExcelCreater _Create;
		static DateTime _Date;
		public static ExcelCreater GetInstance(DateTime date)
		{
			if (_Create == null)
			{
				_Create = new ExcelCreater();
			}
			_Date = date;
			return _Create;
		}

		public void CreateExcel(string filename)
		{
			//worksheets只代表工作表，仅第一个。sheets包括全部
			Excel.Application app = new Excel.Application();

			Workbooks books = app.Workbooks;
			DateTime date = DateTime.Now.AddYears(1);
			var book = CreateWorkBook(books);
			//CreateSheet_Year(book, date);
			CreateSheet_Date(book.Sheets.Add() as Worksheet, DateTime.Now, DateTime.Now.AddDays(20));

			book.SaveAs(filename);
			app.Quit();

		}

		public Workbook CreateWorkBook(Workbooks books)
		{
			return books.Add();
		}

		public void CreateSheet_Year(Workbook book, DateTime date)
		{
			CreateSheet_Quarter(book, date.Year, 1);
			CreateSheet_Quarter(book, date.Year, 2);
			CreateSheet_Quarter(book, date.Year, 3);
			CreateSheet_Quarter(book, date.Year, 4);
		}
		public void CreateSheet_Quarter(Workbook book, int year, int num)
		{
			Worksheet sheet = book.Sheets.Add() as Worksheet;
			sheet.Name = $"第{num}季度";
			DateTime start = DateTime.Parse($"{year}-01-01");
			DateTime end = start.AddMonths(3 * num + 1).AddDays(-2);
			CreateSheet_Date(sheet, start, end);
		}
		public void CreateSheet_Date(Worksheet worksheet, DateTime startDate, DateTime endDate)
		{
			worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 23]).MergeCells = true;//合并单元格
			Random random = new Random();
			worksheet.Cells[1, 1] = List[random.Next(List.Length)];

			Excel.Range head = ((Excel.Range)worksheet.Cells[1, 1]);
			head.RowHeight = 40;
			head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
			head.Font.Name = "微软雅黑";
			head.Font.Bold = true;
			head.Font.FontStyle = "微软雅黑";
			int dayOfWeek = (int)DayOfWeek.Sunday;
			for (int i = 2; i < 23; i = i + 3, dayOfWeek++)
			{
				int weekRow = 2;
				Range weekhead = worksheet.get_Range(worksheet.Cells[weekRow, i], worksheet.Cells[weekRow, i + 2]);
				weekhead.MergeCells = true;
				initHeadRange(weekhead);

				worksheet.Cells[weekRow, i] = $"{Enum.Parse(typeof(DayOfWeek), dayOfWeek.ToString())}";

			}
			DateTime indexStartDate = startDate;
			DateTime indexEndDate = startDate;

			for (int row = 3; indexEndDate <= endDate;)
			{
				indexEndDate = indexEndDate.AddDays(1);
				if (indexEndDate.DayOfWeek < DayOfWeek.Saturday)
				{
					continue;
				}
				CreateSheet_Line(worksheet, indexStartDate, indexEndDate, row);
				indexStartDate = indexEndDate.AddDays(1);
				row = row + 6;
			}
		}

		/// <summary>
		/// 在一行中显示的； 要保证同一个礼拜的在一行中
		/// </summary>
		/// <param name="worksheet"></param>
		/// <param name="startDate"></param>
		/// <param name="row">每6个人一组</param>
		public void CreateSheet_Line(Worksheet worksheet, DateTime startDate, DateTime endDate, int row)
		{
			//Time  3 * 7 生活， 工作、学习
			Range timerow = worksheet.get_Range(worksheet.Cells[row, 1], worksheet.Cells[row + 1, 1]);
			timerow.ColumnWidth = 10;
			timerow.Interior.ColorIndex = 35;

			worksheet.Cells[row + 2, 1] = "9:00-12:00";
			worksheet.Cells[row + 3, 1] = "12:00-18:00";
			worksheet.Cells[row + 4, 1] = "18:00-23:00";
			worksheet.Cells[row + 5, 1] = "备注";
			//Range timerange = worksheet.Rows[1];

			//Range Ranger = worksheet.get_Range(mySheet.Cells[1, 1], mySheet.Cells[DT.Rows.Count + 2, DT.Columns.Count - 3]);
			DateTime indextime = startDate;

			int firtDayOfWeek = (int)startDate.DayOfWeek;
			int i = 2 + firtDayOfWeek * 3;
			for (; indextime <= endDate; i = i + 3, indextime = indextime.AddDays(1))
			{
				Range head = worksheet.get_Range(worksheet.Cells[row, i], worksheet.Cells[row, i + 2]);
				head.MergeCells = true;
				initHeadRange(head);

				worksheet.Cells[row, i] = $"{indextime.ToShortDateString()}";

				worksheet.Cells[row + 1, i] = "工作";
				worksheet.Cells[row + 1, i + 1] = "生活";
				worksheet.Cells[row + 1, i + 2] = "学习";
			}

			//worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 7]).MergeCells = true;
			//worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 7]).Font.Bold = true;//


		}

		public void initHeadRange(Range head)
		{
			head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
			head.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
			head.RowHeight = 26;
			head.ColumnWidth = 5;
			head.Font.Name = "微软雅黑";
			head.Font.Bold = true;
			head.Font.FontStyle = "微软雅黑";
			head.Interior.ColorIndex = 35;

		}
		//*********************************************************
		public void CreateDiarySheets(string filename)
		{
			object Nothing = System.Reflection.Missing.Value;
			Excel.Application xapp = new Excel.Application();
			Excel.Workbook book = xapp.Workbooks.Add(Nothing);
			book.Sheets.Add(Nothing);//默认是三个sheet，多余三个需要手动添加
			book.Sheets.Add(Nothing);
			book.Sheets.Add(Nothing);
			book.Sheets.Add(Nothing);
			book.Sheets.Add(Nothing);

			CreateSheet(book, 1, "第一季度");
			CreateSheet(book, 2, "第二季度");
			CreateSheet(book, 3, "第三季度");
			CreateSheet(book, 4, "第四季度");
			CreateSheet(book, 5, "周报");
			CreateSheet(book, 6, _Date.Year + "年重大事件安排表");
			//book.Sheets.Add(CreateSheet("第二季度"));
			//book.Sheets.Add(CreateSheet("第三季度"));
			//book.Sheets.Add(CreateSheet("第四季度"));
			InitDiarySheet((Excel.Worksheet)book.Sheets[1], 1);
			InitDiarySheet((Excel.Worksheet)book.Sheets[2], 2);
			InitDiarySheet((Excel.Worksheet)book.Sheets[3], 3);
			InitDiarySheet((Excel.Worksheet)book.Sheets[4], 4);
			//InitDiarySheet((Excel.Worksheet)book.Sheets[5], 5);

			book.SaveAs(filename);

			xapp.Quit();
		}



		public void CreateSheet(Excel.Workbook workBook, int sheetNum, string sheetName)
		{
			Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[sheetNum];
			worksheet.Name = sheetName;

		}


		public void InitDiarySheet(Excel.Worksheet worksheet, int sheetNum)
		{
			worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, 7]).MergeCells = true;//合并单元格
			worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 7]).MergeCells = true;//合并单元格
			worksheet.Cells[1, 1] = string.Format(_Date.Year + "年第{0}季度日志", sheetNum);
			Random random = new Random();
			worksheet.Cells[2, 1] = List[random.Next(List.Length)];

			Excel.Range head = ((Excel.Range)worksheet.Cells[1, 1]);
			head.RowHeight = 40;
			head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
			head.Font.Name = "微软雅黑";
			head.Font.Bold = true;
			head.Font.FontStyle = "微软雅黑";
			//head.Cells.
			InitRange(worksheet.get_Range(worksheet.Cells[2, 1], worksheet.Cells[2, 7]));

			////worksheet.Cells.ColumnWidth = 168;
			//Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
			////worksheet.Columns[0]
			//rng.Font.Size = 16;//设置单元格字体大小
			//rng.Font.Bold = true;//设置单元格字体为粗体
			//rng.RowHeight = 40;//设置单元格行高
			//rng.Font.Name = "微软雅黑";//设置单元格字体
			//rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
			//rng.ColumnWidth = 20;//设置单元格列宽
			//rng.Borders.ColorIndex = 1;//设置单元格字体颜色。
			int startIndex = 3;
			DateTime dt = DateTime.Parse(string.Format("{0}-{1}-01", _Date.Year, (sheetNum - 1) * 3 + 1));
			DateTime dtEnd = DateTime.Parse(string.Format("{0}-{1}-01", _Date.Year, (sheetNum) * 3)).AddMonths(1).AddDays(-1);

			for (int i = 0; dt <= dtEnd; i++)
			{
				for (int j = 0; j <= 6 && dt <= dtEnd; j++)
				{
					Excel.Range range = (Excel.Range)worksheet.Cells[startIndex + i * 10, j + 1];
					range.Interior.ColorIndex = 35;
					range.RowHeight = 17;
					range.Font.FontStyle = "华文细黑";
					if (i == 0 && j < (int)dt.DayOfWeek)
					{
						continue;
					}
					if (j == 6)
					{
						range.Borders.LineStyle = 1;
					}
					if (dt.DayOfWeek == DayOfWeek.Saturday || dt.DayOfWeek == DayOfWeek.Sunday)
					{
						worksheet.get_Range(worksheet.Cells[startIndex + i * 10 + 1, j + 1], worksheet.Cells[startIndex + i * 10 + 3, j + 1]).MergeCells = true;//合并单元格
						worksheet.get_Range(worksheet.Cells[startIndex + i * 10 + 3, j + 1], worksheet.Cells[startIndex + i * 10 + 6, j + 1]).MergeCells = true;//合并单元格
						worksheet.get_Range(worksheet.Cells[startIndex + i * 10 + 6, j + 1], worksheet.Cells[startIndex + i * 10 + 9, j + 1]).MergeCells = true;//合并单元格

						//for (int k = 1; k < 10; k++)
						//{
						//	range = (Excel.Range)worksheet.Cells[startIndex + i * 10 + k, j + 1];
						//	range.Interior.ColorIndex = 2;
						//}
					}
					//worksheet.Cells[3 + i * 5, j] = dt.ToLocalTime().ToShortDateString() + dt.ToLocalTime().DayOfWeek;
					worksheet.Cells[startIndex + i * 10, j + 1] = dt.ToLocalTime().ToShortDateString() + GetChDayOfWeek(dt);
					dt = dt.AddDays(1);
				}
			}
		}


		public void InitRange(Excel.Range rng)
		{
			rng.Font.Size = 16;//设置单元格字体大小
			rng.Font.Bold = true;//设置单元格字体为粗体
			rng.RowHeight = 40;//设置单元格行高
			rng.Font.Name = "华文细黑";//设置单元格字体
			rng.Font.FontStyle = "华文细黑";
			rng.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;//居中
			rng.ColumnWidth = 20;//设置单元格列宽
			rng.Borders.ColorIndex = 1;//设置单元格字体颜色。
			rng.Interior.ColorIndex = 20;

		}

		private string GetChDayOfWeek(System.DateTime dt)
		{
			return "星期" + "日一二三四五六".Substring((int)dt.DayOfWeek, 1); ;
		}

		private string[] List = new string[] { "天道酬勤", "名言", "诗词", "一切失败都是从解释开始的", "Do it well, or not at all.", "方法总比困难多" };
	}
}

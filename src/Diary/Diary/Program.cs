using Diary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary
{
	static class Program
	{
		public static string FilePath = ConfigHelper.GetAppSettingString("FilePath", "D:\\");
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Init();
			//Application.Run(new Form1());
		}

		static void Init()
		{
			ConfigHelper.InitConfig();
			FilePath = ConfigHelper.GetAppSettingString("FilePath");
			if (!System.IO.Directory.Exists(FilePath))
			{
				System.IO.Directory.CreateDirectory(FilePath);
			}
			string filename = $"{FilePath}test.xlsx";
			if (System.IO.File.Exists(filename))
			{
				System.IO.File.Delete(filename);
			}
			Data.ExcelCreater.GetInstance(DateTime.Now).CreateExcel(filename);

		}
	}
}

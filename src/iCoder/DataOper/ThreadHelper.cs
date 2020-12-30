using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DataOper
{
	class ThreadHelper
	{
		public class ThreadClass
		{
			public static void Th_Start()
			{
				Thread thValidate = new Thread(Th_DoCmd);
				thValidate.Start();

			}


			/// <summary>
			/// 对账清算文件
			/// </summary>
			public static void Th_DoCmd()
			{
				while (true)
				{
					try
					{
						Thread.Sleep(1000);
						DateTime tradeDate = DateTime.Now;

						//int time = tradeDate.GetHHMM();

						//if (time < 1900)
						//{
						//	ClearLog.Log("time < 1900，【暂时不用验证ABC清算文件】，休息1个小时");
						//	Thread.Sleep(1000 * 60 * 60);
						//	continue;
						//}
						//else if (time < 2000)
						//{
						//	ClearLog.Log("time < 2000，【暂时不用验证ABC清算文件】，休息0.1个小时");
						//	Thread.Sleep(1000 * 60 * 10);
						//	continue;
						//}

						//string dicPath = DoCreateDir(tradeDate);
						//int nowDate = tradeDate.GetYYYYMMDD();
						//string abcPosFile = string.Format("{1}" + ConfigMgr.AbcConfig.ExportInstrumentPositionFromABC, tradeDate.ToString("yyyyMMdd"), dicPath);
						//string abcCashFile = string.Format("{1}" + ConfigMgr.AbcConfig.ExportCashPositionFromABC, tradeDate.ToString("yyyyMMdd"), dicPath);

						//if (!System.IO.File.Exists(abcPosFile)
						//	|| !System.IO.File.Exists(abcCashFile))
						//{
						//	ClearLog.Log(string.Format("---今日还没有生成过文档【{0}】的【清算文件】，休息3分钟", nowDate));
						//	Thread.Sleep(1000 * 60 * 3);
						//	continue;
						//}
						//ClearLog.Log("[开始验证ABC清算文件]." + tradeDate);

						//ClearLog.Log("读取资金：" + abcCashFile);


						//ClearLog.Log("*****Success：对账清算文件对单成功. 休息6个小时" + tradeDate);
						//Thread.Sleep(1000 * 60 * 60 * 6);

					}
					catch (Exception e)
					{
				Console.Write(e.ToString());
						Thread.Sleep(1000 * 60 * 5);
					}
				}

			}

		}

	}
}

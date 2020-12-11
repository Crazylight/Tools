using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diary.Data
{
	public class DiaryData
	{
		public enum eBelongType
		{
			Self,
			Work
		}

		public enum eDiaryType
		{

		}

		public string Title { get; set; }

		public string Content { get; set; }

		public eBelongType BelongType { get; set; }

		public eDiaryType DiaryType { get; set; }

		public DateTime DiaryDate;

		public DateTime DiaryTime;

		public string Address { get; set; }

		public string Partners { get; set; }
	}
}

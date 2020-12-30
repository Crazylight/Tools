using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LayersProductor.MySql
{
	public class MySqlProc
	{
		public void Create()
		{


		}

		public static string CreateTable()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("create table us_position");
			sb.Append("(");
			sb.Append("	Symbol varchar(15), ");
			sb.Append(" Fundaccountid varchar(25),");
			sb.Append(" Quantity int,");
			sb.Append(" Available int,");
			sb.Append(" TransID int,");
			sb.Append(" Cost decimal(10,4)");
			sb.Append(" ");
			sb.Append(" ");
			sb.Append(")");

			return sb.ToString();
		}

		public static string CreateBaseProc()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("create PROCEDURE proc_test");
			sb.Append("(");
			sb.Append("	Symbol varchar(15), ");
			sb.Append(" Fundaccountid varchar(25),");
			sb.Append(" Quantity int,");
			sb.Append(" Available int,");
			sb.Append(" TransID int,");
			sb.Append(" Cost decimal(10,4)");
			sb.Append(" ");
			sb.Append(" ");
			sb.Append(")");

			return sb.ToString();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
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

		public static string CreateProc(DataTable dt)
		{
			StringBuilder sbCreate = new StringBuilder();

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				string name = dt.Rows[i][0].ToString();
				string type = dt.Rows[i][1].ToString();


				if (i == dt.Rows.Count - 1)
				{
					sbCreate.Append($"IN p_in_{ dt.Rows[i][0].ToString()} { dt.Rows[i][1].ToString()} )");
				}
				else
				{
					//sb.Append($"IN p_in_{ model.Table.Rows[i][0].ToString()} { model.Table.Rows[i][1].ToString()},\r\n");
					sbCreate.Append($"IN p_in_{dt.Rows[i][0].ToString()} { dt.Rows[i][1].ToString()},");
				}
			}
			return sbCreate.ToString();
		}
	}
}

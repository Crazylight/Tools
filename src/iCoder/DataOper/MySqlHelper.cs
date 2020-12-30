using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataOper
{
	public class MySqlHelper
	{
		#region Fileds
		private static string _strDataBases = "show DATABASES;";
		private static string _strTableNames = "show TABLES;";
		//private static string _strTableFields = "SELECT A.name AS 'name',(SELECT B.name FROM [sys].[types] B WHERE B.system_type_id = A.system_type_id) AS 'type' FROM [SYS].[all_columns] A WHERE A.object_id =";
		private static string _strTableFields = "select COLUMN_NAME from information_schema.COLUMNS where table_name = '{0}';";
		#endregion
		private MySqlHelper()
		{

		}

		public static DataTable GetDataBases(MySqlConnection conn)
		{
			DataTable dt = new DataTable();
			try
			{
				MySqlCommand _comm = new MySqlCommand();
				_comm = new MySqlCommand(_strDataBases, conn);
				// _comm.Connection.ConnectionString = "Data Source=.\\MySqlEXPRESS;Uid=biz001;pwd=biz121";
				_comm.Connection.Open();

				using (MySqlDataAdapter da = new MySqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception e)
			{
				throw e;
			}
			return dt;
		}

		public static DataTable getTable(string connStr)
		{
			DataTable dt = new DataTable();
			MySqlCommand _comm = new MySqlCommand();
			try
			{
				_comm.Connection.ConnectionString = connStr;
				_comm.Connection.Open();

				using (MySqlDataAdapter da = new MySqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
				_comm.Connection.Close();
			}
			return dt;
		}

		public static DataTable GetTableNames(MySqlConnection conn)
		{
			MySqlCommand _comm = new MySqlCommand();
			_comm.Connection = conn; ;
			_comm.CommandText = _strTableNames;
			DataTable dt = new DataTable();
			try
			{
				_comm.Connection.Open();

				using (MySqlDataAdapter da = new MySqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
				_comm.Connection.Close();
			}
			return dt;
		}

		public static DataTable GetTableFieldsByTableId(MySqlConnection conn, object tableid)
		{
			MySqlCommand _comm = new MySqlCommand();
			_comm.Connection = conn;
			_comm.CommandText = _strTableFields + tableid + " ORDER BY column_id";
			DataTable dt = new DataTable();
			try
			{
				_comm.Connection.Open();

				using (MySqlDataAdapter da = new MySqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception ex)
			{
				Console.Write(ex.ToString());
				_comm.Connection.Close();
			}
			finally
			{
				_comm.Dispose();
			}
			return dt;
		}

		public static DataTable GetDtNames(MySqlConnection conn)
		{
			MySqlCommand comm = new MySqlCommand();
			comm.Connection = conn;

			comm.CommandText = "show tables;";

			using (MySqlDataAdapter da = new MySqlDataAdapter(comm))
			{
				DataTable dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
		}

		/// <summary>
		/// Gets the dt.
		/// </summary>
		/// <returns></returns>
		public static DataTable GetDtFields(MySqlConnection conn, string tableName)
		{
			DataTable dt = new DataTable();
			MySqlCommand comm = new MySqlCommand();
			comm.Connection = conn;

			//# show columns /FIELDS from table_name from database_name; 或show columns from database_name.table_name; -- 显示表中列名称。 
			comm.CommandText = $"show columns from {conn.Database}.{tableName}";
			//select COLUMN_NAME, DATA_TYPE, COLUMN_COMMENT from information_schema.COLUMNS where table_name = 'us_orders' and table_schema = 'tjz_trade';
			using (MySqlDataAdapter da = new MySqlDataAdapter(comm))
			{
				da.Fill(dt);
			}
			dt.TableName = tableName;

			return dt;
		}
	}
}

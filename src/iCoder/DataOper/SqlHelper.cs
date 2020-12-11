using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataOper
{
	public sealed class SqlHelper
	{
		#region Fileds
		private static string _strDataBases = "select name from [sys].[databases] where [database_id] > 4 ORDER BY NAME";
		private static string _strTableNames = "SELECT [NAME] as name, OBJECT_ID AS id FROM [SYS].[ALL_OBJECTS] WHERE TYPE = 'U' ORDER BY NAME";
		//private static string _strTableFields = "SELECT A.name AS 'name',(SELECT B.name FROM [sys].[types] B WHERE B.system_type_id = A.system_type_id) AS 'type' FROM [SYS].[all_columns] A WHERE A.object_id =";
		private static string _strTableFields = "SELECT A.NAME  'name', B.NAME  'type' FROM [SYS].[ALL_COLUMNS] A, [SYS].[TYPES] B  WHERE B.system_type_id = A.system_type_id AND B.name <> 'SYSNAME' AND A.OBJECT_ID = ";
		#endregion
		private SqlHelper()
		{

		}

		public static DataTable GetDataBases(SqlConnection conn)
		{
			DataTable dt = new DataTable();
			try
			{
				SqlCommand _comm = new SqlCommand();
				_comm = new SqlCommand(_strDataBases, conn);
				// _comm.Connection.ConnectionString = "Data Source=.\\SQLEXPRESS;Uid=biz001;pwd=biz121";
				_comm.Connection.Open();

				using (SqlDataAdapter da = new SqlDataAdapter(_comm))
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
			SqlCommand _comm = new SqlCommand();
			try
			{
				_comm.Connection.ConnectionString = connStr;
				_comm.Connection.Open();

				using (SqlDataAdapter da = new SqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception ex)
			{
				// System.Windows.Forms.MessageBox.Show(ex.Message);
				_comm.Connection.Close();
			}
			return dt;
		}

		public static DataTable GetTableNames(SqlConnection conn)
		{
			SqlCommand _comm = new SqlCommand();
			_comm.Connection = conn; ;
			_comm.CommandText = _strTableNames;
			DataTable dt = new DataTable();
			try
			{
				_comm.Connection.Open();

				using (SqlDataAdapter da = new SqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception ex)
			{
				//  System.Windows.Forms.MessageBox.Show(ex.Message);
				_comm.Connection.Close();
			}
			return dt;
		}

		public static DataTable GetTableFieldsByTableId(SqlConnection conn, object tableid)
		{
			SqlCommand _comm = new SqlCommand();
			_comm.Connection = conn;
			_comm.CommandText = _strTableFields + tableid + " ORDER BY column_id";
			DataTable dt = new DataTable();
			try
			{
				_comm.Connection.Open();

				using (SqlDataAdapter da = new SqlDataAdapter(_comm))
				{
					da.Fill(dt);
				}
				_comm.Connection.Close();
			}
			catch (Exception ex)
			{
				//  System.Windows.Forms.MessageBox.Show(ex.Message);
				_comm.Connection.Close();
			}
			finally
			{
				_comm.Dispose();
			}
			return dt;
		}
	}
}

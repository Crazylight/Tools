using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Common
{
    public sealed class SQLCmd
    {
        public static bool ExecuteNonQuery(string sql, string connectionString, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteNonQuery(string sql, ref SqlParameter[] sqlParameters, string connectionString, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        for (int i = 0; i < sqlParameters.Length; i++)
                        {
                            cmd.Parameters.Add(sqlParameters[i]);
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }


        public static bool ExecuteNonQuery(string sql, string connectionString, SqlTransaction trans, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn, trans))
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteNonQuery(string sql, ref SqlParameter[] sqlParameters, string connectionString, SqlTransaction trans, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        for (int i = 0; i < sqlParameters.Length; i++)
                        {
                            cmd.Parameters.Add(sqlParameters[i]);
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }





        /// <summary>
        /// 执行标准SQL查询语句，返回记录集。失败返回null
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataSet ExecuteForDataset(string sql, string connectionString)
        {
            DataSet ds;
            string err;
            if (ExecuteDataset(sql, connectionString, out ds, out err))
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 执行标准SQL查询语句，返回记录集
        /// </summary>
        /// <param name="sql">标准SQL查询语句</param>
        /// <param name="connectionString">连库字符串</param>
        /// <param name="ds">查询结果记录集</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>布尔值，true表示该执行成功，false表示执行失败</returns>
        public static bool ExecuteDataset(string sql, string connectionString, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(sql, conn))
                    {
                        command.CommandType = CommandType.Text;

                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteDataset(string sql, string connectionString, int commandTimeout, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = commandTimeout;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }
        public static bool ExecuteDataset(string sql, string connectionString, int StartRecordNo, int PageSize, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds, StartRecordNo, PageSize, "TableName");
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteDataset(string sql, string connectionString, ref SqlParameter[] sqlParameters, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.CommandType = CommandType.Text;
                        command.Parameters.AddRange(sqlParameters);
                        using (SqlDataAdapter adapter = new SqlDataAdapter())
                        {
                            adapter.SelectCommand = command;
                            adapter.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }
        /// <summary>
        /// 返回结果集的第一张表。失败或者不存在返回null
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable ExecuteForFirstTable(string sql, string connectionString)
        {
            DataSet ds;
            string errMsg;
            if (ExecuteDataset(sql, connectionString, out ds, out errMsg))
            {
                if (ds.Tables.Count > 0)
                {
                    return ds.Tables[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 返回结果集的第一行。失败或者不存在返回null
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataRow ExecuteForFirstLine(string sql, string connectionString)
        {
            DataSet ds;
            string errMsg;
            if (ExecuteDataset(sql, connectionString, out ds, out errMsg))
            {
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0];
                }
            }
            return null;
        }

        /// <summary>
        /// 返回结果集的第一行的第一个字段。失败或者不存在返回null。DBNull返回空字符串""
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static string ExecuteForFirstField(string sql, string connectionString)
        {
            var row = ExecuteForFirstLine(sql, connectionString);
            if (row != null && row.ItemArray.Length > 0)
            {
                return row[0].ToString();
            }
            return null;
        }

        public static bool ExcueteScalar(string sql, string connectionString, out object scalar, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            scalar = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        scalar = cmd.ExecuteScalar();
                        result = scalar != null;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }
        public static bool ExcueteScalar(string sql, string connectionString, ref SqlParameter[] sqlParameters, out object scalar, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            scalar = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddRange(sqlParameters);
                        scalar = cmd.ExecuteScalar();
                        result = !(scalar is DBNull);
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 提供通用的调用存储过程的方法（需要返回查询的记录集的调用）
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="connectionString">连库字符串</param>
        /// <param name="sqlParameters">存储过程参数数组</param>
        /// <param name="ds">存储过程里面返回的记录集</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>布尔值，true表示该执行成功，false表示执行失败</returns>
        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, ref SqlParameter[] sqlParameters, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            for (int i = 0; i < sqlParameters.Length; i++)
                            {
                                da.SelectCommand.Parameters.Add(sqlParameters[i]);
                            }
                            da.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, int commandTimeout, ref SqlParameter[] sqlParameters, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = commandTimeout;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            for (int i = 0; i < sqlParameters.Length; i++)
                            {
                                da.SelectCommand.Parameters.Add(sqlParameters[i]);
                            }
                            da.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, ref List<SqlParameter> sqlParameters, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            for (int i = 0; i < sqlParameters.Count; i++)
                            {
                                da.SelectCommand.Parameters.Add(sqlParameters[i]);
                            }
                            da.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        /// <summary>
        /// 只执行，不返回参数
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="conn"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="sqlParameters"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public static bool ExecuteStoredProcedure(string procedureName, SqlConnection conn, List<SqlParameter> sqlParameters, SqlTransaction trans)
        {
            DataSet ds = new DataSet();
            try
            {
                //using (SqlCommand cmd = new SqlCommand(procedureName, conn, trans))
                //{
                //	cmd.CommandType = CommandType.StoredProcedure;

                //	for (int i = 0; i < sqlParameters.Count; i++)
                //	{
                //		cmd.Parameters.Add(sqlParameters[i]);
                //	}
                //	cmd.ExecuteNonQuery();
                //}
                using (SqlCommand cmd = new SqlCommand(procedureName, conn, trans))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        for (int i = 0; i < sqlParameters.Count; i++)
                        {
                            da.SelectCommand.Parameters.Add(sqlParameters[i]);
                        }
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, int commandTimeout, ref List<SqlParameter> sqlParameters, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = commandTimeout;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            for (int i = 0; i < sqlParameters.Count; i++)
                            {
                                da.SelectCommand.Parameters.Add(sqlParameters[i]);
                            }
                            da.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        //public static bool ExecuteStoredProcedure(string procedureName, string connectionString, ref SqlParameter[] sqlParameters, out DataSet ds, out string errMsg)
        //{
        //    bool result = false;
        //    errMsg = string.Empty;
        //    ds = new DataSet();
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        SqlDataAdapter dsCommand = new SqlDataAdapter();
        //        dsCommand.SelectCommand = new SqlCommand(procedureName, conn);
        //        dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        for (int i = 0; i < sqlParameters.Length; i++)
        //        {
        //            dsCommand.SelectCommand.Parameters.Add(sqlParameters[i]);
        //        }
        //        dsCommand.Fill(ds);
        //        result = true;
        //    }
        //    catch (Exception e)
        //    {
        //        errMsg = e.Message;
        //    }
        //    return result;
        //}
        /// <summary>
        /// 提供通用的调用存储过程的方法（需要返回查询的记录集的调用）
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="connectionString">连库字符串</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>布尔值，true表示该执行成功，false表示执行失败</returns>
        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }

        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, int commandTimeout, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = commandTimeout;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }
        //public static bool ExecuteStoredProcedure(string procedureName, string connectionString, out string errMsg)
        //{
        //    bool result = false;
        //    errMsg = string.Empty;
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(procedureName, conn);
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        conn.Open();
        //        cmd.ExecuteNonQuery();
        //        result = true;
        //    }
        //    catch (Exception e)
        //    {
        //        errMsg = e.Message;

        //    }
        //    finally
        //    {
        //        if (conn.State == ConnectionState.Open)
        //            conn.Close();
        //    }
        //    return result;
        //}



        /// <summary>
        ///  提供通用的调用存储过程的方法（需要返回查询的记录集的调用）
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="connectionString">连库字符串</param>
        /// <param name="ds">存储过程里面返回的记录集</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>布尔值，true表示该执行成功，false表示执行失败</returns>
        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }
        //public static bool ExecuteStoredProcedure(string procedureName, string connectionString, out DataSet ds, out string errMsg)
        //{
        //    bool result = false;
        //    errMsg = string.Empty;
        //    ds = new DataSet();
        //    SqlConnection conn = new SqlConnection(connectionString);
        //    try
        //    {
        //        SqlDataAdapter dsCommand = new SqlDataAdapter();
        //        dsCommand.SelectCommand = new SqlCommand(procedureName, conn);
        //        dsCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        dsCommand.Fill(ds);
        //        result = true;
        //    }
        //    catch (Exception e)
        //    {
        //        errMsg = e.Message;
        //    }
        //    return result;
        //}

        /// <summary>
        /// 提供通用的调用存储过程的方法（需要返回查询的记录集的调用）
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="connectionString">连库字符串</param>
        /// <param name="startRecord">从其开始的从零开始的记录号</param>
        /// <param name="maxRecords">要检索的最大记录数</param>
        /// <param name="sqlParameters">存储过程参数数组</param>
        /// <param name="ds">存储过程里面返回的记录集</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>布尔值，true表示该执行成功，false表示执行失败</returns>
        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, int startRecord, int maxRecords, ref SqlParameter[] sqlParameters, out DataSet ds, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;
            ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            for (int i = 0; i < sqlParameters.Length; i++)
                            {
                                da.SelectCommand.Parameters.Add(sqlParameters[i]);
                            }
                            da.Fill(ds, startRecord, maxRecords, "srcTable");
                            result = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;
            }
            return result;
        }
        /// <summary>
        /// 提供通用的调用存储过程的方法（不需要返回查询的记录集的调用）
        /// </summary>
        /// <param name="procedureName">存储过程名称</param>
        /// <param name="connectionString">连库字符串</param>
        /// <param name="sqlParameters">存储过程参数数组</param>
        /// <param name="errMsg">错误信息</param>
        /// <returns>布尔值，true表示该执行成功，false表示执行失败</returns>
        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, ref SqlParameter[] sqlParameters, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < sqlParameters.Length; i++)
                        {
                            cmd.Parameters.Add(sqlParameters[i]);
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;

            }
            return result;
        }

        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, ref List<SqlParameter> sqlParameters, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 0; i < sqlParameters.Count; i++)
                        {
                            cmd.Parameters.Add(sqlParameters[i]);
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;

            }
            return result;
        }

        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, int commandTimeout, ref SqlParameter[] sqlParameters, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = commandTimeout;
                        for (int i = 0; i < sqlParameters.Length; i++)
                        {
                            cmd.Parameters.Add(sqlParameters[i]);
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;

            }
            return result;
        }
        public static bool ExecuteStoredProcedure(string procedureName, string connectionString, int commandTimeout, ref List<SqlParameter> sqlParameters, out string errMsg)
        {
            bool result = false;
            errMsg = string.Empty;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = commandTimeout;
                        for (int i = 0; i < sqlParameters.Count; i++)
                        {
                            cmd.Parameters.Add(sqlParameters[i]);
                        }
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                errMsg = e.Message;

            }
            return result;
        }


        /// <summary>
        /// 利用SqlBulkCopy快速大量导入数据
        /// </summary>
        /// <param name="batchSize">一次批量的插入的数据量</param>
        /// <param name="bulkCopyTimeout">超时时间</param>
        /// <param name="notifyAfter">在插入设定条数后，呼叫相应事件</param>
        /// <param name="tableName">要批量写入的表</param>
        /// <param name="columnMappings">自定义的datatable和数据库的字段的映射</param>
        /// <param name="dataTable">数据集</param>
        /// <returns></returns>
        public static bool ExecuteBySqlBulkCopy(string connectionString, int batchSize, int bulkCopyTimeout, int notifyAfter, string tableName, Dictionary<string, string> columnMappings, DataTable dataTable, out string errMsg)
        {
            bool result = false;
            errMsg = "";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conn);
            sqlBulkCopy.BatchSize = batchSize;
            sqlBulkCopy.BulkCopyTimeout = bulkCopyTimeout;
            sqlBulkCopy.NotifyAfter = notifyAfter;
            sqlBulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);

            try
            {
                sqlBulkCopy.DestinationTableName = tableName;
                foreach (string key in columnMappings.Keys)
                {
                    sqlBulkCopy.ColumnMappings.Add(key, columnMappings[key]);
                }
                conn.Open();
                sqlBulkCopy.WriteToServer(dataTable);
                result = true;
            }
            catch (Exception e)
            {
                errMsg = e.Message;
                result = false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                sqlBulkCopy.Close();
            }
            return result;
        }
        private static void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            //  插入数据后的处理
            return;
        }



        /// <summary>
        /// 批量插入数据。
        /// </summary>
        /// <param name="connectionString">数据库连接串</param>
        /// <param name="destinationTableName">要插入表名称</param>
        /// <param name="dt">数据</param>
        public static void DataTableToSQLServer(string connectionString, string destinationTableName, DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    try
                    {
                        bulkCopy.DestinationTableName = destinationTableName;//要插入表名称  
                        foreach (DataColumn columnItem in dt.Columns)
                        {
                            bulkCopy.ColumnMappings.Add(columnItem.ColumnName, columnItem.ColumnName);
                        }
                        bulkCopy.BulkCopyTimeout = 3600;//1小时
                        bulkCopy.WriteToServer(dt);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        bulkCopy.Close();
                    }
                }
            }
            return;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LayersProductor
{
	public class ProcCreater : CommonPro
	{
		static ProcCreater instance;
		public ProcCreater(DataTable dt)
			: base(dt, "", "")
		{

		}

		public static ProcCreater getInstance(DataTable dt)
		{
			instance = new ProcCreater(dt); //换了表的时候保证此处也跟着变化

			return instance;
		}

		/*************************存贮过程*********/
		public string CreateProcAdd()
		{
			StringBuilder content = new StringBuilder();
			content.Append(CreateHead());

			content.Append(CreateProcFrame(_dt.TableName + "_Add", CreateParam(), JudgeExist() + "\r\nBEGIN\r\n" + CreateBodyInsert() + "\r\nEND\r\n"));

			return content.ToString();
		}


		public string CreateProcUpdate()
		{
			StringBuilder content = new StringBuilder();
			content.Append(CreateHead());

			content.Append(CreateProcFrame(_dt.TableName + "_Update", CreateParam(), CreateBodyUpdate()));

			return content.ToString();
		}


		public string CreateProcAddOrUpdate()
		{
			StringBuilder content = new StringBuilder();
			content.Append(CreateHead());

			content.Append(CreateProcFrame(_dt.TableName + "_AddOrUpdate", CreateParam(), CreateBodyAddOrUpdate()));

			return content.ToString();
		}

		public string CreateProcGetAll()
		{
			StringBuilder content = new StringBuilder();
			content.Append(CreateHead());

			content.Append(CreateProcFrame(_dt.TableName + "_GetAll", "", CreateBodyGetAll()));

			return content.ToString();

		}

		public string CreateProcDel()
		{
			StringBuilder content = new StringBuilder();
			content.Append(CreateHead());

			content.Append(CreateProcFrame(_dt.TableName + "_Del", "  @id  varchar(10)", CreateBodyDel()));

			return content.ToString();

		}


		public string CreateProcGetByID()
		{
			StringBuilder content = new StringBuilder();
			content.Append(CreateHead());

			List<string> listKey = GetPrimaryKey();
			string param = "";
			string primaryKey = "";
			foreach (string name in listKey)
			{
				param += " @" + name + " varchar(10),";
				primaryKey += name;
			}
			if (param.Length > 0)
			{
				param = param.Remove(param.Length - 1);
			}

			content.Append(CreateProcFrame(string.Format("{0}_GetBy{1}", _dt.TableName, primaryKey), param, CreateBodyGetByPrimarykey()));

			return content.ToString();

		}

		private string CreateProcFrame(string proName, string param, string body)
		{
			StringBuilder proc = new StringBuilder();
			proc.Append("CREATE PROCEDURE [DBO].[proc_" + proName + "] ");
			//proc.Append("CREATE PROCEDURE [DBO].[SP_" + proName + "] ");
			proc.Append(param);
			proc.Append("\r\n");
			proc.Append("AS \r\n");
			proc.Append("   SET NOCOUNT ON;\r\n");
			proc.Append("   SET XACT_ABORT ON;\r\n");
			proc.Append("\r\n");
			proc.Append("BEGIN TRANSACTION\r\n");
			proc.Append("\r\n");
			proc.Append(body);
			//proc.Append("  SELECT 0, 'OK';--结果表\r\n\r\n");
			proc.Append("COMMIT TRANSACTION;\r\n");
			return proc.ToString();
		}
		private string CreateTryCatchProcFrame(string proName, string param, string body)
		{
			StringBuilder proc = new StringBuilder();
			proc.Append("CREATE PROCEDURE [DBO].[proc_" + proName + "] ");
			proc.Append(param);
			proc.Append("\r\n");
			proc.Append("AS \r\n");
			proc.Append("   SET NOCOUNT ON;\r\n");
			proc.Append("   SET XACT_ABORT ON;\r\n");
			proc.Append("\r\n");
			proc.Append("BEGIN TRY\r\n");
			proc.Append("BEGIN TRAN\r\n");
			proc.Append("\r\n");
			proc.Append(body);
			//proc.Append("  SELECT 0, 'OK';--结果表\r\n\r\n");
			proc.Append("COMMIT TRAN\r\n");
			proc.Append("END TRY\r\n");
			proc.Append("BEGIN CATCH\r\n");
			proc.Append("   SELECT -1, N'执行出错'\r\n");
			proc.Append("\r\n");
			proc.Append("END CATCH\r\n");
			proc.Append("RETURN \r\n");
			return proc.ToString();
		}
		private string Bottum()
		{
			StringBuilder bottum = new StringBuilder();
			bottum.Append("\r\n");
			bottum.Append("     IF @@ROWCOUNT > 0 \r\n");
			bottum.Append("     BEGIN\r\n");
			bottum.Append("         SELECT 0, 'OK'\r\n");
			bottum.Append("     END\r\n");
			bottum.Append("     ELSE\r\n");
			bottum.Append("     BEGIN\r\n");
			bottum.Append("         SELECT -1, '没有受影响的行数'\r\n");
			bottum.Append("     END\r\n");
			bottum.Append("\r\n");
			return bottum.ToString();
		}

		#region Private Methods
		private string CreateHead()
		{
			StringBuilder head = new StringBuilder();
			head.Append("-- =========================================================================================================\r\n");
			head.Append(" \r\n");
			head.Append("-- 	Athor			:	刘德庆\r\n");
			// head.Append(" \r\n");
			head.Append("-- 	Status			:	完成	\r\n");
			head.Append(" \r\n");
			head.Append("-- 	Description		:	\r\n");
			// head.Append(" \r\n");
			head.Append("-- 	Version			:		1.0.0.0\r\n");
			// head.Append(" \r\n");
			head.Append("-- 	CopyRight (C) . All Rights reserved.\r\n");
			//head.Append(" \r\n");
			head.Append("-- =========================================================================================================\r\n");
			//  head.Append(" \r\n");
			head.Append("-- 	Histroy:		" + DateTime.Now.ToString() + "   Created By LDQ\r\n");
			// head.Append(" \r\n");
			head.Append("-- =========================================================================================================\r\n\r\n");

			return head.ToString();
		}

		private bool NeedLength(string type)
		{
			if (type == "char" ||
				type == "varchar" ||
				type == "nvarchar")
			{
				return true;
			}
			return false;
		}

		private string CreateParam()
		{
			StringBuilder param = new StringBuilder();
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				// if (i % 4 == 0)
				{
					param.Append("\r\n");
					param.Append("   ");
				}
				param.Append("@" + _dt.Rows[i]["name"].ToString() + " ");
				param.Append(_dt.Rows[i]["type"].ToString());
				if (NeedLength(_dt.Rows[i]["type"].ToString()))
				{
					param.Append("(");
					param.Append(_dt.Rows[i]["LENGTH"]);
					param.Append(")");
				}
				if (i < _dt.Rows.Count - 1)
				{
					param.Append(", ");
				}
				else
				{
					param.Append("\r\n");
				}
			}
			return param.ToString();
		}


		private string JudgeExist()
		{
			StringBuilder exist = new StringBuilder();
			//exist.Append("  DECLARE @count INT\r\n");
			//exist.Append("\r\n");
			//exist.Append("  SELECT @count = COUNT(1) FROM [" + _dt.TableName + "] WHERE " + _dt.Rows[0]["name"] + " = @" + _dt.Rows[0]["name"] + "; \r\n");
			//exist.Append("    IF @count = 0 \r\n");

			exist.Append(" IF NOT EXISTS( SELECT * FROM [" + _dt.TableName + "] WHERE " + _dt.Rows[0]["name"] + " = @" + _dt.Rows[0]["name"] + ") \r\n");

			return exist.ToString();
		}
		//*******************************Insert
		private string CreateBodyInsert()
		{
			StringBuilder body = new StringBuilder();
			body.Append("      INSERT INTO [" + _dt.TableName + "]( ");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
				{
					continue;
				}
				if (i % 6 == 0)
				{
					body.Append("\r\n");
					body.Append("          ");
				}
				body.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "]");
				if (i < _dt.Rows.Count - 1)
				{
					body.Append(", ");
				}
				else
				{
					body.Append(")\r\n");
				}
			}
			body.Append("   VALUES (");

			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (i % 6 == 0 && i != 0)
				{
					body.Append("\r\n");
					body.Append("          ");
				}
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
				 || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					body.Append("GETDATE(),");
					continue;
				}
				body.Append("@" + _dt.Rows[i]["name"].ToString());
				if (i < _dt.Rows.Count - 1)
				{
					body.Append(", ");
				}
				else
				{
					body.Append(")\r\n");
				}
			}
			if (body.ToString().EndsWith(","))
			{
				body.Remove(body.Length - 1, 1);
				body.Append(")");
			}
			body.Append(Bottum());
			return body.ToString();

		}

		//*******************************Update
		private string CreateBodyUpdate()
		{
			StringBuilder body = new StringBuilder();
			body.Append("UPDATE [" + _dt.TableName + "] SET");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (i % 6 == 0 && i > 0)
				{
					body.Append("\r\n");
					body.Append("\t\t");
				}
				body.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = ");
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
				 || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					body.Append("GETDATE(),");
				}
				else
				{
					body.Append("@" + _dt.Rows[i]["name"].ToString());
				}
				if (i == _dt.Rows.Count - 1)
				{
					body.Append("\r\n");
					body.Append(GetWhereConditionInProc() + ";\r\n");
				}
				else
				{
					body.Append(", ");
				}
			}
			if (body.ToString().EndsWith(","))
			{
				body.Remove(body.Length - 1, 1);
				body.Append(")");
			}

			body.Append(Bottum());
			return body.ToString();

		}

		//*******************************AddOrUpdate
		private string CreateBodyAddOrUpdate()
		{
			StringBuilder body = new StringBuilder();
			body.Append("");
			body.Append(" IF NOT EXISTS( SELECT * FROM [" + _dt.TableName + "] WHERE " + _dt.Rows[0]["name"] + " = @" + _dt.Rows[0]["name"] + ") \r\n");
			body.Append("BEGIN \r\n");

			body.Append("\t\t INSERT INTO [" + _dt.TableName + "]( ");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
				{
					continue;
				}
				body.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "]");
				if (i < _dt.Rows.Count - 1)
				{
					body.Append(", ");
				}
				else
				{
					body.Append(")\r\n");
				}
			}
			body.Append("\r\n");
			body.Append("\t\t VALUES (");

			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("id"))
					continue;
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
				 || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					body.Append("GETDATE()");
				}
				else
				{
					body.Append("@" + _dt.Rows[i]["name"].ToString());
				}
				if (i < _dt.Rows.Count - 1)
				{
					body.Append(", ");
				}
				else
				{
					body.Append(")\r\n");
				}
			}
			body.Append("END \r\n");
			body.Append("ELSE \r\n");
			body.Append("BEGIN \r\n");
			body.Append("\t\t UPDATE [" + _dt.TableName + "] SET");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				body.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "] = ");
				if (_dt.Rows[i]["name"].ToString().ToLower().Equals("addtime")
				 || _dt.Rows[i]["name"].ToString().ToLower().Equals("adddate"))
				{
					body.Append("GETDATE()");
				}
				else
				{
					body.Append("@" + _dt.Rows[i]["name"].ToString());
				}
				if (i == _dt.Rows.Count - 1)
				{
					body.Append("\r\n");
					body.Append(GetWhereConditionInProc() + "\r\n");
				}
				else
				{
					body.Append(", ");
				}
			}
			body.Append("End\r\n");

			body.Append(Bottum());
			return body.ToString();

		}

		//*******************************GetAll
		private string CreateBodyGetAll()
		{
			StringBuilder body = new StringBuilder();
			body.Append("   SELECT ");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (i % 6 == 0 && i != 0)
				{
					body.Append("\r\n");
					body.Append("\t\t");
				}
				body.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "]");
				if (i < _dt.Rows.Count - 1)
				{
					body.Append(", ");
				}
			}
			body.Append(" FROM [" + _dt.TableName + "]");
			body.Append("\r\n");

			return body.ToString();

		}

		//*******************************GetByID
		private string CreateBodyGetByPrimarykey()
		{
			StringBuilder body = new StringBuilder();
			body.Append("   SELECT ");
			for (int i = 0; i < _dt.Rows.Count; i++)
			{
				if (i % 6 == 0 && i != 0)
				{
					body.Append("\r\n");
					body.Append("       ");
				}
				body.Append("[" + _dt.Rows[i]["name"].ToString().ToUpper() + "]");
				if (i < _dt.Rows.Count - 1)
				{
					body.Append(", ");
				}
			}
			body.Append(" FROM [" + _dt.TableName + "]");
			body.Append(GetWhereConditionInProc() + ";\r\n");

			return body.ToString();

		}

		//*******************************Del
		private string CreateBodyDel()
		{
			StringBuilder body = new StringBuilder();
			body.Append("   DELETE ");
			body.Append(" FROM [" + _dt.TableName + "]");
			body.Append(GetWhereConditionInProc() + ";\r\n");

			body.Append(Bottum());
			return body.ToString();

		}

		#endregion
	}
}

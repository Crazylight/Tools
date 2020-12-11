using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LayersProductor
{
	public class Facade
	{
		/*静态方法 VS 非静态方法
		 * 1. 静态方法属于类， 非静态方法属于实例
		 * 2. 静态方法一开始就分配到内存（）， 非静态方法需要在创建实例的时候才分配内存；
		 * 3. 静态方法效率高，但不能自动销毁
		 * 4. 静态方法和静态变量始终使用同一块内存，而实例会创建多个内存；
		 * 5.获取类的名称：
		 *  静态： string className = System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.FullName;
		 *  非静态： string className = this.GetTyoe().FullName;
		 *  6. 静态速度快， 占内存
		 *  
		 * 总结： 实例化方法更多的被使用和稳妥， 静态方法少使用。
		 * 如果从线程安全、 性能、兼容性上来看， 也是选实例化方法为宜；
		 * **************************************************************************************/
		public static string GenerateEntity(DataTable dt, string projName, string entityName)
		{
			//   return EntityPro.getInstance(dt, projName, entityName).CreatePropertyEntity();
			return EntityPro.getInstance(dt, projName, entityName).CreatePublicEntity();
		}
		public static string CreateMVCModel(DataTable dt, string projName, string entityName)
		{
			//   return EntityPro.getInstance(dt, projName, entityName).CreatePropertyEntity();
			return EntityPro.getInstance(dt, projName, entityName).CreateMVCModel();
		}

		public static string GenerateDAL(DataTable dt, string projName, string entityName)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			//BizDAL dal = new BizDAL(dt, projName, entityName);
			//SQLDALPro dal = new SQLDALPro(dt, projName, entityName);
			//SqlParamsDAL dal = new SqlParamsDAL(dt, projName, entityName);
			SQLDALProForNiugu dal = new SQLDALProForNiugu(dt, projName, entityName);
			return dal.CreateDAL();
		}

		public static string GenerateBLL(DataTable dt, string projName, string entityName)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			// return SQLBLLPro.getInstance(dt, projName, entityName).CreateBLL();
			return BizBLL.getInstance(dt, projName, entityName).CreateBLL();
		}

		/******************************存贮过程********************************************/
		public static string GenerateProcAdd(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProcCreater.getInstance(dt).CreateProcAdd();
		}

		public static string GenerateProcUpdate(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProcCreater.getInstance(dt).CreateProcUpdate();
		}

		public static string GenerateProcAddOrUpdate(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProcCreater.getInstance(dt).CreateProcAddOrUpdate();
		}
		public static string GenerateProcGetAll(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProcCreater.getInstance(dt).CreateProcGetAll();
		}

		public static string GenerateProcGetByID(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProcCreater.getInstance(dt).CreateProcGetByID();
		}

		public static string GenerateProcDelByID(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProcCreater.getInstance(dt).CreateProcDel();
		}

		/******************************存贮过程调用********************************************/
		public static string GenerateProcCaller_Row(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProCaller.getInstance(dt).CreateProCaller_Row();
		}
		public static string GenerateProcCaller_Entity(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProCaller.getInstance(dt).CreateProCaller_Entity();
		}

		public static string GenerateProcCaller_Parameter(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return "";
			}
			return ProCaller.getInstance(dt).CreateProCaller_Parameter();
		}
	}
}

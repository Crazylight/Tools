using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor
{
    internal class EntityProj
    {
        static EntityProj _entity;
        private EntityProj()
        {

        }

        public static EntityProj getInstance()
        {
            if (_entity == null)
            {
                _entity = new EntityProj();
            }
            return _entity;
        }

        public string CreateBaseEntity(string nameSpace)
        {
            StringBuilder file = new StringBuilder();
            file.Append("using System;\r\n");
            file.Append("namespace " + nameSpace + "\r\n");
            file.Append("{\r\n");
            file.Append("   public class BaseEntity\r\n");
            file.Append("   {\r\n");
            file.Append("       public BaseEntity()\r\n");
            file.Append("       {\r\n");
            file.Append("       }\r\n");
            file.Append("\r\n");
            file.Append("\r\n");
            file.Append("\r\n");
            file.Append("   }\r\n");
            file.Append("}\r\n");


            return file.ToString();
        }

        public string CreateResultEntity(string nameSpace)
        {
            StringBuilder file = new StringBuilder();
            file.Append("using System;\r\n");
            file.Append("namespace " + nameSpace + "\r\n");
            file.Append("{\r\n");
            file.Append("   public class Result\r\n");
            file.Append("   {\r\n");
            file.Append("       public Result()\r\n");
            file.Append("       {\r\n");
            file.Append("       }\r\n\r\n");
            file.Append("         #region Status\r\n");
            file.Append("       /// <summary>\r\n");
            file.Append("       ///\r\n");
            file.Append("       /// </summary>\r\n");
            file.Append("        public int Status{get;set;}\r\n");
            file.Append("        #endregion\r\n\r\n");
            file.Append("         #region Msg\r\n");
            file.Append("       /// <summary>\r\n");
            file.Append("       ///\r\n");
            file.Append("       /// </summary>\r\n");
            file.Append("         public string Msg{get;set;}\r\n");
            file.Append("        #endregion\r\n\r\n");
            file.Append("         #region Data\r\n");
            file.Append("       /// <summary>\r\n");
            file.Append("       ///\r\n");
            file.Append("       /// </summary>\r\n");
            file.Append("         public object Data{get;set;}\r\n");
            file.Append("         #endregion\r\n\r\n");
            file.Append("   }\r\n");
            file.Append("}\r\n");


            return file.ToString();
        }
    }
}

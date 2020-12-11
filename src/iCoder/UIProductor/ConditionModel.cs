using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIProductor.Page;
using System.Data;

namespace UIProductor
{
    public class ConditionModel
    {
        public ConditionModel()
        {

        }

        public string TableName { get; set; }

        public DataTable Table { get; set; }

        public string EntityName { get; set; }

        public string NameSpace { get; set; }

        public ePageType PageType { get; set; }

        public bool IsDOL { get; set; }

        public eShowMsg MsgType { get; set; }
    }
}

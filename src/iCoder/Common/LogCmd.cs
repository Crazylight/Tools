using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LogCmd
    {
        static object logLock = new object();
        static string logpath = string.Empty;
        static LogCmd()
        {

        }

        public static void WriteLog(String filename, String msg)
        {

            msg = string.Format("{0} {1}\r\n", System.DateTime.Now.ToString(), msg);
            string fLogName = string.Format("{0}{1}{2}", logpath, System.DateTime.Now.ToString("yyyy-MM-dd HH "), filename);
            try
            {
                if (!fLogName.EndsWith(".log"))
                {
                    fLogName += ".log";
                }
                using (FileStream fs = new FileStream(fLogName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    using (BinaryWriter w = new BinaryWriter(fs))
                    {
                        w.Write(msg.ToCharArray());
                    }
                }
            }
            catch (Exception exp)
            {
                string s = exp.Message;
            }
        }

    }
}

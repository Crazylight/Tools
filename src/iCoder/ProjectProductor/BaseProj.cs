using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ProjectProductor
{
    internal class BaseProj
    {
        #region Fields
        protected string _projectName;
        protected string _rootDirPath;
        protected Hashtable _projectHash;
        protected DelegateCreateFile _CreateFile;
        protected DelegateCreateDirectory _CreateDir;
        #endregion

        public BaseProj()
        {
            _CreateFile = new DelegateCreateFile(CreateFile);
            _CreateDir = new DelegateCreateDirectory(CreateDirectory);
        }

        private void CreateFile(string filePath, string content)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            // if (!File.Exists(filePath))
            {
                //FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
                //StreamWriter sw = new StreamWriter(fileStream);
                //sw.Write(content);
                //sw.Flush();
                //sw.Close();
            }

            File.WriteAllText(filePath, content, UTF8Encoding.UTF8);
        }

        private void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }


        protected delegate void DelegateCreateDirectory(string dicPath);
        protected delegate void DelegateCreateFile(string filePath, string fileContent);
    }
}

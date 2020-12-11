using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectProductor
{
    public class ProjFacade
    {
        static ProjFacade _instance;
        ProjStart start;
        private ProjFacade(string rootDir, string projName)
            : base()
        {
            start = new ProjStart(rootDir, projName);
        }

        public static ProjFacade getInstance(string rootDir, string projName)
        {
            //if (null == _instance)
            //{
            return _instance = new ProjFacade(rootDir, projName);
            //}

            //return _instance;
        }

        public void CreateProject()
        {
            CreateDirs();
            CreateProjConfigFiles();

            CreateBLLFiles();
            CreateDALFiles();
            CreateEntityFiles();
            CreateWebFiles();
            CreateWizardFiles();
        }

        private void CreateDirs()
        {
            start.CreateProjectDirs();
        }

        private void CreateProjConfigFiles()
        {
            start.CreateProjConfigFiles();
        }


        private void CreateWebFiles()
        {
            start.CreateWebFiles();
        }

        private void CreateEntityFiles()
        {
            start.CreateEntityFiles();
        }

        private void CreateDALFiles()
        {
            start.CreateDALFiles();
        }

        private void CreateBLLFiles()
        {
            start.CreateBLLFiles();
        }

        private void CreateWizardFiles()
        {
            start.CreateWizardFiles();
        }

    }
}

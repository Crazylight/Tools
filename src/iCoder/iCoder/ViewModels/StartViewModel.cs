using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace iCoder.ViewModels
{
    public class StartViewModel
    {
        public StartViewModel()
        {

        }


        #region Commands
        #region Create New Version Previous
        private DelegateCommand _createLayersCommand;
        public ICommand CreateLayersCommand
        {
            get
            {
                if (_createLayersCommand == null)
                {
                    _createLayersCommand = new DelegateCommand(ExcuteCreateLayersCommand, () => { return true; });
                }
                return _createLayersCommand;
            }
        }
        private void ExcuteCreateLayersCommand()
        {
           
        }
        #endregion

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class AddManagerViewModel: ViewModelBase
    {
        AddManagerView view;
        Service service = new Service();

        public AddManagerViewModel(AddManagerView view )
        {
            this.view = view;
            manager = new vwManager();
            ManagerList = service.GetAllManagerView().ToList();

        }
        #region Properties
        private vwManager manager;
        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }
        #region Properties
        private List<vwManager> managerList;
        public List<vwManager> ManagerList
        {
            get { return managerList; }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }



        /// <summary>
        /// Checks if its possible to execute the add and edit manager commands
        /// </summary>
        private bool isUpdateManager;
        public bool IsUpdateManager
        {
            get
            {
                return isUpdateManager;
            }
            set
            {
                isUpdateManager = value;
            }
        }
        #endregion

        #endregion

        #region Commands
        /// <summary>
        /// command save
        /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        /// <summary>
        /// command close
        /// </summary>
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        #endregion

        #region Functions
        /// <summary>
        /// Save execute- how to save admin
        /// </summary>
        private void SaveExecute()
        {
            var result = MessageBox.Show("Are you sure you want to create this manager?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    service.AddManager(Manager);
                    IsUpdateManager = true;
                    service.GetAllManagerView().ToList();
                    MessageBox.Show("You successfully created manager!", "Notification");
                    view.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception" + ex.Message.ToString());
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Can save
        /// </summary>
        /// <returns></returns>
        private bool CanSaveExecute()
        {

            
                return true;
           
        }
        /// <summary>
        /// Close execute
        /// </summary>
        private void CloseExecute()
        {
            view.Close();
        }
        /// <summary>
        /// Can close
        /// </summary>
        /// <returns></returns>
        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
    

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
    class AddEmployeeViewModel: ViewModelBase
    {
        AddEmployeeView eview;
        Service service = new Service();

        public AddEmployeeViewModel(AddEmployeeView eview)
        {
            this.eview = eview;
            employee = new vwEmployee();
            EmployeeList = service.GetAllEmployeeView().ToList();

        }
        #region Properties
        private vwEmployee employee;
        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }
        #region Properties
        private List<vwEmployee> employeeList;
        public List<vwEmployee> EmployeeList
        {
            get { return employeeList; }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }



        /// <summary>
        /// Checks if its possible to execute the add and edit employee commands
        /// </summary>
        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
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
            var result = MessageBox.Show("Are you sure you want to create this employee?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {

                    service.AddEmployee(Employee);
                    IsUpdateEmployee = true;
                    service.GetAllEmployeeView().ToList();
                    MessageBox.Show("You successfully created employee!", "Notification");
                    eview.Close();
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
            if (service.CanCreateEmployee(employee))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

          
        /// <summary>
        /// Close execute
        /// </summary>
        private void CloseExecute()
        {
            eview.Close();
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
    

    

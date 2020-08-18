using System;
using System.Collections.Generic;
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
    class ManagerViewModel : ViewModelBase
    {
        ManagerView managerView;
        Service service = new Service();


        #region Constructor
        public ManagerViewModel(ManagerView view)
        {
            managerView = view;
            EmployeeList = service.GetAllEmployeeView().ToList();
        }
        #endregion

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

        private vwEmployee employee;
        public vwEmployee Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private Visibility employeeView = Visibility.Visible;
        public Visibility EmployeeView
        {
            get
            {
                return employeeView;
            }
            set
            {
                employeeView = value;
                OnPropertyChanged("EmployeeView");
            }
        }
        #endregion


        private ICommand logOut;
        public ICommand LogOut
        {
            get
            {
                if (logOut == null)
                {
                    logOut = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logOut;
            }
        }
        public bool CanLogoutExecute()
        {
            return true;
        }

        public void LogoutExecute()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                managerView.Close();
            }
        }
    }
}




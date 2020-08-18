using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        LoginView view;
        Service service = new Service();


        #region Constructors

        public LoginViewModel(LoginView view)
        {
            this.view = view;

        }
        #endregion

        #region Property

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

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


        #endregion

        #region Commands
        private ICommand login;
        /// <summary>
        /// Command login
        /// </summary>
        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
            set { login = value; }
        }
        /// <summary>
        /// Method for checking username and password
        /// </summary>
        /// <param name="o"></param>
        private void LoginExecute(object o)
        {
            try
            {
                StreamReader sr = new StreamReader(@"..\..\OwnerAccess.txt");
                string line = "";
                List<string> owner = new List<string>();

                while ((line = sr.ReadLine()) != null)
                {
                    owner.Add(line);
                }
                sr.Close();
                string password = (o as PasswordBox).Password;
                if (userName == owner[0] && password == owner[1])
                {
                    OwnerView ow = new OwnerView();
                    view.Close();
                    ow.ShowDialog();
                }

                else if (service.IsUser(UserName))
                {
                    Manager = service.FindManager(UserName);
                    ManagerView managerView = new AdministratorView();
                    view.Close();
                    managerView.ShowDialog();

                }


                else
                {
                    MessageBox.Show("Incorrect username or password");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        #endregion
    }
}
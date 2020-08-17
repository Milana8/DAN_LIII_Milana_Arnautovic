﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class OwnerViewModel : ViewModelBase
    {
        OwnerView oView;

        public OwnerViewModel(OwnerView oView)
        {
            this.oView = oView;
        }

        private ICommand addEmployee;

        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeeExecute(), param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }

        public bool CanAddEmployeeExecute()
        {
            return true;
        }

        public void AddEmployeeExecute()
        {
            AddEmployeeView employeeView = new AddEmployeeView();
            employeeView.ShowDialog();
        }
    

    private ICommand addManager;

    public ICommand AddManager
    {
        get
        {
            if (addManager == null)
            {
                addManager = new RelayCommand(param => AddManagerExecute(), param => CanAddManagerExecute());
            }
            return addManager;
        }
    }

    public bool CanAddManagerExecute()
    {
        return true;
    }

    public void AddManagerExecute()
    {
        AddManagerView managerView = new AddManagerView();
        managerView.ShowDialog();
    }



}
}

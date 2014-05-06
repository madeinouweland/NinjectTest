using System;
using System.Windows.Input;
using NinjectTest.Interfaces;
using NinjectTest.Utilities;
using NinjectTest.Services;

namespace NinjectTest.ViewModels {
    public class MainViewModel : IMainViewModel {
        public string PageName {
            get { return "Pagina 1"; }
        }

        public ICommand AddEmployeeCommand { get; private set; }

        public MainViewModel() {
            AddEmployeeCommand = new DelegateCommand<object>(o => IOC.Get<EmployeeService>().AddEmployee());
        }
    }
}

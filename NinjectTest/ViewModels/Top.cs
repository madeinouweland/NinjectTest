using Ninject;
using NinjectTest.Container;
using NinjectTest.Interfaces;
using NinjectTest.Model;
using NinjectTest.Services;
using NinjectTest.Utilities;

namespace NinjectTest.ViewModels {
    public class Top {
        public Top() {
            // IOC.Instance is created in App() 
            // Dusring design time is is null and then we create it with DesignTimeBinder
            if (IOC.Instance == null) {
                IOC.Instance = new StandardKernel(new DesignTimeBinder());
            }
        }

        public IMainViewModel MainViewModel {
            get { return IOC.Get<IMainViewModel>(); }
        }
        public EmployeeService EmployeeService {
            get { return IOC.Get<EmployeeService>(); }
        }

        public RootModel RootModel {
            get { return IOC.Get<RootModel>(); }
        }
    }
}

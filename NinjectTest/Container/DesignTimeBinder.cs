using Ninject.Modules;
using NinjectTest.Entities;
using NinjectTest.Interfaces;
using NinjectTest.Model;
using NinjectTest.ViewModels;

namespace NinjectTest.Container {
    public class DesignTimeBinder : NinjectModule {
        public override void Load() {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<RootModel>().ToMethod(l => {
                var w = new RootModel();
                w.Employees.Add(new Employee {
                    Name = "Vera",
                    Salary = 1000
                });
                w.Employees.Add(new Employee {
                    Name = "Chuck",
                    Salary = 2000
                });
                return w;
            });
        }
    }
}

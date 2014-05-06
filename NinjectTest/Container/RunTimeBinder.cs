using Ninject.Modules;
using NinjectTest.Interfaces;
using NinjectTest.Model;
using NinjectTest.Services;
using NinjectTest.ViewModels;

namespace NinjectTest.Container {
    public class RunTimeBinder : NinjectModule {
        public override void Load() {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<RootModel>().ToSelf().InSingletonScope();
            Bind<EmployeeService>().ToSelf().InSingletonScope();
        }
    }
}

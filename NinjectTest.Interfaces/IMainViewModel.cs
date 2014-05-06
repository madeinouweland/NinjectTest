using System.Windows.Input;
namespace NinjectTest.Interfaces {
    public interface IMainViewModel {
        ICommand AddEmployeeCommand { get; }
        string PageName { get; }
    }
}

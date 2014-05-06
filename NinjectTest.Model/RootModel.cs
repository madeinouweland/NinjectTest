using System.Collections.ObjectModel;
using NinjectTest.Entities;

namespace NinjectTest.Model {
    public class RootModel {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees {
            get {
                return employees;
            }
        }
    }
}

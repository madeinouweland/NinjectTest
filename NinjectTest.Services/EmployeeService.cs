using System;
using System.Collections.Generic;
using System.Windows.Input;
using NinjectTest.Entities;
using NinjectTest.Interfaces;
using NinjectTest.Model;
using NinjectTest.Utilities;

namespace NinjectTest.Services {
    public class EmployeeService : IService {
        public void Start() {
            var employees = new List<Employee>();
            employees.Add(new Employee { Name = "Vera" });
            employees.Add(new Employee { Name = "Chuck" });
            employees.Add(new Employee { Name = "Dave" });

            foreach (var employee in employees) {
                IOC.Get<RootModel>().Employees.Add(employee);
            }

            AddEmployeeCommand = new DelegateCommand<object>(o => {
                IOC.Get<RootModel>().Employees.Add(new Employee { Name = "TEST" + DateTime.Now });
            });

        }

        public void Stop() {
        }

        public void AddEmployee() {
            IOC.Get<RootModel>().Employees.Add(new Employee { Name = "Test", Salary = DateTime.Now.Millisecond });
        }

        public ICommand AddEmployeeCommand { get; set; }
    }
}

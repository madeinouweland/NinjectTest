using System;
using NinjectTest.Utilities;

namespace NinjectTest.Entities {
    public class Employee : ObservableObject {
        public string Name {
            get { return name; }
            set {
                if (name != value) {
                    name = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        private string name;

        public Decimal Salary {
            get { return salary; }
            set {
                if (salary == value) return;

                salary = value;
                OnPropertyChanged(() => Salary);
            }
        }

        private Decimal salary;

    }
}

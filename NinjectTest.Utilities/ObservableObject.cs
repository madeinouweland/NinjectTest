using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace NinjectTest.Utilities {

    public class ObservableObject : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged<TViewModel>(
            Expression<Func<TViewModel>> property
            ) {
            var pc = PropertyChanged;
            if (pc == null) {
                return;
            }

            var expression = (MemberExpression)property.Body;

            var name = expression.Member.Name;
            pc(this, new PropertyChangedEventArgs(name));
        }
    }

}
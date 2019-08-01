using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace CSharpWPF
{
    public class DelegateCommand : ICommand
    {
        public DelegateCommand(INotifyPropertyChanged owner, Action execute)
        {
            owner.PropertyChanged += (s, e) => OnCanExecuteChanged();
            _execute = x => execute();
            _canExecute = x => true;
        }
        public DelegateCommand(INotifyPropertyChanged owner, Action execute, Func<bool> canExecute)
        {
            owner.PropertyChanged += (s, e) => OnCanExecuteChanged();
            _execute = x => execute();
            _canExecute = x => canExecute();
        }
        public DelegateCommand(INotifyPropertyChanged owner, Action<object> execute)
        {
            owner.PropertyChanged += (s, e) => OnCanExecuteChanged();
            _execute = execute;
            _canExecute = x => true;
        }
        public DelegateCommand(INotifyPropertyChanged owner, Action<object> execute, Func<object, bool> canExecute)
        {
            owner.PropertyChanged += (s, e) => OnCanExecuteChanged();
            _execute = execute;
            _canExecute = canExecute;
        }


        private readonly Action<object> _execute;
        public void Execute(object value) => _execute(value);

        private readonly Func<object, bool> _canExecute;
        public bool CanExecute(object value) => _canExecute(value);

        public event EventHandler CanExecuteChanged;
        public virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged == null) return;
            CanExecuteChanged(this, EventArgs.Empty);
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace CSharpWPF
{
    public class MouseCoordinatesAction : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command",
            typeof(ICommand),
            typeof(MouseCoordinatesAction),
            new UIPropertyMetadata(null)
            );
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            var eventArgs = parameter as MouseEventArgs;
            var element = AssociatedObject as IInputElement;
            if (Command == null || eventArgs == null || element == null) return;
            var position = eventArgs.GetPosition(element);
            if (Command.CanExecute(position))
            {
                Command.Execute(position);
            }
        }

    }
}

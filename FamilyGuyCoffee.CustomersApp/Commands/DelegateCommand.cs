using System.Windows.Input;

namespace FamilyGuyCoffee.CustomersApp.Commands
{
    public class DelegateCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = canExecute;
        }

        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }


}

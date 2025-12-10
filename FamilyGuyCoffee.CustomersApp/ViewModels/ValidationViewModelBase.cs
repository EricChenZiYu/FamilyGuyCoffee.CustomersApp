using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FamilyGuyCoffee.CustomersApp.ViewModels
{
    public class ValidationViewModelBase : ViewModelbase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new Dictionary<string, List<string>>();
        public bool HasErrors => _errorsByPropertyName.Count != 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_errorsByPropertyName.ContainsKey(propertyName))
                return Enumerable.Empty<string>();

            return _errorsByPropertyName[propertyName];
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
        }

        protected void AddError(string error, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null)
            {
                return;
            }
            if (!_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }
            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors([CallerMemberName] string? propertyName = null)
        {
            if (propertyName is null)
            {
                return;
            }
            if (_errorsByPropertyName.ContainsKey(propertyName))
            {
                _errorsByPropertyName.Remove(propertyName);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }
    }
}

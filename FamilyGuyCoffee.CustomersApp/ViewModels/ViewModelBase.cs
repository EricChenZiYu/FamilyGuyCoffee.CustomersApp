using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FamilyGuyCoffee.CustomersApp.ViewModels
{
    public class ViewModelbase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual async Task LoadAsync()
        {
            await Task.CompletedTask;
        }
    }
}

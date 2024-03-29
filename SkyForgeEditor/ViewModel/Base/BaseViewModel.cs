using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SkyForgeEditor.ViewModel.Base
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        protected virtual void PropertyChange([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T? field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (field?.Equals(value) ?? true)
                return false;
            
            field = value;
            PropertyChange(PropertyName);
            return true;
        }

    }
}

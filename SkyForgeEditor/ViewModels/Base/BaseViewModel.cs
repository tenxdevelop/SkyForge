/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeEditor.Infrastructure.Reactive.WPF;
using System.ComponentModel;

namespace SkyForgeEditor.ViewModels.Base
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public BaseViewModel()
        {
            var type = GetType();
            var reactiveProperties = type.GetProperties().Where(property => typeof(IReactivePropertyWPF).IsAssignableFrom(property.PropertyType));

            foreach (var propertyInfo in reactiveProperties)
            {
                var property = propertyInfo.GetValue(this) as IReactivePropertyWPF;
                property?.Bind(this);
            }
        }

        public void OnChangedProperty(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

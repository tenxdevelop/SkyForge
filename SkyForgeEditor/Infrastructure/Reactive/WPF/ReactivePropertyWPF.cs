/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeEditor.ViewModels.Base;
using System.Runtime.CompilerServices;

namespace SkyForgeEditor.Infrastructure.Reactive.WPF
{
    public class ReactivePropertyWPF<T> : ReactiveProperty<T>, IReactivePropertyWPF
    {
        private string m_propertyName;
        public ReactivePropertyWPF([CallerMemberName] string propertyName = null)
        {
            m_propertyName = propertyName;
        }

        public void Bind(BaseViewModel viewModel)
        {
            ObservableSubscribeExtention.Subscribe(this, _ => viewModel.OnChangedProperty(m_propertyName));
        }
    }

    public interface IReactivePropertyWPF
    {
        void Bind(BaseViewModel viewModel);
    }
}

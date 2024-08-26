
using SkyForgeEditor.ViewModels.Base;
using System.Runtime.CompilerServices;

namespace SkyForgeEditor.Infrastructure.Reactive.WPF
{
    public class ReactiveProperty<T> : Reactive.ReactiveProperty<T>, IReactiveProperty
    {
        private string m_propertyName;
        public ReactiveProperty([CallerMemberName] string propertyName = null)
        {
            m_propertyName = propertyName;
        }

        public void Bind(BaseViewModel viewModel)
        {
            ObservableSubscribeExtention.Subscribe(this, _ => viewModel.OnChangedProperty(m_propertyName));
        }
    }

    public interface IReactiveProperty
    {
        void Bind(BaseViewModel viewModel);
    }
}

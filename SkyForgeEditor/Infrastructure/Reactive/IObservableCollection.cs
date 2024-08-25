/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeEngine.Infrastructure.Reactive
{
    public interface IObservableCollection<T>
    {
        IBinding Subscribe(IObserverCollection<T> observer);
        void Unsubscribe(IObserverCollection<T> observer);
    }
}

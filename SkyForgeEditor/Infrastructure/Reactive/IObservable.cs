/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeEngine.Infrastructure.Reactive
{
    public interface IObservable<out T>
    {
        IBinding Subscribe(IObserver<T> observer);
        void Unsubscribe(IObserver<T> observer);
    }
}

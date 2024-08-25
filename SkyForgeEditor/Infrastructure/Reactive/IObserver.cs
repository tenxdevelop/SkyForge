/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


namespace SkyForgeEngine.Infrastructure.Reactive
{
    public interface IObserver<in T> : IDisposable
    {
        void NotifyObservableChanged(object sender, T value);
    }
}

/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


namespace SkyForgeEngine.Infrastructure.Reactive
{
    public interface IObserverCollection<in T> : IDisposable
    {
        void NotifyCollectionAdded(object sender, T newValue);
        void NotifyCollectionRemoved(object sender, T newValue);
        void NotifyCollectionClear(object sender);
    }
}

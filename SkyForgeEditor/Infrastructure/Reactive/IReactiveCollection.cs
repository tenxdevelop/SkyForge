/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/


namespace SkyForgeEngine.Infrastructure.Reactive
{
    public interface IReactiveCollection<T> : IObservableCollection<T>, ICollection<T>
    {
        void Add(object sender, T item);
        void Clear(object sender);
        bool Remove(object sender, T item);

    }
}

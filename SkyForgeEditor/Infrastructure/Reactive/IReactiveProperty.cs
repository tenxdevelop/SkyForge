/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeEngine.Infrastructure.Reactive
{
    public interface IReactiveProperty<out T> : IObservable<T>
    {
        T Value { get; }  
    }
}

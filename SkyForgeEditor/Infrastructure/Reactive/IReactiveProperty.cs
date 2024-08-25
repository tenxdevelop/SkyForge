/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace HavocAndSouls.Infrastructure.Reactive
{
    public interface IReactiveProperty<out T> : IObservable<T>
    {
        T Value { get; }  
    }
}

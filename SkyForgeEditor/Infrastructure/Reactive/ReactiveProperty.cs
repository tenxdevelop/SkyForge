/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeEditor.Infrastructure.Reactive
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {  
        public T Value { get => m_value; set => SetValue(null, value); }

        private T m_value;
        private List<IObserver<T>> m_observers;
        public ReactiveProperty() : this(default(T)) { }

        public ReactiveProperty(T value)
        {
            m_value = value;
            m_observers = new List<IObserver<T>>();
        }

        public IBinding Subscribe(IObserver<T> observer)
        {
            if (!m_observers.Contains(observer))
            {
                m_observers.Add(observer);
                return new ReactiveSubscription<T>(this, observer);
            }
            return null;
        }

        public void Unsubscribe(IObserver<T> observer)
        {
            if (!m_observers.Contains(observer))
            {
                m_observers.Remove(observer);
            }
        }

        public void SetValue(object sender, T value)
        {
            if (m_value != null && m_value.Equals(value))
                return;

            m_value = value;
            OnChanged(sender, value);
        }

        protected virtual void OnChanged(object sender, T newValue)
        {
            foreach (var observer in m_observers)
                observer.NotifyObservableChanged(sender, newValue);
        }
    }  
}

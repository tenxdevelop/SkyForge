/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using SkyForgeEditor.Infrastructure;

namespace SkyForgeEditor
{
    public class DIContainer
    {
        private DIContainer m_parentContainer;

        private Dictionary<(string, Type), DIEntry> m_container;
        private HashSet<(string, Type)> m_cachedKey;

        public DIContainer(DIContainer parentContainer = null)
        {
            m_container = new Dictionary<(string, Type), DIEntry>();
            m_cachedKey = new HashSet<(string, Type)>();

            m_parentContainer = parentContainer;
        }

        public void Register<T>(Func<DIContainer, T> factory)
        {
            Register(("", typeof(T)), factory);
        }

        public void Register<T>(Func<DIContainer, T> factory, string tag)
        {
            Register((tag, typeof(T)), factory);
        }

        public void RegisterSingleton<T>(Func<DIContainer, T> factory)
        {
            RegisterSingleton(("", typeof(T)), factory);
        }

        public void RegisterSingleton<T>(Func<DIContainer, T> factory, string tag)
        {
            RegisterSingleton((tag, typeof(T)), factory);
        }

        public void RegisterInstance<T>(T instance)
        {
            RegisterInstance(("", typeof(T)), _ => instance);
        }

        public void RegisterInstance<T>(T instance, string tag)
        {
            RegisterInstance((tag, typeof(T)), _ => instance);
        }

        public T Resolve<T>(string tag = "")
        {
            var key = (tag, typeof(T));

            if (m_cachedKey.Contains(key))
            {

                //TODO: get to the log error warning "Debug.LogWarning($"factory with key: {key} is already being searched in the DIcontainer");"
                return default(T);
            }

            m_cachedKey.Add(key);
            T result = FindFactory<T>(key);
            m_cachedKey.Remove(key);

            return result;
        }

        private T FindFactory<T>((string, Type) key)
        {
            T result;
            if (!m_container.ContainsKey(key))
            {
                if(m_parentContainer is null)
                    result = default(T);
                result = m_parentContainer.FindFactory<T>(key);
            }
            else
            {
                result = m_container[key].CreateFactory<T>();
            }
            return result;
        }

        private void Register<T>((string, Type) key, Func<DIContainer, T> factory)
        {
            if (CheckKey<T>(key))
                return;

            var dIEntry = new DIEntryTransient<T>(this, factory);
            m_container[key] = dIEntry;
        }

        private void RegisterSingleton<T>((string, Type) key, Func<DIContainer, T> factory)
        {
            if (CheckKey<T>(key))
                return;

            var dIEntry = new DIEntrySingleton<T>(this, factory);
            m_container[key] = dIEntry;
        }

        private void RegisterInstance<T>((string, Type) key, Func<DIContainer, T> factory)
        {
            Register(key, factory);    
        }

        private bool CheckKey<T>((string, Type) key)
        {
            var result = m_container.ContainsKey(key);

            //TODO: get to the log error warning "Debug.LogWarning($"{typeof(T).Name} contains with key: {key} in the DIcontainer");"
            return result;
        }
    }
}
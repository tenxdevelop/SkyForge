/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

namespace SkyForgeEditor.Infrastructure
{
    public class DIEntryTransient<T> : DIEntry<T>
    {
        public DIEntryTransient(DIContainer container, Func<DIContainer, T> factory) : base(container, factory) { }

        public override T CreateFactory()
        {
            return m_factory(m_container);
        }
    }
}

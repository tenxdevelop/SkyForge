/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using System;

namespace HavocAndSouls.Infrastructure.Reactive
{
    public interface IBinding : IDisposable
    {
        void Binded();
    }
}

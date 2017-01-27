using System;
using JetBrains.Annotations;
using LogoFX.Practices.IoC;
using Samples.Client.Model.Contracts;

namespace Samples.Client.Model
{
    [UsedImplicitly]
    class SimpleModule : ISimpleCompositionModule
    {
        public void RegisterModule(SimpleContainer container, Func<object> lifetimeScopeProvider)
        {
            container.RegisterPerLifetime(lifetimeScopeProvider, typeof(IDataService), null, typeof(DataService));
        }
    }
}
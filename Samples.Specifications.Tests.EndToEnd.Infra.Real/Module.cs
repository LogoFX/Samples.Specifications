﻿using Attest.Testing.Contracts;
using JetBrains.Annotations;
using LogoFX.Client.Testing.Contracts;
using LogoFX.Client.Testing.EndToEnd;
using Solid.Practices.IoC;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Real
{
    [UsedImplicitly]
    internal sealed class Module : ICompositionModule<IDependencyRegistrator>
    {
        public void RegisterModule(IDependencyRegistrator dependencyRegistrator) => dependencyRegistrator
            .AddSingleton<IStartApplicationService, StartApplicationService.WithRealProviders>()
            .AddSingleton<ISetupService, SetupService>();
    }
}

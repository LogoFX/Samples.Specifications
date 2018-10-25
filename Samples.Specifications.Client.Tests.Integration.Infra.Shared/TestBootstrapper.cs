﻿using LogoFX.Client.Bootstrapping;
using LogoFX.Client.Bootstrapping.Adapters.SimpleContainer;
using Samples.Specifications.Client.Launcher.Shared;
using Samples.Specifications.Client.Presentation.Shell.ViewModels;

namespace Samples.Specifications.Client.Tests.Integration.Infra.Shared
{
    public class TestBootstrapper : TestBootstrapperContainerBase<ExtendedSimpleContainerAdapter>
        .WithRootObject<ShellViewModel>
    {
        public TestBootstrapper() :
            base(new ExtendedSimpleContainerAdapter(), new BootstrapperCreationOptions
            {
                UseApplication = false,
                ReuseCompositionInformation = true
            })
        {
            this.UseResolver().UseShared().Initialize();
        }

        public override string[] Prefixes => new[]
        {
            "Samples.Specifications.Client.Presentation", "Samples.Client.Model", "Samples.Specifications.Client.Data",
            "Samples.Specifications.Client.Tests", "Samples.Client.Tests", "Samples.Specifications.Tests.Steps"
        };

        public class SpecBased : TestBootstrapper
        {
            public override string[] Prefixes => new[]
            {
                "Samples.Specifications.Client.Presentation", "Samples.Client.Model",
                "Samples.Specifications.Client.Data"
            };
        }
    }
}
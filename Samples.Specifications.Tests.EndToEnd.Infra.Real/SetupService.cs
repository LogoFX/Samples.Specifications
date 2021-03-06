﻿using Attest.Testing.Contracts;
using Samples.Specifications.Tests.Steps.Real.Helpers;

namespace Samples.Specifications.Tests.EndToEnd.Infra.Real
{
    internal sealed class SetupService : ISetupService
    {
        private readonly ISetupHelper _setupHelper;

        public SetupService(ISetupHelper setupHelper)
        {
            _setupHelper = setupHelper;
        }

        public void Setup() => _setupHelper.Initialize();
    }
}

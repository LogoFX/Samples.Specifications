﻿using System.IO;
using LogoFX.Client.Testing.Contracts;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Steps
{
    public class GeneralSteps
    {
        private readonly IStartApplicationService _startApplicationService;

        public GeneralSteps(IStartApplicationService startApplicationService)
        {
            _startApplicationService = startApplicationService;
        }

        public void WhenIOpenTheApplication()
        {
            var testDirectory = Directory.GetCurrentDirectory();            
            var applicationDirectory = Directory.GetParent(testDirectory).FullName;
            var applicationPath = Path.Combine(applicationDirectory, "LogoFX.Samples.Specifications.Client.Launcher.exe");
            Directory.SetCurrentDirectory(applicationDirectory);
            _startApplicationService.StartApplication(applicationPath);            
            Directory.SetCurrentDirectory(testDirectory);
        }
    }
}

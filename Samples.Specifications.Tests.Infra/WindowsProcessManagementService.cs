using System;
using System.Diagnostics;
using JetBrains.Annotations;
using Samples.Specifications.Tests.Contracts;

namespace Samples.Specifications.Tests.Infra
{
    //TODO: Move to packages
    [UsedImplicitly]
    internal sealed class WindowsProcessManagementService : IProcessManagementService
    {
        public int Start(string tool, string args)
        {
            var process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    RedirectStandardError = false,
                    FileName = "cmd.exe",
                    CreateNoWindow = false,
                    Arguments = $"/k {tool} {args}"
                }
            };
            process.Start();
            return process.Id;
        }

        public void Stop(int processId)
        {
            Action killAction = () => processId.KillProcessAndChildren();
            killAction.Execute();
        }
    }
}

using System;
using System.Threading.Tasks;
using Solid.Practices.Scheduling;

namespace Samples.Client.Model
{
    internal abstract class ServiceBase
    {
        private readonly TaskFactory _taskFactory = TaskFactoryFactory.CreateTaskFactory();

        protected Task RunAsync(Action action) => _taskFactory.StartNew(action);

        protected Task<TResult> RunAsync<TResult>(Func<TResult> func) => _taskFactory.StartNew(func);
    }
}
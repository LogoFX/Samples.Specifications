using System.Collections.Generic;
using System.Linq;
using Solid.Bootstrapping;
using Solid.Extensibility;
using Solid.Practices.Composition;
using Solid.Practices.Composition.Container;
using Solid.Practices.Composition.Contracts;
using Solid.Practices.IoC;
using Solid.Practices.Middleware;
using Solid.Practices.Modularity;

namespace Samples.Specifications.Tests.Infra.Launcher
{
    internal sealed class Bootstrapper : IInitializable,
        IExtensible<Bootstrapper>,
        ICompositionModulesProvider,
        IHaveRegistrator
    {
        private readonly
            List<IMiddleware<Bootstrapper>>
            _middlewares =
                new List<IMiddleware<Bootstrapper>>();

        public Bootstrapper(IDependencyRegistrator dependencyRegistrator) => Registrator = dependencyRegistrator;

        public IEnumerable<ICompositionModule> Modules { get; private set; } = new ICompositionModule[] { };

        public string ModulesPath => ".";

        public string[] Prefixes { get; } =
        {
            "Samples.Specifications.Tests", "Samples.Specifications.Client.Tests", "Samples.Specifications.Tests.Steps"
        };

        public IDependencyRegistrator Registrator { get; }

        private void InitializeCompositionModules()
        {
            var compositionManager = new CompositionManager();
            try
            {
                compositionManager.Initialize(ModulesPath, Prefixes);
            }
#pragma warning disable 168 
            //Used for debug
            catch (AggregateAssemblyInspectionException ex)
#pragma warning restore 168
            {

            }
            finally
            {
                Modules = compositionManager.Modules.ToArray();
            }
        }

        public Bootstrapper Use(
            IMiddleware<Bootstrapper> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }

        public void Initialize()
        {
            InitializeCompositionModules();
            MiddlewareApplier.ApplyMiddlewares(this, _middlewares);
        }
    }
}
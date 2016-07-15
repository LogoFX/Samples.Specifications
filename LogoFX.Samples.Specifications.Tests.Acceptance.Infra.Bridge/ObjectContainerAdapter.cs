using System;
using System.Collections;
using System.Collections.Generic;
using BoDi;
using Solid.Practices.IoC;

namespace LogoFX.Samples.Specifications.Tests.Acceptance.Infra.Bridge
{
    class ObjectContainerAdapter : IIocContainer, IIocContainerAdapter<IObjectContainer>
    {
        private readonly IObjectContainer _objectContainer;

        public ObjectContainerAdapter(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        public void RegisterTransient<TService, TImplementation>() where TImplementation : class, TService
        {
            throw new System.NotImplementedException();
        }

        public void RegisterTransient<TService>() where TService : class
        {
            throw new System.NotImplementedException();
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _objectContainer.RegisterTypeAs<TImplementation, TService>();
        }

        public void RegisterInstance<TService>(TService instance) where TService : class
        {
            _objectContainer.RegisterInstanceAs(instance);
        }

        public void RegisterCollection<TService>(IEnumerable<Type> dependencyTypes) where TService : class
        {
            throw new NotImplementedException();
        }

        public void RegisterCollection<TService>(IEnumerable<TService> dependencies) where TService : class
        {
            throw new System.NotImplementedException();
        }

        public void RegisterCollection(Type dependencyType, IEnumerable<Type> dependencyTypes)
        {
            throw new NotImplementedException();
        }

        public void RegisterCollection(Type dependencyType, IEnumerable<object> dependencies)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterCollection(Type dependencyType, IEnumerable dependencyTypes)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterCollection<TService>(IEnumerable dependencyTypes) where TService : class
        {
            throw new System.NotImplementedException();
        }

        public void RegisterHandler<TService>(Func<object> handler) where TService : class
        {
            throw new System.NotImplementedException();
        }

        public void RegisterHandler(Type dependencyType, Func<object> handler)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterHandler<TService>(Func<TService> handler) where TService : class
        {
            throw new NotImplementedException();
        }

        public void RegisterInstance(Type dependencyType, object instance)
        {
            _objectContainer.RegisterInstanceAs(instance, dependencyType);
        }

        public void RegisterSingleton(Type serviceType, Type implementationType)
        {
            throw new System.NotImplementedException();
        }

        public void RegisterTransient(Type serviceType, Type implementationType)
        {
            throw new System.NotImplementedException();
        }

        public TService Resolve<TService>() where TService : class
        {
            return _objectContainer.Resolve<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return _objectContainer.Resolve(serviceType);
        }

        public void Dispose()
        {
            _objectContainer.Dispose();
        }
    }
}
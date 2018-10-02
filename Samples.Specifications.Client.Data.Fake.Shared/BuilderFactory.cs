using System;
using System.Reflection;

namespace Samples.Specifications.Client.Data.Fake.Shared
{
    public static class BuilderFactory
    {
        public static object CreateBuilderInstance(Type type)
        {
            return CreateBuilderInstanceImpl(type);
        }

        private static object CreateBuilderInstanceImpl(Type type)
        {
            const string methodName = "CreateBuilder";
            return type.GetRuntimeMethod(methodName, new Type[] { }).Invoke(null, null);
        }
    }
}

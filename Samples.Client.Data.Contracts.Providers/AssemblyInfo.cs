using System.Reflection;

namespace Samples.Client.Data.Contracts.Providers
{
    public static class AssemblyInfo
    {
        public static string AssemblyName { get; } = $"{Assembly.GetExecutingAssembly().GetName().Name}.dll";
    }
}

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.Loader;
using Autofac;
using System.Text.RegularExpressions;

namespace Wb.Core
{
    /// <summary>
    /// Provides initialization and startup functions for bootstraping interfaces
    /// </summary>
    public static class Bootstrap
    {
        public static void RegisterAutofac(ContainerBuilder builder, string assemblyPrefix = "Wb.")
        {
            var types = GetTypesWithInterface(typeof(IConfigureDependencies), assemblyPrefix);
            var implementations = types.Select(t => t.CreateInstance<IConfigureDependencies>()).ToList();
            
            implementations.ForEach(i => i.Register(builder));
        }

        /// <summary>
        /// Gets a list of all types in the current domain that implement an interface
        /// </summary>
        /// <param name="type">Type type the interface must implement</param>
        /// <param name="assembleyFilter">The assembly prefix</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWithInterface(Type interfaceType, string assembleyFilter)
        {
            return AppDomain.CurrentDomain
                            .GetAssemblies()
                            .Where(a => string.IsNullOrEmpty(assembleyFilter) || Regex.IsMatch(a.FullName, assembleyFilter))
                            .SelectMany(a => a.GetTypes())
                            .Where(t => t.GetInterfaces()
                                        .Any(i => i == interfaceType));
        }

        /// <summary>
        /// Creates and instance of a type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        private static T CreateInstance<T>(this Type type) where T : class
        {
            return Activator.CreateInstance(type) as T;
        }
    }
}

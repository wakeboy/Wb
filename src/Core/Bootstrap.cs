using System;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyModel;
using System.Linq;
using System.Diagnostics;
using System.Runtime.Loader;
using Autofac;

namespace Wb.Core
{
    /// <summary>
    /// Provides initialization and startup functions for bootstraping interfaces
    /// </summary>
    public static class Bootstrap
    {
        public static void RegisterAutofac(ContainerBuilder builder, string assemblyPrefix = "Wb.")
        {
            var types = GetTypesWithInterface(typeof(IConfigureAutofac), assemblyPrefix);
            var implementations = types.Select(t => t.CreateInstance<IConfigureAutofac>()).ToList();
            
            implementations.ForEach(i => i.Register(builder));
        }

        /// <summary>
        /// Gets a lost of all types in the current domain that implement an interface
        /// </summary>
        /// <param name="type">Type type the interface must implement</param>
        /// <param name="assemblyPrefix">The assembly prefix</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWithInterface(Type interfaceType, string assemblyPrefix)
        {
            List<Type> interfaceList = new List<Type>();

            foreach (ProcessModule module in Process.GetCurrentProcess().Modules)
            {
                if (module.ModuleName.StartsWith(assemblyPrefix))
                {
                   var assemblyName = AssemblyLoadContext.GetAssemblyName(module.FileName);
                    var assembly = Assembly.Load(assemblyName);

                    interfaceList.AddRange(assembly.GetTypes()
                                       .Where(t => t.GetInterfaces()
                                                    .Any(i => i == interfaceType)));
                };
            }

            return interfaceList;
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

using Wb.Core;
using System;
using Autofac;
using Wb.PersistenceExample;

namespace PersistenceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            Bootstrap.RegisterAutofac(builder);
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = container.Resolve<IApplication>();
                app.Start();
            }
            
            Console.ReadKey();
        }
    }
}

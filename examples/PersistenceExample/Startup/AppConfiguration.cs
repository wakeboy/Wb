using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Wb.Core;

namespace Wb.PersistenceExample.Startup
{
    public class AppConfiguration : IConfigureDependencies
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<Application>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}

using Autofac;
using Wb.Core;
using Wb.PersistenceCore;
using Wb.PersistenceExample.Repository;
using Microsoft.EntityFrameworkCore;

namespace Wb.PersistenceExample.Startup
{
    public class PersistanceConfiguration : IConfigureDependencies
    {
        public void Register(ContainerBuilder builder)
        {
            var contextOptions = new DbContextOptionsBuilder()
                                .UseSqlServer(@"Server=localhost;Database=Demo;Trusted_Connection=True;")
                                .Options;

            builder.RegisterGeneric(typeof(WbDbContext<>))
                   .InstancePerLifetimeScope()
                   .WithParameter("options", contextOptions);

            builder.RegisterType<ProductRepository>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<ContactRepository>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}

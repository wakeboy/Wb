using Autofac;
using Wb.Core;
using Wb.Persistence;
using Wb.PersistenceExample.Repository;
using Microsoft.EntityFrameworkCore;

namespace Wb.PersistenceExample.Startup
{
    public class PersistanceConfiguration : IConfigureAutofac
    {
        public void Register(ContainerBuilder builder)
        {
            var contextOptions = new DbContextOptionsBuilder()
                                .UseSqlServer(@"Server=.\sqlexpress;Database=Demo;Trusted_Connection=True;")
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

using Autofac;

namespace Wb.Core
{
    public interface IConfigureDependencies
    {
        void Register(ContainerBuilder builder);
    }
}

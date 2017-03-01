using Autofac;

namespace Wb.Core
{
    public interface IConfigureAutofac
    {
        void Register(ContainerBuilder builder);
    }
}

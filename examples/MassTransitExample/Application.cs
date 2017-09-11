using System.Threading.Tasks;
using ConsoleCore;
using MassTransit;

namespace Wb.MassTransitExample
{
    public class Application : IApplication
    {
        private readonly IBusControl bus;

        public Application(IBusControl bus)
        {
            this.bus = bus;
        }

        public async Task Start()
        {
            await this.bus.StartAsync();
        }
        
        public async Task Stop()
        {
            await this.bus.StopAsync();
        }
    }
}

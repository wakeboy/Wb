using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Wb.Core;

namespace MassTransitCore
{
    public class MassTransitConfig
    {
        public MassTransitConfig(IConfigurationRoot configuration)
        {
            var config = configuration.GetSection("MassTransit");

        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Endpoint { get; set; }

        public string QueueName { get; set; }

        public void Configure()
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri(Endpoint), h =>
                {
                    h.Username(Username);
                    h.Password(Password);
                });

                sbc.ReceiveEndpoint(host, QueueName, ep =>
                {
                    ep.Handler<YourMessage>(context =>
                    {
                        return Console.Out.WriteLineAsync($"Received: {context.Message.Text}");
                    });
                });
            });

            bus.Start();

            bus.Publish(new YourMessage { Text = "Hi" });

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            bus.Stop();
        }

        public class YourMessage { public string Text { get; set; }}
    }
}

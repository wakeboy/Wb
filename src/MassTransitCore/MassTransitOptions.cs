using System;
using System.Collections.Generic;
using System.Text;

namespace MassTransitCore
{
    public class MassTransitOptions
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Endpoint { get; set; }

        public string QueueName { get; set; }
    }
}

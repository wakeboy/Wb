using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCore
{
    public interface IApplication
    {
        /// <summary>
        /// Run application startup code
        /// </summary>
        Task Start();

        /// <summary>
        /// Run application shut down code
        /// </summary>
        Task Stop();
    }
}

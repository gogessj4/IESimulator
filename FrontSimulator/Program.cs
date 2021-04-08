using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IssueEngine.Client.Domain.Interfaces;
using IssueEngine.Client.Domain.Resources;
using IssueEngine.Client.Messaging.Commands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FrontSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            Startup startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            Console.WriteLine("Console started!");

            var signalRManager = serviceProvider.GetService<ISignalRManager>();
            Task.Run(() => signalRManager.ConnectHubs());

            Console.WriteLine("Hubs Connected!");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using IssueEngine.Client.Domain.Interfaces;
using IssueEngine.Client.ServiceAgent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FrontSimulator
{
    public class Startup
    {
        IConfigurationRoot Configuration { get; }

        public Startup()
        {
            var builder = new ConfigurationBuilder();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ISignalRManager, SignalRManager>();
        }
    }
}

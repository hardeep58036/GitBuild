using GITBuild.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GITBuild
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            services
                .AddSingleton<Executor, Executor>()
                .BuildServiceProvider()
                .GetService<Executor>()
                .Execute();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IStartup, Startup>();
            services.AddSingleton<ITranslatationService, TranslatationService>();
            services.AddSingleton<ITranslator, Translator>();
        }
    }

    public class Executor
    {
        private readonly IStartup _start;

        public Executor(IStartup start)
        {
            _start = start;
        }

        public void Execute()
        {
            _start.Start();
            Console.ReadLine();
        }
    }
}

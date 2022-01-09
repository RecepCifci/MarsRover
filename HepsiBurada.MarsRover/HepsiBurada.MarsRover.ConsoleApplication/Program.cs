using Microsoft.Extensions.DependencyInjection;

namespace HepsiBurada.MarsRover.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = DIConfiguration.Configure();

            var app = serviceProvider.GetService<App>();
            app.Initialize();
        }
    }
}
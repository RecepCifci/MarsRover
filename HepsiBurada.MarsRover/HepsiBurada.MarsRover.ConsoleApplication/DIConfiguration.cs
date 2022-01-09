using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Business.Concrete;
using HepsiBurada.MarsRover.Core.Abstract;
using HepsiBurada.MarsRover.Core.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace HepsiBurada.MarsRover.ConsoleApplication
{
    public static class DIConfiguration
    {
        public static ServiceProvider Configure()
        {
            var collection = new ServiceCollection()
                                       .AddTransient<IRoverPosition, RoverPosition>()
                                       .AddTransient<IRoverCommands, RoverCommands>()
                                       .AddTransient<IRover, Rover>()
                                       .AddTransient<IPlateau, Plateau>()
                                       .AddTransient<IRoverManager, RoverManager>()
                                       .AddTransient<IRoverCommandsManager, RoverCommandsManager>()
                                       .AddTransient<IPlateauManager, PlateauManager>()
                                       .AddSingleton<PlateauManager>()
                                       .AddTransient<RoverManager>()
                                       .AddSingleton<App>()
                                       .BuildServiceProvider();
            return collection;
        }
    }
}
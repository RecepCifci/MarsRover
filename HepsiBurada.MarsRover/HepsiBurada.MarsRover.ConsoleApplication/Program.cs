using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Business.Concrete;
using HepsiBurada.MarsRover.Core;
using HepsiBurada.MarsRover.Core.Abstract;
using HepsiBurada.MarsRover.Core.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HepsiBurada.MarsRover.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                                       .AddTransient<IRoverPosition, RoverPosition>()
                                       .AddTransient<IRoverCommands, RoverCommands>()
                                       .AddTransient<IRover, Rover>()
                                       .AddTransient<IPlateau, Plateau>()
                                       .AddTransient<IRoverManager, RoverManager>()
                                       .AddTransient<IRoverCommandsManager, RoverCommandsManager>()
                                       .AddTransient<IPlateauManager, PlateauManager>()
                                       .BuildServiceProvider();

            Console.WriteLine(Messages.Information.EnterPlateauCoordinates);
            var plateauInputs = Console.ReadLine();
            //var plateauInputs = "5 5";

            var plateu = serviceProvider.GetService<IPlateau>();
            var plateuManager = serviceProvider.GetService<IPlateauManager>();
            plateuManager.Plateau = plateu;

            var isPlateauValid = plateuManager.CheckInputIsValid(plateauInputs);

            if (!isPlateauValid)
            {
                Console.WriteLine(Messages.Error.ErrorPlateauCoordinates);
                return;
            }

            var addAnotherRover = false;

            do
            {
                var rover = serviceProvider.GetService<IRover>();
                var roverManager = serviceProvider.GetService<IRoverManager>();
                roverManager.Rover = rover;
                rover.Plateau = plateu;

                Console.WriteLine(Messages.Information.EnterRoverPosition);
                var roverPositionInput = Console.ReadLine();
                //var roverPositionInput = "3 3 E";

                var isRoverPositionValid = roverManager.CheckPositionInputIsValid(roverPositionInput);
                if (!isRoverPositionValid) return;

                Console.WriteLine(Messages.Information.EnterRoverCommands);

                var roverCommandsInput = Console.ReadLine();
                //var roverCommandsInput = "MMRMMRMRRM";

                var isRoverCommandValid = roverManager.CheckCommandInputIsValid(roverCommandsInput);
                if (!isRoverCommandValid) return;

                var roverCommandsManager = serviceProvider.GetService<IRoverCommandsManager>();
                roverCommandsManager.CommandList = roverCommandsInput;
                roverCommandsManager.RoverManager = roverManager;
                roverManager.RoverCommandsManager = roverCommandsManager;

                plateuManager.RoverManagerList.Add(roverManager);

                Console.WriteLine(Messages.Information.AddAnotherRover);

                var addAnotherRoverInput = Console.ReadLine();

                addAnotherRover = addAnotherRoverInput.ToUpper() == "Y" ? true : false;

            } while (addAnotherRover);

            foreach (var roverManager in plateuManager.RoverManagerList)
            {
                roverManager.RoverCommandsManager.Proceed();
            }

            foreach (var roverManager in plateuManager.RoverManagerList)
            {
                Console.WriteLine($"{roverManager.Rover.Position.CoordinateX} {roverManager.Rover.Position.CoordinateY} {roverManager.Rover.Position.Direction.ToString().Substring(0, 1)}");
            }
            Console.ReadLine();
        }
    }
}
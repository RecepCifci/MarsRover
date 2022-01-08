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
                                       .BuildServiceProvider();

            Console.WriteLine(Messages.Information.EnterPlateauCoordinates);
            var plateauInputs = Console.ReadLine();

            IPlateau plateu = serviceProvider.GetService<IPlateau>();

            var isPlateauValid = plateu.CheckInputIsValid(plateauInputs);

            if (!isPlateauValid)
            {
                Console.WriteLine(Messages.Error.ErrorPlateauCoordinates);
                return;
            }

            var addAnotherRover = false;

            do
            {
                var rover = serviceProvider.GetService<IRover>();
                rover.Plateau = plateu;

                Console.WriteLine(Messages.Information.EnterRoverPosition);
                var roverPositionInput = Console.ReadLine();

                var isRoverPositionValid = rover.CheckPositionInputIsValid(roverPositionInput);
                if (!isRoverPositionValid) return;

                Console.WriteLine(Messages.Information.EnterRoverCommands);

                var roverCommandsInput = Console.ReadLine();

                var isRoverCommandValid = rover.CheckCommandInputIsValid(roverCommandsInput);
                if (!isRoverCommandValid) return;

                var roverCommands = serviceProvider.GetService<IRoverCommands>();
                roverCommands.Rover = rover;
                roverCommands.CommandList = roverCommandsInput;

                rover.RoverCommands = roverCommands;

                plateu.RoverList.Add(rover);

                Console.WriteLine(Messages.Information.AddAnotherRover);

                var addAnotherRoverInput = Console.ReadLine();

                addAnotherRover = addAnotherRoverInput.ToUpper() == "Y" ? true : false;

            } while (addAnotherRover);

            foreach (var rover in plateu.RoverList)
            {
                rover.RoverCommands.Proceed();
            }

            foreach (var rover in plateu.RoverList)
            {
                Console.WriteLine($"{rover.Position.CoordinateX} {rover.Position.CoordinateY} {rover.Position.Direction.ToString().Substring(0, 1)}");
            }
            Console.ReadLine();
        }
    }
}
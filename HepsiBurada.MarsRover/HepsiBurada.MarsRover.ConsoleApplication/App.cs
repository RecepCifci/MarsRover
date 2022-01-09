using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Core;
using HepsiBurada.MarsRover.Core.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HepsiBurada.MarsRover.ConsoleApplication
{
    public class App
    {
        private readonly IPlateau _plateau;
        private readonly IPlateauManager _plateauManager;
        private readonly IRover _rover;
        private readonly IRoverManager _roverManager;
        private readonly IRoverCommandsManager _roverCommandsManager;
        public App(IPlateau plateau, IPlateauManager plateauManager, IRover rover, IRoverManager roverManager, IRoverCommandsManager roverCommandsManager)
        {
            this._plateau = plateau;
            this._plateauManager = plateauManager;
            this._rover = rover;
            this._roverManager = roverManager;
            this._roverCommandsManager = roverCommandsManager;

            plateauManager.Plateau = plateau;
            _roverManager.Rover = _rover;
            _rover.Plateau = _plateau;
            _roverCommandsManager.RoverManager = _roverManager;
            _roverManager.RoverCommandsManager = _roverCommandsManager;
        }
        public void Initialize()
        {
            CheckPlateauValues(_plateauManager);

            var addAnotherRover = false;
            do
            {
                CheckRoverPositionValues(_roverManager);
                string roverCommandsInput = CheckRoverCommandValues(_roverManager);
                _roverCommandsManager.CommandList = roverCommandsInput;

                _plateauManager.RoverManagerList.Add(_roverManager);

                Console.WriteLine(Messages.Information.AddAnotherRover);

                var addAnotherRoverInput = Console.ReadLine();

                addAnotherRover = addAnotherRoverInput.ToUpper() == "Y" ? true : false;
            } while (addAnotherRover);

            _plateauManager.Process();
            _plateauManager.Print();
            Console.ReadLine();
        }
        private void CheckPlateauValues(IPlateauManager plateauManager)
        {
            bool isPlateauInvalid = true;
            Console.WriteLine(Messages.Information.EnterPlateauCoordinates);
            do
            {
                var plateauInputs = Console.ReadLine();
                isPlateauInvalid = plateauManager.CheckInputIsInvalid(plateauInputs);

                if (isPlateauInvalid)
                    Console.WriteLine(Messages.Error.ErrorPlateauCoordinates);

            } while (isPlateauInvalid);
        }
        private void CheckRoverPositionValues(IRoverManager roverManager)
        {
            bool isRoverPositionInvalid = true;
            Console.WriteLine(Messages.Information.EnterRoverPosition);
            do
            {
                var roverPositionInput = Console.ReadLine();

                isRoverPositionInvalid = roverManager.CheckPositionInputIsInvalid(roverPositionInput);
                if (isRoverPositionInvalid)
                    Console.WriteLine(Messages.Error.ErrorRoverPosition);

            } while (isRoverPositionInvalid);
        }
        private string CheckRoverCommandValues(IRoverManager roverManager)
        {
            bool isRoverCommandInvalid = true;
            Console.WriteLine(Messages.Information.EnterRoverCommands);
            string command = "";
            do
            {
                command = Console.ReadLine();

                isRoverCommandInvalid = roverManager.CheckCommandInputIsInvalid(command);
                if (isRoverCommandInvalid)
                    Console.WriteLine(Messages.Error.ErrorRoverCommands);

            } while (isRoverCommandInvalid);
            return command;
        }
    }
}
using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Core;
using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HepsiBurada.MarsRover.Core.Enums;

namespace HepsiBurada.MarsRover.Business.Concrete
{
    public class RoverManager : IRoverManager
    {
        public IRover Rover { get; set; }
        public IRoverCommandsManager RoverCommandsManager { get; set; }

        public bool CheckPositionInputIsValid(string roverPositionStr)
        {
            if (string.IsNullOrEmpty(roverPositionStr)) return false;

            var roverCoordinate = roverPositionStr.Split(' ');

            if (roverCoordinate.Length != 3) return false;

            this.Rover.Position.CoordinateX = Convert.ToInt32(roverCoordinate[0]);
            this.Rover.Position.CoordinateY = Convert.ToInt32(roverCoordinate[1]);

            switch (roverCoordinate[2].ToUpper())
            {
                case "N":
                    this.Rover.Position.Direction = Direction.North; break;
                case "E":
                    this.Rover.Position.Direction = Direction.East; break;
                case "S":
                    this.Rover.Position.Direction = Direction.South; break;
                case "W":
                    this.Rover.Position.Direction = Direction.West; break;
                default: throw new Exception(Messages.Error.InvalidDirection);
            }

            return true;
        }
        public bool CheckCommandInputIsValid(string roverCommandStr)
        {
            return !String.IsNullOrEmpty(roverCommandStr);
        }

        public void CheckRoverIsAtValidGridBoundaries()
        {
            var currentRoverPosition = this.Rover.Position;

            if (currentRoverPosition.CoordinateX > this.Rover.Plateau.CoordinateX || currentRoverPosition.CoordinateX < 0 ||
                currentRoverPosition.CoordinateY > this.Rover.Plateau.CoordinateY || currentRoverPosition.CoordinateY < 0)
            {
                throw new Exception(Messages.Error.OutOfPlateau);
            }
        }
    }
}

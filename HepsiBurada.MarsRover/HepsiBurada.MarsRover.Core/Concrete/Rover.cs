using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HepsiBurada.MarsRover.Core.Enums;

namespace HepsiBurada.MarsRover.Core.Concrete
{
    public class Rover : IRover
    {
        public Guid Id { get; set; }
        public IPlateau Plateau { get; set; }
        public IRoverCommands RoverCommands { get; set; }
        public IRoverPosition Position { get; set; }

        public Rover(IRoverPosition position)
        {
            this.Id = new Guid();
            this.Position = position;
        }
        public bool CheckPositionInputIsValid(string roverPositionStr)
        {
            if (string.IsNullOrEmpty(roverPositionStr)) return false;

            var roverCoordinate = roverPositionStr.Split(' ');

            if (roverCoordinate.Length != 3) return false;

            this.Position.CoordinateX = Convert.ToInt32(roverCoordinate[0]);
            this.Position.CoordinateY = Convert.ToInt32(roverCoordinate[1]);

            switch (roverCoordinate[2].ToUpper())
            {
                case "N":
                    this.Position.Direction = Direction.North; break;
                case "E":
                    this.Position.Direction = Direction.East; break;
                case "S":
                    this.Position.Direction = Direction.South; break;
                case "W":
                    this.Position.Direction = Direction.West; break;
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
            var currentRoverPosition = this.Position;

            if (currentRoverPosition.CoordinateX > Plateau.CoordinateX || currentRoverPosition.CoordinateX < 0 ||
                currentRoverPosition.CoordinateY > Plateau.CoordinateY || currentRoverPosition.CoordinateY < 0)
            {
                throw new Exception(Messages.Error.OutOfPlateau);
            }
        }
    }
}

using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HepsiBurada.MarsRover.Core.Enums;

namespace HepsiBurada.MarsRover.Core.Concrete
{
    public class RoverCommands : IRoverCommands
    {
        public IRover Rover { get; set; }
        public string CommandList { get; set; }
        public void Proceed()
        {
            foreach (var command in CommandList.ToCharArray())
            {
                switch (char.ToUpper(command))
                {
                    case 'R':
                        this.Rover.Position.Direction =TurnRight(Rover.Position.Direction);
                        break;
                    case 'L':
                        this.Rover.Position.Direction = TurnLeft(Rover.Position.Direction);
                        break;
                    case 'M':
                        this.Rover.Position = Move(Rover.Position);
                        this.Rover.CheckRoverIsAtValidGridBoundaries();
                        break;
                    default:
                        throw new Exception(Messages.Error.InvalidMovement);
                }
            }
        }
        public IRoverPosition Move(IRoverPosition roverPosition)
        {
            IRoverPosition currentRoverPosition = roverPosition;

            switch (roverPosition.Direction)
            {
                case Direction.North:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.CoordinateX, roverPosition.CoordinateY + 1);
                    break;
                case Direction.South:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.CoordinateX, roverPosition.CoordinateY - 1);
                    break;
                case Direction.West:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.CoordinateX - 1, roverPosition.CoordinateY);
                    break;
                case Direction.East:
                    currentRoverPosition = new RoverPosition(roverPosition.Direction, roverPosition.CoordinateX + 1, roverPosition.CoordinateY);
                    break;
            }

            return currentRoverPosition;
        }
        public Direction TurnRight(Direction Direction)
        {
            Direction currentDirection = Direction;

            switch (Direction)
            {
                case Direction.North:
                    currentDirection = Direction.East;
                    break;
                case Direction.East:
                    currentDirection = Direction.South;
                    break;
                case Direction.South:
                    currentDirection = Direction.West;
                    break;
                case Direction.West:
                    currentDirection = Direction.North;
                    break;
            }
            return currentDirection;
        }
        public Direction TurnLeft(Direction Direction)
        {
            Direction currentDirection = Direction;

            switch (currentDirection)
            {
                case Direction.North:
                    currentDirection = Direction.West;
                    break;
                case Direction.East:
                    currentDirection = Direction.North;
                    break;
                case Direction.South:
                    currentDirection = Direction.East;
                    break;
                case Direction.West:
                    currentDirection = Direction.South;
                    break;
            }
            return currentDirection;
        }
    }
}
using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Core;
using HepsiBurada.MarsRover.Core.Abstract;
using HepsiBurada.MarsRover.Core.Concrete;
using System;
using static HepsiBurada.MarsRover.Core.Enums;

namespace HepsiBurada.MarsRover.Business.Concrete
{
    public class RoverCommandsManager : IRoverCommandsManager
    {
        public string CommandList { get; set; }
        public IRoverManager RoverManager { get; set; }

        public void Proceed()
        {
            foreach (var command in CommandList.ToCharArray())
            {
                switch (char.ToUpper(command))
                {
                    case 'R':
                        this.RoverManager.Rover.Position.Direction = TurnRight(this.RoverManager.Rover.Position.Direction);
                        break;
                    case 'L':
                        this.RoverManager.Rover.Position.Direction = TurnLeft(this.RoverManager.Rover.Position.Direction);
                        break;
                    case 'M':
                        this.RoverManager.Rover.Position = Move(this.RoverManager.Rover.Position);
                        this.RoverManager.CheckRoverIsAtValidGridBoundaries();
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

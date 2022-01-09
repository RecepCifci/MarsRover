using HepsiBurada.MarsRover.Core.Abstract;
using System;

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
    }
}

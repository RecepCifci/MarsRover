using HepsiBurada.MarsRover.Core.Abstract;

namespace HepsiBurada.MarsRover.Core.Concrete
{
    public class RoverCommands : IRoverCommands
    {
        public IRover Rover { get; set; }
        public string CommandList { get; set; }
    }
}
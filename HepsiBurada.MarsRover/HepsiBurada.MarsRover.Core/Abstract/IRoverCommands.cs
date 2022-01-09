namespace HepsiBurada.MarsRover.Core.Abstract
{
    public interface IRoverCommands
    {
        public IRover Rover { get; set; }
        public string CommandList { get; set; }
    }
}

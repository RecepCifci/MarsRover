using HepsiBurada.MarsRover.Core.Abstract;

namespace HepsiBurada.MarsRover.Business.Abstract
{
    public interface IRoverManager
    {
        IRover Rover { get; set; }
        IRoverCommandsManager RoverCommandsManager { get; set; }
        bool CheckPositionInputIsInvalid(string roverStr);
        bool CheckCommandInputIsInvalid(string roverCommandStr);
        void CheckRoverIsAtValidGridBoundaries();
    }
}

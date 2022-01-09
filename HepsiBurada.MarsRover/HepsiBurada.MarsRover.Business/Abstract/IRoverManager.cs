using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Business.Abstract
{
    public interface IRoverManager
    {
        IRover Rover { get; set; }
        IRoverCommandsManager RoverCommandsManager { get; set; }
        bool CheckPositionInputIsValid(string roverStr);
        bool CheckCommandInputIsValid(string roverCommandStr);
        void CheckRoverIsAtValidGridBoundaries();
    }
}

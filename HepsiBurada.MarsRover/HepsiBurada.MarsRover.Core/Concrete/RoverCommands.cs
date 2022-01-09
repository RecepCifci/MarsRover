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
    }
}
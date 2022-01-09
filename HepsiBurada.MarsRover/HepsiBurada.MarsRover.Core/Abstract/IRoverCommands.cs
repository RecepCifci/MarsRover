using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Core.Abstract
{
    public interface IRoverCommands
    {
        public IRover Rover { get; set; }
        public string CommandList { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Core.Abstract
{
    public interface IRover
    {
        Guid Id { get; set; }
        IPlateau Plateau { get; set; }
        IRoverPosition Position { get; set; }
        IRoverCommands RoverCommands { get; set; }
    }
}

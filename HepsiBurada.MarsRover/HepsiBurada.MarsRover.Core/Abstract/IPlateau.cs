using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Core.Abstract
{
    public interface IPlateau
    {
        int CoordinateX { get; set; }
        int CoordinateY { get; set; }
        List<IRover> RoverList { get; set; }
        bool CheckInputIsValid(string platenauStr);
    }
}

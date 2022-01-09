using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Core.Concrete
{
    public class Plateau : IPlateau
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
    }
}
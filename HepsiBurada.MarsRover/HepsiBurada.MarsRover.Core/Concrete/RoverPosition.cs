using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HepsiBurada.MarsRover.Core.Enums;

namespace HepsiBurada.MarsRover.Core.Concrete
{
    public class RoverPosition : IRoverPosition
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public Direction Direction { get; set; }

        public RoverPosition(Direction direction = Direction.North, int x = 0, int y = 0)
        {
            this.CoordinateX = x;
            this.CoordinateY = y;
            this.Direction = direction;
        }
    }
}

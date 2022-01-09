using static HepsiBurada.MarsRover.Core.Enums;

namespace HepsiBurada.MarsRover.Core.Abstract
{
    public interface IRoverPosition
    {
        int CoordinateX { get; set; }
        int CoordinateY { get; set; }
        Direction Direction { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Constants
{
    public class Messages
    {
        public static string EnterBoard = "Please enter board value with 2 integer with one blank. Example: 5 5";
        public static string EnterCurrentPosition = "Please enter current position value with 2 integer, one direction with one blank. Example: 1 2 N";
        public static string EnterProcessList = "Please enter process list value without blank. Only R, L, M values are allowed";
        public static string BoardInvalidError = "Board is invalid!";
        public static string PositionInvalidError = "Position is invalid!";
        public static string ProcessInvalidError = "Process is invalid!";
        public static string OutOfBoundError = "Position is out of bounds!";
    }
}

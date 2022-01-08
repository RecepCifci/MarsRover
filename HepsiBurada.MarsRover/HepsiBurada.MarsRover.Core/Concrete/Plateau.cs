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
        public List<IRover> RoverList { get; set; }
        public Plateau()
        {
            this.RoverList = new List<IRover>();
        }

        public bool CheckInputIsValid(string platenauStr)
        {
            if (string.IsNullOrEmpty(platenauStr)) return false;

            var platenauCoordinate = platenauStr.Split(' ');

            if (platenauCoordinate.Length != 2) return false;

            if(!platenauCoordinate.All(x => x.All(char.IsDigit))) return false;

            this.CoordinateX = Convert.ToInt32(platenauCoordinate[0]);
            this.CoordinateY = Convert.ToInt32(platenauCoordinate[1]);

            return true;
        }
    }
}
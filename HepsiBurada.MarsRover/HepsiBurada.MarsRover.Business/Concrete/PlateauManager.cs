using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Business.Concrete
{
    public class PlateauManager : IPlateauManager
    {
        public PlateauManager()
        {
            this.RoverManagerList = new List<IRoverManager>();
        }
        public IPlateau Plateau { get; set; }
        public List<IRoverManager> RoverManagerList { get; set; }
        public bool CheckInputIsValid(string platenauStr)
        {
            if (string.IsNullOrEmpty(platenauStr)) return false;

            var platenauCoordinate = platenauStr.Split(' ');

            if (platenauCoordinate.Length != 2) return false;

            if (!platenauCoordinate.All(x => x.All(char.IsDigit))) return false;

            this.Plateau.CoordinateX = Convert.ToInt32(platenauCoordinate[0]);
            this.Plateau.CoordinateY = Convert.ToInt32(platenauCoordinate[1]);

            return true;
        }
        public void Process()
        {
            foreach (var roverManager in RoverManagerList)
            {
                roverManager.RoverCommandsManager.Proceed();
            }
        }
        public void Print()
        {
            foreach (var roverManager in RoverManagerList)
            {
                Console.WriteLine($"{roverManager.Rover.Position.CoordinateX} {roverManager.Rover.Position.CoordinateY} {roverManager.Rover.Position.Direction.ToString().Substring(0, 1)}");
            }
        }
    }
}

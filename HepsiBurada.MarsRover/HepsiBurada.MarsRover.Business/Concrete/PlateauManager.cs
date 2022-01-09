using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public bool CheckInputIsInvalid(string platenauStr)
        {
            if (string.IsNullOrEmpty(platenauStr)) return true;

            var platenauCoordinate = platenauStr.Trim().Split(' ');

            if (platenauCoordinate.Length != 2) return true;

            if (!platenauCoordinate.All(x => x.All(char.IsDigit))) return true;

            this.Plateau.CoordinateX = Convert.ToInt32(platenauCoordinate[0]);
            this.Plateau.CoordinateY = Convert.ToInt32(platenauCoordinate[1]);

            return false;
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

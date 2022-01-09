using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Business.Concrete;
using HepsiBurada.MarsRover.Core.Concrete;
using System;
using System.Collections.Generic;
using Xunit;
using static HepsiBurada.MarsRover.Core.Enums;
using System.Linq;

namespace HepsiBurada.MarsRover.UnitTest
{
    public class UnitTest1
    {
        [Theory]
        [MemberData(nameof(LoyaltyTestData))]
        public void Test1(IPlateauManager plateauManager, string position)
        {
            plateauManager.Process();
            string coordiinate = $"{plateauManager.RoverManagerList.FirstOrDefault().Rover.Position.CoordinateX} {plateauManager.RoverManagerList.FirstOrDefault().Rover.Position.CoordinateY} {plateauManager.RoverManagerList.FirstOrDefault().Rover.Position.Direction.ToString().Substring(0, 1)}";

            Assert.Equal(coordiinate, position);
        }
        public static IEnumerable<object[]> LoyaltyTestData()
        {
            IPlateauManager plateauManager = new PlateauManager { };
            plateauManager.Plateau = new Plateau();
            plateauManager.Plateau.CoordinateX = 5;
            plateauManager.Plateau.CoordinateY = 5;

            plateauManager.RoverManagerList = new List<IRoverManager>();
            IRoverManager roverManager = new RoverManager();
            roverManager.Rover = new Rover(new RoverPosition { CoordinateX = 1, CoordinateY = 2, Direction = Direction.North });
            roverManager.RoverCommandsManager = new RoverCommandsManager();
            roverManager.RoverCommandsManager.CommandList = "LMLMLMLMM";
            roverManager.RoverCommandsManager.RoverManager = roverManager;
            roverManager.Rover.RoverCommands = roverManager.Rover.RoverCommands;
            roverManager.Rover.Plateau = plateauManager.Plateau;

            plateauManager.RoverManagerList.Add(roverManager);

            yield return new object[] { plateauManager, "1 3 N" };
        }
    }
}

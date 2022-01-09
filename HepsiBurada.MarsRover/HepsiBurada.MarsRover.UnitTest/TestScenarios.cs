using HepsiBurada.MarsRover.Business.Abstract;
using HepsiBurada.MarsRover.Business.Concrete;
using HepsiBurada.MarsRover.Core.Concrete;
using System;
using System.Collections.Generic;
using Xunit;
using static HepsiBurada.MarsRover.Core.Enums;
using System.Linq;
using System.Text;

namespace HepsiBurada.MarsRover.UnitTest
{
    public class TestScenarios
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestMethod(string testname, IPlateauManager plateauManager, string[] position)
        {
            plateauManager.Process();
            string[] positionList = new string[plateauManager.RoverManagerList.Count];

            for (int i = 0; i < plateauManager.RoverManagerList.Count; i++)
            {
                positionList[i] = $"{plateauManager.RoverManagerList[i].Rover.Position.CoordinateX} {plateauManager.RoverManagerList[i].Rover.Position.CoordinateY} {plateauManager.RoverManagerList[i].Rover.Position.Direction.ToString().Substring(0, 1)}";
            }

            Assert.Equal(positionList, position);
        }
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "Plateau 5x5, Rover {Position 1 2 N, Command LMLMLMLMM}", Case1(), new string[] { "1 3 N" } };
            yield return new object[] { "Plateau 5x5, Rover {Position 3 3 E, Command MMRMMRMRRM}", Case2(), new string[] { "5 1 E" } };
            yield return new object[] { "Plateau 5x5, Rover {Position 1 2 N, Command LMLMLMLMM and Position 3 3 E, Command MMRMMRMRRM}", Case3(), new string[] { "1 3 N", "5 1 E" } };
        }
        public static IPlateauManager Case1()
        {
            IPlateauManager plateauManager = new PlateauManager { };
            IRoverManager roverManager = new RoverManager();

            plateauManager.Plateau = new Plateau();
            plateauManager.Plateau.CoordinateX = 5;
            plateauManager.Plateau.CoordinateY = 5;

            plateauManager.RoverManagerList = new List<IRoverManager>();
            roverManager.Rover = new Rover(new RoverPosition { CoordinateX = 1, CoordinateY = 2, Direction = Direction.North });
            roverManager.RoverCommandsManager = new RoverCommandsManager();
            roverManager.RoverCommandsManager.CommandList = "LMLMLMLMM";
            roverManager.RoverCommandsManager.RoverManager = roverManager;
            roverManager.Rover.RoverCommands = roverManager.Rover.RoverCommands;
            roverManager.Rover.Plateau = plateauManager.Plateau;

            plateauManager.RoverManagerList.Add(roverManager);
            return plateauManager;
        }
        public static IPlateauManager Case2()
        {
            IPlateauManager plateauManager = new PlateauManager { };
            IRoverManager roverManager = new RoverManager();
            plateauManager.Plateau = new Plateau();
            plateauManager.Plateau.CoordinateX = 5;
            plateauManager.Plateau.CoordinateY = 5;

            plateauManager.RoverManagerList = new List<IRoverManager>();
            roverManager.Rover = new Rover(new RoverPosition { CoordinateX = 3, CoordinateY = 3, Direction = Direction.East });
            roverManager.RoverCommandsManager = new RoverCommandsManager();
            roverManager.RoverCommandsManager.CommandList = "MMRMMRMRRM";
            roverManager.RoverCommandsManager.RoverManager = roverManager;
            roverManager.Rover.RoverCommands = roverManager.Rover.RoverCommands;
            roverManager.Rover.Plateau = plateauManager.Plateau;

            plateauManager.RoverManagerList.Add(roverManager);
            return plateauManager;
        }
        public static IPlateauManager Case3()
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

            IRoverManager roverManager2 = new RoverManager();
            roverManager2.Rover = new Rover(new RoverPosition { CoordinateX = 3, CoordinateY = 3, Direction = Direction.East });
            roverManager2.RoverCommandsManager = new RoverCommandsManager();
            roverManager2.RoverCommandsManager.CommandList = "MMRMMRMRRM";
            roverManager2.RoverCommandsManager.RoverManager = roverManager2;
            roverManager2.Rover.RoverCommands = roverManager2.Rover.RoverCommands;
            roverManager2.Rover.Plateau = plateauManager.Plateau;
            plateauManager.RoverManagerList.Add(roverManager2);
            return plateauManager;
        }
    }
}

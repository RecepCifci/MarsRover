using MarsRover.BusinessLayer.Concrete;
using MarsRover.Models;
using System;
using System.Linq;
using static MarsRover.Models.Enums;

namespace MarsRover.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RotateManager rotateManager = new RotateManager();
            rotateManager.Process();
            Console.ReadLine();
        }
    }
}
using MarsRover.BusinessLayer.Abstract;
using MarsRover.BusinessLayer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Concrete
{
    public class GetDataManager : IGetDataManager
    {
        public string GetBoardData()
        {
            Console.WriteLine(Messages.EnterBoard);
            return Console.ReadLine();
        }

        public string GetCurrentPositionData()
        {
            Console.WriteLine(Messages.EnterCurrentPosition);
            return Console.ReadLine();
        }

        public string GetProcessListData()
        {
            Console.WriteLine(Messages.EnterProcessList);
            return Console.ReadLine();
        }
    }
}

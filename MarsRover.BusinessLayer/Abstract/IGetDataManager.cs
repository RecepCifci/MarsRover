using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Abstract
{
    public interface IGetDataManager
    {
        string GetBoardData();
        string GetCurrentPositionData();
        string GetProcessListData();
    }
}

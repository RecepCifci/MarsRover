using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Abstract
{
    public interface ISetDataManager
    {
        Board SetBoardData(string boardStr);
        Rotate SetCurrentPositionData(string positionStr);
    }
}

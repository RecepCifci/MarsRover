using MarsRover.BusinessLayer.Abstract;
using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.Models.Enums;

namespace MarsRover.BusinessLayer.Concrete
{
    public class SetDataManager : ISetDataManager
    {
        public Board SetBoardData(string boardStr)
        {
            Board board = new Board();
            var boardSplit = boardStr.Split(' ');
            board.X = Convert.ToInt32(boardSplit[0]);
            board.Y = Convert.ToInt32(boardSplit[1]);
            return board;
        }
        public Rotate SetCurrentPositionData(string positionStr)
        {
            Rotate currentPosition = new Rotate();
            var currentPositionSplit = positionStr.Split(' ');
            currentPosition.X = Convert.ToInt32(currentPositionSplit[0]);
            currentPosition.Y = Convert.ToInt32(currentPositionSplit[1]);
            currentPosition.Direction = (Direction)Enum.Parse(typeof(Direction), currentPositionSplit[2].ToUpper());
            return currentPosition;
        }
    }
}

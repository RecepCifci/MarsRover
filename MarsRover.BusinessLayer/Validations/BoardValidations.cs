using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MarsRover.Models;

namespace MarsRover.BusinessLayer.Validations
{
    public class BoardValidations : IBoardValidations
    {
        public bool CheckIfBoardIsValid(string boardValue)
        {
            var boardSplit = boardValue.Split(' ');
            if (boardSplit.Length != 2) return false;

            return CheckIfBoardContainsOnlyNumber(boardSplit);
        }
        public bool CheckIfBoardContainsOnlyNumber(string[] boardList)
        {
            return boardList.All(x => x.All(char.IsDigit));
        }
        public bool CheckIfPositionIsInBoard(Board board, Rotate position)
        {
            return board.X >= position.X && board.Y >= position.Y;
        }
    }
}

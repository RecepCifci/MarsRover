using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Validations
{
    public interface IBoardValidations
    {
        bool CheckIfBoardIsValid(string boardValue);
        bool CheckIfBoardContainsOnlyNumber(string[] boardList);
        bool CheckIfPositionIsInBoard(Board board, Rotate position);
    }
}

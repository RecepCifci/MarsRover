using MarsRover.Models;
using System;
using static MarsRover.Models.Enums;
using MarsRover.BusinessLayer.Abstract;
using MarsRover.Core;
using MarsRover.BusinessLayer.Validations;
using MarsRover.BusinessLayer.Constants;

namespace MarsRover.BusinessLayer.Concrete
{
    public class RotateManager : IRotateManager
    {
        PositionValidations _positionValidations;
        BoardValidations _boardValidations;
        ProcessValidation _processValidation;
        GetDataManager _getDataManager;
        SetDataManager _setDataManager;
        public RotateManager()
        {
            _positionValidations = new PositionValidations();
            _boardValidations = new BoardValidations();
            _processValidation = new ProcessValidation();
            _getDataManager = new GetDataManager();
            _setDataManager = new SetDataManager();
        }
        public void Move(ref Rotate position)
        {
            switch (position.Direction)
            {
                case Direction.N:
                    position.Y += 1;
                    break;
                case Direction.E:
                    position.X += 1;
                    break;
                case Direction.S:
                    position.Y += -1;
                    break;
                case Direction.W:
                    position.X += -1;
                    break;
                default:
                    break;
            }
        }
        public void Process()
        {
            string boardStr = _getDataManager.GetBoardData();
            bool boardValid = _boardValidations.CheckIfBoardIsValid(boardStr);
            if (!boardValid)
            {
                Console.WriteLine(Messages.BoardInvalidError);
                return;
            }
            Board board = _setDataManager.SetBoardData(boardStr);

            string currentPositionStr = _getDataManager.GetCurrentPositionData();
            bool positionValid = _positionValidations.ChekIfPositionIsValid(currentPositionStr);
            if (!positionValid)
            {
                Console.WriteLine(Messages.PositionInvalidError);
                return;
            }
            Rotate currentPosition = _setDataManager.SetCurrentPositionData(currentPositionStr);

            string processListStr = _getDataManager.GetProcessListData();
            bool processValid = _processValidation.CheckIfProcessContainValidValue(processListStr);
            if (!positionValid)
            {
                Console.WriteLine(Messages.ProcessInvalidError);
                return;
            }

            foreach (var item in processListStr)
            {
                switch (item)
                {
                    case 'R': currentPosition.Direction = Extensions.Next(currentPosition.Direction); break;
                    case 'L': currentPosition.Direction = Extensions.Previous(currentPosition.Direction); break;
                    case 'M':
                        Move(ref currentPosition);
                        bool isValid = _boardValidations.CheckIfPositionIsInBoard(board, currentPosition);
                        if (!isValid)
                        {
                            Console.WriteLine(Messages.OutOfBoundError);
                            return;
                        }
                        break;
                }
            }
            PrintCurrentLocation(currentPosition);
        }
        public void PrintCurrentLocation(Rotate currentPosition)
        {
            Console.WriteLine(String.Format("{0} {1} {2}", currentPosition.X, currentPosition.Y, currentPosition.Direction));
        }
    }
}
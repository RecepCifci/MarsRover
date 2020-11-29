using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.BusinessLayer.Validations
{
    public class PositionValidations : IPositionValidations
    {
        public bool ChekIfPositionIsValid(string position)
        {
            var positionSplit = position.Split(' ');
            if (positionSplit.Length != 3) return false;
            return CheckIfPositionValueOrder(positionSplit);
        }
        public bool CheckIfPositionValueOrder(string[] positionList)
        {
            bool returnValue = true;

            for (int strIndex = 0; strIndex < positionList.Length; strIndex++)
            {
                if (strIndex == 0 || strIndex == 1)
                    returnValue = positionList[strIndex].All(char.IsDigit);
                else
                    returnValue = positionList[strIndex].Any(char.IsLetter);
            }
            return returnValue;
        }
    }
}

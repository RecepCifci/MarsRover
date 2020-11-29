using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Validations
{
    public interface IPositionValidations
    {
        bool ChekIfPositionIsValid(string position);

        bool CheckIfPositionValueOrder(string[] positionList);
    }
}

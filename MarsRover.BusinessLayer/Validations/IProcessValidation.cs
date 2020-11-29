using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Validations
{
    public interface IProcessValidation
    {
        bool CheckIfProcessContainValidValue(string processList);
    }
}

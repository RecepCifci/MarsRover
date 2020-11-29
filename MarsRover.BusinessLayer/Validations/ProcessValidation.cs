using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MarsRover.BusinessLayer.Validations
{
    public class ProcessValidation : IProcessValidation
    {
        public bool CheckIfProcessContainValidValue(string processList)
        {
            return processList.ToCharArray().Any(x => !x.Equals('R') && !x.Equals('L') && !x.Equals('M'));
        }
    }
}

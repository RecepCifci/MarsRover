using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Business.Abstract
{
    public interface IPlateauManager
    {
        IPlateau Plateau { get; set; }
        List<IRoverManager> RoverManagerList { get; set; }
        bool CheckInputIsValid(string platenauStr);
        void Process();
        void Print();
    }
}

using HepsiBurada.MarsRover.Core.Abstract;
using System.Collections.Generic;

namespace HepsiBurada.MarsRover.Business.Abstract
{
    public interface IPlateauManager
    {
        IPlateau Plateau { get; set; }
        List<IRoverManager> RoverManagerList { get; set; }
        bool CheckInputIsInvalid(string platenauStr);
        void Process();
        void Print();
    }
}

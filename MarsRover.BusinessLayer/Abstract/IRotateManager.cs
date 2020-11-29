using MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.BusinessLayer.Abstract
{
    public interface IRotateManager
    {
        void Move(ref Rotate position);
        void Process();
        void PrintCurrentLocation(Rotate currentPosition);
    }
}

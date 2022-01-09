using HepsiBurada.MarsRover.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBurada.MarsRover.Business.Abstract
{
    public interface IRoverCommandsManager
    {
        public IRoverManager RoverManager { get; set; }
        public string CommandList { get; set; }
        void Proceed();
    }
}
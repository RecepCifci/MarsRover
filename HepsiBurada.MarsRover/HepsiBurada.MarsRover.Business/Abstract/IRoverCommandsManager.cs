namespace HepsiBurada.MarsRover.Business.Abstract
{
    public interface IRoverCommandsManager
    {
        public IRoverManager RoverManager { get; set; }
        public string CommandList { get; set; }
        void Proceed();
    }
}
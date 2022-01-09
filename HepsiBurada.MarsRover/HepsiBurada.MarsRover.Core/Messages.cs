namespace HepsiBurada.MarsRover.Core
{
    public static class Messages
    {
        public static class Information
        {
            public static string EnterPlateauCoordinates => "Please enter Plateau Coordinates";
            public static string EnterRoverPosition => "Please enter Rover Position";
            public static string EnterRoverCommands => "Please enter Rover Commands";

            public static string AddAnotherRover => "Do you want to add another rover?";
        }
        public static class Error
        {
            public static string ErrorPlateauCoordinates => "Please enter Valid Plateau Coordinates";
            public static string ErrorRoverPosition => "Please enter Valid Rover Position";
            public static string ErrorRoverCommands => "Please enter Valid Rover Commands";
            public static string InvalidDirection => "Please enter Valid Direction";
            public static string InvalidMovement => "Please enter Valid Movement";
            public static string OutOfPlateau => "Rover is Out of plateau";
        }
    }
}

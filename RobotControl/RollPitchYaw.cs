namespace RobotControl
{
    public class RollPitchYaw
    {
        public double LastRoll { get; set; }
        public double LastPitch { get; set; }
        public double LastYaw { get; set; }

        public RollPitchYaw(double lastRoll, double lastPitch, double lastYaw)
        {
            LastRoll = lastRoll;
            LastPitch = lastPitch;
            LastYaw = lastYaw;
        }
    }
}
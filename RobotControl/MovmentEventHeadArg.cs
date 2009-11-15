using System;

namespace RobotControl
{
    public class MovmentEventHeadArg : EventArgs
    {
        public RollPitchYaw RollPitchYaw { get; set; }

        public MovmentEventHeadArg(RollPitchYaw rollPitchYaw)
        {
            RollPitchYaw = rollPitchYaw;
        }
    }
}
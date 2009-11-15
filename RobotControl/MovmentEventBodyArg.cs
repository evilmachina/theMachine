using System;

namespace RobotControl
{
    public class MovmentEventBodyArg : EventArgs
    {
        public Movment Movment { get; private set; }

        public MovmentEventBodyArg(Movment movment)
        {
            Movment = movment;
        }
    }
}
using System;

namespace RobotControl
{
    public class MovmentEventArg : EventArgs
    {
        public Movment Movment { get; private set; }

        public MovmentEventArg(Movment movment)
        {
            Movment = movment;
        }
    }
}
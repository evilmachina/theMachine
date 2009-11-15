using System;

namespace RobotControl
{
    public interface IInputDeviceHead
    {
        event EventHandler<MovmentEventHeadArg> MovmentInput;
    }
}
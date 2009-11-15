using System;

namespace RobotControl
{
    public interface IInputDeviceBody
    {
        event EventHandler<MovmentEventBodyArg> MovmentInput;
    }
}
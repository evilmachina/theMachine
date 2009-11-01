using System;

namespace RobotControl
{
    public interface IInputDevice
    {
        event EventHandler<MovmentEventArg> MovmentInput;
    }
}
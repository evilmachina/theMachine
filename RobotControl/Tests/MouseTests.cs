using System;
using NUnit.Framework;
using Robot;

namespace RobotControl.Tests
{
    [TestFixture]
    public class MouseTests
    {
        [Test]
        public void testtss()
        {
            var i = IK.CalculateIKOneJoint(1600, -1600);
        }

        //[Test]
        //public void CanGetForvardCommand()
        //{
        //    IInputDevice inputDevice = new FakeInputDevice();
        //    inputDevice.MovmentInput += OnMovmentInput;
        //    Movment movment = new Movment();
        //    ((FakeInputDevice)inputDevice).RaseMovmentEvent(movment);

        //   // Assert.That();
        //}

        private void OnMovmentInput(object sender, MovmentEventArg e)
        {
            
        }
    }

    public class FakeInputDevice : IInputDevice
    {
        public event EventHandler<MovmentEventArg> MovmentInput;

        private void InvokeSensorInput(MovmentEventArg e)
        {
            EventHandler<MovmentEventArg> input = MovmentInput;
            if (input != null) input(this, e);
        }

        public void RaseMovmentEvent(Movment movment)
        {
            MovmentEventArg movmentEventArg = new MovmentEventArg(movment);
        }
    }
}
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
        //    IInputDeviceBody inputDevice = new FakeInputDeviceBody();
        //    inputDevice.MovmentInput += OnMovmentInput;
        //    Movment movment = new Movment();
        //    ((FakeInputDeviceBody)inputDevice).RaseMovmentEvent(movment);

        //   // Assert.That();
        //}

        private void OnMovmentInput(object sender, MovmentEventBodyArg e)
        {
            
        }
    }

    public class FakeInputDeviceBody : IInputDeviceBody
    {
        public event EventHandler<MovmentEventBodyArg> MovmentInput;

        private void InvokeSensorInput(MovmentEventBodyArg e)
        {
            EventHandler<MovmentEventBodyArg> input = MovmentInput;
            if (input != null) input(this, e);
        }

        public void RaseMovmentEvent(Movment movment)
        {
            MovmentEventBodyArg movmentEventBodyArg = new MovmentEventBodyArg(movment);
        }
    }
}
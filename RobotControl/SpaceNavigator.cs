using System;
using System.Runtime.InteropServices;
using Robot;
using TDx.TDxInput;

namespace RobotControl
{
    /// <summary>
    /// 3dconnexion's SpaceNavigator  
    /// </summary>
    public class SpaceNavigator : IInputDeviceBody
    {
        private readonly Device _device;
        private readonly Sensor _sensor;
        public event EventHandler<MovmentEventBodyArg> MovmentInput;

        private void InvokeMovmentInput(MovmentEventBodyArg e)
        {
            EventHandler<MovmentEventBodyArg> input = MovmentInput;
            if (input != null) input(this, e);
        }


        public SpaceNavigator()
        {
            try
            {
                _device = new Device();
                _sensor = _device.Sensor;
                _sensor.SensorInput += OnSensorInput;
               // keyboard.KeyDown += keyboard_KeyDown;
               // keyboard.KeyUp += keyboard_KeyUp;

                // Associate a configuration with this _device'
                _device.LoadPreferences("csMonitor");
                _device.Connect();

              
            }
            catch (COMException e)
            {
                Console.WriteLine("{0} Caught exception #1.", e);
                throw e;
            }
        }

        private void OnSensorInput()
        {
            
            Vector3D translation = _sensor.Translation;
            AngleAxis angleAxis = _sensor.Rotation;

            Movment movment = GetMovment(translation, angleAxis);
            MovmentEventBodyArg movmentEventBodyArg = new MovmentEventBodyArg(movment);
            InvokeMovmentInput(movmentEventBodyArg);
        }

        private Movment GetMovment(Vector3D translation, AngleAxis angleAxis)
        {
            double X = GetValue(translation.X);
            double Y = GetValue(translation.Z);

            double angle = IK.CalculateIKOneJoint(X, Y);
            int direction = 1; 
            
            if (translation.Z < 0)
            {
                angle = IK.Rotate180Degrees(angle);
                direction = -1;
            }
            angle = Math.Abs(angle);
            if(angle == 180)
            {
                angle = 0;
            }

            double speed = IK.lengthBetwenSolderandWrist(X, Y) / 1600;
            var rotation = (angleAxis.Y * angleAxis.Angle) / 1600;
            var centerX = (angleAxis.Z * angleAxis.Angle) / 75;
            var centerY = (angleAxis.X * angleAxis.Angle) / 75;


            return new Movment(angle, direction, speed, rotation, centerX, centerY);
        }

        private double GetValue( double value)
        {
            //if (value < 300 && value > -300)
            //{
            //    return 0;
            //}
            return value;
        }
    }
}
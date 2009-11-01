using System;
using System.Runtime.InteropServices;
using Robot;
using TDx.TDxInput;

namespace RobotControl
{
    public class TreDConnexion : IInputDevice
    {
        private readonly Device _device;
        private readonly Sensor _sensor;
        public event EventHandler<MovmentEventArg> MovmentInput;

        private void InvokeMovmentInput(MovmentEventArg e)
        {
            EventHandler<MovmentEventArg> input = MovmentInput;
            if (input != null) input(this, e);
        }


        public TreDConnexion()
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
            MovmentEventArg movmentEventArg = new MovmentEventArg(movment);
            InvokeMovmentInput(movmentEventArg);
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
            var centerX = (angleAxis.Z * angleAxis.Angle) / 100;
            var centerY = (angleAxis.X * angleAxis.Angle) / 100;


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
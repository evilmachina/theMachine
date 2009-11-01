using System;

namespace RobotControl
{
    public class Movment
    {
        public double Angle { get; private set; }
        public int Direction { get; private set; }
        public double Speed { get; private set; }
        public double Rotation { get; private set; }
        public double CenterX { get; private set; }
        public double CenterY { get; private set; }


        public Movment(double angle, int direction, double speed, double rotation, double centerX, double centerY)
        {
            Angle = angle;
            Direction = direction;
            Speed = speed;
            Rotation = rotation;
            CenterX = centerX;
            CenterY = centerY;
        }
    }
}
using System;

namespace Robot
{
    public class Leg
    {
        private ServoBase _coxa;
        private ServoBase _femur;
        private ServoBase _tibia;
        private double _X;
        private double _Y;
        private double _Z;
        private Position _position;
        private Side _side;
        private double _offset;


        public ServoBase Coxa
        {
            get { return _coxa; }
            set { _coxa = value; }
        }

        public ServoBase Femur
        {
            get { return _femur; }
            set { _femur = value; }
        }

        public ServoBase Tibia
        {
            get { return _tibia; }
            set { _tibia = value; }
        }

        public double X
        {
            get { return _X; }
            set { _X = value; }
        }

        public double Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        public double Z
        {
            get { return _Z; }
            set { _Z = value; }
        }

        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Side Side
        {
            get { return _side; }
            set { _side = value; }
        }

        public double Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        public Movment[] GetMovements()
        {
            var movements = new Movment[3];
            movements[0] = Coxa.GetMovment();
            movements[1] = Femur.GetMovment();
            movements[2] = Tibia.GetMovment();

            return movements;
        }

        public static void CalculateNewPosition(Leg leg, double distance, double directionInRadian)
        {
            CalculateNewPosition(leg, distance, directionInRadian, 0);
        }

        public static void CalculateNewPosition(Leg leg, double distance, double direction, double yDistance)
        {
            double newX;
            double newZ;

            CalculateXandZ(direction, distance,leg.Side, leg.X, leg.Z, out newX, out newZ);
            leg.SetXYZ(newX, newZ, leg.Y - yDistance);
        }

        public void SetXYZ(double newX, double newZ, double newY)
        {
            X = newX;
            Z = newZ;
            Y = newY;

            double x = Math.Sqrt(X * X + Z * Z);
            double y = Y;

            JointAngeles angeles = IK.CalculateIK(Coxa.Length, Femur.Length, Tibia.Length, x, y);
            Femur.Angle = angeles.FemurAngle;
            Tibia.Angle = angeles.TibiaAngle;

            switch (Position)
            {
                case Position.Front:
                    Coxa.Angle = IK.CalculateIKOneJoint(X, Z) + Offset;
                    break;
                case Position.Middle:
                    Coxa.Angle = IK.CalculateIKOneJoint(X, Z);
                    break;
                case Position.Rear:
                    Coxa.Angle = IK.CalculateIKOneJoint(X, Z) - Offset;
                    break;
            }
        }

        public static void CalculateXandZ(double direction, double distance,Side side, double X, double Z, out double newX, out double newZ)
        {
            var directionInRadians = Math.Tan(direction * (Math.PI / 180));
         

            if (direction > 45 || direction < -45)
            {
                newX = side == Side.Left ? X + (distance / directionInRadians) : X - (distance / directionInRadians);
                newZ = Z + distance;
            }
            else
            {
                newX = side == Side.Left ? X + distance : X - distance;
                newZ = Z + distance * directionInRadians;
            }
        }
    }
}
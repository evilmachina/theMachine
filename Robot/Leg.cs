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
        private static double _legXPosition;
        private readonly double _distanceToX;
        private readonly double _distanceToY;

        public Leg(double distanceToX, double distanceToY)
        {
            _distanceToX = distanceToX;
            _distanceToY = distanceToY;
        }


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

        public double RealX
        {
            get { return DistanceToX + X; }
        }

        public double RealY
        {
            get { return DistanceToY + Y; }
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

        public double DistanceToX
        {
            get { return _distanceToX; }
        }

        public double DistanceToY
        {
            get { return _distanceToY; }
        }

        private double TotRotation { get; set; }

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

            Coxa.Angle = IK.CalculateIKOneJoint(X, Z) + Offset;
                   
            
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



        public static void CalculateNewPositionForRotation(Leg leg, double degrees, double direction,double xCenter,double yCenter)
        {
            //_legXPosition 

            //Y-rotation
            //angel in rad
            double angleXRCT = Math.Atan2(leg.RealY - yCenter, leg.RealX - xCenter);
           //G46 =DEGREES(ATAN2((B46-B72);(C46-C72)))
            double tmpX = Math.Cos(angleXRCT + IK.DegToRad(degrees))*CalculateDistance(leg.RealX - xCenter, leg.RealY - yCenter) + xCenter;
            tmpX = leg.RealX + tmpX;

            double tmpY = Math.Sin(angleXRCT + IK.DegToRad(degrees)) * CalculateDistance(leg.RealX - xCenter, leg.RealY - yCenter) + xCenter;
            tmpY = leg.RealY + tmpY;

            leg.TotRotation = leg.TotRotation + degrees;

        }

        public static double CalculateDistance(double X, double Y)
        {
            return Math.Sqrt(Math.Pow(X, 2)*Math.Pow(Y, 2));
        }
    }
}
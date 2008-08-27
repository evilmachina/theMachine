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
        private readonly double _distanceToZ;

        public Leg(double distanceToX, double distanceToY)
        {
            _distanceToX = distanceToX;
            _distanceToZ = distanceToY;
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

        public double RealZ
        {
            get { return DistanceToZ + Z; }
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

        public double DistanceToZ
        {
            get { return _distanceToZ; }
        }

        public double CT
        {
            get { return Math.Sqrt(X * X + Z * Z); }
        }
        private double TotRotation { get; set; }

        public MovmentComandAX12[] GetMovements()
        {
            var movements = new MovmentComandAX12[3];
            movements[0] = Coxa.GetMovement();
            movements[1] = Femur.GetMovement();
            movements[2] = Tibia.GetMovement();

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

            double x = CT;
            double y = Y;
            JointAngeles angeles = IK.CalculateIK(Coxa.Length, Femur.Length, Tibia.Length, x, y);
            Femur.Angle = angeles.FemurAngle;
            Tibia.Angle = angeles.TibiaAngle;

            Coxa.Angle = IK.CalculateIKOneJoint(X, Z);
                   
            
        }

        public static void CalculateXandZ(double direction, double distance,Side side, double X, double Z, out double newX, out double newZ)
        {
            var directionInRadians = Math.Tan(direction * (Math.PI / 180));
         

            if (direction > 45 || direction < -45)
            {
                newX = X + (distance/directionInRadians);
                
                newZ = Z + distance;
            }
            else
            {
                newX = X + distance;
                newZ = Z + distance * directionInRadians;
            }
        }



        public static void CalculateNewPositionForRotation(Leg leg, double degrees, double direction,double xCenter,double zCenter)
        {
            //_legXPosition 

            //Y-rotation
            //angel in rad
            double angleXRCT = Math.Atan2(leg.RealZ - zCenter, leg.RealX - xCenter);
           //G46 =DEGREES(ATAN2((B46-B72);(C46-C72)))
            double tmpX = Math.Cos(angleXRCT + IK.DegToRad(degrees))* CalculateHypotenuse(leg.RealX - xCenter, leg.RealZ - zCenter) + xCenter;
            

            double tmpZ = Math.Sin(angleXRCT + IK.DegToRad(degrees)) * CalculateHypotenuse(leg.RealX - xCenter, leg.RealZ - zCenter) + xCenter;
          

            leg.TotRotation = leg.TotRotation + degrees;

            leg.SetRealXYZ(tmpX, tmpZ, leg.Y);

        }

        public static double CalculateHypotenuse(double X, double Y)
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }

        private void SetRealXYZ(double x, double z, double y)
        {
            SetXYZ(x - _distanceToX, z - _distanceToZ, y);
        }
    }
}
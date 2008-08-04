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
        private double _distanceToX;
        private double _distanceToZ;
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

        public double DistanceToX
        {
            get { return _distanceToX; }
            set { _distanceToX = value; }
        }

        public double DistanceToZ
        {
            get { return _distanceToZ; }
            set { _distanceToZ = value; }
        }

        public double Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }
        public void CalculateNewPosision(double distance, double directionInRadian)
        {
            CalculateNewPosision(distance, directionInRadian, 0);
        }

        public void CalculateNewPosision(double distance, double direction, double yDistance)
        {
            var directionInRadians = Math.Tan(direction * (Math.PI / 180));

            if (direction > 45 || direction < -45)
            {
                X = Side == Side.Left ? X + (distance / directionInRadians) : X - (distance / directionInRadians);
                Z = Z + distance;
            }
            else 
            {
                X = Side == Side.Left ? X + distance  : X - distance;
                Z = Z + distance * directionInRadians;
            }

           

            var x = Math.Sqrt(X*X + Z*Z); //X
            var y = Y - yDistance; //no roll or pitch 
 
            JointAngeles angeles = IK.CalculateIK(Coxa.Length, Femur.Length, Tibia.Length, x, y);
            Femur.Angle = angeles.FemurAngle;
            Tibia.Angle = angeles.TibiaAngle;

            switch (Position)
            {
                case Position.Front:
                    Coxa.Angle = (Math.Atan2(Z, X) * 180 / Math.PI) + Offset;
                    break;
                case Position.Middle:
                    Coxa.Angle = (Math.Atan2(Z, X) * 180 / Math.PI);
                    break;
                case Position.Rear:
                    Coxa.Angle = (Math.Atan2(Z, X) * 180 / Math.PI) - Offset;
                    break;
            }
            
          

        }

        public Movment[] GetMovements()
        {
            var movements = new Movment[3];
            movements[0] = Coxa.GetMovment();
            movements[1] = Femur.GetMovment();
            movements[2] = Tibia.GetMovment();

            return movements;
        }
    }
}
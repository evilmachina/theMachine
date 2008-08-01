namespace Robot
{
    public class Leg
    {
        private ServoBase _coxa;
        private ServoBase _femur;
        private ServoBase _tibia;
        private double _x;
        private double _y;
        private double _z;
        private Position _position;
        private Side _side;
        private double _distanceToX;
        private double _distanceToZ;


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
            get { return _x; }
        }

        public double Y
        {
            get { return _y; }
        }

        public double Z
        {
            get { return _z; }
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
    }
}
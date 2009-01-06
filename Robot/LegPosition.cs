namespace Robot
{
    public struct LegPosition
    {
        private readonly double _X;
        private readonly double _Y;
        private readonly double _Z;


        public LegPosition(double X, double Y, double Z)
        {
            _X = X;
            _Y = Y;
            _Z = Z;
        }

        public double X
        {
            get { return _X; }
        }

        public double Y
        {
            get { return _Y; }
        }

        public double Z
        {
            get { return _Z; }
        }

      
    }
}
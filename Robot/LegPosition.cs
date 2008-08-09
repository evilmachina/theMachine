namespace Robot
{
    public class LegPosition
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public LegPosition(double X, double Y, double Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
}
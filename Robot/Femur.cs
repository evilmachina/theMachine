namespace Robot
{
    internal class Femur : ServoBase
    {
        public Femur(double length, double offset, int servoId, double minAngle, double maxAngle, Side side) : base(length, offset, servoId, minAngle, maxAngle, side)
        {
        }
    }
}
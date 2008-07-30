namespace Robot
{
    internal class Tibia : ServoBase
    {
        public Tibia(double length, double offset, int servoId, double minAngle, double maxAngle, Side side) : base(length, offset, servoId, minAngle, maxAngle, side)
        {
        }
    }
}
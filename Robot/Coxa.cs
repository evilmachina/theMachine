
namespace Robot
{
    public class Coxa : ServoBase
    {
        public Coxa(double length, double offset, int servoId, double minAngle, double maxAngle, Side side) : base(length, offset, servoId, minAngle, maxAngle, side)
        {
        }
    }
}
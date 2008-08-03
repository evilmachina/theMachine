
namespace Robot
{
    public class Coxa : ServoBase
    {
        public Coxa(double length, double offset, short servoId, double minAngle, double maxAngle, Side side)
            : base(length, offset, servoId, minAngle, maxAngle, side)
        {
        }

        public override Movment GetMovment()
        {
            short positon = (short)0;
            switch (Side)
            {
                case Side.Left:
                    positon = Convert(-(Angle + Offset));
                    break;
                case Side.Right:
                    positon = Convert(Angle + Offset);
                    break;
            }

            return new Movment((byte)ServoId, positon, 0x050);
        }
    }
}
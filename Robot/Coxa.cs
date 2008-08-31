namespace Robot
{
    public class Coxa : ServoBase
    {
        public Coxa(double length, double offset, short servoId, double minAngle, double maxAngle, Side side) : base(length, offset, servoId, minAngle, maxAngle, side)
        {
        }

        public override MovmentComandAX12 GetMovement()
        {
            short positon = 0;
            if (Side != Side.Right)
                positon = Convert(-(Angle + Offset));
            else
            {
                positon = Convert((IK.Rotate180Degrees(Angle) - Offset));
            }

            return new MovmentComandAX12((byte)ServoId, positon, CalculateSpeed());
        }
    }
}

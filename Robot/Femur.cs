namespace Robot
{
    public class Femur : ServoBase
    {
        public Femur(double length, double offset, short servoId, double minAngle, double maxAngle, Side side)
            : base(length, offset, servoId, minAngle, maxAngle, side)
        {
        }

        public override MovmentComandAX12 GetMovement()
        {
            short positon = 0;
            positon = Convert((double)Side * -(Angle + Offset));

            return new MovmentComandAX12((byte)ServoId, positon, CalculateSpeed());
        }
    }
}

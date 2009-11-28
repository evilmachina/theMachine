using System;

namespace Robot
{
    public class HeadServo
    {
        
        public double Offset { get; set; }
        public short ServoId { get; set; }
        public double MinAngle { get; set; }
        public double MaxAngle { get; set; }

        private const int MaxSpead = 0x3ff /2;

        public HeadServo(double offset, short servoId, double minAngle, double maxAngle)
        {
            Offset = offset;
            ServoId = servoId;
            MinAngle = minAngle;
            MaxAngle = maxAngle;
        }

        protected static short Convert(double d)
        {
            return (short)((0x3ff / (double)300) * (150 + d));
        }

        public MovmentComandAX12 GetMovment()
        {
            short positon = 0;
           
            positon = Convert((Angle + Offset));

            return new MovmentComandAX12((byte)ServoId, positon, MaxSpead);
        }

        public double Angle { get; private set; }

        public void SetAngle(double newAngle)
        {
            if (newAngle < MinAngle) newAngle = MinAngle;
            else if (newAngle > MaxAngle) newAngle = MaxAngle;

            Angle = newAngle;
        }
    }
}
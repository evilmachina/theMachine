using System;
using System.Collections.Generic;


namespace Robot
{
    public class Head : IHead
    {
        public HeadServo YawServo { get; set; }
        public HeadServo PitchServo { get; set; }
        public HeadServo RollServo { get; set; }

        public Head(HeadServo yawServo, HeadServo pitchServo, HeadServo rollServo)
        {
            YawServo = yawServo;
            PitchServo = pitchServo;
            RollServo = rollServo;
        }

        public double Yaw { get; private set; }
        public double Pitch { get; private set; }
        public double Roll { get; set; }

        public MovmentComandAX12[] GetMovements()
        {
            YawServo.SetAngle(Yaw);
            PitchServo.SetAngle(Pitch);
            RollServo.SetAngle(Roll);

            List<MovmentComandAX12> movmentComands = new List<MovmentComandAX12>();
            movmentComands.Add(YawServo.GetMovment());
            movmentComands.Add(PitchServo.GetMovment());
            movmentComands.Add(RollServo.GetMovment());
            return movmentComands.ToArray();
        }

        

        public void SetPosition(double yaw, double pitch, double roll)
        {
            Yaw = yaw;
            Pitch = pitch;
            Roll = roll;
        }
    }
}
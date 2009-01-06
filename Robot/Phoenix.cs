using System;
using System.Collections.Generic;

namespace Robot
{
    public class Phoenix  
    {
        private Leg _leftFrontLeg;
        private Leg _rightFrontLeg;
        private Leg _leftMiddleLeg;
        private Leg _rightMiddleLeg;
        private Leg _leftRearLeg;
        private Leg _rightRearLeg;
        private double _xCenter;
        private double _yCenter;

        public Leg LeftFrontLeg
        {
            get { return _leftFrontLeg; }
            set { _leftFrontLeg = value; }
        }

        public Leg RightFrontLeg
        {
            get { return _rightFrontLeg; }
            set { _rightFrontLeg = value; }
        }

        public Leg LeftMiddleLeg
        {
            get { return _leftMiddleLeg; }
            set { _leftMiddleLeg = value; }
        }

        public Leg RightMiddleLeg
        {
            get { return _rightMiddleLeg; }
            set { _rightMiddleLeg = value; }
        }

        public Leg LeftRearLeg
        {
            get { return _leftRearLeg; }
            set { _leftRearLeg = value; }
        }

        public Leg RightRearLeg
        {
            get { return _rightRearLeg; }
            set { _rightRearLeg = value; }
        }

        public void MoveBody(double distance, double direction)
        {
            MoveBody(distance, direction, 0);
        }

        public void MoveBody(double distance, double direction, double yDistance)
        {
            Leg.CalculateNewPosition(LeftFrontLeg, distance, direction, yDistance);
            Leg.CalculateNewPosition(RightFrontLeg, distance, direction, yDistance);
            Leg.CalculateNewPosition(LeftMiddleLeg, distance, direction, yDistance);
            Leg.CalculateNewPosition(RightMiddleLeg, distance, direction, yDistance);
            Leg.CalculateNewPosition(LeftRearLeg, distance, direction, yDistance);
            Leg.CalculateNewPosition(RightRearLeg, distance, direction, yDistance);
        }

        public MovmentComandAX12[] GetMovements()
        {
            var movements = new List<MovmentComandAX12>();
            movements.AddRange(LeftFrontLeg.GetMovements());
            movements.AddRange(RightFrontLeg.GetMovements());
            movements.AddRange(LeftMiddleLeg.GetMovements());
            movements.AddRange(RightMiddleLeg.GetMovements());
            movements.AddRange(LeftRearLeg.GetMovements());
            movements.AddRange(RightRearLeg.GetMovements());

            return movements.ToArray();
        }

        public void RotateBody(double degrees, double direction)
        {
           Leg.RotateLeg(LeftFrontLeg, degrees, direction, _xCenter , _yCenter);
           Leg.RotateLeg(RightFrontLeg, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(LeftMiddleLeg, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(RightMiddleLeg, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(LeftRearLeg, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(RightRearLeg, degrees, direction, _xCenter, _yCenter);
        }
    }
}
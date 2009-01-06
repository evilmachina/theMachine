namespace Robot
{
    public struct HomePosition
    {
        private readonly LegPosition _leftFrontLeg;
        private readonly LegPosition _rightFrontLeg;
        private readonly LegPosition _leftMiddleLeg;
        private readonly LegPosition _rightMiddleLeg;
        private readonly LegPosition _leftRearLeg;
        private readonly LegPosition _rightRearLeg;

        public HomePosition(LegPosition leftFrontLeg, LegPosition rightFrontLeg, LegPosition leftMiddleLeg, LegPosition rightMiddleLeg, LegPosition leftRearLeg, LegPosition rightRearLeg)
        {
            _leftFrontLeg = leftFrontLeg;
            _rightRearLeg = rightRearLeg;
            _leftRearLeg = leftRearLeg;
            _rightMiddleLeg = rightMiddleLeg;
            _leftMiddleLeg = leftMiddleLeg;
            _rightFrontLeg = rightFrontLeg;
        }

        public LegPosition LeftFrontLeg
        {
            get { return _leftFrontLeg; }
          
        }

        public LegPosition RightFrontLeg
        {
            get { return _rightFrontLeg; }
        
        }

        public LegPosition LeftMiddleLeg
        {
            get { return _leftMiddleLeg; }
          
        }

        public LegPosition RightMiddleLeg
        {
            get { return _rightMiddleLeg; }
         
        }

        public LegPosition LeftRearLeg
        {
            get { return _leftRearLeg; }
         
        }

        public LegPosition RightRearLeg
        {
            get { return _rightRearLeg; }
         
        }
    }
}
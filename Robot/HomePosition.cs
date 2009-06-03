// Copyright (c) 2009 Marcus Olsson
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
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
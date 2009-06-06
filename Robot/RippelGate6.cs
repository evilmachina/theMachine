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
using System;
using System.Collections;
using System.Collections.Generic;

namespace Robot
{
    public class RippelGate6
    {
        private const double _stepHeight = 4;
        private readonly Phoenix _phoenix;
        private readonly HomePosition _homePosition;
        List<MovmentComandAX12>[] _movments = new List<MovmentComandAX12>[6];
        private int rflStep;
        private int rmlStep;
        private int rrlStep;
        private int lflStep;
        private int lmlStep;
        private int lrlStep;
        private int step;

        public RippelGate6(Phoenix phoenix, HomePosition homePosition)
        {
            _phoenix = phoenix;
            _homePosition = homePosition;


            rflStep = 5;
            rmlStep = 1;
            rrlStep = 3;
            lflStep = 2;
            lmlStep = 4;
            lrlStep = 0;
            step = 0;
        }

        public List<MovmentComandAX12>[] Positions
        {
            get { return _movments; }
        }


        /* 
         rflStep = 6 ‘Right front leg
         rmlStep = 2 ‘Right middle leg
         rrlStep = 4 ‘Right rear leg
         lflStep = 3 ‘Left front leg
         lmlStep = 5 ‘Left middle leg
         lrlStep = 1 ‘Left rear leg   
         * */

        public void AddPosision(Phoenix phoenix)
        {
            try
            {
                _movments[addStep(rflStep)].AddRange(phoenix.RightFrontLeg.GetMovements());
                _movments[addStep(rmlStep)].AddRange(phoenix.RightMiddleLeg.GetMovements());
                _movments[addStep(rrlStep)].AddRange(phoenix.RightRearLeg.GetMovements());
                _movments[addStep(lflStep)].AddRange(phoenix.LeftFrontLeg.GetMovements());
                _movments[addStep(lmlStep)].AddRange(phoenix.LeftMiddleLeg.GetMovements());
                _movments[addStep(lrlStep)].AddRange(phoenix.LeftRearLeg.GetMovements());
                step++;
            }
            catch (Exception e)
            {
                
                throw;
            }  
        
        }

        private int addStep(int p)
        {

            return (p + step) % 6;
        }


        private FromPoint GetFromPoint(LegPosition homeLegPosition, int startPosition, Leg leg)
        {

            FromPoint point;
            switch ((step + startPosition) % 6)
            {
                case 0:
                case 5:
                    point = new FromPoint(homeLegPosition.X, homeLegPosition.Z, homeLegPosition.Y);
                    break;
                default:
                    point = new FromPoint(leg.X, leg.Z, homeLegPosition.Y);
                    break;
            }
            
            
            return point;
        }

        private double GetYDistance(double yDistance, int startPosition)
        {
            double distance = 0d;
            switch ((step + startPosition) % 6)
            {
                case 0:
                    distance = 0;
                    break;
                case 1:
                    distance = 0;
                    break;
                case 2:
                    distance = 0;
                    break;
                case 3:
                    distance = 0;
                    break;
                case 4:
                    distance = 0;
                    break;
                case 5:
                    distance = yDistance;
                    break;
            }
            return distance;
        }

        private double GetXDistance(double stepValue, int startPosition)
        {
            double distance = 0d;
            switch ((step + startPosition) % 6)
            {
                case 0:
                    distance = -stepValue*2; // längst frame
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    distance = stepValue;
                    break;
                case 5:
                    distance = 0; //halvägs frame till främre positon
                    break;
            }
            return distance;
        }


        private double GetDegrees(int startPosition, double stepValue)
        {
            double degrees = 0d;
            switch ((step + startPosition) % 6)
            {
                case 0:
                    degrees = -stepValue * 2; // längst frame
                    break;
                case 1:
                case 2:
                case 3:
                case 4:
                    degrees = stepValue;
                    break;
                case 5:
                    degrees = 0; //halvägs frame till främre positon
                    break;
            }
            return degrees;
        }

        public class FromPoint
        {
            private double fromX;
            private double fromZ;
            private double fromY;

            public FromPoint(double fromX, double fromZ, double fromY)
            {
                this.fromX = fromX;
                this.fromZ = fromZ;
                this.fromY = fromY;
            }

            public double FromX
            {
                get { return fromX; }
            }

            public double FromZ
            {
                get { return fromZ; }
            }

            public double FromY
            {
                get { return fromY; }
            }
        }

        private void CalculateNextStep(Leg leg, double direction, double distance, double yDistance, FromPoint fromPoint)
        {
            double newX;
            double newZ;
            double newY;

            Leg.CalculateXandZ(direction, distance, leg.Side, fromPoint.FromX, fromPoint.FromZ, out newX, out newZ);
            newY = fromPoint.FromY - yDistance;
            leg.SetXYZ(newX, newZ, newY);
        }

        private void CalculateNextStepRotation(Leg leg, double degrees, double yDistance, FromPoint fromPoint, double centerX, double centerZ)
        {
            double newX;
            double newZ;
            double newY;

            Leg.CalculateNewCoordinatesForRotation(leg.DistanceToX + fromPoint.FromX, leg.DistanceToZ + fromPoint.FromZ, centerX, centerZ, degrees, out newX, out newZ);

            newY = fromPoint.FromY - yDistance;
            leg.SetRealXYZ(newX, newZ, newY);
        }


        public MovmentComandAX12[] NextSequenceRotation(double stepValue, double centerX, double centerZ)
        {
            CalculateNextStepRotation(_phoenix.LeftFrontLeg, GetDegrees(lflStep, stepValue), GetYDistance(_stepHeight, lflStep),
                                      GetFromPoint(_homePosition.LeftFrontLeg, lflStep, _phoenix.LeftFrontLeg), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.RightFrontLeg, GetDegrees(rflStep, stepValue), GetYDistance(_stepHeight, rflStep),
                                      GetFromPoint(_homePosition.RightFrontLeg, rflStep, _phoenix.RightFrontLeg), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.LeftMiddleLeg, GetDegrees(lmlStep, stepValue), GetYDistance(_stepHeight, lmlStep),
                                      GetFromPoint(_homePosition.LeftMiddleLeg, lmlStep, _phoenix.LeftMiddleLeg), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.RightMiddleLeg, GetDegrees(rmlStep, stepValue), GetYDistance(_stepHeight, rmlStep),
                                      GetFromPoint(_homePosition.RightMiddleLeg, rmlStep, _phoenix.RightMiddleLeg), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.LeftRearLeg, GetDegrees(lrlStep, stepValue), GetYDistance(_stepHeight, lrlStep),
                                      GetFromPoint(_homePosition.LeftRearLeg, lrlStep, _phoenix.LeftRearLeg), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.RightRearLeg, GetDegrees(rrlStep, stepValue), GetYDistance(_stepHeight, rrlStep),
                                      GetFromPoint(_homePosition.RightRearLeg, rrlStep, _phoenix.RightRearLeg), centerX, centerZ);

            step++;
            return _phoenix.GetMovements();
        }

     

        public MovmentComandAX12[] NextSequence(double direction, double stepValue)
        {
            CalculateNextStep(_phoenix.LeftFrontLeg, direction, GetXDistance(stepValue, lflStep), GetYDistance(_stepHeight, lflStep), GetFromPoint(_homePosition.LeftFrontLeg, lflStep, _phoenix.LeftFrontLeg));
            CalculateNextStep(_phoenix.RightFrontLeg, direction, GetXDistance(stepValue, rflStep), GetYDistance(_stepHeight, rflStep), GetFromPoint(_homePosition.RightFrontLeg, rflStep, _phoenix.RightFrontLeg));
            CalculateNextStep(_phoenix.LeftMiddleLeg, direction, GetXDistance(stepValue, lmlStep), GetYDistance(_stepHeight, lmlStep), GetFromPoint(_homePosition.LeftMiddleLeg, lmlStep, _phoenix.LeftMiddleLeg));
            CalculateNextStep(_phoenix.RightMiddleLeg, direction, GetXDistance(stepValue, rmlStep), GetYDistance(_stepHeight, rmlStep), GetFromPoint(_homePosition.RightMiddleLeg, rmlStep, _phoenix.RightMiddleLeg));
            CalculateNextStep(_phoenix.LeftRearLeg, direction, GetXDistance(stepValue, lrlStep), GetYDistance(_stepHeight, lrlStep), GetFromPoint(_homePosition.LeftRearLeg, lrlStep, _phoenix.LeftRearLeg));
            CalculateNextStep(_phoenix.RightRearLeg, direction, GetXDistance(stepValue, rrlStep), GetYDistance(_stepHeight, rrlStep), GetFromPoint(_homePosition.RightRearLeg, rrlStep, _phoenix.RightRearLeg));


            step++;

            return _phoenix.GetMovements();
        }


       
    }
}
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

        public RippelGate6()
        {
            for (int i = 0; i < _movments.Length; i++)
            {
                _movments[i] = new List<MovmentComandAX12>();
            }

            rflStep = 5;
            rmlStep = 1;
            rrlStep = 3;
            lflStep = 2;
            lmlStep = 4;
            lrlStep = 0;
            step = 0;
        }

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
                _movments[addStep(rflStep)].AddRange(phoenix.rfl.GetMovements());
                _movments[addStep(rmlStep)].AddRange(phoenix.rml.GetMovements());
                _movments[addStep(rrlStep)].AddRange(phoenix.rrl.GetMovements());
                _movments[addStep(lflStep)].AddRange(phoenix.lfl.GetMovements());
                _movments[addStep(lmlStep)].AddRange(phoenix.lml.GetMovements());
                _movments[addStep(lrlStep)].AddRange(phoenix.lrl.GetMovements());
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

        public static RippelGate6 CreateRippelGate6(Phoenix phoenix, double stepValue, double direction)
        {

            RippelGate6 rippelGate6 = new RippelGate6();
            phoenix.MoveBody(-stepValue * 2, direction);
            rippelGate6.AddPosision(phoenix);
            phoenix.MoveBody(stepValue, direction);
            rippelGate6.AddPosision(phoenix);
            phoenix.MoveBody(stepValue, direction);
            rippelGate6.AddPosision(phoenix);
            phoenix.MoveBody(stepValue, direction);
            rippelGate6.AddPosision(phoenix);
            phoenix.MoveBody(stepValue, direction);
            rippelGate6.AddPosision(phoenix);
            phoenix.MoveBody(-stepValue * 2, direction, 8);
            rippelGate6.AddPosision(phoenix);

            return rippelGate6;
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
            CalculateNextStepRotation(_phoenix.lfl, GetDegrees(lflStep, stepValue), GetYDistance(_stepHeight, lflStep),
                                      GetFromPoint(_homePosition.lfl, lflStep, _phoenix.lfl), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.rfl, GetDegrees(rflStep, stepValue), GetYDistance(_stepHeight, rflStep),
                                      GetFromPoint(_homePosition.rfl, rflStep, _phoenix.rfl), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.lml, GetDegrees(lmlStep, stepValue), GetYDistance(_stepHeight, lmlStep),
                                      GetFromPoint(_homePosition.lml, lmlStep, _phoenix.lml), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.rml, GetDegrees(rmlStep, stepValue), GetYDistance(_stepHeight, rmlStep),
                                      GetFromPoint(_homePosition.rml, rmlStep, _phoenix.rml), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.lrl, GetDegrees(lrlStep, stepValue), GetYDistance(_stepHeight, lrlStep),
                                      GetFromPoint(_homePosition.lrl, lrlStep, _phoenix.lrl), centerX, centerZ);
            CalculateNextStepRotation(_phoenix.rrl, GetDegrees(rrlStep, stepValue), GetYDistance(_stepHeight, rrlStep),
                                      GetFromPoint(_homePosition.rrl, rrlStep, _phoenix.rrl), centerX, centerZ);

            step++;
            return _phoenix.GetMovements();
        }

     

        public MovmentComandAX12[] NextSequence(double direction, double stepValue)
        {
            CalculateNextStep(_phoenix.lfl, direction, GetXDistance(stepValue, lflStep), GetYDistance(_stepHeight, lflStep), GetFromPoint(_homePosition.lfl, lflStep, _phoenix.lfl));
            CalculateNextStep(_phoenix.rfl, direction, GetXDistance(stepValue, rflStep), GetYDistance(_stepHeight, rflStep), GetFromPoint(_homePosition.rfl, rflStep, _phoenix.rfl));
            CalculateNextStep(_phoenix.lml, direction, GetXDistance(stepValue, lmlStep), GetYDistance(_stepHeight, lmlStep), GetFromPoint(_homePosition.lml, lmlStep, _phoenix.lml));
            CalculateNextStep(_phoenix.rml, direction, GetXDistance(stepValue, rmlStep), GetYDistance(_stepHeight, rmlStep), GetFromPoint(_homePosition.rml, rmlStep, _phoenix.rml));
            CalculateNextStep(_phoenix.lrl, direction, GetXDistance(stepValue, lrlStep), GetYDistance(_stepHeight, lrlStep), GetFromPoint(_homePosition.lrl, lrlStep, _phoenix.lrl));
            CalculateNextStep(_phoenix.rrl, direction, GetXDistance(stepValue, rrlStep), GetYDistance(_stepHeight, rrlStep), GetFromPoint(_homePosition.rrl, rrlStep, _phoenix.rrl));


            step++;

            return _phoenix.GetMovements();
        }


       
    }
}
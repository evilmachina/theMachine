using System;
using System.Collections;
using System.Collections.Generic;

namespace Robot
{
    public class RippelGate6
    {
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



        public MovmentComandAX12[] NextSequence(double direction, double stepValue)
        {
            List<MovmentComandAX12> nexSequence = new List<MovmentComandAX12>();

            double stepHeight = 4;

            CalculateNextStep(_phoenix.lfl, _homePosition.lfl, direction, GetXDistance(stepValue, lflStep), GetYDistance(stepHeight, lflStep));
            CalculateNextStep(_phoenix.rfl, _homePosition.rfl, direction, GetXDistance(stepValue, rflStep), GetYDistance(stepHeight, rflStep));
            CalculateNextStep(_phoenix.lml, _homePosition.lml, direction, GetXDistance(stepValue, lmlStep), GetYDistance(stepHeight, lmlStep));
            CalculateNextStep(_phoenix.rml, _homePosition.rml, direction, GetXDistance(stepValue, rmlStep), GetYDistance(stepHeight, rmlStep));
            CalculateNextStep(_phoenix.lrl, _homePosition.lrl, direction, GetXDistance(stepValue, lrlStep), GetYDistance(stepHeight, lrlStep));
            CalculateNextStep(_phoenix.rrl, _homePosition.rrl, direction, GetXDistance(stepValue, rrlStep), GetYDistance(stepHeight, rrlStep));
            step++;

            return _phoenix.GetMovements();
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
                    distance = -stepValue*2;
                    break;
                case 1:
                    distance = -stepValue;
                    break;
                case 2:
                    distance = 0;
                    break;
                case 3:
                    distance = stepValue;
                    break;
                case 4:
                    distance = stepValue * 2;
                    break;
                case 5:
                    distance = 0;
                    break;
            }
            return distance;
        }

        private void CalculateNextStep(Leg leg, LegPosition homeLegPosition, double direction, double distance, double yDistance)
        {
            double newX;
            double newZ;
            double newY;

            Leg.CalculateXandZ(direction, distance, leg.Side, homeLegPosition.X, homeLegPosition.Z, out newX, out newZ);

            newY = homeLegPosition.Y - yDistance;
            leg.SetXYZ(newX, newZ, newY);
        }

       
    }
}
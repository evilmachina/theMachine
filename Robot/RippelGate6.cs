using System;
using System.Collections;
using System.Collections.Generic;

namespace Robot
{
    public class RippelGate6
    {
        List<Movment>[] _movments = new List<Movment>[6];
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
                _movments[i] = new List<Movment>();
            }

            rflStep = 5;
            rmlStep = 1;
            rrlStep = 3;
            lflStep = 2;
            lmlStep = 4;
            lrlStep = 0;
            step = 0;
        }

        public List<Movment>[] Positions
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
    }
}
using System;
using System.Collections.Generic;

namespace Robot
{
    public class Phoenix  
    {
        private Leg _lfl;
        private Leg _rfl;
        private Leg _lml;
        private Leg _rml;
        private Leg _lrl;
        private Leg _rrl;

        public Leg lfl
        {
            get { return _lfl; }
            set { _lfl = value; }
        }

        public Leg rfl
        {
            get { return _rfl; }
            set { _rfl = value; }
        }

        public Leg lml
        {
            get { return _lml; }
            set { _lml = value; }
        }

        public Leg rml
        {
            get { return _rml; }
            set { _rml = value; }
        }

        public Leg lrl
        {
            get { return _lrl; }
            set { _lrl = value; }
        }

        public Leg rrl
        {
            get { return _rrl; }
            set { _rrl = value; }
        }

        public void MoveBody(double distance, double direction)
        {
            MoveBody(distance, direction, 0);
        }

        public void MoveBody(double distance, double direction, double yDistance)
        {
            var directionInRadianer = Math.Tan(direction * (Math.PI / 180));

            lfl.CalculateNewPosision(distance, directionInRadianer, yDistance);
            rfl.CalculateNewPosision(distance, directionInRadianer, yDistance);
            lml.CalculateNewPosision(distance, directionInRadianer, yDistance);
            rml.CalculateNewPosision(distance, directionInRadianer, yDistance);
            lrl.CalculateNewPosision(distance, directionInRadianer, yDistance);
            rrl.CalculateNewPosision(distance, directionInRadianer, yDistance);
        }

        public Movment[] GetMovements()
        {
            var movements = new List<Movment>();
            movements.AddRange(lfl.GetMovements());
            movements.AddRange(rfl.GetMovements());
            movements.AddRange(lml.GetMovements());
            movements.AddRange(rml.GetMovements());
            movements.AddRange(lrl.GetMovements());
            movements.AddRange(rrl.GetMovements());

            return movements.ToArray();
        }

        public RippelGate6 CreateRippelGate6(double stepValue, double direction, int distance)
        {
            /* 
             rflStep = 6 ‘Right front leg
             rmlStep = 2 ‘Right middle leg
             rrlStep = 4 ‘Right rear leg
             lflStep = 3 ‘Left front leg
             lmlStep = 5 ‘Left middle leg
             lrlStep = 1 ‘Left rear leg
             * */

            RippelGate6 rippelGate6 = new RippelGate6();
            MoveBody(-2, 90);
            rippelGate6.AddPosision(this);
            MoveBody(1, 90);
            rippelGate6.AddPosision(this);
            MoveBody(1, 90);
            rippelGate6.AddPosision(this);
            MoveBody(1, 90);
            rippelGate6.AddPosision(this);
            MoveBody(1, 90);
            rippelGate6.AddPosision(this);
            MoveBody(-2, 90, 4);
            rippelGate6.AddPosision(this);

            return rippelGate6;
        }
        

    }
}
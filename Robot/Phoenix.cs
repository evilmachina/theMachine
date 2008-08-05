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
           

            lfl.CalculateNewPosision(distance, direction, yDistance);
            rfl.CalculateNewPosision(distance, direction, yDistance);
            lml.CalculateNewPosision(distance, direction, yDistance);
            rml.CalculateNewPosision(distance, direction, yDistance);
            lrl.CalculateNewPosision(distance, direction, yDistance);
            rrl.CalculateNewPosision(distance, direction, yDistance);
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

        public RippelGate6 CreateRippelGate6(double stepValue, double direction)
        {

            RippelGate6 rippelGate6 = new RippelGate6();
            MoveBody(-stepValue * 2, direction);
            rippelGate6.AddPosision(this);
            MoveBody(stepValue, direction);
            rippelGate6.AddPosision(this);
            MoveBody(stepValue, direction);
            rippelGate6.AddPosision(this);
            MoveBody(stepValue, direction);
            rippelGate6.AddPosision(this);
            MoveBody(stepValue, direction);
            rippelGate6.AddPosision(this);
            MoveBody(-stepValue * 2, direction, 8);
            rippelGate6.AddPosision(this);

            return rippelGate6;
        }
        

    }
}
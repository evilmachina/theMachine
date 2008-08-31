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
        private double _xCenter;
        private double _yCenter;

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
            Leg.CalculateNewPosition(lfl, distance, direction, yDistance);
            Leg.CalculateNewPosition(rfl, distance, direction, yDistance);
            Leg.CalculateNewPosition(lml, distance, direction, yDistance);
            Leg.CalculateNewPosition(rml, distance, direction, yDistance);
            Leg.CalculateNewPosition(lrl, distance, direction, yDistance);
            Leg.CalculateNewPosition(rrl, distance, direction, yDistance);
        }

        public MovmentComandAX12[] GetMovements()
        {
            var movements = new List<MovmentComandAX12>();
            movements.AddRange(lfl.GetMovements());
            movements.AddRange(rfl.GetMovements());
            movements.AddRange(lml.GetMovements());
            movements.AddRange(rml.GetMovements());
            movements.AddRange(lrl.GetMovements());
            movements.AddRange(rrl.GetMovements());

            return movements.ToArray();
        }

        public void RotateBody(double degrees, double direction)
        {
           Leg.RotateLeg(lfl, degrees, direction, _xCenter , _yCenter);
           Leg.RotateLeg(rfl, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(lml, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(rml, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(lrl, degrees, direction, _xCenter, _yCenter);
           Leg.RotateLeg(rrl, degrees, direction, _xCenter, _yCenter);
        }
    }
}
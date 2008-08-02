using System;

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
            var directionInRadianer = Math.Tan(direction * (Math.PI / 180));

            lfl.CalculateNewPosision(distance, directionInRadianer);
            rfl.CalculateNewPosision(distance, directionInRadianer);
            lml.CalculateNewPosision(distance, directionInRadianer);
            rml.CalculateNewPosision(distance, directionInRadianer);
            lrl.CalculateNewPosision(distance, directionInRadianer);
            rrl.CalculateNewPosision(distance, directionInRadianer);
        }
    }
}
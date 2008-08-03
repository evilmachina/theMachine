using System;

namespace Robot
{
    public abstract class ServoBase
    {
        private readonly double _length;
        private readonly double _offset;
        private readonly short _servoId;
        private readonly double _minAngle;
        private readonly double _maxAngle;
        private readonly Side _side;

        private double _angle;

        public ServoBase(double length, double offset, short servoId, double minAngle, double maxAngle, Side side)
        {
            _length = length;
            _offset = offset;
            _servoId = servoId;
            _minAngle = minAngle;
            _maxAngle = maxAngle;
            _side = side;
        }

        public double Length
        {
            get { return _length; }
        }

        public double Offset
        {
            get { return _offset; }
        }

        public int ServoId
        {
            get { return _servoId; }
        }

        public double MinAngle
        {
            get { return _minAngle; }
        }

        public double MaxAngle
        {
            get { return _maxAngle; }
        }

        public Side Side
        {
            get { return _side; }
        }
        
        public double Angle
        {
            get { return Math.Round(_angle,1,MidpointRounding.ToEven); }
            set { _angle = value; }
        }

        public abstract Movment GetMovment();

        protected static short Convert(double d)
        {
            return (short)((0x3ff / (double)300) * (150 + d));
        }
    }
}
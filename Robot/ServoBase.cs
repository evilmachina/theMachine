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

namespace Robot
{
    public class ServoBase
    {
        private readonly double _length;
        private readonly double _offset;
        private readonly short _servoId;
        private readonly double _minAngle;
        private readonly double _maxAngle;
        private readonly Side _side;

        private double _angle;
        private double _oldAngle;
        private const double K = (double)684 / 1023;
        private bool _firstTime = true;
        private static double _timeBox = 1;

        public static double TimeBox
        {
            set { _timeBox = value; }
            get { return _timeBox; }
        }

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
            internal set
            {
                _oldAngle = _angle;
                _angle = value;
            }
        }

        protected static short Convert(double d)
        {
            return (short)((0x3ff / (double)300) * (150 + d));
        }

        protected short CalculateSpeed()
        {
            //0.196 =  sec/60 deg  ; 0,196 * 60 /300
            //Max 0x3ff

            //114 RPM = 3ff  = 8,9736842105263157894736842105263  * 2PI/60 rad/s  = 180/Math.PI  = 684 deg/s
            //57 RPM = 200   = 8,9824561403508771929824561403509  * 2PI/60                         342
            //0,5
            //100  

            //1     = 0,66862170087976539589442815249267 deg/s
            //1023  = 684 deg/s

            //_K;
          //  return 0x050;
            if(_firstTime)
            {
                _firstTime = false;
                return 0x050;
            }
            
            
           
            var speed = (short)((Math.Sqrt(Math.Pow(CalculateAngle(), 2))) / K / _timeBox);
            if(speed == 0)
                return 1;
            else if(speed > 0x3ff)
            {
                throw new ApplicationException("To fast max 1023. speed = " + speed);
            }

            return speed;
        }

        private double CalculateAngle()
        {
            if(Side == Side.Right)
            {
                return IK.Rotate180Degrees(_oldAngle) - IK.Rotate180Degrees(_angle);
            }
            return _oldAngle - _angle;
        }

        public virtual MovmentComandAX12 GetMovement()
        {
            short positon = 0;
            positon = Convert((double)Side*(Angle + Offset));
          
            return new MovmentComandAX12((byte)ServoId, positon, CalculateSpeed());
        }
    }
}
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

namespace Robot.StatusPacketes
{
    public class StatusPacket
    {
        private readonly List<byte> _receivedData;
        private readonly byte _startByte1;
        private readonly byte _startByte2;
        private readonly byte _servoId;
        private readonly byte _lengthOfResult;
        private readonly byte _error;
        private readonly List<byte> _parameters = new List<byte>();
        private readonly byte _checkSum;
       

        public StatusPacket(List<byte> receivedData)
        {
            _receivedData = receivedData;
            _startByte1 = receivedData[0];
            _startByte2 = receivedData[1];
            _servoId = receivedData[2];
            _lengthOfResult = receivedData[3];
            _error = receivedData[4];

            GetParameters(receivedData);

            _checkSum = receivedData[receivedData.Count-1];

        }

        private void GetParameters(List<byte> receivedData)
        {
            _parameters.AddRange(receivedData.GetRange(5,_lengthOfResult - 2));
        }

        public int StartByte1
        {
            get { return _startByte1; }
        }

        public int StartByte2
        {
            get { return _startByte2; }
        }

        public byte ServoId
        {
            get { return _servoId; }
        }

        public byte LengthOfResult
        {
            get { return _lengthOfResult; }
        }

        public byte Error
        {
            get { return _error; }
        }

        public List<byte> Parameters
        {
            get { return _parameters; }
        }

        public byte CheckSum
        {
            get { return _checkSum; }
        }

        public List<byte> ReceivedData
        {
            get { return _receivedData; }
        }

        public double Position
        {
            get { return CalculatePositon(); }
        }

        public double Speed
        {
            get { return CalculateSpeed(); }
           
        }

        public Direction LoadDirection
        {
            get { return GetLoadDirection(); }
        }

        public short Load
        {
            get { return GetLoad(); }
        }

        public double Voltage
        {
            get {return GetVoltage(); }
        }

        public int Temperature
        {
            get { return GetTemperatureParameter(); }
        }

        private double GetVoltage()
        {
            return GetVoltageParameter()/10.0;
        }

        private short GetLoad()
        {
            return (short)(BitConverter.ToInt16(GetLoadParameters(), 0) & 0x3FF);
        }

        private Direction GetLoadDirection()
        {
            BitArray loadParametersAsBitArray = new BitArray(GetLoadParameters());
            return loadParametersAsBitArray[10] ? Direction.Clockwise : Direction.Counterclockwise;
        }

        private double CalculateSpeed()
        {
            return BitConverter.ToInt16(GetSpeedParameters(), 0);
        }

        private double CalculatePositon()
        {
           short rawPositon = BitConverter.ToInt16(GetPositonParameters(), 0);
           return (((double)300 / 0x3ff) * rawPositon) - 150; 
        }

        private byte[] GetPositonParameters()
        {
            return new[] {Parameters[0], Parameters[1]};
        }

        private byte[] GetSpeedParameters()
        {
            return new[] { Parameters[2], Parameters[3] };
        }

        private byte[] GetLoadParameters()
        {
            return new[] { Parameters[4], Parameters[5] };
        }

        private byte GetVoltageParameter()
        {
           return Parameters[6];
        }

        private byte GetTemperatureParameter()
        {
            return Parameters[7];
        }
    }
}
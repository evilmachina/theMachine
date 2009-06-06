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
using System.Collections.Generic;

namespace Robot.InstructionPackets
{
    public class InstructionPacketBase
    {
        private const byte _startByte1 = 0xFF;
        private const byte _startByte2 = 0xFF;

        private readonly byte _servoId;
        protected byte _instruction;
        private bool _isSent;
        protected byte _lengthOfCommand;
        protected List<byte> _parameters = new List<byte>();
        protected ISender _sender;

        public InstructionPacketBase(byte servoId, ISender sender)
        {
            _servoId = servoId;
            _sender = sender;
        }

        public byte StartByte1
        {
            get { return _startByte1; }
        }

        public byte StartByte2
        {
            get { return _startByte2; }
        }

        public byte ServoId
        {
            get { return _servoId; }
        }

        public byte LengthOfCommand
        {
            get { return _lengthOfCommand; }
        }

        public byte Instruction
        {
            get { return _instruction; }
        }

        public byte CheckSum
        {
            get { return (byte) ~(_servoId + _lengthOfCommand + _instruction + SumOfParameters()); }
        }

        public bool IsSent
        {
            get { return _isSent; }
        }

        private int SumOfParameters()
        {
            int sum = 0;
            foreach (byte parameter in _parameters)
            {
                sum += parameter;
            }
            return sum;
        }

        public byte[] ToByte()
        {
            var bytes = new List<byte>();
            bytes.Add(_startByte1);
            bytes.Add(_startByte2);
            bytes.Add(_servoId);
            bytes.Add(_lengthOfCommand);
            bytes.Add(_instruction);
            bytes.AddRange(_parameters);
            bytes.Add(CheckSum);
            return bytes.ToArray();
        }

        public void Send()
        {
            _sender.Send(ToByte());
            _isSent = true;
        }
    }
}
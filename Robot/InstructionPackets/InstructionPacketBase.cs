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
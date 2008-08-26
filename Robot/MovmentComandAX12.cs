using System;
using System.Collections.Generic;

namespace Robot
{
    public class MovmentComandAX12
    {
        private readonly short _position;
        private readonly byte _servoId;
        private readonly short _speed;

        public MovmentComandAX12(byte servoId, short position, short speed)
        {
            _servoId = servoId;
            _position = position;
            _speed = speed;
        }

        public IEnumerable<byte> ToByte()
        {
            var param = new List<byte>();
            param.Add(_servoId);
            param.AddRange(BitConverter.GetBytes(_position));
            param.AddRange(BitConverter.GetBytes(_speed));

            return param;
        }
    }
}
namespace Robot.StatusPacketes
{
    public class StatusPacket
    {
        private readonly byte[] _receivedData;
        private readonly byte _startByte1;
        private readonly byte _startByte2;
        private readonly byte _servoId;
        private readonly byte _lengthOfResult;
        private readonly byte _error;
        private readonly byte _parameters;
        private readonly byte _checkSum;
       

        public StatusPacket(byte[] receivedData)
        {
            _receivedData = receivedData;
            _startByte1 = receivedData[0];
            _startByte2 = receivedData[1];
            _servoId = receivedData[2];
            _lengthOfResult = receivedData[3];
            _error = receivedData[4];
            _parameters = receivedData[5];
            _checkSum = receivedData[6];

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

        public byte Parameters
        {
            get { return _parameters; }
        }

        public byte CheckSum
        {
            get { return _checkSum; }
        }

        public byte[] ReceivedData
        {
            get { return _receivedData; }
        }
    }
}
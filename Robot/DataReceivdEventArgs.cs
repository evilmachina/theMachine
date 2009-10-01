using System;

namespace Robot
{
    public class DataReceivdEventArgs : EventArgs
    {
        private readonly byte[] _receivdData;

        public DataReceivdEventArgs(byte[] receivdData)
        {
            _receivdData = receivdData;
        }

        public byte[] ReceivdData
        {
            get { return _receivdData; }
        }
    }
}
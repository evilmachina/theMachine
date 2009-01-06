using System;
using System.IO.Ports;

namespace Robot
{
    public class CommunicationObject : ISender, IDisposable
    {
        private static readonly SerialPort _comPort = new SerialPort();

        public CommunicationObject(string comPortName)
        {
            SetupComport(comPortName);
           

            // When data is recieved through the port, call this method
            // _comPort.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        public bool IsOpen
        {
            get { return _comPort.IsOpen; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _comPort.Close();
        }

        #endregion

        #region ISender Members

        public void Send(byte[] bytes)
        {
            if (!IsOpen)
            {
                Open();
            }
            _comPort.Write(bytes, 0, bytes.Length);
        }

        #endregion

        private void SetupComport(string comPortName)
        {
            _comPort.BaudRate = 1000000;
            _comPort.PortName = comPortName;
        }

        public void Open()
        {
            _comPort.Open();
        }
    }
}
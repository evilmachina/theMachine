using System;
using System.IO.Ports;

namespace Robot
{
    public class CommunicationObject : ISender, IDisposable
    {
        private static readonly SerialPort _comport = new SerialPort();

        public CommunicationObject()
        {
            SetupComport();
            //foreach(string s in SerialPort.GetPortNames())
            //{

            //}

            // When data is recieved through the port, call this method
            // _comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }

        public bool IsOpen
        {
            get { return _comport.IsOpen; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _comport.Close();
        }

        #endregion

        #region ISender Members

        public void Send(byte[] bytes)
        {
            if (!IsOpen)
            {
                Open();
            }
            _comport.Write(bytes, 0, bytes.Length);
        }

        #endregion

        private void SetupComport()
        {
            _comport.BaudRate = 1000000;
            _comport.PortName = "COM5"; //Behövs nog hämtas från config

            // Open the port
            //comport.Open();
        }

        public void Open()
        {
            _comport.Open();
        }
    }
}
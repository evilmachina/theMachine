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
using System.IO.Ports;

namespace Robot
{
    public class CommunicationObject : ISender, IDisposable
    {
        private static readonly SerialPort _comPort = new SerialPort();

        public CommunicationObject(string comPortName)
        {
            SetupComPort(comPortName);
           
            // When data is recieved through the port, call this method
          
            _comPort.DataReceived += port_DataReceived;
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int lastred;
            do
            {
               
                lastred = _comPort.ReadByte();
                Console.Write(lastred.ToString("X2") + ",");
            } while (_comPort.BytesToRead > 0);

            Console.WriteLine("ute ur loppen");
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

        private void SetupComPort(string comPortName)
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
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
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Robot.InstructionPackets;
using Robot.StatusPacketes;
using TestProj;

namespace Robot.Tests
{
    [TestFixture]
    public class SennsorTests 
    {
        private const int SERVO_ID = 1;

        [Test]
        public void CanBuildInstructionForReadingTemperature()
        {
            ISender sender = new FakeSender();
            InstructionPacketBase instructionPacket = new InstructionPacketReadTemperature(SERVO_ID, sender);

            Assert.AreEqual(0xFF, instructionPacket.StartByte1);
            Assert.AreEqual(0xFF, instructionPacket.StartByte2);
            Assert.AreEqual(0x01, instructionPacket.ServoId);
            Assert.AreEqual(0x04, instructionPacket.LengthOfCommand);
            Assert.AreEqual(0x02, instructionPacket.Instruction);
            Assert.AreEqual(0xCC, instructionPacket.CheckSum);
            var corectResult = new byte[] { 0XFF, 0XFF, 0X01, 0X04, 0X02, 0X2B, 0X01, 0XCC};
            Assert.AreEqual(corectResult, instructionPacket.ToByte());

            //temp 43 0x2B
            //loadL 40 0x28
            //loadH 41 0x29
            //Load Direction = 0 : CCW Load, Load Direction = 1: CW Load
        }

        [Test]
        public void CanReadStatusPacketForTemperature()
        {
            List<byte> corectResult = new List<byte> { 0XFF, 0XFF, 0X01, 0X03, 0X00, 0X20, 0XDB };

            StatusPacket statusPacket = new StatusPacket(corectResult);
            Assert.AreEqual(0xFF, statusPacket.StartByte1);
            Assert.AreEqual(0xFF, statusPacket.StartByte2);
            Assert.AreEqual(0x01, statusPacket.ServoId);
            Assert.AreEqual(0x03, statusPacket.LengthOfResult);
            Assert.AreEqual(0x00, statusPacket.Error);
            Assert.That(statusPacket.Parameters, Is.EquivalentTo(new List<byte> { 0x20 }));
            Assert.AreEqual(0xDB, statusPacket.CheckSum);
            Assert.AreEqual(corectResult, statusPacket.ReceivedData);
        }

        [Test]
        public void CanBuildInstructionForPresentLoad()
        {
            ISender sender = new FakeSender();
            InstructionPacketBase instructionPacket = new InstructionPacketReadPresentLoad(SERVO_ID, sender);

            Assert.AreEqual(0xFF, instructionPacket.StartByte1);
            Assert.AreEqual(0xFF, instructionPacket.StartByte2);
            Assert.AreEqual(0x01, instructionPacket.ServoId);
            Assert.AreEqual(0x04, instructionPacket.LengthOfCommand);
            Assert.AreEqual(0x02, instructionPacket.Instruction);
            Assert.AreEqual(0xCE, instructionPacket.CheckSum);
            var corectResult = new byte[] { 0XFF, 0XFF, 0X01, 0X04, 0X02, 0X28, 0X02, 0XCE };
            Assert.AreEqual(corectResult, instructionPacket.ToByte());
        }


        [Test]
        public void CanReadStatusPacketForPresentLoad()
        {
            List<byte> corectResult = new List<byte> { 0xFF, 0xFF, 0x05, 0x04, 0x00, 0x00, 0x00, 0xF6 };

            StatusPacket statusPacket = new StatusPacket(corectResult);
            Assert.AreEqual(0xFF, statusPacket.StartByte1);
            Assert.AreEqual(0xFF, statusPacket.StartByte2);
            Assert.AreEqual(0x05, statusPacket.ServoId);
            Assert.AreEqual(0x04, statusPacket.LengthOfResult);
            Assert.AreEqual(0x00, statusPacket.Error);
            Assert.That(statusPacket.Parameters, Is.EquivalentTo(new byte[] {0x00, 0x00}));
            Assert.AreEqual(0xF6, statusPacket.CheckSum);
            Assert.AreEqual(corectResult, statusPacket.ReceivedData);
        }

        [Test]
        public void CanBuildInstructionForSensorData()
        {
            ISender sender = new FakeSender();
            var corectResult = new byte[] { 0XFF, 0XFF, 0X01, 0X04, 0X02, 0X24, 0X08, 0XCC };
            InstructionPacketBase instructionPacket = new InstructionPacketReadServoSensorData(SERVO_ID, sender);

            Assert.AreEqual(0xFF, instructionPacket.StartByte1);
            Assert.AreEqual(0xFF, instructionPacket.StartByte2);
            Assert.AreEqual(0x01, instructionPacket.ServoId);
            Assert.AreEqual(0x04, instructionPacket.LengthOfCommand);
            Assert.AreEqual(0x02, instructionPacket.Instruction);
            Assert.AreEqual(0xCC, instructionPacket.CheckSum);
            Assert.AreEqual(corectResult, instructionPacket.ToByte());
        }

        [Test]
        public void CanReadStatusPacketForSensorData()
        {

            List<byte> receivedData = new List<byte>
                                          {
                                              0xFF, //bytes indicate the start of the packet
                                              0xFF, //bytes indicate the start of the packet
                                              0x05, //ID
                                              0x0A, //length
                                              0x00, //Error
                                              0x7F, //Present Position(L)
                                              0x02, //Present Position(H)
                                              0x04, //Present Speed(L)
                                              0x04, //Present Speed(H)
                                              0x05, //Present Load(L)
                                              0x04, //Present Load(H)
                                              0x7B, //Present Voltage
                                              0x26, //Present Temperature
                                              0xBD  //Checksum
                                          };

            StatusPacket statusPacket = new StatusPacket(receivedData);
            Assert.AreEqual(0xFF, statusPacket.StartByte1);
            Assert.AreEqual(0xFF, statusPacket.StartByte2);
            Assert.AreEqual(0x05, statusPacket.ServoId);
            Assert.AreEqual(0x0A, statusPacket.LengthOfResult);
            Assert.AreEqual(0x00, statusPacket.Error);
            Assert.AreEqual(37.39, statusPacket.Position, 0.01);
            Assert.AreEqual(1028, statusPacket.Speed);
            Assert.AreEqual(Direction.Clockwise, statusPacket.LoadDirection);
            Assert.AreEqual(5, statusPacket.Load);
            Assert.AreEqual(12.3, statusPacket.Voltage);
            Assert.AreEqual(38, statusPacket.Temperature);
            Assert.AreEqual(new byte[] { 0x7F, 0x02, 0x04, 0x04, 0x05, 0x04, 0x7B, 0x26 }, statusPacket.Parameters);
            Assert.AreEqual(0xBD, statusPacket.CheckSum);
            Assert.AreEqual(receivedData, statusPacket.ReceivedData);
        }



        [Test, Ignore("Need to be connected to robot")]
        public void LiveSensorTest()
        {
            CommunicationObject communicationObject = new CommunicationObject("COM4");
            //communicationObject.Respons 

            while (true)
            {
                var instructionPacket = new InstructionPacketReadServoSensorData(5, communicationObject);
                instructionPacket.Send();
                Thread.Sleep(2000);  
            }
            
            
            ((CommunicationObject)communicationObject).Dispose();
        }



    }
}
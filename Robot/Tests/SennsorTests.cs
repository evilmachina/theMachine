using NUnit.Framework;
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
        public void CanSendInstructionForReadingTemperature()
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
            var corectResult = new byte[] { 0XFF, 0XFF, 0X01, 0X03, 0X00, 0X20, 0XDB };

            StatusPacket statusPacket = new StatusPacket(corectResult);
            Assert.AreEqual(0xFF, statusPacket.StartByte1);
            Assert.AreEqual(0xFF, statusPacket.StartByte2);
            Assert.AreEqual(0x01, statusPacket.ServoId);
            Assert.AreEqual(0x03, statusPacket.LengthOfResult);
            Assert.AreEqual(0x00, statusPacket.Error);
            Assert.AreEqual(0x20, statusPacket.Parameters);
            Assert.AreEqual(0xDB, statusPacket.CheckSum);
            Assert.AreEqual(corectResult, statusPacket.ReceivedData);
            
        }
    }
}
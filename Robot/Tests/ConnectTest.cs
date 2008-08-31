using NUnit.Framework;
using TestProj;

namespace Robot.Tests
{
    [TestFixture]
    public class ConnectTest
    {
        private const int SERVO_ID = 1;

        [Test, Ignore("Ned to be connected to robot")]
        public void CanCreateInstructionPacketForPingId1()
        {
            ISender sender = new FakeSender();
            var instructionPacket = new InstructionPacketPing(SERVO_ID, sender);


            Assert.AreEqual(0xFF, instructionPacket.StartByte1);
            Assert.AreEqual(0xFF, instructionPacket.StartByte2);
            Assert.AreEqual(0x01, instructionPacket.ServoId);
            Assert.AreEqual(0x02, instructionPacket.LengthOfCommand);
            Assert.AreEqual(0x01, instructionPacket.Instruction);
            Assert.AreEqual(0xFB, instructionPacket.CheckSum);
            var corectResult = new byte[] {0XFF, 0XFF, 0X01, 0X02, 0X01, 0XFB};
            Assert.AreEqual(corectResult, instructionPacket.ToByte());
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanCreateInstructionPacketForSyncedMovment()
        {
            ISender sender = new FakeSender();
            var movment1 = new MovmentComandAX12(0, 0x010, 0x150);
            var movment2 = new MovmentComandAX12(1, 0x220, 0x360);
            var movment3 = new MovmentComandAX12(2, 0x030, 0x170);
            var movment4 = new MovmentComandAX12(3, 0x220, 0x380);
            var instructionPacket = new InstructionPacketSyncMovment(sender, movment1, movment2, movment3, movment4);

            var corectResult = new byte[]
                                   {
                                       0XFF, 0XFF, 0XFE, 0X18, 0X83, 0X1E, 0X04, 0X00, 0X10, 0X00, 0X50, 0X01, 0X01,
                                       0X20, 0X02, 0X60, 0X03, 0X02, 0X30, 0X00, 0X70, 0X01, 0X03, 0X20, 0X02, 0X80,
                                       0X03, 0X12
                                   };
            Assert.AreEqual(corectResult, instructionPacket.ToByte());
            // Console.WriteLine(BitConverter.ToString(corectResult));
            // Console.WriteLine(BitConverter.ToString(instructionPacket.ToByte()));
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanFindCorectComPort()
        {
            var communicationObject = new CommunicationObject();
            communicationObject.Open();
            Assert.IsTrue(communicationObject.IsOpen);
            communicationObject.Dispose();
        }


        [Test, Ignore("Ned to be connected to robot")]
        public void CanMoveServo5()
        {
            ISender sender = new CommunicationObject();
            var movment1 = new MovmentComandAX12(5, 0x0ff, 0x150);
            var movment2 = new MovmentComandAX12(3, 0x0ff, 0x150);

            var instructionPacket = new InstructionPacketSyncMovment(sender, movment1, movment2);
            instructionPacket.Send();

            ((CommunicationObject) sender).Dispose();

            // Console.WriteLine(BitConverter.ToString(corectResult));
            // Console.WriteLine(BitConverter.ToString(instructionPacket.ToByte()));
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void CanSendInstructionPacketPingToServoID1()
        {
            ISender sender = new CommunicationObject();
            var ping = new InstructionPacketPing(SERVO_ID, sender);

            ping.Send();
            Assert.IsTrue(ping.IsSent);
            ((CommunicationObject) sender).Dispose();
        }

        [Test, Ignore("Ned to be connected to robot")]
        public void MakeQuiet()
        {
            var ids = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18};
            ISender sender = new CommunicationObject();
            var punch = new InstructionPacketSyncPunch(sender, ids);
            punch.Send();

            var margin = new InstructionPacketSyncCOMPLIANCE_MARGIN(sender, ids);
            margin.Send();

            ((CommunicationObject) sender).Dispose();
        }
    }
}
using System;
using System.Threading;
using NUnit.Framework;
using Robot.InstructionPackets;

namespace Robot.Tests
{
    [TestFixture]
    public class UpdateAX12ID
    {
        [Test]
        [Ignore("Warning!! chance the ID of the AX12. Need to be connected to AX ID")]
        public void SetID()
        {
            CommunicationObject communicationObject = new CommunicationObject("COM3");
            byte idToUpdate = 22;
            byte newId =23;
           // var instructionPacket = new InstructionPacketSetID(idToUpdate, newId, communicationObject);
           // instructionPacket.Send();
            CanMoveServo(newId, communicationObject);
        }



        public void CanMoveServo(byte id, CommunicationObject sender)
        {
            var movment1 = new MovmentComandAX12(id, 0x0ff, 0x150);
            var movment2 = new MovmentComandAX12(id, 0x1ff, 0x150);
            var instructionPacket = new InstructionPacketSyncMovment(sender, movment1);
            instructionPacket.Send();
            
            Thread.Sleep(2000);
            instructionPacket = new InstructionPacketSyncMovment(sender, movment2);
            instructionPacket.Send();
         
            sender.Dispose();

        }

        [Test]
        [Ignore("Warning!! chance the ID of the AX12. Need to be connected to AX ID")]
        public void testss()
        {
             CommunicationObject communicationObject = new CommunicationObject("COM3");
            CanMoveServo(21,communicationObject);
        }
    }

    public class InstructionPacketSetID : InstructionPacketBase
    {
        public InstructionPacketSetID(byte servoId, byte newId, ISender sender)
            : base(servoId, sender)
        {
            
            _instruction = 0x03;
            _lengthOfCommand = 0x04;
            _parameters.AddRange(new[] { (byte)0x03, newId });
        }
    }
}
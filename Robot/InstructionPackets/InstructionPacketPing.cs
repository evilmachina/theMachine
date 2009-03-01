namespace Robot.InstructionPackets
{
    public class InstructionPacketPing : InstructionPacketBase
    {
        public InstructionPacketPing(byte servoId, ISender sender)
            : base(servoId, sender)
        {
            _instruction = 0x01;
            _lengthOfCommand = 0x02;
        }
    }
}
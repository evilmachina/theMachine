namespace Robot.InstructionPackets
{
    public class InstructionPacketReadTemperature : InstructionPacketBase
    {
        private const byte _lengtOfDataToBeRead = 0X01;
        private const byte _addressForInternalTemperature = 0X2B;

        public InstructionPacketReadTemperature(byte servoId, ISender sender)
            : base(servoId, sender)
        {
            _instruction = 0x02;
            _lengthOfCommand = 0x04;
            _parameters.Add(_addressForInternalTemperature);
            _parameters.Add(_lengtOfDataToBeRead);
        }
    }
}
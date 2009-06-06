namespace Robot.InstructionPackets
{
    public class InstructionPacketReadServoSensorData : InstructionPacketBase
    {
        private const byte LENGT_OF_DATA_TO_BE_READ = 0X08;
        private const byte START_ADDRESS_TO_READ = 0x24;

        public InstructionPacketReadServoSensorData(byte servoId, ISender sender) : base(servoId,sender)
        {
            _instruction = 0x02;
            _lengthOfCommand = 0x04;
            _parameters.Add(START_ADDRESS_TO_READ);
            _parameters.Add(LENGT_OF_DATA_TO_BE_READ);
        }
    }
}
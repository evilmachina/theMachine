namespace Robot.InstructionPackets
{
    public class InstructionPacketSyncMovment : InstructionPacketBase
    {
        public InstructionPacketSyncMovment(ISender sender, params MovmentComandAX12[] movmentComandAX12s)
            : base(0xFE, sender)
        {
            _instruction = 0X83;
            _lengthOfCommand = (byte) ((4 + 1)*movmentComandAX12s.Length + 4);

            _parameters.Add(0X1E); //Starting address of the location where the data is to be written
            _parameters.Add(0X04); //lengd
            foreach (MovmentComandAX12 movment in movmentComandAX12s)
            {
                _parameters.AddRange(movment.ToByte());
            }
        }
    }
}
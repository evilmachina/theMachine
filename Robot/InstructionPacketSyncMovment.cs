namespace Robot
{
    public class InstructionPacketSyncMovment : InstructionPacketBase
    {
        public InstructionPacketSyncMovment(ISender sender, params Movment[] movments)
            : base(0xFE, sender)
        {
            _instruction = 0X83;
            _lengthOfCommand = (byte) ((4 + 1)*movments.Length + 4);

            _parameters.Add(0X1E); //Starting address of the location where the data is to be written
            _parameters.Add(0X04); //lengd
            foreach (Movment movment in movments)
            {
                _parameters.AddRange(movment.ToByte());
            }
        }
    }
}
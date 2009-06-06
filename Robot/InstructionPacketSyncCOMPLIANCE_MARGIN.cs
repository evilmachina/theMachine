namespace Robot
{
    public class InstructionPacketSyncCOMPLIANCE_MARGIN : InstructionPacketBase
    {
        public InstructionPacketSyncCOMPLIANCE_MARGIN(ISender sender, params byte[] ids)
            : base(0xFE, sender)
        {
            _instruction = 0X83;
            _lengthOfCommand = (byte) ((2 + 1)*ids.Length + 4);

            _parameters.Add(0X1A);
            _parameters.Add(0X02);
            foreach (byte id in ids)
            {
                _parameters.Add(id);
                _parameters.Add(2);
                _parameters.Add(2);
            }
        }
    }
}
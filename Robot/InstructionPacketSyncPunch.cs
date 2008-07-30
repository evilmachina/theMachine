using System;

namespace Robot
{
    public class InstructionPacketSyncPunch : InstructionPacketBase
    {
        public InstructionPacketSyncPunch(ISender sender, params byte[] ids)
            : base(0xFE, sender)
        {
            _instruction = 0X83;
            _lengthOfCommand = (byte) ((2 + 1)*ids.Length + 4);

            _parameters.Add(0X30);
            _parameters.Add(0X02);
            foreach (byte id in ids)
            {
                _parameters.Add(id);
                _parameters.AddRange(BitConverter.GetBytes((short) 150));
            }
        }
    }
}
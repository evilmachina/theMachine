// Copyright (c) 2009 Marcus Olsson
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
// 
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
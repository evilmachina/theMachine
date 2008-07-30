using System;
using Robot;

namespace TestProj
{
    public class FakeSender : ISender
    {
        #region ISender Members

        public void Send(byte[] bytes)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
using System;

namespace CLSoft.MyWallet.Business.Time
{
    public class SystemTimeProvider : TimeProvider
    {
        public override DateTime Now => DateTime.Now;
    }
}
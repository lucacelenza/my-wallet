using System;

namespace CLSoft.MyWallet.Business.Time
{
    public abstract class TimeProvider
    {
        private static TimeProvider _current;

        public static TimeProvider Current
        {
            get => _current ?? (_current = new SystemTimeProvider());
            set => _current = value;
        }

        public abstract DateTime Now { get; }

        public static void ResetToDefault()
        {
            _current = new SystemTimeProvider();
        }
    }
}
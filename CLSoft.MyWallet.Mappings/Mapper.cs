namespace CLSoft.MyWallet.Mappings
{
    public abstract class Mapper
    {
        public abstract TDest Map<TDest>(object source);

        private static Mapper _mapper;
        public static Mapper Current
        {
            get
            {
                if (_mapper == null)
                    _mapper = new NullMapper();

                return _mapper;
            }
            set
            {
                _mapper = value;
            }
        }
    }
}
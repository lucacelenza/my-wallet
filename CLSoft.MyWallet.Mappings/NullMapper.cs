namespace CLSoft.MyWallet.Mappings
{
    public class NullMapper : Mapper
    {
        public override TDest Map<TDest>(object source)
        {
            return default(TDest);
        }
    }
}
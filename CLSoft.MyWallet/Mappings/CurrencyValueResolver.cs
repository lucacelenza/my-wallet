using AutoMapper;
using CLSoft.MyWallet.Models;
using System.Globalization;

namespace CLSoft.MyWallet.Mappings
{
    public class CurrencyValueResolver : IMemberValueResolver<object, object, CurrencyViewModel, decimal>
    {
        public decimal Resolve(object source, object destination, CurrencyViewModel sourceMember, decimal destMember, ResolutionContext context)
        {
            return decimal.Parse(
                sourceMember.Value.Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture);
        }
    }
}
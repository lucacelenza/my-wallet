using AutoMapper;
using CLSoft.MyWallet.Models;
using System.Globalization;

namespace CLSoft.MyWallet.Mappings
{
    public class CurrencyTypeConverter : ITypeConverter<CurrencyViewModel, decimal>
    {
        public decimal Convert(CurrencyViewModel source, decimal destination, ResolutionContext context)
        {
            return decimal.Parse(
                source.Value.Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture);
        }
    }
}
using AutoMapper;
using CLSoft.MyWallet.Models.Home;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Mappings.Home
{
    public class TimeBalanceProviderProfile : Profile
    {
        public TimeBalanceProviderProfile()
        {
            CreateMap<IDictionary<string, decimal>, TimeBalanceViewModel>()
                .ConvertUsing((src) =>
                {
                    return new TimeBalanceViewModel
                    {
                        Labels = src.Keys,
                        Data = src.Values,
                        Culture = "it-IT",
                        CurrencyCode = "EUR"
                    };
                });
        }
    }
}
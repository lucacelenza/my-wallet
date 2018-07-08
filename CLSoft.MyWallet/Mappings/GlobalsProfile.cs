using AutoMapper;
using System;
using System.Globalization;

namespace CLSoft.MyWallet.Mappings
{
    public class GlobalsProfile : Profile
    {
        public GlobalsProfile()
        {
            var cultureInfo = new CultureInfo("it-IT");

            CreateMap<decimal, string>().ConvertUsing(f => f.ToString("c", cultureInfo));
            CreateMap<DateTime, string>().ConvertUsing(f => f.ToString("d", cultureInfo));
        }
    }
}

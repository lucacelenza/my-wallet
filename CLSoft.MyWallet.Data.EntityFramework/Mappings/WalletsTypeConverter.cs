using AutoMapper;
using CLSoft.MyWallet.Data.Models.Wallets;
using System;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class WalletsTypeConverter : ITypeConverter<IEnumerable<Entities.Wallet>, Wallets>
    {
        private readonly IMapper _mapper;

        public WalletsTypeConverter(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Wallets Convert(IEnumerable<Entities.Wallet> source, Wallets destination, ResolutionContext context)
        {
            return new Wallets(_mapper.Map<IEnumerable<Wallets.Wallet>>(source));
        }
    }
}
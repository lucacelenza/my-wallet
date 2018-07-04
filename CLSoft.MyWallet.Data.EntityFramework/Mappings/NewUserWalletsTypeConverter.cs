using AutoMapper;
using CLSoft.MyWallet.Data.EntityFramework.Entities;
using CLSoft.MyWallet.Data.Models.Auth;
using System;
using System.Collections.Generic;

namespace CLSoft.MyWallet.Data.EntityFramework.Mappings
{
    public class NewUserWalletsTypeConverter : ITypeConverter<AddUserRequest.Wallet, ICollection<Wallet>>
    {
        private readonly IMapper _mapper;

        public NewUserWalletsTypeConverter(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public ICollection<Wallet> Convert(AddUserRequest.Wallet source, ICollection<Wallet> destination, ResolutionContext context)
        {
            return new[] { _mapper.Map<Wallet>(source) };
        }
    }
}
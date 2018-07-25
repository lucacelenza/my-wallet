using AutoMapper;
using CLSoft.MyWallet.Data.Models.Wallets;
using CLSoft.MyWallet.Models.Wallets;
using System;

namespace CLSoft.MyWallet.Mappings.Wallets
{
    public class AddWalletBaseTransactionResolver : IValueResolver<WalletViewModel, AddWalletRequest, AddWalletRequest.Transaction>
    {
        private readonly IMapper _mapper;

        public AddWalletBaseTransactionResolver(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public AddWalletRequest.Transaction Resolve(WalletViewModel source, AddWalletRequest destination, AddWalletRequest.Transaction destMember, ResolutionContext context)
        {
            return new AddWalletRequest.Transaction
            {
                Amount = _mapper.Map<decimal>(source.Amount.Value),
                Description = $"Registered deposit for {source.Name} wallet."
            };
        }
    }
}
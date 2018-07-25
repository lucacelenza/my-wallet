using AutoMapper;
using CLSoft.MyWallet.Models;
using CLSoft.MyWallet.Models.Wallets;
using CLSoft.MyWallet.Data.Models.Wallets;
using System;
using CLSoft.MyWallet.Data.Repositories;

namespace CLSoft.MyWallet.Mappings.Wallets
{
    public class WalletBaseAmountResolver : IValueResolver<Wallet, WalletViewModel, CurrencyViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionsRepository _repository;

        public WalletBaseAmountResolver(IMapper mapper, ITransactionsRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public CurrencyViewModel Resolve(Wallet source, WalletViewModel destination, CurrencyViewModel destMember, ResolutionContext context)
        {
            var baseTransaction = _repository.GetBaseTransactionByWalletId(source.Id);
            return new CurrencyViewModel() { Value = _mapper.Map<string>(baseTransaction.Amount) };
        }
    }
}
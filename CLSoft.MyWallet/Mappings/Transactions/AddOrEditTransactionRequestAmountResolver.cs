using System;
using AutoMapper;
using CLSoft.MyWallet.Models.Transactions;

namespace CLSoft.MyWallet.Mappings.Transactions
{
    public class AddOrEditTransactionRequestAmountResolver : IValueResolver<TransactionViewModel, object, decimal>
    {
        private readonly IMapper _mapper;

        public AddOrEditTransactionRequestAmountResolver(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public decimal Resolve(TransactionViewModel source, object destination, decimal destMember,
            ResolutionContext context)
        {
            var amount = _mapper.Map<decimal>(source.Amount);
            if (source.Type == TransactionType.Debit) amount *= -1;
            return amount;
        }
    }
}
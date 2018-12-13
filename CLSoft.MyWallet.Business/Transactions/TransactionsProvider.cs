using AutoMapper;
using CLSoft.MyWallet.Business.Transactions.Models;
using CLSoft.MyWallet.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Business.Transactions
{
    public class TransactionsProvider : ITransactionsProvider
    {
        private readonly ITransactionsRepository _repository;
        private readonly IMapper _mapper;

        public TransactionsProvider(ITransactionsRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(long? walletId = null)
        {
            var transactions = await _repository.GetTransactionsAsync(
                new Data.Models.Transactions.GetTransactionsRequest()
                {
                    Page = 1,
                    RecordsPerPage = 10,
                    WalletId = walletId
                });

            return _mapper.Map<IEnumerable<Transaction>>(transactions);
        }
    }
}
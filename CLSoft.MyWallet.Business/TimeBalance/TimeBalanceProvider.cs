using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Business.TimeBalance.Models;
using CLSoft.MyWallet.Data.Repositories;

namespace CLSoft.MyWallet.Business.TimeBalance
{
    public class TimeBalanceProvider : ITimeBalanceProvider
    {
        private readonly ITransactionsRepository _repository;
        private readonly IMapper _mapper;

        public TimeBalanceProvider(ITransactionsRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IDictionary<string, decimal>> GetTimeBalanceAsync(GetTimeBalanceRequest request)
        {
            var startFromBalance = await _repository
                .GetBalanceUntilAsync(request.WalletId, request.SearchRange.From);

            var transactions = await _repository.GetTransactionsAsync(
                new Data.Models.Transactions.GetTransactionsRequest
                {
                    WalletId = request.WalletId,
                    DatesRange = new Data.Models.DatesRange(request.SearchRange.From, request.SearchRange.To)
                });

            return request.SearchRange.GetTimeBalance(startFromBalance, transactions);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Business.TimeBalance;
using CLSoft.MyWallet.Business.TimeBalance.Models;
using CLSoft.MyWallet.Business.Transactions;
using CLSoft.MyWallet.Business.Wallets;
using CLSoft.MyWallet.Models.Home;

namespace CLSoft.MyWallet.Application.Home
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly IWalletsProvider _walletsProvider;
        private readonly ITransactionsProvider _transactionsProvider;
        private readonly ITimeBalanceProvider _timeBalanceProvider;
        private readonly IMapper _mapper;

        public HomeControllerService(IWalletsProvider walletsProvider,
            ITransactionsProvider transactionsProvider, ITimeBalanceProvider timeBalanceProvider, IMapper mapper)
        {
            _walletsProvider = walletsProvider ?? throw new ArgumentNullException(nameof(walletsProvider));
            _transactionsProvider = transactionsProvider ?? throw new ArgumentNullException(nameof(transactionsProvider));
            _timeBalanceProvider = timeBalanceProvider ?? throw new ArgumentNullException(nameof(timeBalanceProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DashboardViewModel> GetDashboardViewModelAsync(long? selectedWalletId = null)
        {
            var wallets = await _walletsProvider.GetAllWalletsAsync(selectedWalletId);
            var transactions = await _transactionsProvider.GetTransactionsAsync(selectedWalletId);

            var timeBalance = await _timeBalanceProvider.GetTimeBalanceAsync(new GetTimeBalanceRequest
            {
                WalletId = selectedWalletId,
                SearchRange = new LastMonthTimeBalanceSearchRange()
            });

            return new DashboardViewModel()
            {
                CurrentBalance = _mapper.Map<CurrentBalanceViewModel>(wallets),
                Transactions = _mapper.Map<IEnumerable<TransactionViewModel>>(transactions),
                Wallets = _mapper.Map<IEnumerable<WalletViewModel>>(wallets),
                TimeBalance = _mapper.Map<TimeBalanceViewModel>(timeBalance)
            };
        }
    }
}
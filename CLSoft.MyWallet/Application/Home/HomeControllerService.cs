using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Business.TimeBalance;
using CLSoft.MyWallet.Business.TimeBalance.Models;
using CLSoft.MyWallet.Business.Transactions;
using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Business.Wallets;
using CLSoft.MyWallet.Business.Wallets.Models;
using CLSoft.MyWallet.Models.Home;

namespace CLSoft.MyWallet.Application.Home
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly IWalletsProvider _walletsProvider;
        private readonly ITransactionsProvider _transactionsProvider;
        private readonly ITimeBalanceProvider _timeBalanceProvider;
        private readonly IUserNameProvider _userNameProvider;
        private readonly IMapper _mapper;

        public HomeControllerService(IWalletsProvider walletsProvider,
            ITransactionsProvider transactionsProvider, ITimeBalanceProvider timeBalanceProvider, IMapper mapper, IUserNameProvider userNameProvider)
        {
            _walletsProvider = walletsProvider ?? throw new ArgumentNullException(nameof(walletsProvider));
            _transactionsProvider = transactionsProvider ?? throw new ArgumentNullException(nameof(transactionsProvider));
            _timeBalanceProvider = timeBalanceProvider ?? throw new ArgumentNullException(nameof(timeBalanceProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userNameProvider = userNameProvider ?? throw new ArgumentNullException(nameof(userNameProvider));
        }

        public async Task<DashboardViewModel> GetDashboardViewModelAsync()
        {
            var userName = await _userNameProvider.GetUserNameAsync();
            var wallets = await _walletsProvider.GetAllWalletsAsync();
            var transactions = await _transactionsProvider.GetTransactionsAsync();

            var timeBalance = await _timeBalanceProvider.GetTimeBalanceAsync(new GetTimeBalanceRequest(new LastMonthTimeBalanceSearchRange()));

            var walletViewModels = _mapper.Map<IEnumerable<WalletViewModel>>(wallets).ToList();
            walletViewModels.Add(WalletViewModel.CreateNewWalletViewModel());

            return new DashboardViewModel()
            {
                UserName = userName,
                CurrentBalance = _mapper.Map<CurrentBalanceViewModel>(wallets),
                Transactions = _mapper.Map<IEnumerable<TransactionViewModel>>(transactions),
                Wallets = walletViewModels.ToImmutableArray(),
                TimeBalance = _mapper.Map<TimeBalanceViewModel>(timeBalance)
            };
        }
    }
}
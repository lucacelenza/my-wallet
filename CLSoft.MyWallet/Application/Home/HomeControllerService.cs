using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Application.Wallets;
using CLSoft.MyWallet.Business.Transactions;
using CLSoft.MyWallet.Business.Wallets;
using CLSoft.MyWallet.Models.Home;

namespace CLSoft.MyWallet.Application.Home
{
    public class HomeControllerService : IHomeControllerService
    {
        private readonly IWalletsProvider _walletsProvider;
        private readonly ITransactionsProvider _transactionsProvider;
        private readonly IMapper _mapper;

        public HomeControllerService(IWalletsProvider walletsProvider,
            ITransactionsProvider transactionsProvider, IMapper mapper)
        {
            _walletsProvider = walletsProvider ?? throw new ArgumentNullException(nameof(walletsProvider));
            _transactionsProvider = transactionsProvider ?? throw new ArgumentNullException(nameof(transactionsProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DashboardViewModel> GetDashboardViewModelAsync()
        {
            var wallets = await _walletsProvider.GetAllWalletsAsync();
            var transactions = await _transactionsProvider.GetTransactionsAsync();

            return new DashboardViewModel()
            {
                Wallets = _mapper.Map<IEnumerable<WalletViewModel>>(wallets),
                CurrentBalance = _mapper.Map<CurrentBalanceViewModel>(wallets),
                Transactions = _mapper.Map<IEnumerable<TransactionViewModel>>(transactions)
            };
        }
    }
}
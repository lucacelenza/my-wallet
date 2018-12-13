using System;
using System.Threading.Tasks;
using AutoMapper;
using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Data.Models.Transactions;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Models.Transactions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLSoft.MyWallet.Application.Transactions
{
    public class TransactionControllerService : ITransactionsControllerService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IWalletsRepository _walletsRepository;
        private readonly IUserIdProvider _userIdProvider;
        private readonly IMapper _mapper;

        public TransactionControllerService(
            ITransactionsRepository transactionsRepository, 
            IWalletsRepository walletsRepository, IUserIdProvider userIdProvider,
            IMapper mapper)
        {
            _transactionsRepository = transactionsRepository ?? throw new ArgumentNullException(nameof(transactionsRepository));
            _walletsRepository = walletsRepository ?? throw new ArgumentNullException(nameof(walletsRepository));
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task AddTransactionAsync(TransactionViewModel viewModel)
        {
            var repositoryModel = _mapper.Map<AddTransactionRequest>(viewModel);
            await _transactionsRepository.AddTransactionAsync(repositoryModel);
        }

        public async Task DeleteTransactionAsync(long transactionId)
        {
            await _transactionsRepository.DeleteTransactionByIdAsync(transactionId);
        }

        public async Task EditTransactionAsync(long transactionId, TransactionViewModel viewModel)
        {
            var request = _mapper.Map<EditTransactionRequest>(viewModel);
            request.TransactionId = transactionId;
            await _transactionsRepository.EditTransactionAsync(request);
        }

        public async Task<TransactionViewModel> GetTransactionAsync(long? transactionId = null)
        {
            var userId = _userIdProvider.GetUserId();
            var wallets = await _walletsRepository.GetAllWalletsByUserIdAsync(userId);

            var viewModel = new TransactionViewModel();

            if (transactionId.HasValue)
            {
                var transaction = await _transactionsRepository
                    .GetTransactionByIdAsync(transactionId.Value);

                viewModel = _mapper.Map<TransactionViewModel>(transaction);
                viewModel.Wallets = new SelectList(wallets, "Id", "Name", viewModel.SelectedWalletId);
            }
            else
                viewModel.Wallets = new SelectList(wallets, "Id", "Name");

            return viewModel;
        }

        public async Task<ITransactionsViewModel> GetTransactionsAsync(
            Models.Transactions.GetTransactionsRequest request = null)
        {
            if (request == null)
                request = new Models.Transactions.GetTransactionsRequest();

            var transactions = await _transactionsRepository.GetTransactionsAsync(
                _mapper.Map<Data.Models.Transactions.GetTransactionsRequest>(request));

            return _mapper.Map<TransactionsViewModel>(transactions);
        }
    }
}
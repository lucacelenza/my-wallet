using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLSoft.MyWallet.Business.User;
using CLSoft.MyWallet.Data.Models.Transactions;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Mappings;
using CLSoft.MyWallet.Models.Transactions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CLSoft.MyWallet.Application.Transactions
{
    public class TransactionControllerService : ITransactionsControllerService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IWalletsRepository _walletsRepository;
        private readonly IAsyncUserIdProvider _userIdProvider;

        public TransactionControllerService(
            ITransactionsRepository transactionsRepository, 
            IWalletsRepository walletsRepository, IAsyncUserIdProvider userIdProvider)
        {
            _transactionsRepository = transactionsRepository ?? throw new ArgumentNullException(nameof(transactionsRepository));
            _walletsRepository = walletsRepository ?? throw new ArgumentNullException(nameof(walletsRepository));
            _userIdProvider = userIdProvider ?? throw new ArgumentNullException(nameof(userIdProvider));
        }

        public async Task AddTransactionAsync(TransactionViewModel viewModel)
        {
            var repositoryModel = Mapper.Current.Map<AddTransactionRequest>(viewModel);
            await _transactionsRepository.AddTransactionAsync(repositoryModel);
        }

        public async Task DeleteTransactionAsync(long transactionId)
        {
            await _transactionsRepository.DeleteTransactionByIdAsync(transactionId);
        }

        public async Task EditTransactionAsync(long transactionId, TransactionViewModel viewModel)
        {
            var request = Mapper.Current.Map<EditTransactionRequest>(viewModel);
            request.TransactionId = transactionId;
            await _transactionsRepository.EditTransactionAsync(request);
        }

        public async Task<TransactionViewModel> GetTransactionAsync(long? transactionId = null)
        {
            var userId = await _userIdProvider.GetUserIdAsync();
            var wallets = await _walletsRepository.GetAllWalletsByUserIdAsync(userId);

            var viewModel = new TransactionViewModel();

            if (transactionId.HasValue)
            {
                var transaction = await _transactionsRepository
                    .GetTransactionByIdAsync(transactionId.Value);

                viewModel = Mapper.Current.Map<TransactionViewModel>(transaction);
                viewModel.Wallets = new SelectList(wallets, "Id", "Name", viewModel.SelectedWalletId);
            }
            else
                viewModel.Wallets = new SelectList(wallets, "Id", "Name");

            return viewModel;
        }
    }
}
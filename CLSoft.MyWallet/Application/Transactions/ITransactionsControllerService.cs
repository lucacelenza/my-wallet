using CLSoft.MyWallet.Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Application.Transactions
{
    public interface ITransactionsControllerService
    {
        Task<TransactionViewModel> GetTransactionAsync(long? transactionId = null);
        Task AddTransactionAsync(TransactionViewModel viewModel);
        Task EditTransactionAsync(long transactionId, TransactionViewModel viewModel);
        Task DeleteTransactionAsync(long transactionId);
    }
}
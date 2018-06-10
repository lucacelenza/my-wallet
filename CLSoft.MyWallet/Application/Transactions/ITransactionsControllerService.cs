using CLSoft.MyWallet.Models.Transactions;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Application.Transactions
{
    public interface ITransactionsControllerService
    {
        Task<ITransactionsViewModel> GetTransactionsAsync(GetTransactionsRequest request = null);
        Task<TransactionViewModel> GetTransactionAsync(long? transactionId = null);
        Task AddTransactionAsync(TransactionViewModel viewModel);
        Task EditTransactionAsync(long transactionId, TransactionViewModel viewModel);
        Task DeleteTransactionAsync(long transactionId);
    }
}
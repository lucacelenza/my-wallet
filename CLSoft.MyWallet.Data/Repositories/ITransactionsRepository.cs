using CLSoft.MyWallet.Data.Models.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.Repositories
{
    public interface ITransactionsRepository
    {
        Task<IEnumerable<Transaction>> GetTransactionsAsync(GetTransactionsRequest request);
        Task<Transaction> GetTransactionByIdAsync(long transactionId);
        Task AddTransactionAsync(AddTransactionRequest request);
        Task EditTransactionAsync(EditTransactionRequest request);
        Task DeleteTransactionByIdAsync(long transactionId);
    }
}
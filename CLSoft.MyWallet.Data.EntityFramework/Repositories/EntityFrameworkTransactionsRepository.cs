using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using CLSoft.MyWallet.Data.Exceptions;
using CLSoft.MyWallet.Data.Models.Transactions;
using CLSoft.MyWallet.Data.Repositories;
using CLSoft.MyWallet.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLSoft.MyWallet.Data.EntityFramework.Repositories
{
    public class EntityFrameworkTransactionsRepository : EntityFrameworkRepository, ITransactionsRepository
    {
        public EntityFrameworkTransactionsRepository(MyWalletDbContext dbContext) : base(dbContext)
        {
        }

        public async Task AddTransactionAsync(AddTransactionRequest request)
        {
            var entity = Mapper.Current.Map<Entities.Transaction>(request);
            DbContext.Transactions.Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteTransactionByIdAsync(long transactionId)
        {
            var entity = await GetTransactionEntityByIdAsync(transactionId);
            DbContext.Transactions.Remove(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task EditTransactionAsync(EditTransactionRequest request)
        {
            var entity = await GetTransactionEntityByIdAsync(request.TransactionId);

            entity.Description = request.Description;
            entity.Amount = request.Amount;
            entity.WalletId = request.WalletId;
            entity.UpdatedOn = request.UpdatedOn;

            await DbContext.SaveChangesAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(long transactionId)
        {
            var entity = await GetTransactionEntityByIdAsync(transactionId);
            return Mapper.Current.Map<Transaction>(entity);
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(GetTransactionsRequest request)
        {
            var query = DbContext.Transactions.AsQueryable();

            if (request.WalletId.HasValue)
                query = query.Where(w => w.WalletId.Equals(request.WalletId.Value));

            query = query
                .Skip(request.Page * request.RecordsPerPage)
                .Take(request.RecordsPerPage);

            var entities = await query.ToArrayAsync();
            return entities.Select(e => Mapper.Current.Map<Transaction>(e));
        }

        private async Task<Entities.Transaction> GetTransactionEntityByIdAsync(long transactionId)
        {
            var entity = await DbContext.Transactions
                .FirstOrDefaultAsync(t => t.Id.Equals(transactionId));

            if (entity == null)
                throw new DataNotFoundException();

            return entity;
        }
    }
}
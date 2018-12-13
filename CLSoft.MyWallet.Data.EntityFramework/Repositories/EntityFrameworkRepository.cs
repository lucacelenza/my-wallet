using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using System;

namespace CLSoft.MyWallet.Data.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository
    {
        protected MyWalletDbContext DbContext { get; }

        protected EntityFrameworkRepository(MyWalletDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
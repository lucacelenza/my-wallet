using CLSoft.MyWallet.Data.EntityFramework.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CLSoft.MyWallet.Data.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository
    {
        public MyWalletDbContext DbContext { get; }

        public EntityFrameworkRepository(MyWalletDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
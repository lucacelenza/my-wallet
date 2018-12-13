using CLSoft.MyWallet.Data.EntityFramework.Configuration.Entities;
using CLSoft.MyWallet.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace CLSoft.MyWallet.Data.EntityFramework.Configuration
{
    public class MyWalletDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ForgotPasswordToken> ForgotPasswordTokens { get; set; }

        public MyWalletDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new WalletConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new ForgotPasswordTokenConfiguration());
        }
    }
}

using CLSoft.MyWallet.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLSoft.MyWallet.Data.EntityFramework.Configuration.Entities
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transactions");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.WalletId)
                .HasColumnName("wallet_id")
                .IsRequired();

            builder.Property(e => e.RegisteredOn)
                .HasColumnName("registeredon")
                .IsRequired();

            builder.Property(e => e.LastUpdatedOn)
                .HasColumnName("lastupdatedon");

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(e => e.Amount)
                .HasColumnName("amount")
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
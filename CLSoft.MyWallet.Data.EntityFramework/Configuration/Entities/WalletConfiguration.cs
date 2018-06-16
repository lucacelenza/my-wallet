using CLSoft.MyWallet.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLSoft.MyWallet.Data.EntityFramework.Configuration.Entities
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasMaxLength(255);

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.RegisteredOn)
                .HasColumnName("registeredon")
                .IsRequired();

            builder.Property(e => e.LastUpdatedOn)
                .HasColumnName("lastupdatedon");

            builder.HasMany(e => e.Transactions)
                .WithOne(e => e.Wallet)
                .HasForeignKey(e => e.WalletId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
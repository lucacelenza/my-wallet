using CLSoft.MyWallet.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLSoft.MyWallet.Data.EntityFramework.Configuration.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.EmailAddress)
                .HasColumnName("email")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.HashedPassword)
                .HasColumnName("password")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.FirstName)
                .HasColumnName("firstname")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasColumnName("lastname")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.RegisteredOn)
                .HasColumnName("registeredon")
                .IsRequired();

            builder.Property(e => e.PasswordChangedOn)
                .HasColumnName("passwordchangedon");

            builder.HasMany(e => e.Wallets)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.ForgotPasswordTokens)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
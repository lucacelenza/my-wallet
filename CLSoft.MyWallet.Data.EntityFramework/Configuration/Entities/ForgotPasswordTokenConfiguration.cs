using CLSoft.MyWallet.Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CLSoft.MyWallet.Data.EntityFramework.Configuration.Entities
{
    public class ForgotPasswordTokenConfiguration : IEntityTypeConfiguration<ForgotPasswordToken>
    {
        public void Configure(EntityTypeBuilder<ForgotPasswordToken> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Token)
                .HasColumnName("token")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(e => e.RegisteredOn)
                .HasColumnName("registeredon")
                .IsRequired();

            builder.Property(e => e.ExpiresOn)
                .HasColumnName("expireson")
                .IsRequired();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkunkWorksBank.Domain.UserContext.Entities;

namespace SkunkWorksBank.Repository.SharedContext.Data.Mappings
{
    public class UserStatusMap : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> builder)
        {
            #region Table e PK
            builder
                .ToTable("user_status");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_User_Status");
            #endregion

            #region Columns
            builder.Property(x => x.Id)
               .HasColumnName("id")
               .ValueGeneratedNever();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            #endregion
        }
    }
}

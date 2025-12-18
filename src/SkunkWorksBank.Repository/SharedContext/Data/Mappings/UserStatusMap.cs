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

            #region Seeds
            builder.HasData(
              new { Id = 1, Name = "Pending" },
              new { Id = 2, Name = "Active" },
              new { Id = 3, Name = "Blocked" },
              new { Id = 4, Name = "Disabled" }
            );
            #endregion
        }
    }
}

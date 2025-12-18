using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkunkWorksBank.Domain.Users.Entities;

namespace SkunkWorksBank.Repository.SharedContext.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Table e PK
            builder
                .ToTable("User");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_User");
            #endregion

            #region Columns
            builder.HasOne(x => x)
            #endregion
        }
    }
}

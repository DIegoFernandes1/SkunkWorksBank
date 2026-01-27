using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkunkWorksBank.Domain.UserContext.Entities;

namespace SkunkWorksBank.Repository.SharedContext.Data.Mappings
{
    public class ContactTypeMap : IEntityTypeConfiguration<ContactType>
    {
        public void Configure(EntityTypeBuilder<ContactType> builder)
        {
            #region Table e PK
            builder
                .ToTable("contact_types")
                .HasKey(x => x.Id)
                .HasName("PK_Contact_Type");
            #endregion

            #region Columns
            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(50)
                   .IsRequired();
            #endregion
        }
    }
}

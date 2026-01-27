using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkunkWorksBank.Domain.UserContext.Entities;

namespace SkunkWorksBank.Repository.SharedContext.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            #region Table e PK
            builder
                .ToTable("contacts");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_Contacts");
            #endregion

            #region Columns
            builder.Property<Guid>("UserId")
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Contacts)
                   .HasForeignKey("UserId")
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.Property<int>("ContactTypeId")
                   .HasColumnName("contact_type_id")
                   .IsRequired();

            builder.HasOne(x => x.ContactType)
                   .WithMany()
                   .HasForeignKey("ContactTypeId")
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.OwnsOne(x => x.Value, value =>
            {
                value.Property(c => c.Value)
                   .HasColumnName("value")
                   .HasMaxLength(50)
                   .IsRequired();
            });

            builder.Property(x => x.IsPrimary)
                .HasColumnName("is_primary")
                .IsRequired();

            builder.Property(x => x.IsVerified)
                .HasColumnName("is_verified")
                .IsRequired();
            #endregion
        }
    }
}

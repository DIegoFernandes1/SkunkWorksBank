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
                .ToTable("users");

            builder
                .HasKey(x => x.Id)
                .HasName("PK_User");
            #endregion

            #region Columns
            builder.Property<int>("user_status_id");

            builder.HasOne(x => x.UserStatus)
                   .WithMany()
                   .HasForeignKey("user_status_id")
                   .IsRequired();

            builder.OwnsOne(x => x.Cpf, cpf =>
            {
                cpf.Property(p => p.Value)
                   .HasColumnName("cpf")
                   .HasMaxLength(11)
                   .IsRequired();
            });

            builder.OwnsOne(x => x.FullName, name =>
            {
                name.Property(p => p.Value)
                    .HasColumnName("full_name")
                    .HasMaxLength(150)
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Birthdate, birth =>
            {
                birth.Property(p => p.Date)
                     .HasColumnName("birthdate")
                     .IsRequired();
            });

            builder.OwnsOne(x => x.Tracker, tracker =>
            {
                tracker.Property(t => t.CreatedAt)
                       .HasColumnName("created_at")
                       .IsRequired();

                tracker.Property(t => t.UpdatedAt)
                       .HasColumnName("updated_at");
            });

            builder.Property(x => x.IsActive)
                   .HasColumnName("is_active")
                .IsRequired();

            builder.Property(x => x.IsPep)
                .HasColumnName("is_pep")
                       .IsRequired();
            #endregion
        }
    }
}

using DSS.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSS.Data.Configuration
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(br => br.Id);

            builder.Property(br => br.Id)
                .HasColumnName("Id");

            builder.Property(br => br.Name)
                .HasConversion<string>()
                .HasColumnName("Name");

            builder.Property(br => br.Description)
                .HasConversion<string>()
                .HasColumnName("Description");

            builder.Property(br => br.Status)
                .HasConversion<string>()
                .HasColumnName("Status");

            builder.Property(br => br.CratedDate)
                .HasColumnName("CratedDate");

            builder.Property(br => br.ModifyiedDate)
                .HasColumnName("ModifyiedDate");

            // Foreign key to User
            builder.HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Optional
        }
    }
}

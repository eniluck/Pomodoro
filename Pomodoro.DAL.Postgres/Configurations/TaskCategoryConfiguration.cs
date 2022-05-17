using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomodoro.Core.Models;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres.Configurations;

public class TaskCategoryConfiguration : IEntityTypeConfiguration<TaskCategoryEntity>
{
    public void Configure(EntityTypeBuilder<TaskCategoryEntity> builder)
    {
        builder.ToTable("TaskCategories");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(TaskCategory.MAX_NAME_LENGTH);
    }
}

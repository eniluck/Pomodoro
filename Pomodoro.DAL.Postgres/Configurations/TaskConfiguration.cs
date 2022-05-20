using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomodoro.Core.Models;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(b => b.Id);

        // TODO: FK TaskCategory
        builder.HasOne(b => b.Category)
            .WithMany()
            .HasForeignKey(b => b.CategoryId)
            .HasConstraintName("FK_Task_TaskCategories_CategoryId");

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(TaskModel.MAX_NAME_LENGTH);

        builder.Property(b => b.Status)
            .IsRequired();
    }
}

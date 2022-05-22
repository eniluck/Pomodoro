using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pomodoro.DAL.Postgres.Entities;

namespace Pomodoro.DAL.Postgres.Configurations;

public class TaskHistoryConfiguration : IEntityTypeConfiguration<TaskHistoryEntity>
{
    public void Configure(EntityTypeBuilder<TaskHistoryEntity> builder)
    {
        builder.ToTable("TaskHistories");

        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Task)
            .WithMany();

        builder.Property(x => x.Start)
            .HasColumnType("timestamp without time zone")
            .IsRequired();

        builder.Property(x => x.Stop)
            .HasColumnType("timestamp without time zone")
            .IsRequired();
    }
}

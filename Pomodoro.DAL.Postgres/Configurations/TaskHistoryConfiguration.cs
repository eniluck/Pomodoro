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

        builder.Property(x => x.CreateDateTime)
            .HasColumnType("timestamp with time zone")
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(x => x.StartDateTime)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        builder.Property(x => x.StopDateTime)
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        
    }
}

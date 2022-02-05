using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra.Contexts.Mappings;

public class TodoItemMapping : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("Todo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.User)
            .HasColumnName("User")
            .HasColumnType("VARCHAR")
            .HasMaxLength(120);

        builder.Property(x => x.Title)
            .HasColumnName("Title")
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        builder.Property(x => x.Done)
            .HasColumnName("Done")
            .HasColumnType("BIT");

        builder.Property(x => x.Date)
            .HasColumnName("Date")
            .HasColumnType("DATETIME");

        builder.HasIndex(x => x.User, "IX_Todo_User");

    }
}
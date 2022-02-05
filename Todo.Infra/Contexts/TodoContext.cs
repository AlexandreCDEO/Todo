using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Infra.Contexts.Mappings;


namespace Todo.Infra.Contexts;

public class TodoContext : DbContext
{
    public DbSet<TodoItem>? Todos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=Todo;User ID=sa;Password=Password.1");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TodoItemMapping());
    }
}
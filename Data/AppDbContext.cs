using Microsoft.EntityFrameworkCore;
using MinhaListaTarefas.Models;

namespace MinhaListaTarefas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Tarefa> Tarefas { get; set; }
}
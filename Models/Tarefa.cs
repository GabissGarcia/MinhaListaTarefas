namespace MinhaListaTarefas.Models;

public class Tarefa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public bool Concluida { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaListaTarefas.Data;
using MinhaListaTarefas.Models;

namespace MinhaListaTarefas.Controllers;

public class TarefasController : Controller
{
    private readonly AppDbContext _context;

    public TarefasController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var tarefas = await _context.Tarefas.ToListAsync();
        return View(tarefas);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(Tarefa tarefa)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tarefa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Concluir(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa != null)
        {
            tarefa.Concluida = !tarefa.Concluida;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Excluir(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa != null)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
using CRUD_CSHARP.Models.Motoristas;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class MotoristasController : Controller
{
    private static readonly List<Motorista> Motoristas = new()
    {
        new Motorista
        {
            Id = 1,
            Nome = "Ana Souza",
            Cpf = "123.456.789-00",
            Cnh = "CNH123456",
            TipoCnh = TipoCnh.B,
            Telefone = "(11) 99999-0001",
            DataNascimento = new DateTime(1990, 5, 12)
        },
        new Motorista
        {
            Id = 2,
            Nome = "Bruno Lima",
            Cpf = "987.654.321-00",
            Cnh = "CNH987654",
            TipoCnh = TipoCnh.AB,
            Telefone = "(21) 98888-0002",
            DataNascimento = new DateTime(1985, 9, 3)
        }
    };

    private static int _nextId = 3;

    public IActionResult Index()
    {
        var lista = Motoristas.OrderBy(m => m.Nome).ToList();
        return View(lista);
    }

    public IActionResult Details(int id)
    {
        var motorista = Motoristas.FirstOrDefault(m => m.Id == id);
        if (motorista is null)
        {
            return NotFound();
        }

        return View(motorista);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Motorista motorista)
    {
        if (!ModelState.IsValid)
        {
            return View(motorista);
        }

        motorista.Id = _nextId++;
        Motoristas.Add(motorista);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var motorista = Motoristas.FirstOrDefault(m => m.Id == id);
        if (motorista is null)
        {
            return NotFound();
        }

        return View(motorista);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Motorista motorista)
    {
        if (id != motorista.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(motorista);
        }

        var existente = Motoristas.FirstOrDefault(m => m.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        existente.Nome = motorista.Nome;
        existente.Cpf = motorista.Cpf;
        existente.Cnh = motorista.Cnh;
        existente.TipoCnh = motorista.TipoCnh;
        existente.Telefone = motorista.Telefone;
        existente.DataNascimento = motorista.DataNascimento;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var motorista = Motoristas.FirstOrDefault(m => m.Id == id);
        if (motorista is null)
        {
            return NotFound();
        }

        return View(motorista);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Motorista motorista)
    {
        var existente = Motoristas.FirstOrDefault(m => m.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        Motoristas.Remove(existente);
        return RedirectToAction(nameof(Index));
    }
}

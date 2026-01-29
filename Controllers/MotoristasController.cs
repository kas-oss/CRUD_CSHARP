using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class MotoristasController : Controller
{
    private MotoristaRepository _motoristaRepository;

    private static int _nextId = 3;

    public MotoristasController(MotoristaRepository motoristaRepository)
    {
        _motoristaRepository = motoristaRepository;
    }

    public IActionResult Index()
    {
        var lista = _motoristaRepository.Motoristas.OrderBy(m => m.Nome).ToList();
        return View(lista);
    }

    public IActionResult Details(int id)
    {
        var motorista = _motoristaRepository.Motoristas.FirstOrDefault(m => m.Id == id);
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
        _motoristaRepository.Motoristas.Add(motorista);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var motorista = _motoristaRepository.Motoristas.FirstOrDefault(m => m.Id == id);
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

        var existente = _motoristaRepository.Motoristas.FirstOrDefault(m => m.Id == id);
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
        var motorista = _motoristaRepository.Motoristas.FirstOrDefault(m => m.Id == id);
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
        var existente = _motoristaRepository.Motoristas.FirstOrDefault(m => m.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        _motoristaRepository.Motoristas.Remove(existente);
        return RedirectToAction(nameof(Index));
    }
}

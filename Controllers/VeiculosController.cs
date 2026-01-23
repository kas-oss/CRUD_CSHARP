using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    private static readonly List<Veiculo> Veiculos = new();
    private static int _nextId = 1;
    public IActionResult Index()
    {
        var lista = Veiculos.OrderBy(V => V.Marca).ToList();
        return View(lista);
    }

    public IActionResult Details(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);

        if (veiculo == null)
        {
            return NotFound();
        }

        return View(veiculo);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Veiculo veiculo)
    {
        if (ModelState.IsValid)
        {
            veiculo.Id = _nextId++;
            Veiculos.Add(veiculo);
            return RedirectToAction(nameof(Index));
        }
        return View(veiculo);
    }

    public IActionResult Edit(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null) return NotFound();
        return View(veiculo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Veiculo veiculo)
    {
        if (id != veiculo.Id) return NotFound();
        if (ModelState.IsValid)
    {
        var existente = Veiculos.FirstOrDefault(v => v.Id == id);
        if (existente == null) return NotFound();

        existente.Placa = veiculo.Placa;
        existente.Marca = veiculo.Marca;
        existente.Modelo = veiculo.Modelo;
        existente.Ano = veiculo.Ano;
        existente.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
        existente.Combustivel = veiculo.Combustivel;
        existente.Categoria = veiculo.Categoria;

        return RedirectToAction(nameof(Index));
    }
    return View(veiculo);
    }

    public IActionResult Delete(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo) para confirmacao de exclusao.
        throw new NotImplementedException();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
        // O que fazer:
        // - Buscar o veiculo persistido pelo id; se nao existir, retornar NotFound().
        // - Remover o item encontrado da lista estatica.
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).
        throw new NotImplementedException();
    }
}

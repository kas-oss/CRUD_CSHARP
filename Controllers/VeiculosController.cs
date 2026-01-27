
using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    private static readonly List<Veiculo> veiculos = new()
    {
        new Veiculo
        {
            Id = 1,
            Placa = "ABC1C34",
            Marca = "Fiat",
            Modelo = "Cronos",
            Ano = 2026,
            CapacidadeTanqueLitros = 48,
            Combustivel = TipoCombustivel.Gasolina,
            Categoria = CategoriaVeiculo.VeiculoLeve
        },
        new Veiculo
        {
            Id = 2,
            Placa = "KJU1C52",
            Marca = "Fiat",
            Modelo = "Mobi",
            Ano = 2026,
            CapacidadeTanqueLitros = 40,
            Combustivel = TipoCombustivel.Gasolina,
            Categoria = CategoriaVeiculo.VeiculoLeve
        }
    };

    private static int _nextId = 3;
    public IActionResult Index()
    {
        var lista = veiculos.OrderBy(veiculo => veiculo.Placa).ToList();
        return View(lista);
    }

    public IActionResult Details(int id)
    {
        var veiculo = veiculos.FirstOrDefault(m => m.Id == id);
        if (veiculo is null)
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
        if (!ModelState.IsValid)
        {
            return View(veiculo);
        }

        veiculo.Id = _nextId++;
        veiculos.Add(veiculo);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var veiculo = veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (veiculo is null)
        {
            return NotFound();
        }
        return View(veiculo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Veiculo veiculo)
    {
        if (id != veiculo.Id)
        {
            return NotFound();
        }
        if (!ModelState.IsValid)
        {
            return View(veiculo);
        }

        var existente = veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        existente.Placa = veiculo.Placa;
        existente.Marca = veiculo.Marca;
        existente.Modelo = veiculo.Modelo;
        existente.Ano = veiculo.Ano;
        existente.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
        existente.Combustivel = veiculo.Combustivel;
        existente.Categoria = veiculo.Categoria;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var veiculo = veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (veiculo is null)
        {
            return NotFound();
        }

        return View(veiculo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
        var existente = veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        veiculos.Remove(existente);
        return RedirectToAction(nameof(Index));
    }
}

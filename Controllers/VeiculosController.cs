using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    private static readonly List<Veiculo> Veiculos = new()
    {
        new Veiculo
        {
            Id = 1,
            Placa = "ABC1234",
            Marca = "Chevrolet",
            Modelo = "Onix",
            Ano = 2020,
            CapacidadeTanqueLitros = 44,
            Combustivel = TipoCombustivel.Gasolina,
            Categoria = CategoriaVeiculo.VeiculoLeve
        },
        new Veiculo
        {
            Id = 2,
            Placa = "DEF5678",
            Marca = "Toyota",
            Modelo = "Corolla",
            Ano = 2022,
            CapacidadeTanqueLitros = 50,
            Combustivel = TipoCombustivel.Gasolina,
            Categoria = CategoriaVeiculo.VeiculoLeve
        }
    };

    private static int _nextId = 3;

    private Veiculo? ObterVeiculo(int id) => Veiculos.FirstOrDefault(v => v.Id == id);

    public IActionResult Index()
    {
        var lista = Veiculos
        .OrderBy(v => v.Marca)
        .ThenBy(v => v.Modelo)
        .ThenBy(v => v.Ano)
        .ThenBy(v => v.Placa)
        .ToList();

        return View(lista);
    }

    public IActionResult Details(int id)
    {
        var veiculo = ObterVeiculo(id);
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
        Veiculos.Add(veiculo);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var veiculo = ObterVeiculo(id);
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

        var veiculoExistente = ObterVeiculo(id);
        if (veiculoExistente is null)
        {
            return NotFound();
        }

        veiculoExistente.Marca = veiculo.Marca;
        veiculoExistente.Modelo = veiculo.Modelo;
        veiculoExistente.Ano = veiculo.Ano;
        veiculoExistente.Placa = veiculo.Placa;
        veiculoExistente.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
        veiculoExistente.Combustivel = veiculo.Combustivel;
        veiculoExistente.Categoria = veiculo.Categoria;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var veiculo = ObterVeiculo(id);
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
        var veiculoExistente = ObterVeiculo(id);
        if (veiculoExistente is null)
        {
            return NotFound();
        }

        Veiculos.Remove(veiculoExistente);
        return RedirectToAction(nameof(Index));
    }
}

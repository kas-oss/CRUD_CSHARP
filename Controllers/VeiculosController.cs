using CRUD_CSHARP.Models.Veiculos;
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
            Marca = "Renault",
            Modelo = "Sandero",
            Ano = 2024,
            CapacidadeTanqueLitros = 320,
            Combustivel = TipoCombustivel.Gasolina,
            Categoria = CategoriaVeiculo.Onibus
        },
        new Veiculo
        {
            Id = 2,
            Placa = "DIG1942",
            Marca = "Toyota",
            Modelo = "Corolla XEi 2.0 (Flex)",
            Ano = 2024,
            CapacidadeTanqueLitros = 400,
            Combustivel = TipoCombustivel.Diesel,
            Categoria = CategoriaVeiculo.Motocicleta
        }
    };
    private static int _nextId = 3;

    public IActionResult Index()
    {
        var lista = Veiculos.OrderBy(v => v.Marca).ToList();
        return View(lista);
    }

    public IActionResult Details(int id)
    {
    
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
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
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
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

        var existente = Veiculos.FirstOrDefault(v => v.Id == id);
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
        
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
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
        
        var existente = Veiculos.FirstOrDefault(v => v.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        Veiculos.Remove(existente);
        return RedirectToAction(nameof(Index));
    }
}


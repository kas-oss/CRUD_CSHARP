using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    // OBJETIVO DO DESAFIO:
    // - Implementar um CRUD completo de Veiculos seguindo o mesmo padrao do MotoristasController.
    // - Usar persistencia em memoria neste controller: List<Veiculo> estatica + geracao de Id (_nextId).
    // - Criar as Views em Views/Veiculos: Index, Details, Create, Edit, Delete.
    // - Respeitar as validacoes do modelo (DataAnnotations) e tratar casos de "nao encontrado" com NotFound().

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
        var veiculo = Veiculos.FirstOrDefault(m => m.Id == id);
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

        existente.Marca = veiculo.Marca;
        existente.Modelo = veiculo.Modelo;
        existente.Ano = veiculo.Ano;
        existente.Placa = veiculo.Placa;
        existente.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
        existente.Combustivel = veiculo.Combustivel;
        existente.Categoria = veiculo.Categoria;

        return RedirectToAction(nameof(Index));
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

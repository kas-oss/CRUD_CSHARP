using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{

    //criando uma lista estatica
    private static readonly List<Veiculo> Veiculos = new List<Veiculo>();

    private static int nextId = 1;

    // get : Veiculos
    public IActionResult Index()
    {
        
        var lista = View(Veiculos.OrderBy(v => v.Marca).ToList());
        return lista;
    }

    // get : Veiculos/details
    public IActionResult Details(int id)
    {

        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null)
        {
            return NotFound();
        }

        return View(veiculo);
    }

    // get : Veiculos/Create 
    public IActionResult Create()
    {
        return View();
    }

    // POST : Veiculos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Veiculo veiculo)
    {
        if (!ModelState.IsValid)
        {
            return View(veiculo);
        }

        veiculo.Id = nextId++;
        Veiculos.Add(veiculo);
        return RedirectToAction(nameof(Index));
    }

    // get : Veiculos/Edit
    public IActionResult Edit(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null)
        {
            return NotFound();
        }

        return View(veiculo);
    }

    // POST Veiculos/Edit
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

        var veiculoexistente = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculoexistente == null)
        {
            return NotFound();
        }

        // Atualiza os dados
        veiculoexistente.Placa = veiculo.Placa;
        veiculoexistente.Marca = veiculo.Marca;
        veiculoexistente.Modelo = veiculo.Modelo;
        veiculoexistente.Ano = veiculo.Ano;
        veiculoexistente.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
        veiculoexistente.Combustivel = veiculo.Combustivel;
        veiculoexistente.Categoria = veiculo.Categoria;

        return RedirectToAction(nameof(Index));
    }

    // get Veiculos/Delete
    public IActionResult Delete(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null)
        {
            return NotFound();
        }

        return View(veiculo);
    }

    // POST Veiculos/Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
        var veiculoexistente = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculoexistente == null)
        {
            return NotFound();
        }

        Veiculos.Remove(veiculoexistente);
        return RedirectToAction(nameof(Index));
    }
}

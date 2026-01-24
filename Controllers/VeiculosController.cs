using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    // Armazena veículos em memória (dados perdidos ao reiniciar)
    private static readonly List<Veiculo> Veiculos = new();
    private static int _nextId = 1;
    
    // GET: /Veiculos/Index - Lista todos os veículos
    public IActionResult Index()
    {
        var lista = Veiculos.OrderBy(V => V.Marca).ToList();
        return View(lista);
    }

    // GET: /Veiculos/Details/5 - Exibe detalhes de um veículo
    public IActionResult Details(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null) return NotFound();
        return View(veiculo);
    }

    // GET: /Veiculos/Create - Exibe formulário de criação
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Veiculos/Create - Cria novo veículo
    [HttpPost]
    [ValidateAntiForgeryToken] // Proteção CSRF
    public IActionResult Create(Veiculo veiculo)
    {
        // ModelState.IsValid verifica DataAnnotations do Model
        if (ModelState.IsValid)
        {
            veiculo.Id = _nextId++;
            Veiculos.Add(veiculo);
            return RedirectToAction(nameof(Index));
        }
        return View(veiculo);
    }

    // GET: /Veiculos/Edit/5 - Exibe formulário de edição
    public IActionResult Edit(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null) return NotFound();
        return View(veiculo);
    }

    // POST: /Veiculos/Edit/5 - Atualiza veículo existente
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Veiculo veiculo)
    {
        if (id != veiculo.Id) return NotFound();
        
        if (ModelState.IsValid)
        {
            var existente = Veiculos.FirstOrDefault(v => v.Id == id);
            if (existente == null) return NotFound();

            // Atualiza propriedades
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

    // GET: /Veiculos/Delete/5 - Exibe confirmação de exclusão
    public IActionResult Delete(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null) return NotFound();
        return View(veiculo);
    }

    // POST: /Veiculos/Delete/5 - Executa a exclusão
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmado(int id)
    {
        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo != null)
        {
            Veiculos.Remove(veiculo);
        }
        return RedirectToAction(nameof(Index));
    }
}

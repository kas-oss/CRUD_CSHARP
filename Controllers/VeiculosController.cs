using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    //Static List como BD
    private static List<Veiculo> _veiculos = new List<Veiculo>();

    //ID generate
    private static int _nextId = 1;

    // Listagem
    public IActionResult Index()
    {
        return View(_veiculos);
    }

    // Busca pelo ID
    public IActionResult Details(int id)
    {
        var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        if (veiculo == null)
        {
            return NotFound();
        }
        return View(veiculo);
    }

    /// <summary>
    /// Criando um novo veículo - Exibe a view do Create
    /// </summary>
    public IActionResult Create()
    {
        return View();
    }  

    /// <summary>
    /// Criando um novo veículo - Recebe o formulário de criação
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Veiculo veiculo)
    {
        if(ModelState.IsValid)
        {
            veiculo.Id = _nextId++;
            _veiculos.Add(veiculo);
            return RedirectToAction(nameof(Index));
        }
        
        return View(veiculo);
    }

    /// <summary>
    /// Edição de cadastro - Exibe a View de Edit
    /// </summary>
    public IActionResult Edit(int id)
    {
        var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        if(veiculo == null)
        {
            return NotFound();
        }
        return View(veiculo);
    }

    /// <summary>
    /// Edição de cadastro - Recebe o formulário de edição
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Veiculo veiculo)
    {
        if( id != veiculo.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            var veiculoEx = _veiculos.FirstOrDefault(v => v.Id == id); 
            if(veiculoEx == null)
            {
                return NotFound();
            } 
            veiculoEx.Placa = veiculo.Placa;
            veiculoEx.Marca = veiculo.Marca;
            veiculoEx.Modelo = veiculo.Modelo;
            veiculoEx.Ano = veiculo.Ano;
            veiculoEx.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
            veiculoEx.Combustivel = veiculo.Combustivel;
            veiculoEx.Categoria = veiculo.Categoria;
            return (RedirectToAction(nameof(Index)));
        }
        
        return View(veiculo);
    }

    /// <summary>
    /// Deletando um veículo - Exibe a view Delete
    /// </summary>
    public IActionResult Delete(int id)
    {
        var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        if(veiculo == null)
        {
            return NotFound();
        }
        return View(veiculo);
    }

    /// <summary>
    /// Deletando um veículo - recebe o formulário de Delete
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
        var veiculoEx = _veiculos.FirstOrDefault(v => v.Id == id);
        if(veiculo == null)
        {
            return NotFound();
        }
        _veiculos.Remove(veiculo);
        return (RedirectToAction(nameof(Index)));
    }
}

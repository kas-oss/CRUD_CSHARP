
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
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo).

        var veiculo = veiculos.FirstOrDefault(m => m.Id == id);
        if (veiculo is null)
        {
            return NotFound();
        }

        return View(veiculo);
    }

    public IActionResult Create()
    {
        // O que fazer:
        // - Retornar a tela de cadastro (View).
        // - Na View, renderizar dropdowns para os enums do modelo:
        //   - Combustivel (TipoCombustivel)
        //   - Categoria (CategoriaVeiculo)
        // - Garantir que o usuario consiga selecionar valores validos para ambos.
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Veiculo veiculo)
    {
        // O que fazer:
        // - Validar ModelState; se invalido, retornar View(veiculo) para exibir os erros.
        // - Gerar Id unico (incrementando um _nextId) e atribuir em veiculo.Id.
        // - Persistir o veiculo (adicionar na lista estatica).
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).

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
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo) para preencher o formulario.
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
        // O que fazer:
        // - Validar se id == veiculo.Id; se nao, retornar NotFound().
        // - Validar ModelState; se invalido, retornar View(veiculo) para exibir os erros.
        // - Buscar o veiculo persistido pelo id; se nao existir, retornar NotFound().
        // - Atualizar os campos do veiculo persistido:
        //   Placa, Marca, Modelo, Ano, CapacidadeTanqueLitros, Combustivel, Categoria.
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).
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
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo) para confirmacao de exclusao.
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
        // O que fazer:
        // - Buscar o veiculo persistido pelo id; se nao existir, retornar NotFound().
        // - Remover o item encontrado da lista estatica.
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).

        var existente = veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        veiculos.Remove(existente);
        return RedirectToAction(nameof(Index));
    }
}

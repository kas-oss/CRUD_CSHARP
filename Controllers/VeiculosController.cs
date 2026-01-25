
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
        // O que fazer:
        // - Buscar/listar todos os veiculos persistidos (lista estatica).
        // - Ordenar a lista (ex.: Marca, Modelo e/ou Placa) para manter consistencia na exibicao.
        // - Retornar View(lista).
        var lista = veiculos.OrderBy(veiculo => veiculo.Modelo).ToList();
        return View(lista);
    }

    public IActionResult Details(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo).
        throw new NotImplementedException();
    }

    public IActionResult Create()
    {
        // O que fazer:
        // - Retornar a tela de cadastro (View).
        // - Na View, renderizar dropdowns para os enums do modelo:
        //   - Combustivel (TipoCombustivel)
        //   - Categoria (CategoriaVeiculo)
        // - Garantir que o usuario consiga selecionar valores validos para ambos.
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public IActionResult Edit(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo) para preencher o formulario.
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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

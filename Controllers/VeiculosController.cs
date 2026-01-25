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
            Categoria = CategoriaVeiculo.VeiculoLeve
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
    // OBJETIVO DO DESAFIO:
    // - Implementar um CRUD completo de Veiculos seguindo o mesmo padrao do MotoristasController.
    // - Usar persistencia em memoria neste controller: List<Veiculo> estatica + geracao de Id (_nextId).
    // - Criar as Views em Views/Veiculos: Index, Details, Create, Edit, Delete.
    // - Respeitar as validacoes do modelo (DataAnnotations) e tratar casos de "nao encontrado" com NotFound().

    public IActionResult Index()
    {
        // O que fazer:
        // - Buscar/listar todos os veiculos persistidos (lista estatica).
        // - Ordenar a lista (ex.: Marca, Modelo e/ou Placa) para manter consistencia na exibicao.
        // - Retornar View(lista).

        var lista = Veiculos.OrderBy(v => v.Marca).ToList();
        return View(lista);

    }

    public IActionResult Details(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo).

        var veiculo = Veiculos.FirstOrDefault(v => v.Id == id);
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
        // - Persistir o veiculo (adicionar na lista estatnb ica).
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).

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
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo) para preencher o formulario.
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
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        // - Se nao existir, retornar NotFound().
        // - Retornar View(veiculo) para confirmacao de exclusao.
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
        // O que fazer:
        // - Buscar o veiculo persistido pelo id; se nao existir, retornar NotFound().
        // - Remover o item encontrado da lista estatica.
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).
        var existente = Veiculos.FirstOrDefault(v => v.Id == id);
        if (existente is null)
        {
            return NotFound();
        }

        Veiculos.Remove(existente);
        return RedirectToAction(nameof(Index));
    }
}


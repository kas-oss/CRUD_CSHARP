using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_CSHARP.Controllers;

public class VeiculosController : Controller
{
    // OBJETIVO DO DESAFIO:
    // - Implementar um CRUD completo de Veiculos seguindo o mesmo padrao do MotoristasController.
    // - Usar persistencia em memoria neste controller: List<Veiculo> estatica + geracao de Id (_nextId).
    // - Criar as Views em Views/Veiculos: Index, Details, Create, Edit, Delete.
    // - Respeitar as validacoes do modelo (DataAnnotations) e tratar casos de "nao encontrado" com NotFound().

    //Static List como BD
    private static List<Veiculo> _veiculos = new List<Veiculo>();

    //ID generate
    private static int _proxID = 1;

    public IActionResult Index()
    {
        // O que fazer:
        // - Buscar/listar todos os veiculos persistidos (lista estatica).
        // - Ordenar a lista (ex.: Marca, Modelo e/ou Placa) para manter consistencia na exibicao.
        // - Retornar View(lista).
        return View(_veiculos);
    }

    public IActionResult Details(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        // - Se nao existir, retornar NotFound().
        if (veiculo == null)
        {
            return NotFound();
        }
        // - Retornar View(veiculo).
        return View(veiculo);
    }

    public IActionResult Create()
    {
        // O que fazer:
        // - Retornar a tela de cadastro (View).
        return View();
        // - Na View, renderizar dropdowns para os enums do modelo:
        //   - Combustivel (TipoCombustivel)
        //   - Categoria (CategoriaVeiculo)
        // - Garantir que o usuario consiga selecionar valores validos para ambos.
    }  

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Veiculo veiculo)
    {
        // O que fazer:
        // - Validar ModelState; se invalido, retornar View(veiculo) para exibir os erros.
        if(ModelState.IsValid)
        {
            //Gerar Id unico (incrementando um _nextId) e atribuir em veiculo.Id.
            veiculo.Id = _proxID++;
            // - Persistir o veiculo (adicionar na lista estatica).
            _veiculos.Add(veiculo);
            // - Redirecionar para Index (RedirectToAction(nameof(Index))).
            return RedirectToAction(nameof(Index));
        }
        
        return View(veiculo);
    }

    public IActionResult Edit(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        // - Se nao existir, retornar NotFound().
        if(veiculo == null)
        {
            return NotFound();
        }
        // - Retornar View(veiculo) para preencher o formulario.
        return View(veiculo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Veiculo veiculo)
    {
        // O que fazer:
        // - Validar se id == veiculo.Id; se nao, retornar NotFound().
        if( id != veiculo.Id)
        {
            return NotFound();
        }
        // - Validar ModelState; se invalido, retornar View(veiculo) para exibir os erros.
        if (ModelState.IsValid)
        {
            // - Buscar o veiculo persistido pelo id; 
            var veiculoEx = _veiculos.FirstOrDefault(v => v.Id == id); 
            // - se nao existir, retornar NotFound().
            if(veiculoEx == null)
            {
                return NotFound();
            } 
            // - Atualizar os campos do veiculo persistido:
            //   Placa, Marca, Modelo, Ano, CapacidadeTanqueLitros, Combustivel, Categoria.
            veiculoEx.Placa = veiculo.Placa;
            veiculoEx.Marca = veiculo.Marca;
            veiculoEx.Modelo = veiculo.Modelo;
            veiculoEx.Ano = veiculo.Ano;
            veiculoEx.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
            veiculoEx.Combustivel = veiculo.Combustivel;
            veiculoEx.Categoria = veiculo.Categoria;
            // - Redirecionar para Index (RedirectToAction(nameof(Index))).
            return (RedirectToAction(nameof(Index)));
        }
        
        return View(veiculo);
    }

    public IActionResult Delete(int id)
    {
        // O que fazer:
        // - Buscar o veiculo pelo id na lista estatica.
        var veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        // - Se nao existir, retornar NotFound().
        if(veiculo == null)
        {
            return NotFound();
        }
        // - Retornar View(veiculo) para confirmacao de exclusao.
        return View(veiculo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
        // O que fazer:
        // - Buscar o veiculo persistido pelo id; 
        veiculo = _veiculos.FirstOrDefault(v => v.Id == id);
        // se nao existir, retornar NotFound().
        if(veiculo == null)
        {
            return NotFound();
        }
        // - Remover o item encontrado da lista estatica.
        _veiculos.Remove(veiculo);
        // - Redirecionar para Index (RedirectToAction(nameof(Index))).
        return (RedirectToAction(nameof(Index)));
    }
}

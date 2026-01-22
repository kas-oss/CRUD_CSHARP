using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class CarrosController : Controller
{
    // EXPECTATIVA DO TESTE:
    // - Implementar um CRUD completo para Veiculos, seguindo o mesmo padrão do MotoristasController.
    // - Pode ser persistência em memória (List<Veiculo> estática) como Motoristas, ou outra estratégia do projeto.
    // - Criar as Views em Views/Veiculos (Index, Details, Create, Edit, Delete).
    //
    // Dica: o objeto Veiculo já está modelado em Models/Veiculo.cs, você pode consultar o MotoristasController.cs para usar como referência.

    public IActionResult Index()
    {
        // - Buscar/listar veiculos
        // - Ordenar (ex.: por Marca/Modelo ou Placa)
        // - Retornar View(lista)
        throw new NotImplementedException();
    }

    public IActionResult Details(int id)
    {
        // - Buscar veiculo por id
        // - Se não existir, retornar NotFound()
        // - Retornar View(veiculo)
        throw new NotImplementedException();
    }

    public IActionResult Create()
    {
        // - Retornar a tela de cadastro
        // - (Opcional) Preparar dropdown de combustível (TipoCombustivel)
        throw new NotImplementedException();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Veiculo veiculo)
    {
        // - Validar ModelState
        // - Gerar Id (se usar lista em memória)
        // - Persistir o veiculo
        // - RedirectToAction(nameof(Index))
        throw new NotImplementedException();
    }

    public IActionResult Edit(int id)
    {
        // - Buscar veiculo por id
        // - Se não existir, retornar NotFound()
        // - Retornar View(veiculo)
        throw new NotImplementedException();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Veiculo veiculo)
    {
        // - Validar se id == veiculo.Id (senão NotFound/BadRequest)
        // - Validar ModelState
        // - Atualizar dados do veiculo persistido
        // - RedirectToAction(nameof(Index))
        throw new NotImplementedException();
    }

    public IActionResult Delete(int id)
    {
        // - Buscar veiculo por id
        // - Se não existir, retornar NotFound()
        // - Retornar View(veiculo) para confirmação
        throw new NotImplementedException();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
        // - Remover o veiculo persistido pelo id
        // - Se não existir, retornar NotFound()
        // - RedirectToAction(nameof(Index))
        throw new NotImplementedException();
    }
}

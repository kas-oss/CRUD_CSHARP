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
	// Comentários adicionais: Segui o mesmo padrão, mas poderia aplicar alguns principios de SOLID para evitar que a classe VeiculosController
	// e MotoristasController tenha muitas responsabilidades (Sugestão).
	// Utilizei da lista estática em memoria, mas pretendia fazer teste em um banco, a exemplo do SQLite, pra testar scriptsql,
	// porém fiquei com recebio de sair do escopo do teste.
	// Tentei respeitar todas as exigências do teste e dos requisitos pedidos, sem sair do escopo. Grato pelas orientações.

	private static readonly List<Veiculo> Veiculos = new()
	{
		new Veiculo
		{
			Id = 1,
			Placa = "ABC1D34",
			Marca = "VW",
			Modelo = "Gol",
			Ano = 2011,
			CapacidadeTanqueLitros = 55,
			Combustivel = TipoCombustivel.Gasolina,
			Categoria = CategoriaVeiculo.VeiculoLeve
		},
		new Veiculo
		{
			Id = 2,
			Placa = "EFG6H89",
			Marca = "BYD",
			Modelo = "Dolphin",
			Ano = 2024,
			CapacidadeTanqueLitros = 500,
			Combustivel = TipoCombustivel.Eletrico,
			Categoria = CategoriaVeiculo.VeiculoLeve
		}
	};

	public static int _nextId = 3;

	public IActionResult Index()
    {
		List<Veiculo> lista;
		try
		{
			lista = Veiculos.OrderBy(x => x.Marca).ToList(); // Retorna os dados do banco, por exemplo.
		}
		catch (Exception ex)
		{
			// _logger.LogError(ex, "Error simulado"); // Simulando um log de error pra armazenar a informação do error que aconteceu.
			lista = Veiculos.OrderBy(x => x.Marca).ToList(); // Nesse catch retornaria o status de error, por exemplo.
		}

		return View(lista);

		// O que fazer:
		// - Buscar/listar todos os veiculos persistidos (lista estatica). (Feito)
		// - Ordenar a lista (ex.: Marca, Modelo e/ou Placa) para manter consistencia na exibicao. (Feito)
		// - Retornar View(lista). (Feito)
		// Comentários adicionais:
		// Utilizei do try/catch para simular como seria a aplicação em produção, quando tenta acessar servidores ou banco de dados, 
        // caso não houvesse comunicação com um dos dois, lançaria a exceção.
	}

	public IActionResult Details(int id)
    {
		var veiculo = Veiculos.FirstOrDefault(x => x.Id == id);

		if (veiculo == null)
		{
			return NotFound();
		}

		return View(veiculo);

		// O que fazer:
		// - Buscar o veiculo pelo id na lista estatica. (Feito)
		// - Se nao existir, retornar NotFound(). (Feito)
		// - Retornar View(veiculo). (Feito)
    }

    public IActionResult Create()
    {
		return View();

		// O que fazer:
		// - Retornar a tela de cadastro (View). (Feito)
		// - Na View, renderizar dropdowns para os enums do modelo:
		//   - Combustivel (TipoCombustivel)
		//   - Categoria (CategoriaVeiculo)
		// - Garantir que o usuario consiga selecionar valores validos para ambos.
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
		// O que fazer:
		// - Validar ModelState; se invalido, retornar View(veiculo) para exibir os erros. (Feito)
		// - Gerar Id unico (incrementando um _nextId) e atribuir em veiculo.Id. (Feito)
		// - Persistir o veiculo (adicionar na lista estatica). (Feito)
		// - Redirecionar para Index (RedirectToAction(nameof(Index))). (Feito)
    }

    public IActionResult Edit(int id)
    {
		var veiculo = Veiculos.FirstOrDefault(x => x.Id == id);
		if (veiculo == null)
		{
			return NotFound();
		}

		return View(veiculo);
		// O que fazer:
		// - Buscar o veiculo pelo id na lista estatica. (Feito)
		// - Se nao existir, retornar NotFound(). (Feito)
		// - Retornar View(veiculo) para preencher o formulario. (Feito)
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

		var veiculoexistente = Veiculos.FirstOrDefault(x => x.Id == id);
		if (veiculoexistente is null)
		{
			return NotFound();
		}

		veiculoexistente.Placa = veiculo.Placa;
		veiculoexistente.Marca = veiculo.Marca;
		veiculoexistente.Modelo = veiculo.Modelo;
		veiculoexistente.Ano = veiculo.Ano;
		veiculoexistente.CapacidadeTanqueLitros = veiculo.CapacidadeTanqueLitros;
		veiculoexistente.Combustivel = veiculo.Combustivel;
		veiculoexistente.Categoria = veiculo.Categoria;

		return RedirectToAction(nameof(Index));
		// O que fazer:
		// - Validar se id == veiculo.Id; se nao, retornar NotFound(). (Feito)
		// - Validar ModelState; se invalido, retornar View(veiculo) para exibir os erros. (Feito)
		// - Buscar o veiculo persistido pelo id; se nao existir, retornar NotFound(). (Feito)
		// - Atualizar os campos do veiculo persistido: (Feito)
		//   Placa, Marca, Modelo, Ano, CapacidadeTanqueLitros, Combustivel, Categoria.
		// - Redirecionar para Index (RedirectToAction(nameof(Index))). (Feito)
    }

    public IActionResult Delete(int id)
    {
		var veiculo = Veiculos.FirstOrDefault(x => x.Id == id);

		if (veiculo == null)
		{
			return NotFound();
		}

		return View(veiculo);
		// O que fazer:
		// - Buscar o veiculo pelo id na lista estatica. (Feito)
		// - Se nao existir, retornar NotFound(). (Feito)
		// - Retornar View(veiculo) para confirmacao de exclusao. (Feito)
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, Veiculo veiculo)
    {
		var veiculoexistente = Veiculos.FirstOrDefault(x => x.Id == id);

		if (veiculoexistente == null)
		{
			return NotFound();
		}

		Veiculos.Remove(veiculoexistente);

		return RedirectToAction(nameof(Index));
		// O que fazer:
		// - Buscar o veiculo persistido pelo id; se nao existir, retornar NotFound(). (Feito)
		// - Remover o item encontrado da lista estatica. (Feito)
		// - Redirecionar para Index (RedirectToAction(nameof(Index))). (Feito)
    }
}

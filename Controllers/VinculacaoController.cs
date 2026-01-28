using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VinculacaoController : Controller
{

    public VinculacaoRepository _vinculacaoRepository;

    public static int _nextId = 2;

    public VinculacaoController(VinculacaoRepository vinculacaoRepository)
    {
        _vinculacaoRepository = vinculacaoRepository;
    }

    public IActionResult Index()
    {
        var lista = _vinculacaoRepository.Vinculacoes.OrderBy(v => v.Id).ToList();

        return View(lista);
    }
    
}

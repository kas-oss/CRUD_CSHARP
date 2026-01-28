using CRUD_CSHARP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VinculacaoController : Controller
{
    public VinculacaoRepository _vinculacaoRepository;

    public MotoristaRepository _motoristaRepository;
    public VeiculoRepository _veiculoRepository;

    public static int _nextId = 2;

    public VinculacaoController(
        VinculacaoRepository vinculacaoRepository,
        MotoristaRepository motoristaRepository,
        VeiculoRepository veiculoRepository
    )
    {
        _vinculacaoRepository = vinculacaoRepository;
        _motoristaRepository = motoristaRepository;
        _veiculoRepository = veiculoRepository;
    }

    public IActionResult Index()
    {
        var vincs = _vinculacaoRepository.Vinculacoes.OrderBy(v => v.Id).ToList();

        var fullVincs = vincs.Select(vinc =>
        {
            var motorista = _motoristaRepository.Motoristas.FirstOrDefault(m => m.Id == vinc.MotoristaId);
            var veiculo = _veiculoRepository.Veiculos.FirstOrDefault(v => v.Id == vinc.VeiculoId);

            return new VinculacaoFullModel
            {
                Vinculacao = vinc,
                Motorista = motorista,
                Veiculo = veiculo,
            };
        });

        return View(fullVincs);
    }
}

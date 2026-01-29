using CRUD_CSHARP.Models;
using CRUD_CSHARP.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_CSHARP.Controllers;

public class VinculacaoController : Controller
{
    public VinculacaoRepository _vinculacaoRepository;

    public MotoristaRepository _motoristaRepository;
    public VeiculoRepository _veiculoRepository;

    public VinculoService _vinculoService;
    public static int _nextId = 2;

    public VinculacaoController(
        VinculacaoRepository vinculacaoRepository,
        MotoristaRepository motoristaRepository,
        VeiculoRepository veiculoRepository,
        VinculoService vinculoService
    )
    {
        _vinculacaoRepository = vinculacaoRepository;
        _motoristaRepository = motoristaRepository;
        _veiculoRepository = veiculoRepository;
        _vinculoService = vinculoService;
    }

    public IActionResult Index()
    {
        var vincs = _vinculacaoRepository.Vinculacoes.OrderBy(v => v.Id).ToList();

        var fullVincs = vincs.Select(vinc =>
        {
            var motorista = _motoristaRepository.Motoristas.FirstOrDefault(m =>
                m.Id == vinc.MotoristaId
            );
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

    public IActionResult Details(int id)
    {
        var vinc = _vinculacaoRepository.Vinculacoes.FirstOrDefault(v => v.Id == id);
        if (vinc == null)
        {
            return NotFound();
        }

        var motorista = _motoristaRepository.Motoristas.FirstOrDefault(m =>
            m.Id == vinc.MotoristaId
        );
        var veiculo = _veiculoRepository.Veiculos.FirstOrDefault(v => v.Id == vinc.VeiculoId);

        var fullVinc = new VinculacaoFullModel
        {
            Vinculacao = vinc,
            Motorista = motorista,
            Veiculo = veiculo,
        };

        return View(fullVinc);
    }

    public IActionResult Create()
    {
        List<MotoristaDisponibilidadeViewModel> motoristasDisponibilidade =
            _vinculoService.ObterDisponibilidadeMotoristas();

        List<VeiculoDisponibilidadeViewModel> veiculosDisponibilidade =
            _vinculoService.ObterDisponibilidadeVeiculos();

        VinculacaoFormModel model = new VinculacaoFormModel
        {
            MotoristasDisponibilidade = motoristasDisponibilidade,
            VeiculosDisponibilidade = veiculosDisponibilidade,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Create(VinculacaoFormModel vinculacaoFormModel)
    {
        bool error = false;

        if (!ModelState.IsValid)
        {
            error = true;
        }

        if (!_vinculoService.MotoristaEstaDisponivel(vinculacaoFormModel.Vinculacao.MotoristaId))
        {
            ModelState.AddModelError("MotoristaId", "O motorista selecionado não está disponível");
            error = true;
        }

        if (!_vinculoService.VeiculoEstaDisponivel(vinculacaoFormModel.Vinculacao.VeiculoId))
        {
            ModelState.AddModelError("VeiculoId", "O veículo selecionado não está disponível");
            error = true;
        }

        // Em caso de erro, é necessario recarregar a lista de disponibilidades
        // Um exemplo de o porque disso é caso alguem vincule um motorista e veículo enquanto outra pessoa
        // está preenchendo o formulario
        if (error)
        {
            vinculacaoFormModel.MotoristasDisponibilidade =
                _vinculoService.ObterDisponibilidadeMotoristas();
            vinculacaoFormModel.VeiculosDisponibilidade =
                _vinculoService.ObterDisponibilidadeVeiculos();
            return View(vinculacaoFormModel);
        }

        var novaVinculacao = new Vinculacao
        {
            Id = _nextId++,
            MotoristaId = vinculacaoFormModel.Vinculacao.MotoristaId,
            VeiculoId = vinculacaoFormModel.Vinculacao.VeiculoId,
            DataHoraInicio = vinculacaoFormModel.Vinculacao.DataHoraInicio,
            QuilometragemInicial = vinculacaoFormModel.Vinculacao.QuilometragemInicial,
            DataHoraFim = vinculacaoFormModel.Vinculacao.DataHoraFim,
            QuilometragemFinal = vinculacaoFormModel.Vinculacao.QuilometragemFinal,
            Motivo = vinculacaoFormModel.Vinculacao.Motivo,
            Observacoes = vinculacaoFormModel.Vinculacao.Observacoes,
        };

        _vinculacaoRepository.Vinculacoes.Add(novaVinculacao);

        return RedirectToAction(nameof(Index));
    }
}

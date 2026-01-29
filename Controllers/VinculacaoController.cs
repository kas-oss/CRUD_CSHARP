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

    public IActionResult Edit(int id)
    {
        var vinculacao = _vinculacaoRepository.Vinculacoes.FirstOrDefault(v => v.Id == id);

        if (vinculacao == null)
        {
            return NotFound();
        }

        // Carrega as disponibilidades, más marca o motorista e veículo da vinculação em questão como disponiveis.
        List<MotoristaDisponibilidadeViewModel> motoristasDisponibilidade =
            _vinculoService.ObterDisponibilidadeMotoristas();

        motoristasDisponibilidade
            .Find(m => m.Motorista.Id == vinculacao.MotoristaId)!
            .DisponivelParaVinculacao = true;

        List<VeiculoDisponibilidadeViewModel> veiculosDisponibilidade =
            _vinculoService.ObterDisponibilidadeVeiculos();

        veiculosDisponibilidade
            .Find(v => v.Veiculo.Id == vinculacao.VeiculoId)!
            .DisponivelParaVinculacao = true;

        VinculacaoFormModel model = new VinculacaoFormModel
        {
            Vinculacao = vinculacao,
            MotoristasDisponibilidade = motoristasDisponibilidade,
            VeiculosDisponibilidade = veiculosDisponibilidade,
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(int id, VinculacaoFormModel vinculacaoFormModel)
    {
        var vinculacaoExistente = _vinculacaoRepository.Vinculacoes.FirstOrDefault(v => v.Id == id);

        if (vinculacaoExistente == null)
            return NotFound();

        bool error = false;

        if (!ModelState.IsValid)
        {
            error = true;
        }

        // Realiza a verificação de disponibilidade apenas se o motorista ou veículo foram alterados
        if (vinculacaoExistente.MotoristaId != vinculacaoFormModel.Vinculacao.MotoristaId)
        {
            if (
                !_vinculoService.MotoristaEstaDisponivel(vinculacaoFormModel.Vinculacao.MotoristaId)
            )
            {
                ModelState.AddModelError(
                    "Vinculacao.MotoristaId",
                    "O motorista selecionado não está disponível"
                );
                error = true;
            }
        }

        if (vinculacaoExistente.VeiculoId != vinculacaoFormModel.Vinculacao.VeiculoId)
        {
            if (!_vinculoService.VeiculoEstaDisponivel(vinculacaoFormModel.Vinculacao.VeiculoId))
            {
                ModelState.AddModelError(
                    "Vinculacao.VeiculoId",
                    "O veículo selecionado não está disponível"
                );
                error = true;
            }
        }

        if (error)
        {
            vinculacaoFormModel.MotoristasDisponibilidade =
                _vinculoService.ObterDisponibilidadeMotoristas();

            vinculacaoFormModel.VeiculosDisponibilidade =
                _vinculoService.ObterDisponibilidadeVeiculos();

            return View(vinculacaoFormModel);
        }

        vinculacaoExistente.MotoristaId = vinculacaoFormModel.Vinculacao.MotoristaId;
        vinculacaoExistente.VeiculoId = vinculacaoFormModel.Vinculacao.VeiculoId;
        vinculacaoExistente.DataHoraInicio = vinculacaoFormModel.Vinculacao.DataHoraInicio;
        vinculacaoExistente.QuilometragemInicial = vinculacaoFormModel
            .Vinculacao
            .QuilometragemInicial;
        vinculacaoExistente.DataHoraFim = vinculacaoFormModel.Vinculacao.DataHoraFim;
        vinculacaoExistente.QuilometragemFinal = vinculacaoFormModel.Vinculacao.QuilometragemFinal;
        vinculacaoExistente.Motivo = vinculacaoFormModel.Vinculacao.Motivo;
        vinculacaoExistente.Observacoes = vinculacaoFormModel.Vinculacao.Observacoes;

        return RedirectToAction(nameof(Index));
    }
}

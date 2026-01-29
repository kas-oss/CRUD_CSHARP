namespace CRUD_CSHARP.Services;

// Implementa de maneira de maneira modular algumas lógicas de forma que possa ser reutilizada em diferentes partes do sistema
public class VinculoService
{
    private VinculacaoRepository _vinculacaoRepository;
    private MotoristaRepository _motoristaRepository;
    private VeiculoRepository _veiculoRepository;

    public VinculoService(
        VinculacaoRepository vinculacaoRepository,
        MotoristaRepository motoristaRepository,
        VeiculoRepository veiculoRepository
    )
    {
        _vinculacaoRepository = vinculacaoRepository;
        _motoristaRepository = motoristaRepository;
        _veiculoRepository = veiculoRepository;
    }

    public bool MotoristaEstaDisponivel(int motoristaId)
    {
        var vinculacoes = _vinculacaoRepository.GetAll();

        return !vinculacoes.Any(v =>
            v.MotoristaId == motoristaId && (v.DataHoraFim == null || v.QuilometragemFinal == null)
        );
    }

    public bool VeiculoEstaDisponivel(int veiculoId)
    {
        var vinculacoes = _vinculacaoRepository.GetAll();

        return !vinculacoes.Any(v =>
            v.VeiculoId == veiculoId && (v.DataHoraFim == null || v.QuilometragemFinal == null)
        );
    }

    public List<MotoristaDisponibilidadeViewModel> ObterDisponibilidadeMotoristas()
    {
        List<Vinculacao> vinculacoes = _vinculacaoRepository.GetAll();

        List<Motorista> motoristas = _motoristaRepository.GetAll();

        List<MotoristaDisponibilidadeViewModel> disponibilidadeMotoristas = motoristas
            .Select(m =>
            {
                return new MotoristaDisponibilidadeViewModel
                {
                    Motorista = m,
                    DisponivelParaVinculacao = this.MotoristaEstaDisponivel(m.Id),
                };
            })
            .ToList();

        return disponibilidadeMotoristas;
    }

    public List<VeiculoDisponibilidadeViewModel> ObterDisponibilidadeVeiculos()
    {
        List<Vinculacao> vinculacoes = _vinculacaoRepository.GetAll();

        List<Veiculo> veiculos = _veiculoRepository.GetAll();

        List<VeiculoDisponibilidadeViewModel> disponibilidadeVeiculos = veiculos
            .Select(v =>
            {
                new VeiculoDisponibilidadeViewModel
                {
                    Veiculo = v,
                    DisponivelParaVinculacao = this.VeiculoEstaDisponivel(v.Id),
                };
            })
            .ToList();

        return disponibilidadeVeiculos;
    }
}

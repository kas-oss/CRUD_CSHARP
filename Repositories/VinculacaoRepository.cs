using CRUD_CSHARP.Models;

public class VinculacaoRepository
{
    public List<Vinculacao> Vinculacoes { get; set; } =
        new()
        {
            new Vinculacao
            {
                Id = 1,
                MotoristaId = 1,
                VeiculoId = 1,
                DataHoraInicio = DateTime.Now,
                DataHoraFim = null,
                QuilometragemInicial = 10000,
                QuilometragemFinal = null,
                Motivo = "Uso para serviço externo",
                Observacoes = "Veículo em boas condições na saída",
            },
        };
}

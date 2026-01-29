namespace CRUD_CSHARP.Models;

// Esse model não tem como finalidade ser persistido.
// Em vez disso seu objetivo é fornecer aos formulários a lista de motoristas e veículos para os selects
public class VinculacaoFormModel
{
    public Vinculacao Vinculacao { get; set; } = new();

    public List<MotoristaDisponivelParaVinculacaoModel> MotoristasDisponibilidade { get; set; } = new();
    public List<VeiculoDisponivelParaVinculacaoModel> VeiculosDisponibilidade { get; set; } = new();
}

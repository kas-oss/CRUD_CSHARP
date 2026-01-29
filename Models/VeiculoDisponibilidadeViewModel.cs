namespace CRUD_CSHARP.Models;

// Esse model não tem como finalidade ser persistido.
// Seu objetivo é fornecer a informação se um veiculo está disponível para vinculação ou não á view de Create e Edit

public class VeiculoDisponibilidadeViewModel
{
    public Veiculo Veiculo { get; set; } = new();
    public bool DisponivelParaVinculacao { get; set; }
}

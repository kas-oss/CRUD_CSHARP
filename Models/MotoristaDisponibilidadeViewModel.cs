namespace CRUD_CSHARP.Models;

// Esse model não tem como finalidade ser persistido.
// Seu objetivo é fornecer a informação se um motorista está disponível para vinculação ou não á view de Create e Edit

public class MotoristaDisponibilidadeViewModel
{
    public Motorista Motorista { get; set; } = new();

    public bool DisponivelParaVinculacao { get; set; }
}

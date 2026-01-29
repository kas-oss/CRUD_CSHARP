namespace CRUD_CSHARP.Models;

// Esse model não tem como finalidade ser persistido.
// Em vez disso, seu objetivo é tonar possível acessar a partir da view as propriedades do motorista e veiculo relacionados com a vinculação em vez de somente os IDs.
public class VinculacaoFullModel
{
    public Vinculacao Vinculacao { get; set; } = new();

    public Motorista Motorista { get; set; } = new();
    public Veiculo Veiculo { get; set; } = new();
}

using CRUD_CSHARP.Models;

public class MotoristaRepository
{
    public List<Motorista> Motoristas { get; set; } =
        new()
        {
            new Motorista
            {
                Id = 1,
                Nome = "Ana Souza",
                Cpf = "123.456.789-00",
                Cnh = "CNH123456",
                TipoCnh = TipoCnh.B,
                Telefone = "(11) 99999-0001",
                DataNascimento = new DateTime(1990, 5, 12),
            },
            new Motorista
            {
                Id = 2,
                Nome = "Bruno Lima",
                Cpf = "987.654.321-00",
                Cnh = "CNH987654",
                TipoCnh = TipoCnh.AB,
                Telefone = "(21) 98888-0002",
                DataNascimento = new DateTime(1985, 9, 3),
            },
        };
}

using CRUD_CSHARP.Models;

public class VeiculoRepository
{
    public List<Veiculo> Veiculos { get; set; } =
        new()
        {
            new Veiculo
            {
                Id = 1,
                Placa = "ABC-0000",
                Marca = "Volkswagen",
                Modelo = "Taos",
                Ano = 2026,
                CapacidadeTanqueLitros = 48,
                Combustivel = TipoCombustivel.Gasolina,
                Categoria = CategoriaVeiculo.VeiculoLeve,
            },
            new Veiculo
            {
                Id = 2,
                Placa = "ABC-0001",
                Marca = "BYD",
                Modelo = "Dolphin Mini",
                Ano = 2025,

                // Carros eletricos não possuem tanque de combustivel
                // Para respeitar a validacao do model (> 10),
                // Irei considerar a capacidade do tanque de veiculos eletricos como KWh da bateria
                CapacidadeTanqueLitros = 38,
                Combustivel = TipoCombustivel.Eletrico,
                Categoria = CategoriaVeiculo.VeiculoLeve,
            },
            new Veiculo
            {
                Id = 3,
                Placa = "ABC-0002",
                Marca = "Ford",
                Modelo = "Ranger",
                Ano = 2020,
                CapacidadeTanqueLitros = 80,
                Combustivel = TipoCombustivel.Diesel,
                Categoria = CategoriaVeiculo.VeiculoLeve,
            },
        };
}

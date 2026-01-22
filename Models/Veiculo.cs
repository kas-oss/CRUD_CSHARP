using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public class Veiculo
{
    public int Id { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 7)]
    public string Placa { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    public string Marca { get; set; } = string.Empty;

    [Required]
    [StringLength(60)]
    public string Modelo { get; set; } = string.Empty;

    [Range(1900, 2026)]
    public int? Ano { get; set; }

    [Required]
    [Range(10, 1000)]
    public decimal CapacidadeTanqueLitros { get; set; }

    [Required]
    public TipoCombustivel Combustivel { get; set; }
}


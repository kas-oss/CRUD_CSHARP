using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public class Veiculo
{
    public int Id { get; set; }

    [Required]
    [StringLength(8, MinimumLength = 7)]
    [RegularExpression (@"^[a-zA-Z]{3}-?[0-9][A-Za-z0-9][0-9]{2}$", ErrorMessage = "Formato inválido. Use o padrão (ABC-1234) ou Mercosul (ABC1D23).")] // Required adicional criado buscando garantir o formato da placa
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

    [Range(1, int.MaxValue, ErrorMessage = "Selecione a categoria do veículo.")]
    [Display(Name = "Categoria")]
    public CategoriaVeiculo Categoria { get; set; } = CategoriaVeiculo.NaoInformada;
}

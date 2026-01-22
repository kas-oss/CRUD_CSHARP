using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public class Motorista
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Nome Completo")]
    public string Nome { get; set; } = string.Empty;

    [Required]
    [StringLength(14)]
    [Display(Name = "CPF")]
    public string Cpf { get; set; } = string.Empty;

    [Required]
    [StringLength(9)]
    [Display(Name = "Número da CNH")]
    public string Cnh { get; set; } = string.Empty;

    [Phone]
    [StringLength(20)]
    [Display(Name = "Telefone / Celular")]
    public string? Telefone { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Data de Nascimento")]
    public DateTime? DataNascimento { get; set; }
}

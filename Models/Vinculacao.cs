using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public class Vinculacao
{
    public int Id { get; set; }

    [Display(Name = "Motorista")]
    [Required(ErrorMessage = "É obrigatório informar o motorista")]
    public int MotoristaId { get; set; }

    [Display(Name = "Veículo")]
    [Required(ErrorMessage = "É obrigatório informar o veículo")]
    public int VeiculoId { get; set; }

    [Display(Name = "Data e Hora de Início")]
    [Required(ErrorMessage = "É obrigatório informar a data e hora de início")]
    [DataType(DataType.DateTime)]
    public DateTime DataHoraInicio { get; set; }

    [Display(Name = "Data e Hora de Fim")]
    [DataType(DataType.DateTime)]
    public DateTime? DataHoraFim { get; set; }

    [Display(Name = "Quilometragem Inicial")]
    [Required(ErrorMessage = "É obrigatório informar a quilometragem inicial")]
    [Range(0, int.MaxValue, ErrorMessage = "A quilometragem inical precisa ser maior ou igual a zero")]
    public int QuilometragemInicial { get; set; }

    [Display(Name = "Quilometragem Final")]
    [Range(0, int.MaxValue, ErrorMessage = "A quilometragem final precisa ser maior ou igual a zero")]
    public int? QuilometragemFinal { get; set; }

    [Display(Name = "Motivo da Vinculação")]
    [Required(ErrorMessage = "É obrigatório informar o motivo da vinculação")]
    [StringLength(128, ErrorMessage = "O motivo deve ter no máximo 128 caracteres")]
    public string Motivo { get; set; } = string.Empty;

    [Display(Name = "Observações")]
    [StringLength(512, ErrorMessage = "As observações devem ter no máximo 512 caracteres")]
    public string? Observacoes { get; set; }

}

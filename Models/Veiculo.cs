using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public class Veiculo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe a Placa do veiculo")]
    [StringLength(8, MinimumLength = 7)]
    public string Placa { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe a Marca do veiculo")]
    [StringLength(60)]
    public string Marca { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o Modelo do veiculo")]
    [StringLength(60)]
    public string Modelo { get; set; } = string.Empty;

    [Required(ErrorMessage = "Informe o Ano do veiculo")] // Adicionado atributo Required para tornar o campo obrigatório
    [Range(1900, 2026, ErrorMessage = "O ano deve estar entre 1900-2026")] // Definido intervalo válido para o ano
    public int? Ano { get; set; }

    //Melhorei a validacao deste campo com mensagens personalizadas e display name amigavel para exibição na View de Create/Edit e nas mensagens de erro da validação de modelo. Melhor Experiência do Usuário (UX).

    [Required(ErrorMessage = "Informe a capacidade do tanque")] // Mensagem personalizada para campo obrigatório
    [Range(0, 1000, ErrorMessage = "O valor deve estar entre 10 e 1000 litros")] // Validação de intervalo com mensagem personalizada
    [Display(Name = "Capacidade do tanque em litros")] // Nome amigável para exibição
    [DisplayFormat(DataFormatString = "{0:0.##}", ApplyFormatInEditMode = true)] // Formatação para exibir até duas casas decimais
    public decimal? CapacidadeTanqueLitros { get; set; }

    // Não consegui fazer o tipo decimal ser aceito. Quando a view de edição era chamada,
    // ela exibia o número de litros em formato decimal. Alterei para evitar o erro,
    // mas não consegui permitir números com vírgula.

    [Required]
    public TipoCombustivel Combustivel { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Selecione a categoria do veículo.")]
    [Display(Name = "Categoria")]
    public CategoriaVeiculo Categoria { get; set; } = CategoriaVeiculo.NaoInformada;
}

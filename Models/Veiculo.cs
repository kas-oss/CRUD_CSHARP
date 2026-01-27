using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models
{
    public class Veiculo
    {
        public int Id
        { get; set; }

        [Required(ErrorMessage = "A Placa do Veículo é obrigatoria")]
        public string Placa
        { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Modelo do Veículo é obrigatorio")]
        public string Modelo
        { get; set; } = string.Empty;

        [Required(ErrorMessage = "O Marca do Veículo é obrigatorio")]
        public string Marca
        { get; set; } = string.Empty;

        public int Ano
        { get; set; }
    }
}   
using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public enum TipoCombustivel
{
    [Display(Name = "Selecione")]
    NaoInformada = 0,

    [Display(Name = "Gasolina")]
    Gasolina = 1,

    [Display(Name = "Etanol")]
    Etanol = 2,

    [Display(Name = "Flex (Gasolina/Etanol)")]
    Flex = 3,

    [Display(Name = "Diesel")]
    Disel = 4,

    [Display(Name = "GNV")]
    GNV = 5,

    [Display(Name = "Eletrico")]
    Eletrico = 6,
}


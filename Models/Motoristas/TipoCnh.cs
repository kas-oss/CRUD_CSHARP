using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models.Motoristas;

public enum TipoCnh
{
    [Display(Name = "Selecione")]
    NaoInformada = 0,

    [Display(Name = "A")]
    A = 1,

    [Display(Name = "B")]
    B = 2,

    [Display(Name = "AB")]
    AB = 3,

    [Display(Name = "C")]
    C = 4,

    [Display(Name = "D")]
    D = 5,

    [Display(Name = "E")]
    E = 6,

    [Display(Name = "AC")]
    AC = 7,

    [Display(Name = "AD")]
    AD = 8,

    [Display(Name = "AE")]
    AE = 9
}


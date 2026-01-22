using System.ComponentModel.DataAnnotations;

namespace CRUD_CSHARP.Models;

public enum CategoriaVeiculo
{
    [Display(Name = "Selecione")]
    NaoInformada = 0,

    [Display(Name = "Ciclomotor")]
    Ciclomotor = 1,

    [Display(Name = "Motocicleta")]
    Motocicleta = 2,

    [Display(Name = "Veículo leve")]
    VeiculoLeve = 3,

    [Display(Name = "Utilitário")]
    Utilitario = 4,

    [Display(Name = "Caminhão / veículo pesado")]
    VeiculoPesado = 5,

    [Display(Name = "Ônibus / Micro-ônibus")]
    Onibus = 6,

    [Display(Name = "Outro")]
    Outro = 7
}


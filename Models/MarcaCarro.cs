using System.ComponentModel.DataAnnotations;


namespace CRUD_CSHARP.Models
{
    public enum MarcaCarro
    {
        [Display(Name = "Selecione")]
        NaoInformada = 0,

        [Display(Name = "Audi")]
        Audi = 1,

        [Display(Name = "BMW")]
        BMW = 2,

        [Display(Name = "BYD")]
        BYD = 3,

        [Display(Name = "Caoa Chery")]
        CaoaChery = 4,

        [Display(Name = "Chevrolet")]
        Chevrolet = 5,

        [Display(Name = "Citroën")]
        Citroen = 6,

        [Display(Name = "Fiat")]
        Fiat = 7,

        [Display(Name = "Ford")]
        Ford = 8,

        [Display(Name = "GWM (Haval/Ora)")]
        GWM = 9,

        [Display(Name = "Honda")]
        Honda = 10,

        [Display(Name = "Hyundai")]
        Hyundai = 11,

        [Display(Name = "JAC Motors")]
        JacMotors = 12,

        [Display(Name = "Jeep")]
        Jeep = 13,

        [Display(Name = "Kia")]
        Kia = 14,

        [Display(Name = "Land Rover")]
        LandRover = 15,

        [Display(Name = "Mercedes-Benz")]
        MercedesBenz = 16,

        [Display(Name = "Mitsubishi")]
        Mitsubishi = 17,

        [Display(Name = "Nissan")]
        Nissan = 18,

        [Display(Name = "Peugeot")]
        Peugeot = 19,

        [Display(Name = "Porsche")]
        Porsche = 20,

        [Display(Name = "Renault")]
        Renault = 21,

        [Display(Name = "Toyota")]
        Toyota = 22,

        [Display(Name = "Volkswagen")]
        Volkswagen = 23,

        [Display(Name = "Volvo")]
        Volvo = 24,

        [Display(Name = "Outra")]
        Outra = 99
    }
}

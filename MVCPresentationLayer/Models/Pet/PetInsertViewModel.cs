﻿using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MVCPresentationLayer.Models.Pet
{
    public class PetInsertViewModel
    {
        [Required(ErrorMessage = "O nome deve ser informado.")]
        [StringLength(30,MinimumLength = 3, ErrorMessage = "O nome deve conter entre 3 e 30 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A raça deve ser informada.")]
        [Display(Name = "Raça")]
        public string Raca { get; set; }
        [Required(ErrorMessage = "O peso deve ser informado.")]
        [Range(0.5,150,ErrorMessage = "O peso deve estar entre 0.5kg e 150kg")]
        public double Peso { get; set; }
        public string Cor { get; set; }
        public TipoPet Tipo { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_ASPNET.Models
{
    public class Computer
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę!")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę procesora!")]
        [StringLength(50, ErrorMessage = "Nazwa procesora nie może być dłuższa niż 50 znaków!")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Proszę podać ilość pamięci w gigabajtach!")]
        [Range(1, 1024, ErrorMessage = "Pamięć RAM musi mieścić się w przedziale od 1 do 1024 GB!")]
        public int Memory { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę karty graficznej!")]
        [StringLength(50, ErrorMessage = "Nazwa karty graficznej nie może być dłuższa niż 50 znaków!")]
        public string Graphics { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę producenta!")]
        [StringLength(50, ErrorMessage = "Nazwa producenta nie może być dłuższa niż 50 znaków!")]
        public string Maker { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać datę produkcji!")]
        [CustomValidation(typeof(Computer), nameof(ValidateProductionDate))]
        public DateTime ProductionDate { get; set; }

        [StringLength(500, ErrorMessage = "Opis nie może być dłuższy niż 500 znaków!")]
        public string? Description { get; set; }

        // Custom validation for ProductionDate to ensure it's not in the future
        public static ValidationResult? ValidateProductionDate(DateTime productionDate, ValidationContext context)
        {
            if (productionDate > DateTime.Now)
            {
                return new ValidationResult("Data produkcji nie może być w przyszłości!");
            }
            return ValidationResult.Success;
        }
    }
}

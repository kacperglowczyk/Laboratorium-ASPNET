using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_ASPNET.Models;

    public class Contact
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        [Display(Name = "Imię")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Proszę podać adres email!")]
        [EmailAddress(ErrorMessage = "Proszę podać poprawny adres email!")]
        [Display(Name = "Adres Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        [Phone(ErrorMessage = "Proszę podać poprawny numer telefonu!")]
        [Display(Name = "Numer Telefonu")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Proszę podać temat!")]
        [Display(Name = "Temat")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Proszę podać treść wiadomości!")]
        [Display(Name = "Wiadomość")]
        public string Message { get; set; } = string.Empty;

        [Display(Name = "Data Utworzenia")]
        [HiddenInput(DisplayValue = false)]
        public DateTime Created { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Proszę wybrać priorytet!")]
        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }
    }

    public enum Priority
    {
        [Display(Name = "Niski")]
        Low = 1,

        [Display(Name = "Normalny")]
        Normal = 2,

        [Display(Name = "Wysoki")]
        High = 3,

        [Display(Name = "Pilny")]
        Urgent = 4
    }

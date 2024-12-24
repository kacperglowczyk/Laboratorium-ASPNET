using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_ASPNET.Models;
    
public class Contact
{
    [HiddenInput]
    public int Id { get; set; }

    [Required(ErrorMessage = "Proszę podać imię!")]
    public string Name { get; set; }

    [EmailAddress(ErrorMessage = "Proszę podać poprawny email!")]
    [Required(ErrorMessage = "Proszę podać adres email!")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Proszę podać temat wiadomości!")]
    public string Subject { get; set; }

    [MinLength(5, ErrorMessage = "Wiadomość musi mieć co najmniej 5 znaków!")]
    [Required(ErrorMessage = "Proszę wpisać wiadomość!")]
    public string Message { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
}
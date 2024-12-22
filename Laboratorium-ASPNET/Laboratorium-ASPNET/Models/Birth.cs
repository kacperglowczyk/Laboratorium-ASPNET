namespace Laboratorium_ASPNET.Models;

public class Birth
{
    public string? Name { get; set; }
    public DateTime? BirthDate { get; set; }

    public bool IsValid()
    {
        return !string.IsNullOrWhiteSpace(Name) && BirthDate < DateTime.Now;
    }

    public int CalculateAge()
    {
        if (BirthDate == null) return 0;

        var today = DateTime.Today;
        var age = today.Year - BirthDate.Value.Year;

        if (BirthDate.Value.Date > today.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}
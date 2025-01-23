using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Dla [Table] i [Column]

namespace Data.Entities;

[Table("contacts")]
public class ContactEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime Birth { get; set; }
    public int OrganizationId { get; set; }
    public OrganizationEntity? Organization { get; set; }
}

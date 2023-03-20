using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Arendehanteringssystem.Models.Entities;


[Index(nameof(Email), IsUnique = true)]
public class CustomerEntity
{
    public int Id { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "char(13)")]
    public string PhoneNumber { get; set; } = null!;

    public ICollection<ErrandEntity> Errands { get; set; } = null!;
}

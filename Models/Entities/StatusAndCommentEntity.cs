using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Arendehanteringssystem.Models.Entities;

public class StatusAndCommentEntity
{
    [Key]
    public int Id { get; set; }

    [StringLength(11)]
    public Status Status { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string Comment { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public int ErrandId { get; set; }

    public ErrandEntity Errand { get; set; } = null!;
}
public enum Status
{
    [Display(Name = "Ej påbörjad")]
    NotStarted,
    [Display(Name = "Pågående")]
    Ongoing,
    [Display(Name = "Avslutad")]
    Finished
}

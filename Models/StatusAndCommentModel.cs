using Arendehanteringssystem.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Arendehanteringssystem.Models;

public class StatusAndCommentModel
{
    public int Id { get; set; }
    public Status Status { get; set; }
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

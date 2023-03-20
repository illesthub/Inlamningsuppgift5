using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arendehanteringssystem.Models.Entities;

public class ErrandEntity
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(max)")]
    public string ErrandDescription { get; set; } = null!;

    public DateTime TimeStamp { get; set; }

    public int CustomerId { get; set; }

    public CustomerEntity Customer { get; set; } = null!;

    public StatusAndCommentEntity StatusAndComment { get; set; } = null!;
}
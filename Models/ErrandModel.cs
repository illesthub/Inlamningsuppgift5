using Arendehanteringssystem.Models.Entities;

namespace Arendehanteringssystem.Models;

public class ErrandModel
{
    public int Id { get; set; }
    public string ErrandDescription { get; set; } = null!;
    public DateTime TimeStamp { get; set; }
    public int CustomerId { get; set; }
    public CustomerEntity Customer { get; set; } = null!;
    public StatusAndCommentEntity StatusAndComment { get; set; } = null!;

}

using Arendehanteringssystem.Models.Entities;

namespace Arendehanteringssystem.Models;

public class CustomerModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = null!;

    public ICollection<ErrandEntity> Errands { get; set; } = null!;


}

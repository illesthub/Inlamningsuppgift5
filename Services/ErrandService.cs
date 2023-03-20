using Arendehanteringssystem.Contexts;
using Arendehanteringssystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arendehanteringssystem.Services;

public class ErrandService
{
    private static readonly DataContext _context = new();

    //Get all errends klar
    public static async Task<IEnumerable<ErrandEntity>> GetAllAsync()
    {
        var errands = await _context.Errand
        .Include(e => e.StatusAndComment)
        .ToListAsync();

        return errands;
    }

    public static List<ErrandEntity> GetErrandsByEmail(string email)
    {
        var customer = _context.Customer.FirstOrDefault(c => c.Email == email);

        if (customer == null)
        {
            return new List<ErrandEntity>();
        }
        else
        {
            var errands = _context.Errand
                .Include(e => e.StatusAndComment)
                .Where(e => e.CustomerId == customer.Id)
                .ToList();

            return errands;
        }
    }

    public static async Task<ICollection<ErrandEntity>> GetErrandsByEmailAsync(string email)
    {
        var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == email);

        if (customer == null)
        {
            return new List<ErrandEntity>();
        }
        else
        {
            var errands = await _context.Errand
                .Include(e => e.StatusAndComment)
                .Where(e => e.CustomerId == customer.Id)
                .ToListAsync();

            return errands;
        }
    }


    //Save an errand
    public static void SaveErrand(CustomerEntity customer, ErrandEntity errand)
    {
        var _errand = new ErrandEntity 
        {
            ErrandDescription = errand.ErrandDescription,
            TimeStamp = DateTime.Now,
            CustomerId = customer.Id,
            StatusAndComment = new StatusAndCommentEntity
                {
                    ErrandId = errand.Id,
                    Status = Status.NotStarted,
                    Comment = "",
                    TimeStamp = DateTime.Now
            }
        };

        _context.Add(_errand);
        _context.SaveChanges();
    }


}

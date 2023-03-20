using Arendehanteringssystem.Contexts;
using Arendehanteringssystem.Models;
using Arendehanteringssystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Status = Arendehanteringssystem.Models.Entities.Status;

namespace Arendehanteringssystem.Services;

public class CustomerService
{
    private static readonly DataContext _context = new();
    public static async Task SaveUserAndErrandAsync(CustomerModel customer, ErrandModel errand)
    {
        var _customer = new CustomerEntity
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            Errands = new List<ErrandEntity>
            {
                new ErrandEntity
                {
                    CustomerId = errand.CustomerId,
                    ErrandDescription = errand.ErrandDescription,
                    TimeStamp = DateTime.Now,
                    StatusAndComment = new StatusAndCommentEntity
                    {
                        ErrandId = errand.Id,
                        Status = Status.NotStarted,
                        Comment = "",
                        TimeStamp = DateTime.Now
                    }
                }
            }
        };

        _context.Add(_customer);
        await _context.SaveChangesAsync();
    }

    public static CustomerEntity GetUserByEmail(string email)
    {
        var customer = _context.Customer.FirstOrDefault(x => x.Email == email);

        if (customer != null)
            return customer;
        else
            return null!;
        
    }





}

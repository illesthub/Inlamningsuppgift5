using Arendehanteringssystem.Contexts;
using Arendehanteringssystem.Models.Entities;

namespace Arendehanteringssystem.Services;

public class StatusAndCommentService
{
    private static readonly DataContext _context = new();
    public static void SaveUpdatedStatusAndComment(ErrandEntity errand)
    {
        var statusAndCommentEntity = new StatusAndCommentEntity
        {
            ErrandId = errand.Id,
            Status = errand.StatusAndComment.Status,
            Comment = errand.StatusAndComment.Comment,
            TimeStamp = DateTime.Now
        };

        _context.Update(statusAndCommentEntity);
        _context.SaveChangesAsync();
    }
}

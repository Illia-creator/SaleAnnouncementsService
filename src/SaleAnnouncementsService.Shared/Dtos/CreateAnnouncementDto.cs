using System.Reflection;

namespace SaleAnnouncementsService.Shared.Dtos;

public class CreateAnnouncementDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string PhotoLinks { get; set; }
}

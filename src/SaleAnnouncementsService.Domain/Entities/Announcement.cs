namespace SaleAnnouncementsService.Domain.Entities;

public class Announcement
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Photo Photo { get; set; }
    public DateTime Created { get; set; }
}

namespace SaleAnnouncementsService.Domain.Entities;

public class Announcement
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string PhotoLinks { get; set; }
    public DateTime Created { get; set; }
    public Seller Seller { get; set; }
    public Guid SellerId { get; set; }
}

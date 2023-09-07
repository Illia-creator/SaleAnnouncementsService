namespace SaleAnnouncementsService.Domain.Entities;

public class Seller
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public List<Announcement> Announcements { get; set; }   
}

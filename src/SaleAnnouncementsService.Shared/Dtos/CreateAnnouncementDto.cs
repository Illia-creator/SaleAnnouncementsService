using System.Reflection;

namespace SaleAnnouncementsService.Shared.Dtos;

public class CreateAnnouncementDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string MainPhotoLink { get; set; }
    public string SecondPhotoLink { get; set; }
    public string ThirdPhotoLink { get; set; }
}

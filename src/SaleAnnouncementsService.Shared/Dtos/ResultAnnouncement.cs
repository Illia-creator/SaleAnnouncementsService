namespace SaleAnnouncementsService.Shared.Dtos;

public class ResultAnnouncement : ResultAnnouncementInList
{
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public string MainPhotoLink { get; set; }
    public string SecondPhotoLink { get; set; }
    public string ThirdPhotoLink { get; set; }
    public DateTime Created { get; set; }
}

namespace SaleAnnouncementsService.Shared.Dtos;

public class ResultAnnouncement : ResultAnnouncementInList
{
    public string Description { get; set; }
    public string SeckondPhotoLink { get; set; }
    public string ThirdPhotoLink { get; set; }
    public DateTime Created { get; set; }
}

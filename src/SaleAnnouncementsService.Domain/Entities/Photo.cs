namespace SaleAnnouncementsService.Domain.Entities
{
    public class Photo
    {
        public Guid Id { get; set; }
        public Guid AnnoncementId { get; set; }
        public Announcement Annoncement { get; set; }
        public string MainPhotoLink { get; set; }
        public string SeckondPhotoLink { get; set; }
        public string ThirdPhotoLink { get; set; }

    }
}

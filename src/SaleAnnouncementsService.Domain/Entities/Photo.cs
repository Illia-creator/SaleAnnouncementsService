﻿using SaleAnnouncementsService.Shared.Dtos;

namespace SaleAnnouncementsService.Domain.Entities;

public class Photo
{
    public Guid Id { get; set; }
    public Guid AnnoncementId { get; set; }
    public Announcement Annoncement { get; set; }
    public string MainPhotoLink { get; set; }
    public string SecondPhotoLink { get; set; }
    public string ThirdPhotoLink { get; set; }

    public Photo()
    {
            
    }

    public Photo(Guid createdAnnoncementId, CreateAnnouncementDto createAnnouncementDto)
    {
        Id = Guid.NewGuid();
        AnnoncementId = createdAnnoncementId;
        MainPhotoLink = createAnnouncementDto.MainPhotoLink;
        SecondPhotoLink = createAnnouncementDto.SecondPhotoLink;
        ThirdPhotoLink = createAnnouncementDto.ThirdPhotoLink;
    }
}

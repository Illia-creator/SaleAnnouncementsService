using Mapster;
using SaleAnnouncementsService.Domain.Entities;
using SaleAnnouncementsService.Shared.Dtos;

namespace SaleAnnouncementsService.Application.Mappers;

public class RegisterMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Announcement, ResultAnnouncementInList>();
        config.NewConfig<Photo, ResultAnnouncementInList>();


        config.NewConfig<Announcement, ResultAnnouncement>();
        config.NewConfig<Photo, ResultAnnouncement>();
    }
}

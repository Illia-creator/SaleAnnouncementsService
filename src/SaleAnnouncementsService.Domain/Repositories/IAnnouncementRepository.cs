using SaleAnnouncementsService.Shared.Dtos;

namespace SaleAnnouncementsService.Domain.Repositories;

public interface IAnnouncementRepository
{
    Task<List<ResultAnnouncementInList>> GetAll(SortingDto sortingDto);
    Task<ResultAnnouncement> GetFullInfo(Guid id);
    Task<ResultAnnouncement> Create(CreateAnnouncementDto createDto);
}

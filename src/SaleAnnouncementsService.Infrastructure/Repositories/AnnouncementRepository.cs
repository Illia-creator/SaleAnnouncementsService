using Mapster;
using Microsoft.EntityFrameworkCore;
using SaleAnnouncementsService.Domain.Entities;
using SaleAnnouncementsService.Domain.Repositories;
using SaleAnnouncementsService.Infrastructure.DbContexts;
using SaleAnnouncementsService.Shared.Dtos;
using SaleAnnouncementsService.Shared.Exceptions;
using System.Diagnostics;
using System.Linq;
using System.Xml.XPath;

namespace SaleAnnouncementsService.Infrastructure.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly SaleAnnouncementsServiceDbContext _context;

        public AnnouncementRepository(SaleAnnouncementsServiceDbContext context)
        {
            _context = context;
        }

        public async Task<ResultAnnouncement> Create(CreateAnnouncementDto createDto)
        {

            var newAnnouncement = Announcement.Init(createDto);

            var newPhotos = new Photo(newAnnouncement.Id, createDto);

            _context.Announcements.Add(newAnnouncement);
            _context.Photos.Add(newPhotos);

            await _context.SaveChangesAsync();

            var result = new ResultAnnouncement();

            newAnnouncement.Adapt(result);
            newPhotos.Adapt(result);

            return result  ;
        }

        public async Task<List<ResultAnnouncementInList>> GetAll(SortingDto sortingDto)
        {
            var result = new List<ResultAnnouncementInList>();

            var announcements = await _context.Announcements.Include(x => x.Photo).AsNoTracking().ToListAsync();

            foreach (var announcement in announcements)
            {
                var timeResult = new ResultAnnouncementInList();

                announcement.Adapt(timeResult);
                announcement.Photo.Adapt(timeResult);

                result.Add(timeResult);
            }

            return result;
        }

        public async Task<ResultAnnouncement> GetFullInfo(Guid id)
        {
            var announcement = await _context.Announcements.FirstOrDefaultAsync(x => x.Id == id);

            if (announcement == null)
                throw new CustomException(ExceptionCodes.ValueIsNullOrEmpty,
                    $"Annoncement with id: {id} not found");

            var photos = await _context.Photos.FirstOrDefaultAsync(x => x.AnnoncementId == announcement.Id);

            var result = new ResultAnnouncement();

            photos.Adapt(result);
            announcement.Adapt(result);
            
            return result;
        }
    }
}

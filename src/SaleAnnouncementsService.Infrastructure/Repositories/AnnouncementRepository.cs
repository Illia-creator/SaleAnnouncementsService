using Mapster;
using Microsoft.EntityFrameworkCore;
using SaleAnnouncementsService.Domain.Entities;
using SaleAnnouncementsService.Domain.Repositories;
using SaleAnnouncementsService.Infrastructure.DbContexts;
using SaleAnnouncementsService.Shared.Dtos;
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

        public Task<ResultAnnouncement> Create(CreateAnnouncementDto createDto)
        {
            if (createDto == null)
                throw new Exception("Empty Announcement Creating");

                if (createDto.Title == null || createDto.Title.Length > 200)
                    throw new Exception("Title should be between 0 and 200 symbols");

                if (createDto.Description.Length > 200)
                    throw new Exception("Deskription should be between 0 and 1000 symbols");

                if (createDto.Price == null || createDto.Price < 0)
                    throw new Exception("You should Write price!");



            var newAnnouncement = new Announcement()
            {
                Id = Guid.NewGuid(),
                Title = createDto.Title,
                Description = createDto.Description,
                Price = createDto.Price,
                Created = DateTime.UtcNow
            };

            var newPhotos = new Photo()
            {
                Id = Guid.NewGuid(),
                AnnoncementId = newAnnouncement.Id,
                MainPhotoLink = createDto.MainPhotoLink,
                SeckondPhotoLink = createDto.SeckondPhotoLink,  
                ThirdPhotoLink = createDto.ThirdPhotoLink
            };


            _context.Announcements.Add(newAnnouncement);
            _context.Photos.Add(newPhotos);
            _context.SaveChanges();

            var result = new ResultAnnouncement();

            newAnnouncement.Adapt(result);
            newPhotos.Adapt(result);

            return Task.FromResult(result);
        }

        public Task<List<ResultAnnouncementInList>> GetAll(SortingDto sortingDto)
        {
            var announcements = _context.Announcements.ToList();
            var photos = _context.Photos;

            var result = new List<ResultAnnouncementInList>();  

            foreach (var announcement in announcements)
            {
                var photo = photos.FirstOrDefault(x => x.AnnoncementId == announcement.Id);

                var timeResult = new ResultAnnouncementInList();

                announcement.Adapt(timeResult);
                photo.Adapt(timeResult);

                result.Add(timeResult);
            }

            return Task.FromResult(result);

        }

        public async Task<ResultAnnouncement> GetFullInfo(Guid id)
        {
            var announcement = await _context.Announcements.FirstOrDefaultAsync(x => x.Id == id);

            if (announcement == null)
                throw new Exception($"Announcement with id {id} not found");

            var photos = await _context.Photos.FirstOrDefaultAsync(x => x.AnnoncementId == announcement.Id);

            var result = new ResultAnnouncement();

            announcement.Adapt(result);
            photos.Adapt(result);

            return result;
        }
    }
}

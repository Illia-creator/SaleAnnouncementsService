using Microsoft.EntityFrameworkCore;
using SaleAnnouncementsService.Domain.Entities;
using SaleAnnouncementsService.Domain.Repositories;
using SaleAnnouncementsService.Infrastructure.DbContexts;
using SaleAnnouncementsService.Shared.Dtos;
using System.Diagnostics;
using System.Linq;

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

            var seller = _context.Sellers.FirstOrDefault();

            var newAnnouncement = new Announcement()
            {
                Id = Guid.NewGuid(),
                Title = createDto.Title,
                Description = createDto.Description,
                Price = createDto.Price,
                PhotoLinks = createDto.PhotoLinks,
                Created = DateTime.UtcNow,
                SellerId = seller.Id
            };

            _context.Announcements.Add(newAnnouncement);
            _context.SaveChanges();

            var result = new ResultAnnouncement()
            {
                Id = newAnnouncement.Id,
                Title = newAnnouncement.Title,
                Price = newAnnouncement.Price,
                MainPhotoLink = newAnnouncement.PhotoLinks,
                SellerName = seller.Name,
                SellerPhoneNumber = seller.PhoneNumber
            };

            return Task.FromResult(result);
        }

        public Task<List<ResultAnnouncementInList>> GetAll(SortingDto sortingDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultAnnouncement> GetFullInfo(Guid id)
        {
            var announcement = await _context.Announcements.FirstOrDefaultAsync(x => x.Id == id);

            if (announcement == null)
                throw new Exception($"Announcement with id {id} not found");

            var seller = await _context.Sellers.FirstOrDefaultAsync(x => x.Id == id);

            var result = new ResultAnnouncement()
            {
                Id = announcement.Id,
                Title = announcement.Title,
                Price = announcement.Price,
                MainPhotoLink = announcement.PhotoLinks,
                SellerName = seller.Name,
                SellerPhoneNumber = seller.PhoneNumber
            };

            return result;
        }
    }
}

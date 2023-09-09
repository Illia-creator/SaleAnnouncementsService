using SaleAnnouncementsService.Shared.Dtos;
using SaleAnnouncementsService.Shared.Exceptions;

namespace SaleAnnouncementsService.Domain.Entities;

public class Announcement
{
    private const int maxTitleLenght = 200;
    private const int maxDescriptionLenght = 200;
    private const int minPrice = 0;

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public Photo Photo { get; set; }
    public DateTime Created { get; set; }

    public Announcement()
    {
            
    }

    public Announcement(CreateAnnouncementDto createDto)
    {
        Id = Guid.NewGuid();
        Title = createDto.Title;
        Description = createDto.Description;
        Price = createDto.Price;
        Created = DateTime.UtcNow;
    }

    public static Announcement Init(CreateAnnouncementDto createDto)
    {
        if (string.IsNullOrWhiteSpace(createDto.Title))
            throw new CustomException(ExceptionCodes.ValueIsNullOrEmpty,
                $"Title: {createDto.Title}");

        if (createDto.Title.Length > maxTitleLenght)
            throw new CustomException(ExceptionCodes.ValueIsIncorrectRange,
               $"Title: {createDto.Title} is greater than maxLength {maxTitleLenght}");

        if (createDto.Description.Length > maxTitleLenght)
            throw new CustomException(ExceptionCodes.ValueIsIncorrectRange,
               $"Title: {createDto.Description} is greater than maxLength {maxDescriptionLenght}");

        if (createDto.Price < minPrice)
            throw new CustomException(ExceptionCodes.ValueIsIncorrectRange,
                $"Price: {createDto.Price} is less than minPrice {minPrice}");

        return new Announcement(createDto);
    }
}

using Microsoft.AspNetCore.Mvc;
using SaleAnnouncementsService.Domain.Entities;
using SaleAnnouncementsService.Domain.Repositories;
using SaleAnnouncementsService.Shared.Dtos;

namespace SaleAnnouncementsService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnnoncementsController : ControllerBase
{
    private readonly IAnnouncementRepository _repository;

    public AnnoncementsController(IAnnouncementRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("announcement")]
    public async Task<IActionResult> GettById(Guid Id)
    {
        var result = await _repository.GetFullInfo(Id);

        return Ok(result);
    }

    [HttpPost]
    [Route("create-announcement")]
    public async Task<IActionResult> CreateAnnouncement(CreateAnnouncementDto announcementDto)
    {
        var result = await _repository.Create(announcementDto);

        return Ok(result);
    }
}

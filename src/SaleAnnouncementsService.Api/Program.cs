using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using SaleAnnouncementsService.Application.Mappers;
using SaleAnnouncementsService.Domain.Repositories;
using SaleAnnouncementsService.Infrastructure.DbContexts;
using SaleAnnouncementsService.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SaleAnnouncementsServiceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
static TypeAdapterConfig GetConfigureMappingConfig()
{
    var config = new TypeAdapterConfig();

    new RegisterMapper().Register(config);

    return config;
}
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddSingleton(GetConfigureMappingConfig());
builder.Services.AddScoped<IMapper, ServiceMapper>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.Run();

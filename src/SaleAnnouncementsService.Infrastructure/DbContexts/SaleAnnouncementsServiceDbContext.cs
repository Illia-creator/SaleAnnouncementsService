using Microsoft.EntityFrameworkCore;
using SaleAnnouncementsService.Domain.Entities;

namespace SaleAnnouncementsService.Infrastructure.DbContexts;

public class SaleAnnouncementsServiceDbContext : DbContext
{
    public SaleAnnouncementsServiceDbContext(DbContextOptions<SaleAnnouncementsServiceDbContext> options) : base(options)
    {

    }

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Photo> Photos { get; set; }
     

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(a =>
        {
        a.HasKey(a => a.Id);

        a.HasOne(a => a.Photo)
        .WithOne(a => a.Annoncement)
        .HasForeignKey<Photo>(a => a.AnnoncementId);
        });

        modelBuilder.Entity<Photo>(b =>
        {
            b.HasKey(b => b.Id);

        });
    }
}

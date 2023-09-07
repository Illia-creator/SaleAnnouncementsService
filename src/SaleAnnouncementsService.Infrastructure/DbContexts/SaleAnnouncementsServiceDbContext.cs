using Microsoft.EntityFrameworkCore;
using SaleAnnouncementsService.Domain.Entities;

namespace SaleAnnouncementsService.Infrastructure.DbContexts;

public class SaleAnnouncementsServiceDbContext : DbContext
{
    public SaleAnnouncementsServiceDbContext(DbContextOptions<SaleAnnouncementsServiceDbContext> options) : base(options)
    {

    }

    public DbSet<Announcement> Announcements { get; set; }
    public DbSet<Seller> Sellers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(a =>
        {
            a.HasKey(a => a.Id);
        });

        modelBuilder.Entity<Seller>(s =>
        {
            s.HasKey(s => s.Id);

            s.HasMany(s => s.Announcements)
            .WithOne(s => s.Seller)
            .HasForeignKey(s => s.Id);
        });

    }
}

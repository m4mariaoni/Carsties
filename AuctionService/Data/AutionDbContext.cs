using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;
public class AutionDbContext : DbContext
{
    public AutionDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Auction> Auctions { get; set; }
}

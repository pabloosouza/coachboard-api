using Domain.Careers;
using Domain.Members;
using Domain.Players;
using Domain.Teams;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Member> Members { get; }
    public DbSet<Career> Careers { get; }
    public DbSet<Team> Teams { get; }
    public DbSet<Player> Players { get; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
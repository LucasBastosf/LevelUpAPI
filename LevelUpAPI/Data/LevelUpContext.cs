using Microsoft.EntityFrameworkCore;
using LevelUpAPI.Models;

namespace LevelUpAPI.Data
{
    public class LevelUpContext : DbContext
    {
        public LevelUpContext(DbContextOptions<LevelUpContext> options) : base(options) { }

        public DbSet<Game> Games { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace RE4CharacterAPI.Models
{
    public class RE4CharacterAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public RE4CharacterAPIDBContext(DbContextOptions<RE4CharacterAPIDBContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("RE4Character");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Organization> Organizations { get; set; } = null!;
    }
}

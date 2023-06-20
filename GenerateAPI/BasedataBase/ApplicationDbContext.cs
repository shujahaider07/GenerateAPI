using Entities;
using Microsoft.EntityFrameworkCore;

namespace GenerateAPI.BasedataBase
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }


        public DbSet<Card> Cards { get; set; }
        public DbSet<CardCategory> CardCategory { get; set; }
    }
}

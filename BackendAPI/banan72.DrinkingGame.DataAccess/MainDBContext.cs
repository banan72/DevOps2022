using Microsoft.EntityFrameworkCore;

namespace banan72.DrinkingGame.DataAccess
{
    public class MainDBContext: DbContext
    {
        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options)
        {
            
        }
        
        public virtual DbSet<PlayerEntity> Player { get; set; }
        
    }
}
using Microsoft.EntityFrameworkCore;
using MVCtest.Models;

namespace MVCtest.Data
{
    public class BTCDBContext:DbContext
    {
        public BTCDBContext(DbContextOptions<BTCDBContext>options):base(options) {
        
            
        }
        public DbSet<BTC> BTCs { get; set; }
        

        
    }
}

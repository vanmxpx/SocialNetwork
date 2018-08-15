using Microsoft.EntityFrameworkCore;
using SocialNetwork;

namespace SocialNetworkTests
{
    public class DbContextCreator
    {
        private static ShortyContext context;
        public static ShortyContext GetDbContext()
        {
            if(context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ShortyContext>();
                optionsBuilder.UseInMemoryDatabase(databaseName : "shorty_test");  
                context = new ShortyContext(optionsBuilder.Options);
            }
            return context;
        }
    }
}
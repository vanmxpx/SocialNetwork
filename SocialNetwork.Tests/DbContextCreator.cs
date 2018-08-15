using Microsoft.EntityFrameworkCore;
using SocialNetwork;

namespace SocialNetwork.Tests
{
    public class DbContextCreator
    {
        private static ShortyContext context;
        public static ShortyContext GetDbContext()
        {
            if(context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ShortyContext>();
                optionsBuilder.UseMySql("server=localhost;port=3306;database=shorty;username=root;password=root");  
                context = new ShortyContext(optionsBuilder.Options);
            }
            return context;
        }
    }
}
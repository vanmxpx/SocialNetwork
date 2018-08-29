using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;

namespace SocialNetwork.Tests
{
    public class DbContextCreator
    {
        private static ShortyContext context;
        private static Initializer initializer;
        public  static ShortyContext GetDbContext()
        {
            if(context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ShortyContext>();
                optionsBuilder.UseMySql("server=localhost;port=3306;database=shorty_test;username=root;password=NEWPASSWORD");  
                context = new ShortyContext(optionsBuilder.Options);
                initializer = new Initializer(context);
            }
            RefreshDBData();
            return context;
        }
        private static async void RefreshDBData()
        {
            await initializer.DeleteAll();
            await initializer.Seed();
            await context.SaveChangesAsync();
        }
    }
}
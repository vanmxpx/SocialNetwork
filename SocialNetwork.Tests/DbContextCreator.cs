using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SocialNetwork;

namespace SocialNetwork.Tests
{
    public class DbContextCreator
    {
        private ShortyContext context;
        private static Initializer initializer;
        public   ShortyContext GetDbContext()
        {

                var optionsBuilder = new DbContextOptionsBuilder<ShortyContext>();
                optionsBuilder.UseMySql("server=localhost;port=3306;database=shorty_test;username=root;password=root");  
                context = new ShortyContext(optionsBuilder.Options);
                initializer = new Initializer(context);
          
            RefreshDBData();
            return context;
        }
        private  async void RefreshDBData()
        {
            initializer.DeleteAll().Wait();
            initializer.Seed(true).Wait();
            await context.SaveChangesAsync();
        }
    }
}
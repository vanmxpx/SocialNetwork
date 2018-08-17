using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork
{
    public class TestIntitializer
    {
        private ShortyContext SC;
        public TestIntitializer(ShortyContext SC)
        {
            this.SC = SC;
        }
		
		public async Task AddDataToTestDB()
        {			
            string sqlDatabaseCreate = File.ReadAllText(
                Directory.GetCurrentDirectory() + "\\DBComponents\\TestData\\shorty_test.sql");
			SC.Database.ExecuteSqlCommand(sqlDatabaseCreate);
            
            await SC.SaveChangesAsync();
        }
    }
}
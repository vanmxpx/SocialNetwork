using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Repositories.GenericRepository;

namespace SocialNetwork.Repositories
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(ShortyContext Context) : base(Context)
        {
        }
        public async Task<Profile> GetById(int id)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Profile> GetByCredentialId(int id)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.CredenitialRef == id);
        }
        public async Task<Profile> GetByLogin(string login)
        {
            return await Context.Set<Profile>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Login == login);
        }
        public async Task<List<Profile>> GetByNameAndLastName(string name, string lastName)
        {
            return await Context.Profiles
                .Where(profile => profile.Name.StartsWith(name) && profile.LastName.StartsWith(lastName))
                .ToListAsync();
        }

        public void Delete(Profile profile)
        {
            Context.Set<Profile>().Remove(profile);
        }

        public async Task<List<Profile>> GetSubscribersById(int idBloger)
        {
            List<Followings> followings = await Context.Set<Followings>()
                .AsNoTracking()
                .Where(e => e.BloggerRef == idBloger)
                .Include(s => s.Subscriber)
                .ToListAsync();
            List<Profile> subscribers = new List<Profile>();
            if (followings != null)
            {
                foreach (Followings following in followings)
                {
                    subscribers.Add(following.Subscriber);
                }
            }
            return subscribers;
        }
        public async Task<List<Profile>> GetBloggersById(int idSuscriber)
        {
            List<Followings> followings = await Context.Set<Followings>()
                .AsNoTracking()
                .Where(e => e.SubscriberRef == idSuscriber)
                .Include(b => b.Blogger)
                .ToListAsync();
            List<Profile> bloggers = new List<Profile>();
            if (followings != null)
            {
                foreach (Followings following in followings)
                {
                    bloggers.Add(following.Blogger);
                }
            }
            return bloggers;
        }
    }
}

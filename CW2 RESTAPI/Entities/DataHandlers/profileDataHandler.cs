using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CW2_RESTAPI.Entities.DataHandlers
{
    public class profileDataHandler : IRepository<Profile>
    {
        Profile IRepository<Profile>.Get(string email)
        {
            using var context = new Comp2001AbraamContext();
            var profile = context.Profiles.Where(p => p.Email == email).Include(b => b.Bool).ThenInclude(l => l.Location).ToList();
            var result = context.Profiles.Find(profile);
            return result;
        }

        public void Delete(Profile entity)
        {
            using var context = new Comp2001AbraamContext();
            var profile = context.Profiles.Find(entity);
            if (profile != null)
            {
                context.Profiles.Remove(profile);
                context.SaveChanges();
            }
        }

        void IRepository<Profile>.Add(Profile entity)
        {
            using var context = new Comp2001AbraamContext();
            context.Profiles.Add(entity);
            context.SaveChanges();
        }

        void Repository.IRepository<Profile>.Update(Profile entityToUpdate, Profile entity)
        {
            using var context = new Comp2001AbraamContext();
            entityToUpdate = context.Profiles.
                Include(b => b.Bool).
                ThenInclude(l => l.Location).
                Single(e => e.Email == entityToUpdate.Email);
            {
                entityToUpdate.FirstName = entity.FirstName;
                entityToUpdate.LastName = entity.LastName;
                entityToUpdate.AboutMe = entity.AboutMe;
                entityToUpdate.Height = entity.Height;
                entityToUpdate.Weight = entity.Weight;
                entityToUpdate.Birthday = entity.Birthday;
                var addedUnits = entityToUpdate.Bool.Except(entity.Bool).ToList();
                var addedActivityTimePreference = entityToUpdate.Bool.Except(entity.Bool).ToList();
                var addedMemberLocation = entityToUpdate.Location.Except(entity.Location).ToList();
                context.SaveChanges();
            }
        }
    }
}

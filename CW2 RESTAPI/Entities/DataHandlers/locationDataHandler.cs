using Microsoft.EntityFrameworkCore;

namespace CW2_RESTAPI.Entities.DataHandlers
{
    public class locationDataHandler
    {
        void Repository.IRepository<Location>.Update(Location entityToUpdate, Location entity)
        {
            using var context = new Comp2001AbraamContext();
            entityToUpdate = context.Profiles.Include(b => b.Bool).ThenInclude(l => l.Location).Single(e => e.Email == entityToUpdate.Email);
            {
                entityToUpdate.MemberLocation = entity.MemberLocation;
                context.SaveChanges();
            }
        }
    }
}

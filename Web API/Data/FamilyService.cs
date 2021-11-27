using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace FileData
{
    public class FamilyService : IFamilyService
    {

        private FamilyDbContext db { get; set; }

        public FamilyService(FamilyDbContext db)
        {
            this.db = db;
        }
        public async Task AddFamily(Family family)
        {
            await this.db.Families.AddAsync(family);
            await this.db.SaveChangesAsync();
        }

        public async Task<Adult> AddAdultToFamily(int id, Adult adult)
        {
            adult.FamilyId = id;
            await this.db.Adults.AddAsync(adult);
            await this.db.SaveChangesAsync();
            return db.Adults.OrderBy(ad => ad.Id).Last();
        }

        public async Task<Child> AddChildToFamily(int id, Child child)
        {
            child.FamilyId = id;
            await this.db.Children.AddAsync(child);
            await this.db.SaveChangesAsync();
            return db.Children.OrderBy(ad => ad.Id).Last();
        }

        public async Task<Pet> AddPetToFamily(int id, Pet pet)
        {
            pet.FamilyId = id;
            await this.db.Pet.AddAsync(pet);
            await this.db.SaveChangesAsync();
            return db.Pet.OrderBy(ad => ad.Id).Last();
        }

        public async Task<Interest> AddInterest(int id, Interest interest)
        {
            interest.ChildId = id;
            Child ch = await db.Children.FirstOrDefaultAsync(c => c.Id == id);
            ch.Interests.Add(interest);
            await db.SaveChangesAsync();
            return interest;
        }
        public async Task EditFamily(Family family)
        {
            db.Families.Update(family);
            await db.SaveChangesAsync();
        }
        public async Task<DbSet<Family>> GetFamilies()
        {
            DbSet<Family> families = db.Families;
            foreach (var fam in families)
            {
                fam.Adults = await GetAdults(fam.Id);
                fam.Children = await GetChildren(fam.Id);
                fam.Pets = await GetPets(fam.Id);
            }
            return families;
        }

        public async Task<IList<Adult>> GetAdults(int id)
        {
            return db.Adults.Include(j => j.JobTitle).Where(ad => ad.FamilyId == id).ToList<Adult>();
        }

        public async Task<IList<Pet>> GetPets(int id)
        {
            return db.Pet.Where(ad => ad.FamilyId == id).ToList<Pet>();
        }

        public async Task<IList<Adult>> GetAllAdults()
        {
            return db.Adults.Include(j => j.JobTitle).ToList<Adult>();
        }

        public async Task<Adult> GetAdult(int id)
        {
            return await db.Adults.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Child> GetChild(int id)
        {
            return await db.Children.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IList<Child>> GetChildren(int id)
        {
            return db.Children
            .Where(c => c.FamilyId == id)
            .Include(c => c.Interests)
            .ToList<Child>();
        }

        public async Task RemoveFamily(int id)
        {
            Family toRemove = await this.db.Families.FirstOrDefaultAsync(f => f.Id == id);
            toRemove.Adults = await GetAdults(id);
            toRemove.Children = await GetChildren(id);
            toRemove.Pets = await GetPets(id);
            /*db.Entry(toRemove).State = EntityState.Unchanged;
            db.Families.Remove(toRemove);*/
            this.db.Families.RemoveRange(toRemove);
            await this.db.SaveChangesAsync();
        }




    }
}
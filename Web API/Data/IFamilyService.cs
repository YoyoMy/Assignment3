using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;
namespace FileData
{
    public interface IFamilyService
    {
        public Task<DbSet<Family>> GetFamilies();
        public Task AddFamily(Family family);
        public Task EditFamily(Family family);
        public Task RemoveFamily(int id);

        Task<IList<Adult>> GetAdults(int id);
        Task<IList<Pet>> GetPets(int id);
        Task<Adult> AddAdultToFamily(int id, Adult adult);
        Task<Child> AddChildToFamily(int id, Child child);
        Task<Pet> AddPetToFamily(int id, Pet pet);
        Task<IList<Adult>> GetAllAdults();
        Task<Interest> AddInterest(int id, Interest interest);
        Task<Child> GetChild(int id);
        //Task EditAdult(Adult adult);
        Task<Adult> GetAdult(int id);
    }
}
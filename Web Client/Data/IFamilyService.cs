using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
namespace Data
{
    public interface IFamilyService
    {
        public Task<IList<Family>> GetFamilies();
        public Task AddFamily(Family family);
        public Task EditFamily(Family family);
        public Task RemoveFamily(Family family);
        public IList<Family> Families {get;set;}
        public Task AddAdultToFamily(int id, Adult adult);
        public Task AddChildToFamily(int id, Child child);
        public Task AddPetToFamily(int id, Pet pet);
        public Task<Child> GetChild(int id);
        Task<Adult> GetAdult(int id);
        public Task<IList<Adult>> GetAdultsAsync();
        public Task AddInterestToChild(int famId, int id, Interest interest);

    }
}
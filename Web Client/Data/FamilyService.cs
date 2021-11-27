using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Model;
namespace Data
{
    public class FamilyService : IFamilyService
    {
        HttpClientCommunicator httpClientCommunicator{get;set;}
        string url = "Family";

        public FamilyService(HttpClientCommunicator httpClientCommunicator)
        {
            this.httpClientCommunicator = httpClientCommunicator;
        }

        public IList<Family> Families {get;set;}

        public async Task AddFamily(Family family)
        {
            await httpClientCommunicator.AddAsync(family, url);
        }

        public async Task AddAdultToFamily(int id, Adult adult)
        {
            string adultAsJson =  await httpClientCommunicator.AddAsync(adult, url+$"/{id}/Adult");
            Adult ad = JsonSerializer.Deserialize<Adult>(adultAsJson);
            Families.FirstOrDefault(f => f.Id == id).Adults.Add(ad);
        }

        public async Task AddChildToFamily(int id, Child child)
        {
            string childAsJson =  await httpClientCommunicator.AddAsync(child, url+$"/{id}/Child");
            Child ch = JsonSerializer.Deserialize<Child>(childAsJson);
            Families.FirstOrDefault(f => f.Id == id).Children.Add(ch);
        }

        public async Task AddPetToFamily(int id, Pet pet)
        {
            string petAsJson =  await httpClientCommunicator.AddAsync(pet, url+$"/{id}/Pet");
            Pet p = JsonSerializer.Deserialize<Pet>(petAsJson);
            Families.FirstOrDefault(f => f.Id == id).Pets.Add(p);
        }

        public async Task EditFamily(Family family)
        {
            await httpClientCommunicator.PutAsync(family, url+$"/{family.Id}");
        }

        public async Task<IList<Family>> GetFamilies()
        {
            string result = await httpClientCommunicator.GetAsync(url);
            List<Family> families = JsonSerializer.Deserialize<List<Family>>(result);
            Families = families;
            return Families;
        }

        public async Task RemoveFamily(Family family)
        {
            await httpClientCommunicator.DeleteAsync(url+$"/{family.Id}");
        }

        public async Task<Child> GetChild(int id)
        {
            string result = await httpClientCommunicator.GetAsync($"Child/{id}");
            Child child = JsonSerializer.Deserialize<Child>(result);
            return child;
        }
        public async Task AddInterestToChild(int famId, int id, Interest interest)
        {
           string interestAsJson =  await httpClientCommunicator.AddAsync(interest, $"/Child/{id}/Interest");
           Interest intr = JsonSerializer.Deserialize<Interest>(interestAsJson);
            Families.FirstOrDefault(fam => fam.Id == famId)
            .Children.FirstOrDefault(c => c.Id == id)
            .Interests.Add(intr);
        }
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            string result = await httpClientCommunicator.GetAsync("Adult");
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result);
            return adults;
        }

         public async Task<Adult> GetAdult(int id)
        {
            string result = await httpClientCommunicator.GetAsync($"Adult/{id}");
            Adult ad = JsonSerializer.Deserialize<Adult>(result);
            return ad;
        }
    }
}
using BoxProblem.Data;
using BoxProblem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Services
{
    public class BoxService
    {
        private BoxRepository repository;
        public BoxService(ApplicationDbContext context)
        {
            repository = new BoxRepository(context);
        }

        public List<BoxInventory> GetAllBoxes()
        {
            return repository.GetAllBoxes();
        }

        public List<BoxInventory> FilterByWeight(int MinWeight, int MaxWeight)
        {
            return repository.FilterByWeight(MinWeight, MaxWeight);
        }

        public List<BoxInventory> FilterByVolume(int MinVolume, int MaxVolume)
        {
            return repository.FilterByVolume(MinVolume, MaxVolume);
        }
    }
}

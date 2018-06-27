using BoxProblem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private ApplicationDbContext dbContext;
        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }

        public List<BoxInventory> FilterByWeight(int MinWeight, int MaxWeight)
        {
            List<BoxInventory> Boxes = dbContext.Boxes.Where(b => b.Weight <= MaxWeight && b.Weight >= MinWeight).ToList();
            return Boxes;
        }

        public List<BoxInventory> FilterByVolume(int MinVolume, int MaxVolume)
        {
            List<BoxInventory> Boxes = dbContext.Boxes.Where(b => b.Volume <= MaxVolume && b.Volume >= MinVolume).ToList();
            return Boxes;
        }

        public List<BoxInventory> FilterByCost(int MinCost, int MaxCost)
        {
            List<BoxInventory> Boxes = dbContext.Boxes.Where(b => b.Cost <= MaxCost && b.Cost >= MinCost).ToList();
            return Boxes;
        }

        public List<BoxInventory> FilterByLiquidProof(bool isLiquidProof)
        {
            List<BoxInventory> Boxes = dbContext.Boxes.Where(b => b.CanHoldLiquid == isLiquidProof).ToList();
            return Boxes;
        }
    }
}

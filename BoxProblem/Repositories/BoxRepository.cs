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

        public IQueryable<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.AsQueryable();
        }

        public IQueryable<BoxInventory> Filter(int? MinWeight, int? MaxWeight, int? MinVolume, int? MaxVolume, bool? CanHold, bool? CantHold, bool? Either, int? MinCost, int? MaxCost)
        {
            IQueryable<BoxInventory> Filter = dbContext.Boxes.AsQueryable<BoxInventory>();

            if (MaxWeight != null)
            {
                if(MinWeight == null)
                {
                    Filter = Filter.Where(d => d.Weight >= 0 && d.Weight <= MaxWeight);
                }
                else
                {
                    Filter = Filter.Where(d => d.Weight >= MinCost && d.Weight <= MaxWeight);
                }
            }
            if (MaxVolume != null)
            {
                if(MinVolume == null)
                {
                    Filter = Filter.Where(d => d.Volume >= 0 && d.Volume <= MaxVolume);
                }
                else
                {
                    Filter = Filter.Where(d => d.Volume >= MinVolume && d.Volume <= MaxVolume);
                }
            }
            if (CanHold == true)
            {
                Filter = Filter.Where(d => d.CanHoldLiquid == true);
            }
            if (CantHold == true)
            {
                Filter = Filter.Where(d => d.CanHoldLiquid == true);
            }
            if(MaxCost != null)
            {
                if(MinCost == null)
                {
                    Filter = Filter.Where(d => d.Cost >= 0 && d.Cost <= MaxCost);
                }
                else
                {
                    Filter = Filter.Where(d => d.Cost >= MinCost && d.Cost <= MaxCost);
                }
            }

            return Filter;
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

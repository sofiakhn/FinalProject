using BoxProblem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BoxProblem.Repositories
{
    public class BoxRepository
    {
        private ApplicationDbContext dbContext;
        public BoxRepository(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public BoxInventory GetBoxById(int id)
        {
            return dbContext.Boxes.Find(id);
        }

        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }

        public List<BoxInventory> Filter(FilterModel Filter)
        {
            if (Filter.MaxCost == null) Filter.MaxCost = int.MaxValue;
            if (Filter.MinCost == null) Filter.MinCost = 0;
            if (Filter.MaxVolume == null) Filter.MaxVolume = int.MaxValue;
            if (Filter.MinVolume == null) Filter.MinVolume = 0;
            if (Filter.MaxWeight == null) Filter.MaxWeight = int.MaxValue;
            if (Filter.MinWeight == null) Filter.MinWeight = 0;
            if (Filter.MaxInventory == null) Filter.MaxInventory = int.MaxValue;
            if (Filter.MinInventory == null) Filter.MinInventory = 0;

            if (Filter.CanHoldLiquid == null) return dbContext.Boxes.Where(b => b.Cost >= Filter.MinCost && b.Cost <= Filter.MaxCost && 
            b.Volume >= Filter.MinVolume && b.Volume <= Filter.MaxVolume && 
            b.Weight >= Filter.MinWeight && b.Weight <= Filter.MaxWeight && 
            b.InventoryCount >= Filter.MinInventory && b.InventoryCount <= Filter.MaxInventory).ToList();
            else return dbContext.Boxes.Where(b => b.Cost >= Filter.MinCost && b.Cost <= Filter.MaxCost &&
            b.Volume >= Filter.MinVolume && b.Volume <= Filter.MaxVolume &&
            b.Weight >= Filter.MinWeight && b.Weight <= Filter.MaxWeight &&
            b.InventoryCount >= Filter.MinInventory && b.InventoryCount <= Filter.MaxInventory &&
            b.CanHoldLiquid == Filter.CanHoldLiquid).ToList();
        }
        

    }
}

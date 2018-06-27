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

        public List<BoxInventory> GetCheaperBoxes(int maxCost)
        {
            return dbContext.Boxes.Where(b => b.Cost < maxCost).ToList();
        }
    }
}

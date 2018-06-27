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
    }
}

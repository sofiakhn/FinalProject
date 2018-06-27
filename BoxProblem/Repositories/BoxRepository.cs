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

        public void AddBox(BoxInventory toAdd)
        {
            dbContext.Boxes.Add(toAdd);
            dbContext.SaveChanges();
        }

        public void DeleteBox(BoxInventory toDelete)
        {
            dbContext.Boxes.Remove(toDelete);
            dbContext.SaveChanges();
        }

        public void SaveEdits(BoxInventory toSave)
        {
            dbContext.Entry(toSave).State = EntityState.Modified;;
            dbContext.SaveChanges();
        }
<<<<<<< HEAD

=======

        public List<BoxInventory> GetAllBoxes()
        {
            return dbContext.Boxes.ToList();
        }
>>>>>>> dev
    }
}

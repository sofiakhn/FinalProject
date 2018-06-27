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

        public BoxInventory GetBoxById(int id)
        {
            return repository.GetBoxById(id);
        }

        public void AddBox(BoxInventory toAdd){
            repository.AddBox(toAdd);
        }

        public void DeleteBox(BoxInventory toDelete){
            repository.DeleteBox(toDelete);
        }

        public void SaveEdits(BoxInventory toSave)
        {
            repository.SaveEdits(toSave);
        }

        public List<BoxInventory> GetAllBoxes()
        {
            return repository.GetAllBoxes();
        }
    }
}

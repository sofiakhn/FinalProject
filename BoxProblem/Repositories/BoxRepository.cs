﻿using BoxProblem.Data;
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


        public void AddBox(BoxInventory toAdd)
        {
            Boolean duplicate = false;
            if (toAdd.InventoryCount == 0)
                return;
            if (toAdd.Weight == 0)
                return;
            if (toAdd.Volume == 0)
                return;           
            if (toAdd.Weight < 0)
            {
                toAdd.Weight = Math.Abs(toAdd.Weight);
            }
            if (toAdd.Volume < 0)
            {
                toAdd.Volume = Math.Abs(toAdd.Volume);
            }
            if (toAdd.Cost < 0)
            {
                toAdd.Cost = Math.Abs(toAdd.Cost);
            }
            foreach (BoxInventory box in dbContext.Boxes)
            {
                if(toAdd.Weight==box.Weight && toAdd.Volume==box.Volume && toAdd.Cost==box.Cost && (toAdd.CanHoldLiquid == box.CanHoldLiquid)){
                    box.InventoryCount += toAdd.InventoryCount;
                    duplicate = true;
                }
            }
            if(!duplicate)
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
            int idChange = toSave.Id;
            BoxInventory changed = null;
            Boolean duplicate = false;
            if (toSave.InventoryCount == 0)
                return;
            if (toSave.Weight == 0)
                return;
            if (toSave.Volume == 0)
                return;
            if (toSave.Weight < 0)
            {
                toSave.Weight = Math.Abs(toSave.Weight);
            }
            if (toSave.Volume < 0)
            {
                toSave.Volume = Math.Abs(toSave.Volume);
            }
            if (toSave.Cost < 0)
            {
                toSave.Cost = Math.Abs(toSave.Cost);
            }          
            dbContext.Entry(toSave).State = EntityState.Modified;
            foreach (BoxInventory box in dbContext.Boxes)
            {
                if (toSave.Weight == box.Weight && toSave.Volume == box.Volume && toSave.Cost == box.Cost && (toSave.CanHoldLiquid == box.CanHoldLiquid) && toSave.Id!=box.Id)
                {
                    box.InventoryCount += toSave.InventoryCount;
                    duplicate = true;
                }
            }
            foreach (BoxInventory box in dbContext.Boxes)
            {
                if (toSave.Id == box.Id)
                    changed = box;
            }
            if (duplicate)
                dbContext.Boxes.Remove(changed);
            dbContext.SaveChanges();
        }     
    }
}

using CosmeticStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticStore.DataAccessLayer
{
    public class CosmeticDataAccess
    {
        readonly CosmeticDbContext db = new CosmeticDbContext();
            public void AddCosmetic(Cosmetic cosmetic)
            {
                    db.Cosmetics.Add(cosmetic);
                    db.SaveChanges();
            }

        public Cosmetic FindCosmetic(int? id)
        {
            return db.Cosmetics.Find(id);
        }

        public void RemoveCosmetic(Cosmetic cosmetic)
        {
            db.Cosmetics.Remove(cosmetic);
            db.SaveChanges();
        }

        public void EditCosmetic(EntityState entity, Cosmetic cosmetic)
        {
            db.Entry(cosmetic).State = entity;
            db.SaveChanges();
        }

        public DbSet<Cosmetic> ListCosmetic()
        {
            return db.Cosmetics;
        }
    }
}

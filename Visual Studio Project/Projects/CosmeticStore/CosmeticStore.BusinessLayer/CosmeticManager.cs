using CosmeticStore.DataAccessLayer;
using CosmeticStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticStore.BusinessLayer
{
    public class CosmeticManager
    {
        private readonly CosmeticDataAccess cosmeticDataAccess = new CosmeticDataAccess();
        public void AddCosmetic(Cosmetic cosmetic)
        {
            cosmeticDataAccess.AddCosmetic(cosmetic);
        }

        public Cosmetic FindCosmetic(int? id)
        {
            return cosmeticDataAccess.FindCosmetic(id);
        }

        public void RemoveUser(Cosmetic cosmetic)
        {
            cosmeticDataAccess.RemoveCosmetic(cosmetic);
        }

        public void EditUser(EntityState entityState, Cosmetic cosmetic)
        {
            cosmeticDataAccess.EditCosmetic(entityState, cosmetic);
        }
        public DbSet<Cosmetic> ListCosmetic()
        {
            return cosmeticDataAccess.ListCosmetic();
        }
    }
}

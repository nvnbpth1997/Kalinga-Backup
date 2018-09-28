using CosmeticStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticStore.Models
{
    public class CombinedModel
    {
        public User users { get; set; }
        public Cosmetic cosmetics { get; set; }
        public Favourite favourites  { get; set; }
    }
}

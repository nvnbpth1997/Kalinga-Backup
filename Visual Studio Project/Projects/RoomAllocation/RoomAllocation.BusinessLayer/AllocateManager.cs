using RoomAllocation.DataAccessLayer;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAllocation.BusinessLayer
{
   public class AllocateManager
    {
        readonly AllocateDataAccess allocateDataAccess = new AllocateDataAccess();
        public IEnumerable<CombinedModel> filteredUsers()
        {
            return allocateDataAccess.filteredUsers();
        }

        public IEnumerable<CombinedModel> filteredRooms(int? id)
        {
            return allocateDataAccess.filteredRooms(id);
        }

        public CombinedModel Details(int id, int id2)
        {
            return allocateDataAccess.Details(id, id2);
        }
    }
}

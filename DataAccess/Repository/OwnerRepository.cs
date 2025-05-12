using DataAccess.Common;
using DataAccess.Interface;
using Entities;

namespace DataAccess.Repository
{
    public class OwnerRepository : BaseRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(MainContext context) : base(context)
        {
        }
    }    
}

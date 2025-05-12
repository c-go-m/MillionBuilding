using DataAccess.Common;
using DataAccess.Interface;
using Entities;

namespace DataAccess.Repository
{
    public class PropertyRepository : BaseRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(MainContext context) : base(context)
        {
        }
    }    
}

using DataAccess.Common;
using DataAccess.Interface;
using Entities;

namespace DataAccess.Repository
{
    public class PropertyImageRepository : BaseRepository<PropertyImage>, IPropertyImageRepository
    {
        public PropertyImageRepository(MainContext context) : base(context)
        {
        }
    }
}

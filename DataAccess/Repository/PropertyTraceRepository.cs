using DataAccess.Common;
using DataAccess.Interface;
using Entities;

namespace DataAccess.Repository
{
    public class PropertyTraceRepository : BaseRepository<PropertyTrace>, IPropertyTraceRepository
    {
        public PropertyTraceRepository(MainContext context) : base(context)
        {
        }
    }
}

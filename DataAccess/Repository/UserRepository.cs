using DataAccess.Common;
using DataAccess.Interface;
using Entities;

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MainContext context) : base(context)
        {
        }
    }
}

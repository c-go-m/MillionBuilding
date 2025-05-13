using BusinessRules.Common;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;
using Utilities.ExtensionMethod;
using Utilities.Objects;

namespace BusinessRules.BusinessRules
{
    public class UserService : BaseBusinessRules<User, IUserRepository>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public override async Task<int?> CreateAsync(User entity)
        {
            entity.Password = entity.Password.Encript();
            return await base.CreateAsync(entity);
        }

        public override async Task<bool> UpdateAsync(User entity)
        {
            entity.Password = entity.Password.Encript();
            return await base.UpdateAsync(entity);
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return (await repository.GetAllAsync()).Select(u => new User
            {
                Id = u.Id,
                UserName = u.UserName
            }).ToList();
        }

        public override async Task<User?> GetByIdAsync(int id)
        {
            var user = await base.GetByIdAsync(id);
            return user is null ? null : new User
            {
                Id = user.Id,
                UserName = user.UserName
            };
        }

        public override async Task<CustomList<User>> Query(Query query)
        {
            var result = await base.Query(query);
            result.List = result.List.AsEnumerable().Select(u => new User
            {
                Id = u.Id,
                UserName = u.UserName
            }).ToList();
            return result;
        }


        public async Task<bool> ValidateUserAsync(User user)
        {
            return await repository.FindAsync(x => x.UserName == user.UserName && x.Password == user.Password.Encript()) != null;
        }
    }
}

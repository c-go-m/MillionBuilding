using Entities;

namespace BusinessRules.Interface
{
    public interface IUserService : IBaseBusinessRules<User>
    {        
        Task<bool> ValidateUserAsync(User user);
    }
}

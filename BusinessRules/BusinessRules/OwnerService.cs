using BusinessRules.Common;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;

namespace BusinessRules.BusinessRules
{
    public class OwnerService : BaseBusinessRules<Owner, IOwnerRepository>, IOwnerService
    {
        public OwnerService(IOwnerRepository repository) : base(repository)
        {
            
        }
    }
}

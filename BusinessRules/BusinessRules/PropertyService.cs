using BusinessRules.Common;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;
using Utilities.Utilities;

namespace BusinessRules.BusinessRules
{
    public class PropertyService : BaseBusinessRules<Property, IPropertyRepository>, IPropertyService
    {
        private readonly IOwnerService ownerService;
        public PropertyService(IPropertyRepository repository, IOwnerService ownerService) : base(repository)
        {
            this.ownerService = ownerService;
        }

        public override async Task<int?> CreateAsync(Property entity)
        {
            await this.ValidateExistOwnerAsync(entity);
            await this.ValidateCodeDuplicateAsync(entity);
            await this.ValidateAddressDuplicateAsync(entity);

            return await base.CreateAsync(entity);
        }

        public override async Task<bool> UpdateAsync(Property entity)
        {
            await this.ValidateExistOwnerAsync(entity);
            await this.ValidateCodeDuplicateAsync(entity);
            await this.ValidateAddressDuplicateAsync(entity);

            return await base.UpdateAsync(entity);
        }

        #region Validations
        private async Task ValidateCodeDuplicateAsync(Property entity)
        {
            var property = await repository.FindAsync(x => x.CodeInternal == entity.CodeInternal && x.Id != entity.Id);
            if (property is not null)
            {
                throw new ApplicationException(String.Format(ConstantsException.PropertyCodeDuplicate, entity.CodeInternal));
            }
        }

        private async Task ValidateExistOwnerAsync(Property entity)
        {
            var owner = await ownerService.GetByIdAsync(entity.IdOwner);
            if (owner is null)
            {
                throw new ApplicationException(ConstantsException.OwnerNotFound);
            }
        }

        private async Task ValidateAddressDuplicateAsync(Property entity)
        {
            var property = await repository.FindAsync(x => x.Address == entity.Address && x.Id != entity.Id);
            if (property is not null)
            {
                throw new ApplicationException(String.Format(ConstantsException.PropertyAddressDuplicate, entity.Address));
            }
        }
        #endregion
    }
}

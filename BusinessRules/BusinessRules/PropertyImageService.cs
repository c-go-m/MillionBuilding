using BusinessRules.Common;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;
using Utilities.Utilities;

namespace BusinessRules.BusinessRules
{
    public class PropertyImageService : BaseBusinessRules<PropertyImage, IPropertyImageRepository>, IPropertyImageService
    {
        private readonly IPropertyService propertyService;
        public PropertyImageService(IPropertyImageRepository repository, IPropertyService propertyService) : base(repository)
        {
            this.propertyService = propertyService;
        }

        public override async Task<int?> CreateAsync(PropertyImage entity)
        {
            await this.ValidatePropertyExistAsync(entity);

            return await base.CreateAsync(entity);
        }

        public override async Task<bool> UpdateAsync(PropertyImage entity)
        {
            await this.ValidatePropertyExistAsync(entity);

            return await base.UpdateAsync(entity);
        }

        #region Validations
        private async Task ValidatePropertyExistAsync(PropertyImage entity)
        {
            var property = await propertyService.GetByIdAsync(entity.Id);
            if (property is not null)
            {
                throw new ApplicationException(ConstantsException.PropertyCodeDuplicate);
            }
        }
        #endregion
    }
}

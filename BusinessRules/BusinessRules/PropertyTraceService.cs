using BusinessRules.Common;
using BusinessRules.Interface;
using DataAccess.Interface;
using Entities;
using Utilities.Utilities;

namespace BusinessRules.BusinessRules
{
    public class PropertyTraceService : BaseBusinessRules<PropertyTrace, IPropertyTraceRepository>, IPropertyTraceService
    {
        private readonly IPropertyService propertyService;
        public PropertyTraceService(IPropertyTraceRepository repository, IPropertyService propertyService) : base(repository)
        {
            this.propertyService = propertyService;
        }

        public override async Task<int?> CreateAsync(PropertyTrace entity)
        {
            await this.ValidatePropertyExistAsync(entity);

            return await base.CreateAsync(entity);
        }

        public override async Task<bool> UpdateAsync(PropertyTrace entity)
        {
            await this.ValidatePropertyExistAsync(entity);

            return await base.UpdateAsync(entity);
        }

        #region Validations
        private async Task ValidatePropertyExistAsync(PropertyTrace entity)
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

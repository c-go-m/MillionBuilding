using BuildingApi.Controllers.Common;
using BusinessRules.Interface;
using Entities;

namespace BuildingApi.Controllers
{
    public class PropertyImageController : BaseController<PropertyImage, IPropertyImageService>
    {
        public PropertyImageController(IPropertyImageService service) : base(service)
        {
        }
    }
}

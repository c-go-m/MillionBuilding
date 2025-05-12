using BuildingApi.Controllers.Common;
using BusinessRules.Interface;
using Entities;

namespace BuildingApi.Controllers
{
    public class PropertyController : BaseController<Property, IPropertyService>
    {
        public PropertyController(IPropertyService service) : base(service)
        {
        }
    }
}

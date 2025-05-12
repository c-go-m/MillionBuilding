using BuildingApi.Controllers.Common;
using BusinessRules.Interface;
using Entities;

namespace BuildingApi.Controllers
{
    public class PropertyTraceController : BaseController<PropertyTrace, IPropertyTraceService>
    {
        public PropertyTraceController(IPropertyTraceService service) : base(service)
        {
        }
    }
}

using BuildingApi.Controllers.Common;
using BusinessRules.Interface;
using Entities;

namespace BuildingApi.Controllers
{
    public class OwnerController : BaseController<Owner, IOwnerService>
    {
        public OwnerController(IOwnerService service) : base(service)
        {
        }
    }
}

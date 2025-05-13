using BusinessRules.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BuildingApi.Controllers.Common
{
    public abstract partial class BaseController<T, TService>
           where T : class, new()
           where TService : class, IBaseBusinessRules<T>
    {
        protected async Task<IActionResult> ExecutionAsync(Func<Task<IActionResult>> fnCallBack)
        {
            try
            {
                return await fnCallBack().ConfigureAwait(false);
            }
            catch (Exception ex)
                when (ex is ArgumentNullException || ex is ArgumentException || ex is InvalidOperationException)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

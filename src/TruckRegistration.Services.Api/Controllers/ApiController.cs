using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Application.Models.Response;

namespace TruckRegistration.Services.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (IsOperationValid())
            {
                if (result != null)
                {
                    return Ok(result);
                }

                return NoContent();
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(BaseResponse modelState)
        {
            var errors = modelState?.Errors;

            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(error);
                }
            }

            return CustomResponse(modelState.ObjectItem ?? modelState.ObjectItem);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}

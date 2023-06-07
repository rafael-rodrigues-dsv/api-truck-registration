using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Application.Contracts;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Services.Api.Controllers;

namespace TruckRegistration.Services.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("truck-registration/v{version:apiVersion}/trucks")]
    [ApiController]
    public class TruckController : ApiController
    {
        private readonly ITruckAppService _truckAppService;

        public TruckController(ITruckAppService truckAppService)
        {
            _truckAppService = truckAppService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TruckResponse>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public async Task<IEnumerable<TruckResponse>> GeAll()
        {
            return await _truckAppService.GetAll();
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TruckResponse))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("{id:guid}")]
        public async Task<TruckResponse> GetById([FromRoute] Guid id)
        {
            return await _truckAppService.GetById(id);
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TruckResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddTruckRequest request)
        {
            var result = await _truckAppService.Add(request);

            if (!result.IsValid)
            {
                return CustomResponse(result);
            }

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ObjectItem);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UpdateTruckRequest request)
        {
            return CustomResponse(await _truckAppService.Update(id, request));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse))]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return CustomResponse(await _truckAppService.Delete(id));
        }
    }
}

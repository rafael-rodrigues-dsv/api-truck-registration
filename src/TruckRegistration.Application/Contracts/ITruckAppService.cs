using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Application.Models.Response;

namespace TruckRegistration.Application.Contracts
{
    public interface ITruckAppService
    {
        Task<IEnumerable<TruckResponse>> GetAll();
        Task<TruckResponse> GetById(Guid id);
        Task<BaseResponse> Add(AddTruckRequest truckRequest);
        Task<BaseResponse> Update(Guid id, UpdateTruckRequest truckRequest);
        Task<BaseResponse> Delete(Guid id);
    }
}

using System;
using System.Threading.Tasks;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Contracts.Commands
{
    public interface ITruckCommandHandler
    {
        Task<BaseResult> Add(Truck truck);
        Task<BaseResult> Update(Truck truck);
        Task<BaseResult> Delete(Guid id);
    }
}

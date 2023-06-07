using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Application.Contracts;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Domain.Contracts.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Application.Services
{
    public class TruckAppService : ITruckAppService
    {
        private readonly IMapper _mapper;
        private readonly ITruckCommandHandler _truckCommandHandler;
        private readonly ITruckRepository _truckRepository;

        public TruckAppService(IMapper mapper, ITruckCommandHandler truckCommandHandler, ITruckRepository truckRepository)
        {
            _mapper = mapper;
            _truckCommandHandler = truckCommandHandler;
            _truckRepository = truckRepository;
        }

        public async Task<IEnumerable<TruckResponse>> GetAll()
        {
            return _mapper.Map<IEnumerable<TruckResponse>>(await _truckRepository.GetAll());
        }

        public async Task<TruckResponse> GetById(Guid id)
        {
            return _mapper.Map<TruckResponse>(await _truckRepository.GetById(id));
        }

        public async Task<BaseResponse> Add(AddTruckRequest truckRequest)
        {
            return new BaseResponse(await _truckCommandHandler.Add(_mapper.Map<Truck>(truckRequest)).ConfigureAwait(false));
        }

        public async Task<BaseResponse> Update(Guid id, UpdateTruckRequest truckRequest)
        {
            var truck = _mapper.Map<Truck>(truckRequest);
            truck.Id = id;

            return new BaseResponse(await _truckCommandHandler.Update(truck));
        }

        public async Task<BaseResponse> Delete(Guid id)
        {
            return new BaseResponse(await _truckCommandHandler.Delete(id));
        }
    }
}

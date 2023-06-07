using AutoMapper;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Application.AutoMapper
{
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            ViewModelToDomainMap();
            DomainToViewModelMap();
        }

        private void ViewModelToDomainMap()
        {
            CreateMap<AddTruckRequest, Truck>();
            CreateMap<UpdateTruckRequest, Truck>();
        }

        private void DomainToViewModelMap()
        {
            CreateMap<Truck, TruckResponse>();
        }
    }
}

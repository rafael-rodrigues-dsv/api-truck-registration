using FluentValidation;
using System;
using TruckRegistration.Domain.Contracts.Repositories;

namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class UpdateTruckValidation : TruckValidation<Entities.Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public UpdateTruckValidation(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
            ValidateId();
            ValidateIfExistsItem();
            ValidateDescription();
            ValidateModel();
            ValidateManufactureYear();
            ValidateModelYear();
            ValidateRenavam();
            ValidateColor();
        }

        private void ValidateIfExistsItem()
        {
            RuleFor(x => x).Must(item => ExistsById(item.Id));
        }

        private bool ExistsById(Guid id)
        {
            return _truckRepository.GetById(id)
                .GetAwaiter()
                .GetResult() != null;
        }
    }
}

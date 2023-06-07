using FluentValidation;
using System;
using TruckRegistration.Domain.Contracts.Repositories;

namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class DeleteTruckValidation : TruckValidation<Entities.Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public DeleteTruckValidation(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
            ValidateIfExistsItem();
        }

        private void ValidateIfExistsItem()
        {
            RuleFor(x => x).Must(item => ExistsById(item.Id))
                .WithMessage($"The id provided was not found in the database.");
        }

        private bool ExistsById(Guid id)
        {
            return _truckRepository.GetById(id)
                .GetAwaiter()
                .GetResult() != null;
        }
    }
}

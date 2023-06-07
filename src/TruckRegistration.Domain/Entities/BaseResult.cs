using FluentValidation.Results;
using System;

namespace TruckRegistration.Domain.Entities
{
    public class BaseResult
    {
        public BaseResult(ValidationResult validationResult, object objectItem = null, Guid? id = null)
        {
            ValidationResult = validationResult;
            ObjectItem = objectItem;
            Id = id;
        }

        public ValidationResult ValidationResult { get; set; }
        public object ObjectItem { get; set; }
        public Guid? Id { get; set; }

    }
}

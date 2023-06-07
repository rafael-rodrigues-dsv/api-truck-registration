using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Application.Models.Response
{
    public class BaseResponse
    {
        public BaseResponse(BaseResult baseResult)
        {
            if (!baseResult.ValidationResult.IsValid)
            {
                IsValid = false;
                Errors = new List<string>();

                foreach (ValidationFailure failure in baseResult.ValidationResult.Errors)
                {
                    Errors.Add(failure.ErrorMessage);
                }
            }
            else
            {
                IsValid = true;
            }

            if (baseResult.ObjectItem != null)
            {
                ObjectItem = baseResult.ObjectItem;
            }

            if (baseResult.Id != null)
            {
                Id = baseResult.Id;
            }
        }

        [JsonIgnore]
        public bool IsValid { get; set; }

        [JsonIgnore]
        public object ObjectItem { get; set; }

        [JsonIgnore]
        public Guid? Id { get; set; }

        public List<string> Errors { get; set; }
    }
}

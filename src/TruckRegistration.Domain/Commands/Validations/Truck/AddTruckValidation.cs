namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class AddTruckValidation : TruckValidation<Entities.Truck>
    {
        public AddTruckValidation()
        {
            ValidateId(isEmpty: true);
            ValidateDescription();
            ValidateModel();
            ValidateManufactureYear();
            ValidateModelYear();
            ValidateRenavam();
            ValidateColor();
        }
    }
}

using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Application.Models.Request
{
    public class AddTruckRequest
    {
        public string Description { get; set; }
        public EModel? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? ModelYear { get; set; }
        public string Renavam { get; set; }
        public string Color { get; set; }
    }
}

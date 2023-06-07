using System;
using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Domain.Entities
{
    public class Truck : BaseEntity
    {
        public Truck()
        {

        }

        public Truck(Guid id, string description, EModel? model, int? manufactureYear, int? modelYear, string renavam, string color)
        {
            this.Id = id;
            this.Description = description;
            this.Model = model;
            this.ManufactureYear = manufactureYear;
            this.ModelYear = modelYear;
            this.Renavam = renavam;
            this.Color = color;
        }

        public Truck(string description, EModel? model, int? manufactureYear, int? modelYear, string renavam, string color)
        {
            this.Description = description;
            this.Model = model;
            this.ManufactureYear = manufactureYear;
            this.ModelYear = modelYear;
            this.Renavam = renavam;
            this.Color = color;
        }

        public string Description { get; set; }
        public EModel? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? ModelYear { get; set; }
        public string Renavam { get; set; }
        public string Color { get; set; }
    }
}

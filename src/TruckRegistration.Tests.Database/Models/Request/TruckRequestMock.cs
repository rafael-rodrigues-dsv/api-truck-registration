using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Tests.UnitTest.Database.Entities;

namespace TruckRegistration.Tests.UnitTest.Database.Models.Request
{
    public static class TruckRequestMock
    {
        public static AddTruckRequest GetAddTruck(bool withGuidId = true)
        {
            return GetAddTruckList(withGuidId: withGuidId).FirstOrDefault();
        }

        public static List<AddTruckRequest> GetAddTruckList(bool withGuidId = true)
        {
            return TruckEntityMock.GetTruckList(withGuidId: withGuidId).Select(t => new AddTruckRequest
            {
                Description = t.Description,
                Model = t.Model,
                ManufactureYear = t.ManufactureYear,
                ModelYear = t.ModelYear,
                Renavam = t.Renavam,
                Color = t.Color
            }).ToList();
        }

        public static UpdateTruckRequest GetUpdateTruck(bool withGuidId = true)
        {
            return GetUpdateTruckList(withGuidId).FirstOrDefault();
        }

        public static List<UpdateTruckRequest> GetUpdateTruckList(bool withGuidId = true)
        {
            return TruckEntityMock.GetTruckList(withGuidId: withGuidId).Select(t => new UpdateTruckRequest
            {
                Description = t.Description,
                Model = t.Model,
                ManufactureYear = t.ManufactureYear,
                ModelYear = t.ModelYear,
                Renavam = t.Renavam,
                Color = t.Color
            }).ToList();
        }
    }
}

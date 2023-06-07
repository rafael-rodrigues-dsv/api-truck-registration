using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Tests.UnitTest.Database.Entities;

namespace TruckRegistration.Tests.UnitTest.Database.Models.Response
{
    public static class TruckResponseMock
    {
        public static TruckResponse GetTruck(bool withGuidId = true)
        {
            return GetList(withGuidId).FirstOrDefault();
        }

        public static List<TruckResponse> GetList(bool withGuidId = true)
        {
            return TruckEntityMock.GetTruckList(withGuidId: withGuidId).Select(t => new TruckResponse
            {
                Id = t.Id,
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

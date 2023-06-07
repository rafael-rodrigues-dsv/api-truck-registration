using System;
using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Entities.Enums;
using TruckRegistration.Domain.Utils.Extensions;

namespace TruckRegistration.Tests.UnitTest.Database.Entities
{
    public static class TruckEntityMock
    {
        public static Truck GetTruck(bool withGuidId = true)
        {
            return GetTruckList(withGuidId).FirstOrDefault();
        }

        public static List<Truck> GetTruckList(bool withGuidId = true, int itemsToGenerate = 5)
        {
            var trucks = new List<Truck>();

            while (itemsToGenerate > 0)
            {
                var modelGenerated = RandomExtension.RandomEnum<EModel>();

                trucks.Add(new Truck()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = $"Volvo {modelGenerated.ToString()}",
                    Model = modelGenerated,
                    ManufactureYear = DateTime.Now.Year,
                    ModelYear = RandomExtension.RandomInt(new int[] {
                        DateTime.Now.Year,
                        DateTime.Now.AddYears(1).Year
                    }),
                    Renavam = RandomExtension.RandomInt(initialValue: 10000000, endValue: 99999999).ToString().PadLeft(12, '0'),
                    Color = RandomExtension.RandomString(new string[] {
                        "White",
                        "Blue",
                        "Black"
                    })
                });

                itemsToGenerate = itemsToGenerate - 1;
            }

            return trucks;
        }
    }
}

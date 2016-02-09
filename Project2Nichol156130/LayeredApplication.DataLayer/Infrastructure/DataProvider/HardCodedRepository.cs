using LayeredApplication.DataLayer.Infrastructure.Repository;
using LayeredApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LayeredApplication.DataLayer.Infrastructure.DataProvider
{
    public class HardCodedRepository : IContext<Vehicle>
    {
        public HardCodedRepository()
        {
            InMemoryVehicles = HardCodedDataProvider.Instance.Vehicles();
        }

        public static List<Vehicle> InMemoryVehicles { get; set; }

        public Vehicle Add(Vehicle entity)
        {
            if (InMemoryVehicles == null)
                InMemoryVehicles = new List<Vehicle>();

            var vehicle = InMemoryVehicles.OrderByDescending(x => x.Id).FirstOrDefault();
            entity.Id = vehicle.Id + 1;
            InMemoryVehicles.Add(entity);
            return entity;
        }

        public bool Update(Vehicle entity)
        {
            try
            {
                if (InMemoryVehicles == null)
                    InMemoryVehicles = new List<Vehicle>();

                var vehicle = InMemoryVehicles.OrderByDescending(x => x.Id).FirstOrDefault();
                var item = InMemoryVehicles.FirstOrDefault(x => x.Id == entity.Id);
                if (item != null)
                {
                    item.ChasisNumber = entity.ChasisNumber;
                    item.ModelNumber = entity.ModelNumber;
                    item.Name = entity.Name;
                    item.NumberOfWheels = entity.NumberOfWheels;
                    item.RegistrationNumber = entity.RegistrationNumber;
                    item.VehicleType = entity.VehicleType;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(Vehicle entity)
        {
            if (InMemoryVehicles == null)
                InMemoryVehicles = new List<Vehicle>();

            var obj = InMemoryVehicles.FirstOrDefault(x => x.Id == entity.Id);
            if (obj != null)
            {
                InMemoryVehicles.Remove(obj);
                return true;
            }
            return false;
        }

        public Vehicle Get(int id)
        {
            if (InMemoryVehicles == null)
                InMemoryVehicles = HardCodedDataProvider.Instance.Vehicles();

            var obj = InMemoryVehicles.FirstOrDefault(x => x.Id == id);
            return obj;
        }

        public List<Vehicle> Find(Func<Vehicle, bool> predicate)
        {
            if (InMemoryVehicles == null)
                InMemoryVehicles = HardCodedDataProvider.Instance.Vehicles();

            return InMemoryVehicles.Where(predicate).ToList();
        }

        public List<Vehicle> GetAll()
        {
            if (InMemoryVehicles == null)
                InMemoryVehicles = HardCodedDataProvider.Instance.Vehicles();

            return InMemoryVehicles;
        }
    }
}

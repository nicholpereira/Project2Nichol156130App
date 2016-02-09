using LayeredApplication.DataLayer.Infrastructure.Helper;
using LayeredApplication.Model;
using System.Collections.Generic;

namespace LayeredApplication.DataLayer.Infrastructure
{
    public sealed class HardCodedDataProvider
    {
        private static HardCodedData instance { get; set; }

        private HardCodedDataProvider()
        {
        }

        public static HardCodedData Instance
        {
            get
            {
                if (instance == null)
                    instance = new HardCodedData();
                return instance;
            }
        }
    }

    public sealed class HardCodedData
    {
        public List<Vehicle> Vehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>()
            {
                //cars 
                 CreateNewVehicle("Car",1,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",2,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",3,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",4,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",5,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",6,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",7,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",8,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",9,4, VehicleTypeEnum.car),
                 CreateNewVehicle("Car",10,4, VehicleTypeEnum.car),

                 //trucks
                 CreateNewVehicle("Truck",11,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",12,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",13,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",14,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",15,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",16,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",17,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",18,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",19,20, VehicleTypeEnum.truck),
                 CreateNewVehicle("Truck",20,20, VehicleTypeEnum.truck),

                 //bus
                 CreateNewVehicle("bus",21,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",22,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",23,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",24,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",25,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",26,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",27,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",28,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",29,6, VehicleTypeEnum.bus),
                 CreateNewVehicle("bus",30,6, VehicleTypeEnum.bus),
                 
                 //motorcycle
                 CreateNewVehicle("motorcycle",31,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",32,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",33,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",34,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",35,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",36,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",37,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",38,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",39,2, VehicleTypeEnum.motorcycle),
                 CreateNewVehicle("motorcycle",40,2, VehicleTypeEnum.motorcycle),
            };

            return vehicles;
        }

        private Vehicle CreateNewVehicle(string name, int id, int numberOfWheels, VehicleTypeEnum vehicleType)
        {
            Vehicle vec = new Vehicle()
            {
                Id = id,
                ChasisNumber = Util.RandomString(),
                ModelNumber = Util.RandomNum(1000, 9999).ToString(),
                NumberOfWheels = numberOfWheels,
                VehicleType = vehicleType.ToString(),
                Name = string.Format("{0}_{1}", name, Util.RandomString(6)),
                RegistrationNumber = Util.RandomString()
            };

            return vec;
        }
    }
}

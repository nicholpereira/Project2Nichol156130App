using System;
using System.ComponentModel.DataAnnotations;

namespace LayeredApplication.Model
{
    public class Vehicle : IVehicleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Model")]
        public string ModelNumber { get; set; }

        [Display(Name = "Chasis #")]
        public string ChasisNumber { get; set; }

        [Display(Name = "Registration #")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "# of Wheels")]
        public int NumberOfWheels { get; set; }

        [Display(Name = "Type")]
        public string VehicleType { get; set; }
    }
}

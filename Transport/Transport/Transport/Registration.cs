using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Registration
    {
        public string RegistrationPlate { get; set; }
        public string VIN { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string EngineNumber { get; set; }
        public int Horsepower { get; set; }
        public VehicleType VehicleType { get; set; }

        public Registration(string registrationPlate, string vin, string model,
                            int year, string engineNumber, int horsepower,
                            VehicleType vehicleType)
        {
            RegistrationPlate = registrationPlate;
            VIN = vin;
            Model = model;
            Year = year;
            EngineNumber = engineNumber;
            Horsepower = horsepower;
            VehicleType = vehicleType;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{RegistrationPlate} {VIN} {Model}";

            string vehicleTypeStr;
            if (VehicleType == VehicleType.Sedan)
                vehicleTypeStr = "легковой седан";
            else if (VehicleType == VehicleType.Hatchback)
                vehicleTypeStr = "легковой хетчбэк";
            else if (VehicleType == VehicleType.Wagon)
                vehicleTypeStr = "легковой универсал";
            else if (VehicleType == VehicleType.Coupe)
                vehicleTypeStr = "легковое купе";
            else if (VehicleType == VehicleType.SUV)
                vehicleTypeStr = "внедорожник";
            else if (VehicleType == VehicleType.Minivan)
                vehicleTypeStr = "минивэн";
            else
                vehicleTypeStr = "неизвестный тип";

            info[1] = $"Год выпуска: {Year}, Номер двигателя: {EngineNumber}, " +
                      $"Мощность: {Horsepower} л.с., Тип: {vehicleTypeStr}";

            return info;
        }
    }
}
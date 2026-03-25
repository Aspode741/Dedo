using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public enum VehicleType
    {
        Sedan, Hatchback, Wagon, Coupe, SUV, Minivan
    }
    public class Registration
    {
        public string RegistrationPlate { get; }
        public string VIN { get; }
        public string Model { get; }
        public int Year { get; }
        public string EngineNumber { get; }
        public int Horsepower { get; }
        public VehicleType VehicleType { get; }

        public Registration(string registrationPlate, string vin, string model, int year,
                            string engineNumber, int horsepower, VehicleType vehicleType)
        {
            RegistrationPlate = registrationPlate;
            VIN = vin;
            Model = model;
            Year = year;
            EngineNumber = engineNumber;
            Horsepower = horsepower;
            VehicleType = vehicleType;
        }

        public string[] GetInfo()
        {
            string firstLine = $"{RegistrationPlate} {VIN} {Model}";
            string secondLine = $"Год выпуска: {Year}, Номер двигателя: {EngineNumber}, Мощность: {Horsepower} л.с., Тип: {GetVehicleTypeString()}";
            return new string[] { firstLine, secondLine };
        }

        private string GetVehicleTypeString()
        {
            switch (VehicleType)
            {
                case VehicleType.Sedan:
                    return "легковой седан";
                case VehicleType.Hatchback:
                    return "легковой хетчбэк";
                case VehicleType.Wagon:
                    return "легковой универсал";
                case VehicleType.Coupe:
                    return "легковое купе";
                case VehicleType.SUV:
                    return "внедорожник";
                case VehicleType.Minivan:
                    return "минивэн";
                default:
                    return "неизвестный тип";
            }
        }
    }
}
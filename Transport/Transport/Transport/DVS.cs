using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class DVS : Automobile
    {
        public int Cylinders { get; set; }
        public Toplivo Fuel { get; set; }

        public DVS(Registration registration, int enginePower,
                   TransmissionTip transmission, int cylinders, Toplivo fuel)
            : base(registration, enginePower, transmission)
        {
            Cylinders = cylinders;
            Fuel = fuel;
        }

        public override string[] GetInfo()
        {
            var info = new string[4];
            info[0] = $"{Registration.RegistrationPlate} {Registration.VIN} {Registration.Model}";

            string vehicleTypeStr;
            if (Registration.VehicleType == VehicleType.Sedan)
                vehicleTypeStr = "легковой седан";
            else if (Registration.VehicleType == VehicleType.Hatchback)
                vehicleTypeStr = "легковой хетчбэк";
            else if (Registration.VehicleType == VehicleType.Wagon)
                vehicleTypeStr = "легковой универсал";
            else if (Registration.VehicleType == VehicleType.Coupe)
                vehicleTypeStr = "легковое купе";
            else if (Registration.VehicleType == VehicleType.SUV)
                vehicleTypeStr = "внедорожник";
            else if (Registration.VehicleType == VehicleType.Minivan)
                vehicleTypeStr = "минивэн";
            else
                vehicleTypeStr = "неизвестный тип";

            info[1] = $"Год выпуска: {Registration.Year}, Номер двигателя: {Registration.EngineNumber}, " +
                      $"Мощность: {Registration.Horsepower} л.с., Тип: {vehicleTypeStr}";

            string fuelStr;
            if (Fuel == Toplivo.Gasoline)
                fuelStr = "бензин";
            else
                fuelStr = "дизель";

            string transmissionStr;
            if (Transmission == TransmissionTip.Manual)
                transmissionStr = "механическая";
            else if (Transmission == TransmissionTip.Automatic)
                transmissionStr = "гидромеханическая АКПП";
            else if (Transmission == TransmissionTip.CVT)
                transmissionStr = "вариатор";
            else if (Transmission == TransmissionTip.Robot)
                transmissionStr = "робот";
            else if (Transmission == TransmissionTip.DualClutch)
                transmissionStr = "с двойным сцеплением";
            else
                transmissionStr = "неизвестная";

            info[2] = $"ДВС: {Cylinders} цилиндр(ов), топливо: {fuelStr}, " +
                      $"мощность: {EnginePower} л.с., КПП: {transmissionStr}";
            info[3] = $"Регистрация: {Registration.RegistrationPlate}";

            return info;
        }
    }
}

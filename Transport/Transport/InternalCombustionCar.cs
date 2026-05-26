using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class InternalCombustionCar : Automobile
    {
        public int Cylinders { get; set; }   // кол-во цилиндров
        public FuelType Fuel { get; set; }   // топливо

        public InternalCombustionCar(Registration registration, int enginePower,
                                     TransmissionType transmission, int cylinders, FuelType fuel)
            : base(registration, enginePower, transmission)
        {
            Cylinders = cylinders;
            Fuel = fuel;
        }

        public override string[] GetInfo()
        {
            // Получаем строки из свидетельства о регистрации
            var regInfo = Registration.GetInfo();
            var result = new string[4];

            result[0] = regInfo[0];
            result[1] = regInfo[1];
            result[2] = $"ДВС: {Cylinders} цилиндр(ов), топливо: {FuelToString(Fuel)}, " +
                        $"мощность: {EnginePower} л.с., КПП: {TransmissionToString(Transmission)}";
            result[3] = $"Регистрация: {Registration.RegistrationPlate}";

            return result;
        }

        private string FuelToString(FuelType fuel)
        {
            return fuel == FuelType.Gasoline ? "бензин" : "дизель";
        }

        private string TransmissionToString(TransmissionType t)
        {
            switch (t)
            {
                case TransmissionType.Manual: return "механическая";
                case TransmissionType.Automatic: return "гидромеханическая АКПП";
                case TransmissionType.CVT: return "вариатор";
                case TransmissionType.Robot: return "робот";
                case TransmissionType.DualClutch: return "с двойным сцеплением";
                default: return "неизвестная";
            }
        }
    }
}

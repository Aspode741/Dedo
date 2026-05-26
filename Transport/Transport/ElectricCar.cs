using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class ElectricCar : Automobile
    {
        public double BatteryCapacity { get; set; }   // ёмкость
        public double Range { get; set; }             // запас
        public double ChargingTime { get; set; }      // время

        public ElectricCar(Registration registration, int enginePower,
                           TransmissionType transmission, double batteryCapacity,
                           double range, double chargingTime)
            : base(registration, enginePower, transmission)
        {
            BatteryCapacity = batteryCapacity;
            Range = range;
            ChargingTime = chargingTime;
        }

        public override string[] GetInfo()
        {
            var regInfo = Registration.GetInfo();
            var result = new string[5];

            result[0] = regInfo[0];
            result[1] = regInfo[1];
            result[2] = $"Электромобиль: мощность {EnginePower} л.с., КПП: {TransmissionToString(Transmission)}";
            result[3] = $"Батарея: {BatteryCapacity} кВт·ч, запас хода: {Range} км, " +
                        $"зарядка: {ChargingTime} ч";
            result[4] = $"Регистрация: {Registration.RegistrationPlate}";

            return result;
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

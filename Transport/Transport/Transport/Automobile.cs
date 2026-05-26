using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public abstract class Automobile : IComparable<Automobile>
    {
        public Registration Registration { get; set; }
        public int EnginePower { get; set; }
        public TransmissionTip Transmission { get; set; }

        protected Automobile(Registration registration, int enginePower, TransmissionTip transmission)
        {
            Registration = registration;
            EnginePower = enginePower;
            Transmission = transmission;
        }

        public abstract string[] GetInfo();

        // сортировка по марке/модели, потом по рег знаку
        public int CompareTo(Automobile other)
        {
            if (other == null)
                return 1;

            // сравниваем модели 
            int modelCompare = string.Compare(this.Registration.Model, other.Registration.Model, StringComparison.OrdinalIgnoreCase);
            if (modelCompare != 0)
                return modelCompare;

            // если модели одинаковые, то сравниваем знаки
            return string.Compare(this.Registration.RegistrationPlate, other.Registration.RegistrationPlate, StringComparison.OrdinalIgnoreCase);
        }
    }
}
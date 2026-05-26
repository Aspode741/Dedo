using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public abstract class Automobile : IComparable<Automobile>
    {
        public Registration Registration { get; private set; }
        public int EnginePower { get; private set; }
        public TransmissionType Transmission { get; private set; }

        protected Automobile(Registration registration, int enginePower, TransmissionType transmission)
        {
            Registration = registration ?? throw new ArgumentNullException(nameof(registration));
            EnginePower = enginePower;
            Transmission = transmission;
        }

        public abstract string[] GetInfo();

        // сначала по марке потом по щнаку
        public int CompareTo(Automobile other)
        {
            if (other == null) return 1;

            // по модели
            int modelComparison = string.Compare(this.Registration.Model, other.Registration.Model, StringComparison.Ordinal);
            if (modelComparison != 0)
                return modelComparison;

            // по знаку
            return string.Compare(this.Registration.RegistrationPlate, other.Registration.RegistrationPlate, StringComparison.Ordinal);
        }
    }
}
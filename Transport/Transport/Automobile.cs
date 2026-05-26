using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public abstract class Automobile
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
    }
}
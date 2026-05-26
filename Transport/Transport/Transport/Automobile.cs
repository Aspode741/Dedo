using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public abstract class Automobile
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
    }
}
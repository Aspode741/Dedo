using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport
{
    public class Garage : IEnumerable<Automobile>
    {
        public string Name { get; set; }        // название
        public string Address { get; set; }     // адрес

        private List<Automobile> cars;

        public int Count => cars.Count;        // только для чтения

        public Garage(string name, string address, IEnumerable<Automobile> automobiles)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            cars = new List<Automobile>();

            if (automobiles != null)
            {
                foreach (var car in automobiles)
                {
                    // чтоб не повторялось дважды
                    if (!cars.Contains(car))
                        cars.Add(car);
                }
            }
        }

        public IEnumerator<Automobile> GetEnumerator()
        {
            return cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
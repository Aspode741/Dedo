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
        public string Name { get; set; }
        public string Address { get; set; }

        private List<Automobile> cars;

        public int Count
        {
            get { return cars.Count; }
        }

        public Garage(string name, string address, IEnumerable<Automobile> automobiles)
        {
            Name = name;
            Address = address;
            cars = new List<Automobile>();

            if (automobiles != null)
            {
                foreach (var car in automobiles)
                {
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
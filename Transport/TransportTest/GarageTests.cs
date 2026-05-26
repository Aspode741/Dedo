using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport;

namespace TransportTest
{
    [TestFixture]
    public class GarageTests
    {
        private Garage garage;
        private Automobile[] testCars;

        [SetUp]
        public void Setup()
        {
            var reg1 = new Registration("A111AA", "VIN1", "Toyota Corolla", 2019, "1ZR", 132, VehicleType.Sedan);
            var reg2 = new Registration("B222BB", "VIN2", "Honda Civic", 2020, "R18", 141, VehicleType.Sedan);
            var reg3 = new Registration("C333CC", "VIN3", "Ford Focus", 2018, "Duratec", 150, VehicleType.Hatchback);

            var car1 = new InternalCombustionCar(reg1, 132, TransmissionType.Manual, 4, FuelType.Gasoline);
            var car2 = new ElectricCar(reg2, 141, TransmissionType.CVT, 40, 350, 6);
            var car3 = new InternalCombustionCar(reg3, 150, TransmissionType.Robot, 4, FuelType.Diesel);

            // проверка повторов черещ дубляж
            testCars = new Automobile[] { car1, car2, car3, car1 };

            garage = new Garage("Мой гараж", "ул. Ленина, 1", testCars);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(garage.Name, Is.EqualTo("Мой гараж"));
            Assert.That(garage.Address, Is.EqualTo("ул. Ленина, 1"));

            // кар1 один раз
            Assert.That(garage.Count, Is.EqualTo(3));
        }

        [Test]
        public void CountTest()
        {
            Assert.That(garage.Count, Is.EqualTo(3));
        }

        [Test]
        public void IEnumerableTest()
        {
            int i = 0;
            foreach (var car in garage)
            {
                Assert.That(car, Is.SameAs(testCars[i]));
                i++;
            }
            Assert.That(i, Is.EqualTo(3)); // дубликат пропустили
        }
    }
}
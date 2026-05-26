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

            var car1 = new DVS(reg1, 132, TransmissionTip.Manual, 4, Toplivo.Gasoline);
            var car2 = new Electro(reg2, 141, TransmissionTip.CVT, 40, 350, 6);
            var car3 = new DVS(reg3, 150, TransmissionTip.Robot, 4, Toplivo.Diesel);

            // дублирум кар1
            testCars = new Automobile[] { car1, car2, car3, car1 };
            garage = new Garage("Мой гараж", "ул. Ленина, 1", testCars);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.That(garage.Name, Is.EqualTo("Мой гараж"));
            Assert.That(garage.Address, Is.EqualTo("ул. Ленина, 1"));
            // проверка что кар1 1
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
            Assert.That(i, Is.EqualTo(3)); // двойника пропускаем
        }
    }
}
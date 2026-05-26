using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport;

namespace TransportTest
{
    [TestFixture]
    public class RegistrationTests
    {
        [Test]
        public void ConstructorTest()
        {
            var registration = CreateTestRegistration();

            Assert.That(registration.RegistrationPlate, Is.EqualTo("A123BC"));
            Assert.That(registration.VIN, Is.EqualTo("WDB1234567890"));
            Assert.That(registration.Model, Is.EqualTo("Toyota Camry"));
            Assert.That(registration.Year, Is.EqualTo(2015));
            Assert.That(registration.EngineNumber, Is.EqualTo("2GR-FE"));
            Assert.That(registration.Horsepower, Is.EqualTo(249));
            Assert.That(registration.VehicleType, Is.EqualTo(VehicleType.Sedan));
        }

        [Test]
        public void GetInfoTest()
        {
            var registration = CreateTestRegistration();
            var info = registration.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("A123BC WDB1234567890 Toyota Camry"));
            Assert.That(info[1], Is.EqualTo("Год выпуска: 2015, Номер двигателя: 2GR-FE, Мощность: 249 л.с., Тип: легковой седан"));
        }

        private Registration CreateTestRegistration()
        {
            return new Registration(
                "A123BC",
                "WDB1234567890",
                "Toyota Camry",
                2015,
                "2GR-FE",
                249,
                VehicleType.Sedan
            );
        }
    }
}

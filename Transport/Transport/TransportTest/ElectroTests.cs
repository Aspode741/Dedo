using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport;

namespace TransportTest
{
    [TestFixture]
    public class ElectroTests
    {
        [Test]
        public void ConstructorTest()
        {
            var car = CreateTestCar();

            Assert.That(car.Registration, Is.Not.Null);
            Assert.That(car.EnginePower, Is.EqualTo(150));
            Assert.That(car.Transmission, Is.EqualTo(TransmissionTip.CVT));
            Assert.That(car.BatteryCapacity, Is.EqualTo(60.0).Within(1e-6));
            Assert.That(car.Range, Is.EqualTo(400.0).Within(1e-6));
            Assert.That(car.ChargingTime, Is.EqualTo(8.0).Within(1e-6));
        }

        [Test]
        public void GetInfoTest()
        {
            var car = CreateTestCar();
            var info = car.GetInfo();

            Assert.That(info.Length, Is.EqualTo(5));
            Assert.That(info[0], Is.EqualTo("A123BC WDB1234567890 Toyota Camry"));
            Assert.That(info[1], Is.EqualTo("Год выпуска: 2015, Номер двигателя: 2GR-FE, Мощность: 249 л.с., Тип: легковой седан"));
            Assert.That(info[2], Is.EqualTo("Электромобиль: мощность 150 л.с., КПП: вариатор"));
            Assert.That(info[3], Is.EqualTo("Батарея: 60 кВт·ч, запас хода: 400 км, зарядка: 8 ч"));
            Assert.That(info[4], Is.EqualTo("Регистрация: A123BC"));
        }

        private Electro CreateTestCar()
        {
            var reg = new Registration(
                "A123BC",
                "WDB1234567890",
                "Toyota Camry",
                2015,
                "2GR-FE",
                249,
                VehicleType.Sedan
            );

            return new Electro(
                reg,
                150,
                TransmissionTip.CVT,
                60.0,
                400.0,
                8.0
            );
        }
    }
}

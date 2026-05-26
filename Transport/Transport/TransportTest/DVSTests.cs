using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport;

namespace TransportTest
{
    [TestFixture]
    public class DVSTests
    {
        [Test]
        public void ConstructorTest()
        {
            var car = CreateTestCar();

            Assert.That(car.Registration, Is.Not.Null);
            Assert.That(car.EnginePower, Is.EqualTo(249));
            Assert.That(car.Transmission, Is.EqualTo(TransmissionTip.Automatic));
            Assert.That(car.Cylinders, Is.EqualTo(4));
            Assert.That(car.Fuel, Is.EqualTo(Toplivo.Gasoline));
        }

        [Test]
        public void GetInfoTest()
        {
            var car = CreateTestCar();
            var info = car.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[0], Is.EqualTo("A123BC WDB1234567890 Toyota Camry"));
            Assert.That(info[1], Is.EqualTo("Год выпуска: 2015, Номер двигателя: 2GR-FE, Мощность: 249 л.с., Тип: легковой седан"));
            Assert.That(info[2], Is.EqualTo("ДВС: 4 цилиндр(ов), топливо: бензин, мощность: 249 л.с., КПП: гидромеханическая АКПП"));
            Assert.That(info[3], Is.EqualTo("Регистрация: A123BC"));
        }

        private DVS CreateTestCar()
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

            return new DVS(
                reg,
                249,
                TransmissionTip.Automatic,
                4,
                Toplivo.Gasoline
            );
        }
    }
}
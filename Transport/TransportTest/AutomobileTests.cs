using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport;

namespace TransportTest
{
    [TestFixture]
    public class AutomobileTests
    {
        [Test]
        public void CompareToTest()
        {
            var reg1 = new Registration("A123BC", "VIN1", "Toyota Camry", 2015, "2GR", 249, VehicleType.Sedan);
            var reg2 = new Registration("B456DE", "VIN2", "Toyota Camry", 2018, "3GR", 249, VehicleType.Sedan);
            var reg3 = new Registration("C789FG", "VIN3", "Honda Accord", 2020, "K24", 190, VehicleType.Sedan);
            var reg4 = new Registration("A000AA", "VIN4", "Toyota Camry", 2010, "1GR", 249, VehicleType.Sedan);

            var car1 = new InternalCombustionCar(reg1, 249, TransmissionType.Automatic, 4, FuelType.Gasoline);
            var car2 = new InternalCombustionCar(reg2, 249, TransmissionType.Automatic, 4, FuelType.Gasoline);
            var car3 = new InternalCombustionCar(reg3, 190, TransmissionType.CVT, 4, FuelType.Gasoline);
            var car4 = new InternalCombustionCar(reg4, 249, TransmissionType.Automatic, 4, FuelType.Gasoline);

            // хонда < тайоты
            Assert.That(car3.CompareTo(car1), Is.LessThan(0));
            // 2 тайоты = сравнение по номерам A123BC и B456DE итог A < B
            Assert.That(car1.CompareTo(car2), Is.LessThan(0));
            // тайота A000AA и A123BC итог A000AA < A123BC
            Assert.That(car4.CompareTo(car1), Is.LessThan(0));
            // одинаковые машины = 0
            Assert.That(car1.CompareTo(car1), Is.EqualTo(0));
        }
    }
}

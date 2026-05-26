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

            var car1 = new DVS(reg1, 249, TransmissionTip.Automatic, 4, Toplivo.Gasoline);
            var car2 = new DVS(reg2, 249, TransmissionTip.Automatic, 4, Toplivo.Gasoline);
            var car3 = new DVS(reg3, 190, TransmissionTip.CVT, 4, Toplivo.Gasoline);
            var car4 = new DVS(reg4, 249, TransmissionTip.Automatic, 4, Toplivo.Gasoline);

            // хонда < тайота
            Assert.That(car3.CompareTo(car1), Is.LessThan(0));
            // если 2 тайоты то сравниваем номера A123BC и B456DE
            Assert.That(car1.CompareTo(car2), Is.LessThan(0));
            // тайота A000AA и A123BC = A000AA < A123BC
            Assert.That(car4.CompareTo(car1), Is.LessThan(0));
            // дублёр
            Assert.That(car1.CompareTo(car1), Is.EqualTo(0));
        }
    }
}
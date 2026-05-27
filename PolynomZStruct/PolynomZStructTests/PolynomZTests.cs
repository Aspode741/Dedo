using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolynomZStruct;

namespace PolynomZStructTests
{
    [TestFixture]
    public class PolynomZTests
    {
        [Test]
        public void Constructor_NormalizesTrailingZeros()
        {
            var p = new PolynomZ(new int[] { 1, 2, 0, 0 });
            Assert.That(p.Deg, Is.EqualTo(1));
            Assert.That(p.Coeff.Length, Is.EqualTo(2));
            Assert.That(p.Coeff[0], Is.EqualTo(1));
            Assert.That(p.Coeff[1], Is.EqualTo(2));
        }

        [Test]
        public void Constructor_AllZeros_DegMinusOne()
        {
            var p = new PolynomZ(0, 0, 0);
            Assert.That(p.Deg, Is.EqualTo(-1));
            Assert.That(p.Coeff.Length, Is.EqualTo(0));
        }

        [Test]
        public void Constructor_Null_ThrowsArgumentNullException()
        {
            Assert.That(() => new PolynomZ(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ToString_Zero()
        {
            var p = new PolynomZ(0, 0);
            Assert.That(p.ToString(), Is.EqualTo("0"));
        }

        [Test]
        public void ToString_ConstantPositive()
        {
            var p = new PolynomZ(5);
            Assert.That(p.ToString(), Is.EqualTo("5"));
        }

        [Test]
        public void ToString_ConstantNegative()
        {
            var p = new PolynomZ(-3);
            Assert.That(p.ToString(), Is.EqualTo("-3"));
        }

        [Test]
        public void ToString_LeadingOne()
        {
            var p = new PolynomZ(1, 1, 1); // x^2 + x + 1
            Assert.That(p.ToString(), Is.EqualTo("x^2+x+1"));
        }

        [Test]
        public void ToString_LeadingNegativeOne()
        {
            var p = new PolynomZ(-1, -2, -1); // -x^2 - 2x - 1
            Assert.That(p.ToString(), Is.EqualTo("-x^2-2*x-1"));
        }

        [Test]
        public void ToString_MixedWithGaps()
        {
            var p = new PolynomZ(5, 0, 3, 0, 2); // 2x^4 + 3x^2 + 5
            Assert.That(p.ToString(), Is.EqualTo("2*x^4+3*x^2+5"));
        }

        [Test]
        public void ToString_AllPresent()
        {
            var p = new PolynomZ(1, 2, 3); // 3x^2 + 2x + 1
            Assert.That(p.ToString(), Is.EqualTo("3*x^2+2*x+1"));
        }

        [Test]
        public void Equals_SameCoeffs_True()
        {
            var a = new PolynomZ(1, 2, 3);
            var b = new PolynomZ(1, 2, 3);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_Different_False()
        {
            var a = new PolynomZ(1, 2, 3);
            var b = new PolynomZ(1, 2, 4);
            Assert.That(a.Equals(b), Is.False);
        }

        [Test]
        public void Equals_WithTrailingZeros_StillEqual()
        {
            var a = new PolynomZ(1, 2, 3, 0, 0);
            var b = new PolynomZ(1, 2, 3);
            Assert.That(a.Equals(b), Is.True);
        }

        [Test]
        public void Equals_WrongObject_ThrowsArgumentException()
        {
            var p = new PolynomZ(1);
            Assert.That(() => p.Equals("hello"), Throws.ArgumentException);
        }

        [Test]
        public void GetHashCode_SamePolynom_SameHash()
        {
            var a = new PolynomZ(2, 0, 5);
            var b = new PolynomZ(2, 0, 5);
            Assert.That(a.GetHashCode(), Is.EqualTo(b.GetHashCode()));
        }

        [Test]
        public void GetHashCode_DifferentPolynom_ProbablyDifferent()
        {
            var a = new PolynomZ(2, 0, 5);
            var b = new PolynomZ(2, 1, 5);
            Assert.That(a.GetHashCode(), Is.Not.EqualTo(b.GetHashCode()));
        }

        [Test]
        public void OperatorEqualAndNotEqual()
        {
            var x = new PolynomZ(1, 2);
            var y = new PolynomZ(1, 2);
            var z = new PolynomZ(3);
            Assert.That(x == y, Is.True);
            Assert.That(x != z, Is.True);
        }

        [Test]
        public void Addition_Simple()
        {
            var p = new PolynomZ(1, 2, 3);   // 3x^2+2x+1
            var q = new PolynomZ(3, 2, 1);   // x^2+2x+3
            var sum = p + q;
            var expected = new PolynomZ(4, 4, 4); // 4x^2+4x+4
            Assert.That(sum, Is.EqualTo(expected));
        }

        [Test]
        public void Addition_ResultingInZero()
        {
            var p = new PolynomZ(1, 2);
            var q = new PolynomZ(-1, -2);
            var sum = p + q;
            Assert.That(sum.Deg, Is.EqualTo(-1));
            Assert.That(sum.Coeff.Length, Is.EqualTo(0));
        }

        [Test]
        public void ScalarMultiply_Int()
        {
            var p = new PolynomZ(1, -2, 3); // 3x^2 -2x +1
            var expected = new PolynomZ(2, -4, 6);
            Assert.That(2 * p, Is.EqualTo(expected));
            Assert.That(p * 2, Is.EqualTo(expected));
        }

        [Test]
        public void ScalarMultiply_Zero_ReturnsZero()
        {
            var p = new PolynomZ(5, 4, 3);
            Assert.That(0 * p, Is.EqualTo(new PolynomZ()));
        }

        [Test]
        public void ProductOfPolynoms_Simple()
        {
            var p1 = new PolynomZ(1, 1);     // x+1
            var p2 = new PolynomZ(-1, 1);    // x-1
            var prod = p1 * p2;
            var expected = new PolynomZ(-1, 0, 1); // x^2 - 1
            Assert.That(prod, Is.EqualTo(expected));
        }

        [Test]
        public void ProductOfPolynoms_WithZeroCoeffs()
        {
            var p1 = new PolynomZ(0, 2);     // 2x
            var p2 = new PolynomZ(0, 3);     // 3x
            var prod = p1 * p2;              // 6x^2
            var expected = new PolynomZ(0, 0, 6);
            Assert.That(prod, Is.EqualTo(expected));
        }

        [Test]
        public void Product_ByZeroPolynom()
        {
            var p = new PolynomZ(1, 2, 3);
            var zero = new PolynomZ();
            Assert.That(p * zero, Is.EqualTo(zero));
            Assert.That(zero * p, Is.EqualTo(zero));
        }
    }
}

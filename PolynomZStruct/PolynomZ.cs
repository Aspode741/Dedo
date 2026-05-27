using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomZStruct
{
    public struct PolynomZ
    {
        // храним без 0
        private readonly int[] coefficients;

        public int[] Coeff
        {
            get { return coefficients; }
        }

        // -1
        public int Deg
        {
            get { return coefficients.Length - 1; }
        }

        // убираем нули
        public PolynomZ(IEnumerable<int> coeffs)
        {
            if (coeffs == null)
                throw new ArgumentNullException(nameof(coeffs));

            List<int> list = new List<int>(coeffs);
            while (list.Count > 0 && list[list.Count - 1] == 0)
                list.RemoveAt(list.Count - 1);

            coefficients = list.ToArray();
        }

        public PolynomZ(params int[] coeffs) : this((IEnumerable<int>)coeffs) { }

        public override string ToString()
        {
            if (coefficients.Length == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            for (int i = coefficients.Length - 1; i >= 0; i--)
            {
                int coef = coefficients[i];
                if (coef == 0) continue;

                if (sb.Length > 0) // не первый
                {
                    if (coef > 0) sb.Append('+');
                    else sb.Append('-');
                }
                else
                {
                    if (coef < 0) sb.Append('-');
                }

                int absCoef = Math.Abs(coef);

                if (i > 0) // степень > 0
                {
                    if (absCoef != 1)
                    {
                        sb.Append(absCoef);
                        sb.Append("*x");
                    }
                    else
                        sb.Append('x');

                    if (i > 1)
                    {
                        sb.Append('^');
                        sb.Append(i);
                    }
                }
                else // свободный
                {
                    sb.Append(absCoef);
                }
            }

            return sb.ToString();
        }

        // проверка на равенство
        public override bool Equals(object obj)
        {
            if (obj is PolynomZ other)
            {
                if (coefficients.Length != other.coefficients.Length)
                    return false;
                for (int i = 0; i < coefficients.Length; i++)
                {
                    if (coefficients[i] != other.coefficients[i])
                        return false;
                }
                return true;
            }
            throw new ArgumentException("Объект для сравнения не является PolynomZ");
        }

        public override int GetHashCode()
        {
            int hash = 17;
            for (int i = 0; i < coefficients.Length; i++)
            {
                hash = hash * 23 + coefficients[i];
            }
            return hash;
        }

        // сравниваем
        public static bool operator ==(PolynomZ left, PolynomZ right) => left.Equals(right);
        public static bool operator !=(PolynomZ left, PolynomZ right) => !left.Equals(right);

        // складываем
        public static PolynomZ operator +(PolynomZ left, PolynomZ right)
        {
            int maxLen = Math.Max(left.coefficients.Length, right.coefficients.Length);
            int[] sum = new int[maxLen];
            for (int i = 0; i < left.coefficients.Length; i++)
                sum[i] += left.coefficients[i];
            for (int i = 0; i < right.coefficients.Length; i++)
                sum[i] += right.coefficients[i];

            return new PolynomZ(sum);
        }

        // умножаем
        public static PolynomZ operator *(int k, PolynomZ p)
        {
            if (k == 0) return new PolynomZ();
            int[] result = new int[p.coefficients.Length];
            for (int i = 0; i < p.coefficients.Length; i++)
                result[i] = k * p.coefficients[i];
            return new PolynomZ(result);
        }

        public static PolynomZ operator *(PolynomZ p, int k) => k * p;

        // два многочлена
        public static PolynomZ operator *(PolynomZ left, PolynomZ right)
        {
            if (left.coefficients.Length == 0 || right.coefficients.Length == 0)
                return new PolynomZ();

            int[] prod = new int[left.coefficients.Length + right.coefficients.Length - 1];
            for (int i = 0; i < left.coefficients.Length; i++)
            {
                if (left.coefficients[i] == 0) continue;
                for (int j = 0; j < right.coefficients.Length; j++)
                    prod[i + j] += left.coefficients[i] * right.coefficients[j];
            }

            return new PolynomZ(prod);
        }
    }
}

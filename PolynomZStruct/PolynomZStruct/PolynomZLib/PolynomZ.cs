using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomZStruct
{
    public struct PolynomZ
    {
        // коэффициенты
        private readonly int[] coefficients;

        // доступ извне
        public int[] Coeff
        {
            get
            {
                if (coefficients == null)
                    return new int[0];
                return coefficients;
            }
        }

        //  -1 для нулевого
        public int Deg
        {
            get
            {
                int[] c = Coeff;
                return c.Length - 1;
            }
        }

        // убираем 0
        public PolynomZ(IEnumerable<int> coeffs)
        {
            if (coeffs == null)
                throw new ArgumentNullException("coeffs");

            List<int> list = new List<int>(coeffs);
            while (list.Count > 0 && list[list.Count - 1] == 0)
                list.RemoveAt(list.Count - 1);

            coefficients = list.ToArray();
        }

        public PolynomZ(params int[] coeffs) : this((IEnumerable<int>)coeffs) { }

        // строка
        public override string ToString()
        {
            int[] coeffs = Coeff;
            if (coeffs.Length == 0)
                return "0";

            StringBuilder sb = new StringBuilder();
            for (int i = coeffs.Length - 1; i >= 0; i--)
            {
                int coef = coeffs[i];
                if (coef == 0) continue;

                if (sb.Length > 0) // не первый член
                {
                    if (coef > 0) sb.Append('+');
                    else sb.Append('-');
                }
                else // первый
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

        // сравниваем
        public override bool Equals(object obj)
        {
            if (obj is PolynomZ)
            {
                PolynomZ other = (PolynomZ)obj;
                int[] thisCoeffs = this.Coeff;
                int[] otherCoeffs = other.Coeff;

                if (thisCoeffs.Length != otherCoeffs.Length)
                    return false;
                for (int i = 0; i < thisCoeffs.Length; i++)
                {
                    if (thisCoeffs[i] != otherCoeffs[i])
                        return false;
                }
                return true;
            }
            throw new ArgumentException("Объект для сравнения не является PolynomZ");
        }

        public override int GetHashCode()
        {
            int[] coeffs = Coeff;
            int hash = 17;
            for (int i = 0; i < coeffs.Length; i++)
            {
                hash = hash * 23 + coeffs[i];
            }
            return hash;
        }

        // ещё раз проверяем
        public static bool operator ==(PolynomZ left, PolynomZ right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(PolynomZ left, PolynomZ right)
        {
            return !left.Equals(right);
        }

        // +
        public static PolynomZ operator +(PolynomZ left, PolynomZ right)
        {
            int[] leftCoeffs = left.Coeff;
            int[] rightCoeffs = right.Coeff;
            int maxLen = Math.Max(leftCoeffs.Length, rightCoeffs.Length);
            int[] sum = new int[maxLen];
            for (int i = 0; i < leftCoeffs.Length; i++)
                sum[i] += leftCoeffs[i];
            for (int i = 0; i < rightCoeffs.Length; i++)
                sum[i] += rightCoeffs[i];

            return new PolynomZ(sum);
        }

        // на целое
        public static PolynomZ operator *(int k, PolynomZ p)
        {
            if (k == 0)
                return new PolynomZ();
            int[] coeffs = p.Coeff;
            if (coeffs.Length == 0)
                return new PolynomZ();

            int[] result = new int[coeffs.Length];
            for (int i = 0; i < coeffs.Length; i++)
                result[i] = k * coeffs[i];
            return new PolynomZ(result);
        }

        public static PolynomZ operator *(PolynomZ p, int k)
        {
            return k * p;
        }

        // умножение 2 членов
        public static PolynomZ operator *(PolynomZ left, PolynomZ right)
        {
            int[] leftCoeffs = left.Coeff;
            int[] rightCoeffs = right.Coeff;
            if (leftCoeffs.Length == 0 || rightCoeffs.Length == 0)
                return new PolynomZ();

            int[] prod = new int[leftCoeffs.Length + rightCoeffs.Length - 1];
            for (int i = 0; i < leftCoeffs.Length; i++)
            {
                if (leftCoeffs[i] == 0) continue;
                for (int j = 0; j < rightCoeffs.Length; j++)
                    prod[i + j] += leftCoeffs[i] * rightCoeffs[j];
            }

            return new PolynomZ(prod);
        }
    }
}
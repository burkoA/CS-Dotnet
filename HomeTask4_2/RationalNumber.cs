namespace HomeTask4_2
{
    public sealed class RationalNumber : IComparable
    {
        private readonly int _numerator;

        private readonly int _denominator;

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator <= 0)
            {
                throw new Exception("Denominator cannot be null!");
            }

            ReduceFraction(ref numerator, ref denominator);
            _numerator = numerator;
            _denominator = denominator;
        }

        private void ReduceFraction(ref int number, ref int denominator)
        {
            int gcd = GCD(number, denominator);

            number /= gcd;
            denominator /= gcd;

            if(denominator < 0)
            {
                number = -number;
                denominator = -denominator;
            }
        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public override string ToString()
        {
            return $"{_numerator}/{_denominator}";
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is RationalNumber rationlNumber))
                return false;

            RationalNumber otherRational = obj as RationalNumber;

            if (otherRational._numerator != _numerator || otherRational._denominator != _denominator)
            {
                return false;
            }

            return true;
        }

        public int CompareTo(object? obj)
        {
            if (!(obj is RationalNumber rationlNumber))
                return 1;

            RationalNumber otherRational = obj as RationalNumber;

            return (_numerator * otherRational._denominator).CompareTo(otherRational._numerator * _denominator);
        }

        public static RationalNumber operator +(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            int numerator = firstNumber._numerator * secondNumber._denominator + 
                secondNumber._numerator * firstNumber._denominator;

            int denominator = firstNumber._denominator * secondNumber._denominator;

            return new RationalNumber(numerator, denominator);
        }

        public static RationalNumber operator -(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            return new RationalNumber(firstNumber._numerator * secondNumber._denominator -
                secondNumber._numerator * firstNumber._denominator, firstNumber._denominator * secondNumber._denominator);
        }

        public static RationalNumber operator *(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            return new RationalNumber(firstNumber._numerator * secondNumber._numerator,firstNumber._denominator * secondNumber._denominator);
        }

        public static RationalNumber operator /(RationalNumber firstNumber, RationalNumber secondNumber)
        {
            return new RationalNumber(firstNumber._numerator * secondNumber._denominator, firstNumber._denominator * secondNumber._numerator);
        }

        public static explicit operator double(RationalNumber number)
        {
            return (double)number._numerator / number._denominator;
        }

        public static explicit operator int(RationalNumber number)
        {
            return number._numerator / number._denominator;
        }
    }
}

using System;

namespace Learning03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Verifying Initial Constructors ---");
            
            Fraction f1 = new Fraction();
            Console.WriteLine(f1.GetFractionString());
            Console.WriteLine(f1.GetDecimalValue());

            Fraction f2 = new Fraction(5);
            Console.WriteLine(f2.GetFractionString());
            Console.WriteLine(f2.GetDecimalValue());

            Fraction f3 = new Fraction(3, 4);
            Console.WriteLine(f3.GetFractionString());
            Console.WriteLine(f3.GetDecimalValue());

            Fraction f4 = new Fraction(1, 3);
            Console.WriteLine(f4.GetFractionString());
            Console.WriteLine(f4.GetDecimalValue());

            Console.WriteLine();

            Console.WriteLine("--- Starting Random Loop Test (Step 7) ---");
            
            Fraction randomFraction = new Fraction();
            
            Random randomGenerator = new Random();

            for (int i = 1; i <= 20; i++)
            {
                int randomTop = randomGenerator.Next(1, 11);
                
                int randomBottom = randomGenerator.Next(1, 11);

                randomFraction.SetTop(randomTop);
                randomFraction.SetBottom(randomBottom);

                string fractionStr = randomFraction.GetFractionString();
                double decimalVal = randomFraction.GetDecimalValue();
                
                Console.WriteLine($"Fraction {i}: string: {fractionStr} Number: {decimalVal:0.##}");
            }
        }
    }
}
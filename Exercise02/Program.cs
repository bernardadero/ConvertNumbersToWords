//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Exercise01;
using System.Numerics;


namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a Number to convert to words");
                string? input = Console.ReadLine();
                if (input is null) return;

                BigInteger number = BigInteger.Parse(input);

                Console.WriteLine($"{number:N0} in words is {number.ToWords()}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}

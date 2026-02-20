using System.Text;

namespace labka;

class Program
{
    static void Main()  
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        Func<double, double> discountCalculator = null;
        discountCalculator += prise => prise * 0.95;
        discountCalculator += prise => prise * 0.90;
        discountCalculator += prise => prise - 100;
        
        double result = discountCalculator(1000);
        Console.Write(result);
    }
}
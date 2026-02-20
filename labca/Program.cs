using System.Text;

namespace labca;

internal abstract class Program
{
    private static void Main()  
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        Func<double, double> discountCalculator = null!;
        discountCalculator += prise => prise * 0.95;
        discountCalculator += prise => prise * 0.90;
        discountCalculator += prise => prise - 100;
        
        int prise = 1000;
        discountCalculator(prise);
        double fprice = prise;
        Delegate[] delegates = discountCalculator.GetInvocationList();
        foreach (var @delegate in delegates)
        {
            var disound = (Func<double, double>)@delegate;
            fprice = disound(fprice);
        }
        Console.WriteLine(fprice);
    }
}
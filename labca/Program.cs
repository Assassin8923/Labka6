using System.Text;

namespace labca;

public abstract class Ticket(string path, int prise)
{
    protected string? Path { get; set; } = path;
    protected int Prise { get; set; } = prise;

    public abstract void Buying();
}

public interface IRefuelable
{
    void Refill();
}

public class Economy(string path, int prise) : Ticket(path, prise), IRefuelable
{
    public override void Buying()
    {
        Console.WriteLine($"Вартість проїзду за шляхом {Path},  {Prise} грн");
    }

    public void Refill()
    {
        Console.WriteLine($"Квитків за шляхом:{Path} не залишилося");
    }
}

public class Business(string path, int price) : Ticket(path, price), IRefuelable
{
    public override void Buying()
    {
        Console.WriteLine($"Вартість проїзду за шляхом {Path},  {Prise} грн");
    }

    public void Refill()
    {
        Console.WriteLine($"Квитків за шляхом:{Path} залишилося 20 штук");
    }
}

public class FirstClass(string path, int prise) : Ticket(path, prise), IRefuelable
{
    public override void Buying()
    {
        Console.WriteLine($"Вартість проїзду за шляхом {Path},  {Prise} грн");
    }

    public void Refill()
    {
        Console.WriteLine($"Квитків за шляхом:{Path} залишилося 30");
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        List<Ticket> tickets =
        [
            new Economy("Ужгород-Мукачево", 100),
            new FirstClass("Київ-Харків", 5000),
            new Business("Одеса-Львів", 1000)
        ];

        foreach (Ticket ticket in tickets)
        {
            ticket.Buying();

            if (ticket is IRefuelable refuelable)
            {
                refuelable.Refill();
            }

            Console.WriteLine("---");
        }
    }
}
using System.Text;

namespace labca;

public abstract class Vehicle(string brand, int speed)
{
    protected string? Brand { get; set; } = brand;
    protected int Speed { get; set; } = speed;

    public abstract void Move();
}

public interface IRefuelable
{
    void Refill();
}

public class Car(string brand, int speed) : Vehicle(brand, speed), IRefuelable
{
    public override void Move()
    {
        Console.WriteLine($"{Brand} їде зі швидкістю {Speed} км/год");
    }

    public void Refill()
    {
        Console.WriteLine($"{Brand} на заправці");
    }
}

public class Bicycle(string brand, int speed) : Vehicle(brand, speed)
{
    public override void Move()
    {
        Console.WriteLine($"{Brand} катиться зі швидкістю {Speed} км/год");
    }
}

public class Airplane(string brand, int speed) : Vehicle(brand, speed), IRefuelable
{
    public override void Move()
    {
        Console.WriteLine($"{Brand} летить зі швидкістю {Speed} км/год");
    }

    public void Refill()
    {
        Console.WriteLine($"{Brand} дозаправляється");
    }
}

public static class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        
        List<Vehicle> vehicles =
        [
            new Car("Porch 910", 200),
            new Airplane("Airbus A380", 945),
            new Bicycle("BMX", 10)
        ];

        foreach (Vehicle vehicle in vehicles)
        {
            vehicle.Move();

            if (vehicle is IRefuelable refuelable)
            {
                refuelable.Refill();
            }

            Console.WriteLine("---");
        }
    }
}
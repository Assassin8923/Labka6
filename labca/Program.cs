using System.Text;
namespace labka;

public class BankTerminal
{
    public event Action<int> OnMoneyWithdraw;

    public void Withdraw(int amount)
    {
        Console.WriteLine($"[Термінал]проба зняття: {amount} грн.");
        OnMoneyWithdraw?.Invoke(amount);
    }
}
class Program
{
    static void Main()  
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        BankTerminal b = new BankTerminal();
        b.OnMoneyWithdraw += (amount) => Console.WriteLine($"[SMS] знято {amount} грн.");
        b.Withdraw(100);
    }
}
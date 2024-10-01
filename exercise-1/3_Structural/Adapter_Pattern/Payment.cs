// Adapter pattern in C#
using System;

// Legacy system
public class LegacyPayment
{
    public void MakePayment(string cardNumber, double amount)
    {
        Console.WriteLine($"Processing payment of {amount} for card {cardNumber}");
    }
}

// Target interface
public interface INewPayment
{
    void Pay(string cardNumber, double amount);
}

// Adapter class
public class PaymentAdapter : INewPayment
{
    private readonly LegacyPayment _legacyPayment;

    public PaymentAdapter(LegacyPayment legacyPayment)
    {
        _legacyPayment = legacyPayment;
    }

    public void Pay(string cardNumber, double amount)
    {
        _legacyPayment.MakePayment(cardNumber, amount);
    }
}

class Program
{
    static void Main()
    {
        LegacyPayment legacyPayment = new LegacyPayment();
        INewPayment adapter = new PaymentAdapter(legacyPayment);

        // Modern system using the legacy system via adapter
        adapter.Pay("1234-5678-9012-3456", 100.00);
    }
}

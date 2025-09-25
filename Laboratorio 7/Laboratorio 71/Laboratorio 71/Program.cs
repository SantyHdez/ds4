internal class Program
{
    private static void Main(string[] args)
    {
        banco banco1 = new banco();
        banco1.Operar();
        banco1.DepositosTotales();
        Console.ReadKey();
    }
}
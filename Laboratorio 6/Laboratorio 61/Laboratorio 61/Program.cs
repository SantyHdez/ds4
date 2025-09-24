internal class Program
{
    private static void Main(string[] args)
    {
        int num;
        Console.WriteLine("Digite el numero deseado");

        try
        {
            num = Int16.Parse(Console.ReadLine());

        } catch (FormatException ex){

            Console.WriteLine("No se ha introducido un digito valido");
            num = -1;
        }
        Console.WriteLine(num);
    }
}
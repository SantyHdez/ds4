internal class Program
{
    private static void Main(string[] args)
    {
        int radio;

        Console.WriteLine("Bienvenido al programa para calcular area de un circulo");

        Console.WriteLine("introduce el radio del circulo");
        radio = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos ca = new CalculosMatematicos();

        Console.WriteLine("El area del circulo es: " + ca.AreaCirculo(radio)); 

 
    }

    public class CalculosMatematicos
    {
        public int Calculo(int a, int b)
        {
            return (a + b) * (a - b);
        }

        public double AreaCirculo(int a)
        {
            double pi = 3.14159;
            return pi * (a * a);
        }

    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        int altura, Base;

        Console.WriteLine("Bienvenido al programa para calcular perimetro de un rectangulo");

        Console.WriteLine("introduce la base:");
        Base = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("introduce la altura:");
        altura = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos ca = new CalculosMatematicos();

        Console.WriteLine("El perimetro del rectangunlo es: " + ca.PerimetroRec(altura,Base));


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

        public int PerimetroRec(int a, int b)
        {
            return (2*a)+(2*b);

        }



    }
}
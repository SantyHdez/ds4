using System.Reflection.Metadata.Ecma335;

using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero;

        Console.WriteLine("Introduce el primer número: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introduce el segundo número: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        // Crear instancia de la clase
        CalculosMatematicos ca = new CalculosMatematicos();

        Console.WriteLine("La operación de ({0}+{1})*({0}-{1}) es igual a {2}", primerNumero, segundoNumero, ca.Calculo(primerNumero, segundoNumero));

    }

    public class CalculosMatematicos
    {
        public int Calculo(int a, int b)
        {
            return (a+b)*(a-b);
        }

    }
}


    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Ingrese el lado 1: ");
            int lado1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el lado 2: ");
            int lado2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el lado 3: ");
            int lado3 = Convert.ToInt32(Console.ReadLine());

            if (lado1 == lado2 && lado2 == lado3)
            {
                Console.WriteLine("El triángulo es Equilátero");
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                Console.WriteLine("El triángulo es Isósceles");
            }
            else
            {
                Console.WriteLine("El triángulo es Escaleno");
            }
        }
    }
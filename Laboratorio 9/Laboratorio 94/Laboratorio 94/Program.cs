using System; 

    internal class Program
    {
        private static void Main(string[] args)
        {
            Aleatorios aleatorios = new Aleatorios();

            int numero = aleatorios.GenerarNumero(1, 10);
            Console.WriteLine("Número generado entre 1 y 10: " + numero);

            int[] arreglo = aleatorios.GenerarArreglo(5, 1, 20);
            Console.WriteLine("\nArreglo generado:");
            foreach (int n in arreglo)
            {
                Console.Write(n + " ");
            }
        }
    }

using System;
using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Aleatorios aleatorios = new Aleatorios();

            Console.WriteLine("Generando arreglo de números NO repetidos...\n");

            // Ejemplo: 5 números entre 1 y 20
            int[] arreglo = aleatorios.NoRepe(5, 1, 20);

            Console.WriteLine("Arreglo generado:");
            foreach (int n in arreglo)
            {
                Console.Write(n + " ");
            }
        }
    }



using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Ingrese el precio del producto: ");
            double precio = Convert.ToDouble(Console.ReadLine());

            Console.Write("Ingrese la forma de pago (efectivo/tarjeta): ");
            string formaPago = Console.ReadLine();

            string numeroCuenta = "";
            if (formaPago.ToLower() == "tarjeta")
            {
                Console.Write("Ingrese el número de cuenta (16 dígitos): ");
                numeroCuenta = Console.ReadLine();
            }

        }
    }


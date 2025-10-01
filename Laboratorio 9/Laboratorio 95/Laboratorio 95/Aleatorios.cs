using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Aleatorios
{
    private Random random = new Random();

    public int GenerarNumero(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    public int[] NoRepe(int cantidad, int min, int max)
    {

        int[] arreglo = new int[cantidad];
        int contador = 0;

        while (contador < cantidad)
        {
            int num = random.Next(min, max + 1);
            bool repetido = false;


            for (int i = 0; i < contador; i++)
            {
                if (arreglo[i] == num)
                {
                    repetido = true;
                    break;
                }
            }

            if (!repetido)
            {
                arreglo[contador] = num;
                contador++;
            }
        }

        return arreglo;
    }

}
    
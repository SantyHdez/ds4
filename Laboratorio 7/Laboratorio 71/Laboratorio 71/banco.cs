using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class banco
{
    private cliente cliente1, cliente2, cliente3;

    public banco()
    {
        cliente1 = new cliente("Yhonas");
        cliente2 = new cliente("Ana");
        cliente3 = new cliente("Pedro");
    }

    public void Operar()
    {
        cliente1.Depositar(100);
        cliente2.Depositar(150);
        cliente3.Depositar(200);
        cliente3.Extraer(150);
    }

    public void DepositosTotales()
    {
        int t = cliente1.RetornarMonto() +
            cliente2.RetornarMonto() +
            cliente3.RetornarMonto();

        Console.WriteLine("El total de dinero en el banco es: " + t);
        cliente1.Imprimir();
        cliente2.Imprimir();
        cliente3.Imprimir();
    }
}
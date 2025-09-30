using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CuentaAhorro : Cuenta
{
    public CuentaAhorro(string prmttIdCuenta) : base(prmttIdCuenta)
    {
    }

    public override void CalcularIntereses()
    {
        System.Console.WriteLine(
            "CuentaAhorro.CalcularIntereses() efectuado para " +
            "la cuenta {0}", getIdCuenta());
    }
}

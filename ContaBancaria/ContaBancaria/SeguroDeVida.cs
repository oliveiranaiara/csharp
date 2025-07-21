using ContaBancaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SeguroDeVida : ITributavel
{
    public double CalcularImposto()
    {
        return 50.00;
    }
}

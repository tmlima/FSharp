using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathCSharp
{
    public static class Math
    {
        public static int Fat(int n)
        {
            if (n < 1)
                return 1;
            else
                return n * Fat(n - 1);
        }

        public static Decimal JurosSimples(Decimal valor, Decimal juros, int periodos)
        {
            for (int i = 0; i < periodos; i++)
            {
                valor = valor + juros / 100;
            }

            return valor;
        }

        public static Decimal JurosCompostos(Decimal valor, Decimal juros, int periodos)
        {
            for (int i = 0; i < periodos; i++)
            {
                valor = valor + (valor * juros / 100);
            }

            return valor;
        }
    }
}

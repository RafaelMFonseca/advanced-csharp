using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class _Nullable
    {
        public static void Main(string[] args)
        {
            Nullable<int> i = 10;

            i++;

            Console.WriteLine(i); // Resultado = 11

            int x = (int)i;

            x++;

            Console.WriteLine(x); // Resultado = 12

            i = null;

            int y = i ?? 25;

            Console.WriteLine(y); // Resultado = 25

            int z = i.GetValueOrDefault(50);

            Console.WriteLine(z); // Resultado = 50

            float? money = null;

            try
            {
                float value = (float) money;

                Console.WriteLine(value);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message); // Nullable object must have a value.
            }

            int? a = 10;
            int? b = null;
            int? d = 5;

            Console.WriteLine(a + b); // Resultado = null
            Console.WriteLine(a + d); // Resultado = 15

            if (a > b) // Resultado = false porque b é null (se qualquer lado é null, retorna false)
            {
                Console.WriteLine("a maior que b");
            }
            else
            {
                Console.WriteLine("a menor que b");
            }
        }
    }
}

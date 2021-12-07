using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    // Verificar se duas instâncias de classes se referem à mesma memória = método estático Object.Equals().
    // Verificar se duas instâncias de estruturas tem o mesmo valor = método estático ValueType.Equals().

    // Todas classes herdam de System.Object.
    // Todas estruturas herdam de System.ValueType, você pode chamar o método Equals diretamente no seu objeto.
    // Equals do System.ValueType usa reflection e boxing.

    public class Endereco
    {
        public string Rua { get; set; }
    }

    public struct Documento
    {
        public string Numero { get; set; }
    }

    public class _Value_Equality
    {
        public static void Main(string[] args)
        {
            Endereco endereco1 = new Endereco();
            Endereco endereco2 = endereco1;

            Console.WriteLine(Object.Equals(endereco1, endereco2)); // Resultado = True

            Documento documento1 = new Documento();
            documento1.Numero = "777.797.710-59";

            Documento documento2 = new Documento();
            documento2.Numero = "777.797.710-59";

            Console.WriteLine(ValueType.Equals(documento1, documento2)); // Resultado = True
        }
    }
}

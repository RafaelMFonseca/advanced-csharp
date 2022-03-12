using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp;

public class _Pattern_Matching
{
    public enum OperationStatus
    {
        Starting,
        Running,
        Ending
    }

    public static void Main(string[] args)
    {
        int? idade = 14;

        // Podemos testar e converter um nullable para seu tipo enquanto testamos
        // se ele é null:
        if (idade is int intIdade) // declaration pattern
        {
            Console.WriteLine($"Conseguimos converter nullable para seu tipo {intIdade}");
        }

        object expression = null;

        // 'is null' é mais seguro que '==', porque o tipo pode sobrecrever o operador '=='.
        if (expression is not null)
        {
            Console.WriteLine("expression não é nula");
        }
        try
        {
            Console.WriteLine(expression.ToString()); /* Compilador avisa por possível erro */
        }
        catch
        {
            Console.WriteLine("expression foi acessado enquanto era null");
        }

        List<int> idades = new List<int>();

        // verificar se idades não é null e implementa IList
        if (idades is IList<int> listIdades)
        {
            Console.WriteLine("listIdades não é nula e é um IList");
        }

        OperationStatus status = OperationStatus.Running;

        Console.WriteLine(status switch
        {
            OperationStatus.Starting => "Iniciando...",
            OperationStatus.Running => "Executando...",
            OperationStatus.Ending => "Finalizando...",
            /** discard pattern */
            _ => "Parado..." /* lida com valores nulos ou que não estão previstos no switch */
        });

        
        int age = 15;
        /** Relational patterns **/
        Console.WriteLine(age switch
        {
            < 18 => "Menor de idade",
            >= 18 => "Maior de idade" /* Sem esse if, o compilador avisa que casos acimas de 18 não foram previstos. */
        });

        try
        {
            Console.WriteLine(age switch
            {
                < 13 or > 50 => "Com bastante energia" /** 'or' e 'and' = logical patterns **/
            });
        }
        catch (SwitchExpressionException)
        {
            Console.WriteLine("Caiu na exception pq não cobre todos os casos.");
        }
    }
}

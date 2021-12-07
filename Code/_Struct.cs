using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    // Instância de estruturas podem ser criadas usando o operador new, mas não é obrigatório.
    // Estruturas são copiadas em atribuições.
    // Estruturas são alocadas na thread stack.
    // Não suportam herança, mas podem implementar interfaces.

    public struct Person
    {
        public string Name;

        public Person(string name)
        {
            this.Name = name;
        }
    }

    public class _Struct
    {
        public static void Main(string[] args)
        {
            Person person;

            person.Name = "Teste";

            Console.WriteLine(person.Name); // Resultado = Teste
        }
    }
}

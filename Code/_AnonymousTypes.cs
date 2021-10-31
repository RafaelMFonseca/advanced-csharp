using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class _AnonymousTypes
    {
        public static void Main(string[] args)
        {
            var v = new { Name = "Carlos", Age = 20 };
            // var v2 = new { Name = null }; // ERRO: Cannot assign null to anonymous type property.
            Console.WriteLine($"Name = {v.Name}, Age = {v.Age}");

            var products = new List<Product>()
            {
                new Product("Mouse", 100m),
                new Product("Bed", 50m),
                new Product("Headset", 5m),
                new Product("Car", 50000m),
            };

            // O tipo não pode ser especificado, só o compilador tem acesso.
            var productsQuery = from product in products
                                select new { product.Name }; // Não precisa especificar o nome da propriedade

            foreach (var product in productsQuery)
            {
                Console.WriteLine(product.Name);
            }

            // Pode criar arrays:
            var cities = new[]
            {
                new { Name = "Tokyo" },
                new { Name = "São Paulo" }
            };

            foreach (var city in cities)
            {
                Console.WriteLine(city.Name);
            }

            // tipos anonimos são classes dertivadas de object, não pode fazer cast pra qualquer
            // tipo, exceto object.

            // Usar object para tipos anonimos fere o propósito de tipagem forte, se você
            // pretende armazenar o resultado ou passar para fora do método, considere
            // utilizar uma classe ou estrutura.

            object tipoAnonimo = new { Name = "Teste" };
            var nameTipoAnonimo = tipoAnonimo?.GetType()?.GetProperty("Name")?.GetValue(tipoAnonimo);

            Console.WriteLine(tipoAnonimo?.GetType()?.ToString()); // Resultado = <>f__AnonymousType1`1[System.String]
            Console.WriteLine(nameTipoAnonimo);

            var sideA = new { Name = "Some name" };
            var sideB = new { Name = "Some name" };
            var sideC = new { Name = "Some.." };

            // Equals e GetHashCode são definidos em tipo anonimos.
            // São iguais se todas propriedades são iguais.
            Console.WriteLine((sideA.Equals(sideB))); // Resultado = True
            Console.WriteLine((sideA.Equals(sideC))); // Resultado = False
            Console.WriteLine((sideA == sideB)); // Resultado = False (não tem overloading do operator ==)
        }
    }

    public class Product
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
    // Normalmente utilizado em query de `select` (LINQ).
}

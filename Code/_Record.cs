using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    internal class _Record
    {
        public static void Main(string[] args)
        {
            Pessoa p1 = new Pessoa("Lucas", "Silva");
            Pessoa p2 = new Pessoa("Lucas", "Silva");
            Pessoa p3 = new Pessoa("Lucas", "Pereira");

            // p1.SobreNome = "Caio"; // Erro!

            // Value equality
            Console.WriteLine(p1 == p2); // Resultado = True;
            Console.WriteLine(p1 == p3); // Resultado = False;

            Empresa e1 = new Empresa("Coca-Cola");
            Empresa e2 = new Empresa("Pepsi");
            Empresa e3 = new Empresa("Coca-Cola");

            Console.WriteLine(e1 == e2); // Resultado = False;
            Console.WriteLine(e1 == e3); // Resultado = True;

            e1.RazaoSocial = "Coca-Cola Natal";

            // Records tem sua própria implementação do método 'ToString()'.
            Console.WriteLine(e1); // Resultado = Empresa { RazaoSocial = Coca-Cola Natal }

            Produto pt1 = new Produto();
            Cidade c1 = new Cidade();

            // pt1.Nome = "Mouse"; // Erro!
            c1.Nome = "Jaboticabal"; // OK

            Console.WriteLine(pt1); // Resultado = Produto { Nome =  }
            Console.WriteLine(c1); // Resultado = Cidade { Nome = Jaboticabal }

            Carro ca1 = new Carro("Gol");
            ca1.Marca = "Volkswagen";

            Console.WriteLine(ca1); // Resultado = Carro { Nome = Gol, Marca = Volkswagen }

            Pessoa p4 = new Pessoa("Ruth", "Silva");

            // p4.Nome = "Luth"; // Erro!

            // nondestructive mutation
            Pessoa p5 = p4 with
            { // object initializer syntax
                Nome = "Maria"
            };

            Console.WriteLine(p4 == p5); // Resultado = False

            Empregado em1 = new Empregado("Mario", "Silva", "CEO");

            Console.WriteLine(em1); // Resultado = Empregado { Nome = Mario, SobreNome = Silva, Cargo = CEO }

            var (Nome, SobreNome, Cargo) = em1;

            Console.WriteLine($"Desconstrutor = {{ {nameof(Nome)} = {Nome}, {nameof(SobreNome)} = {SobreNome}, {nameof(Cargo)} = {Cargo} }}");
            // Resultado = Desconstrutor = { Nome = Mario, SobreNome = Silva, Cargo = CEO }
        }
    }

    // 'record' ou 'record class' = reference type. Propriedades = { get; init; }
    public record class Pessoa(string Nome, string SobreNome);
    public record class Empregado(string Nome, string SobreNome, string Cargo) : Pessoa(Nome, SobreNome);
    // 'recors struct' = value type.  Propriedades = { get; set; }
    public record struct Empresa(string RazaoSocial);
    // 'readonly record struct' = value type. Propriedades = { get; init; }
    public readonly record struct Produto(string Nome);
    public record struct Cidade(string Nome);

    // 'record class' ou 'record' = Apenas 1 construtor com todos parâmetros. => Valores imutáveis
    // 'record struct' = Contém 2 construtores, um sem parâmetros e outro com. => Valores mutáveis

    // 'record', 'record class' e 'readonly' = propriedades imutáveis = { get; init; } (Valores setados apenas no construtor)

    // 'record' imutáveis = úteis para manter o hashcode o mesmo na hashtable.

    // Você pode definir suas propriedades também
    public record class Carro(string Nome)
    {
        public string Nome { get; set; } = Nome;
        public string Marca { get; set; }
    }
}

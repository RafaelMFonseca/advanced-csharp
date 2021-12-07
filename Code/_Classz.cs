using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    // Deriva da classe base = membros public, protected e internal, excetos constructors e finalizers
    // Classe static = contém apenas membros estaticos e não pode ser instânciado.

    // Objetos também são chamados de instâncias.
    // Uma variável de uma classe guarda a referênciua na memória do objeto na managed heap.

    // Inheritance, together with encapsulation and polymorphism,

    // 3 caracterísitca primárias do POO = herança, encapsulamento e polimorfismo.

    // Herança = ganha todos membros da classe base, exceto construtores e finalizadores.

    public static class Util
    {
        public static void DoSomething() { }
    }

    // 'abstract class' = não pode ser instânciado, um ou mais de seus métodos não tem implementação
    // e serve como base classe para outras classes.
    public abstract class Box
    {
        public abstract void TryGet(string name);
    }

    // sealed = previne herança futura
    public sealed class Container : Box
    {
        public override void TryGet(string name)
        {

        }
    }

    public class BaseClass
    {
        // Construtor padrão,se a classe derivada não invocar o construtor base explicitamente,
        // o construtor default é chamado implicitamente.
        public BaseClass() { }

        // Construtor estático, chamado apenas uma vez, antes de qualquer instância dele ser criado.
        static BaseClass() { }

        // Override do método virtual ToString() do System.Object.
        public override string ToString() => base.ToString();
    }

    public class DirivedClass : BaseClass
    {

    }

    public class BaseClass2
    {
        public string Name { get; set; }

        public BaseClass2(string name)
        {
            this.Name = name;
        }

        // Posso dar um override em um método virtual em classes derivadas.
        public virtual void DoSomething() { } 
    }

    public class DerivedClass2 : BaseClass2
    {
        public DerivedClass2() : base("DerivedClass2")
        {
        }

        public override void DoSomething() { }
    }

    public class DerivedClass3 : BaseClass2
    {
        public DerivedClass3() : base("DerivedClass3")
        {
        }

        // indica explicitamento que o membro não deve ser override da classe base
        // new não é necessário, mas será gerado um warning pelo compilador
        public new void DoSomething() { }
    }

    public class _Classz
    {
        public static void Main(string[] args)
        {

        }
    }
}

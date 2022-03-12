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

    // No código, pode executar um método da classe base e causar a versão da classe derivada 
    // para ser executada. (com virtual e override).

    // override = faz o método da classe de runtime ser chamada, e não do tipo da variável
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

        protected virtual void DoSomething()
        {
            Console.WriteLine("BaseClass.DoSomething()");
        }

        public void DoSomethingPublic()
        {
            this.DoSomething();
        }
    }

    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            this.DoSomething();
        }

        public new void DoSomething()
        {
            Console.WriteLine("DerivedClass.DoSomething()");
        }
    }

    public class BaseClass2
    {
        public string Name { get; set; }

        public BaseClass2(string name)
        {
            this.Name = name;
        }

        // Posso dar um override em um método virtual em classes derivadas.
        // Se tirar o virtual aqui, dá erro
        // "A derived class can override a base class member only if the base class member
        // is declared as virtual or abstract. "
        public virtual void DoSomething() { } 
    }

    public class DerivedClass2 : BaseClass2
    {
        public DerivedClass2() : base("DerivedClass2")
        {
        }

        // A derived class can stop virtual inheritance by declaring an override as sealed. 
        public sealed override void DoSomething() { }
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

    public class DerivedClass4 : DerivedClass2
    {
        public DerivedClass4() : base()
        {
        }

        // public override void DoSomething() { }  ERRO!

        // Ainda posso usar o 'new' em metodo sealed porque só esconde a impl. do pai
        // É como se fosse um método/impl. nova
        public new void DoSomething() // OK!
        {
            base.DoSomething(); /* Chama método do pai */
        }
    }

    public class _Classz
    {
        public static void Main(string[] args)
        {
            DerivedClass derivedClass = new DerivedClass(); // DerivedClass.DoSomething()
            derivedClass.DoSomethingPublic(); // BaseClass.DoSomething()

            BaseClass baseClass = new DerivedClass(); // DerivedClass.DoSomething()
            baseClass.DoSomethingPublic(); // BaseClass.DoSomething()
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class _Interface
    {
        public static void Main(string[] args)
        {
            Administrator adm = new Administrator();
            adm.Increment(); // OK! Na classe é public
            adm.Decrement();
            // ChangeName(); // ERROR!

            IUser adm2 = new Administrator();
            // adm2.Increment(); // ERROR! Na interface é protected
            adm2.Decrement();
            adm2.ChangeName();
        }
    }

    // Por convenção, nomes de interface começam com I maiúsculo.
    public interface IStore { }
    public interface IProduct { }

    public class Car : IProduct { }
    public abstract class FlyingCar : Car, IStore { }

    public struct Database : IStore { }

    // So conseguimos chamar default method implementation e métodos privates/protected
    // com o tipo da interface.

    public interface IUser
    {
        string Name { get; set; } // properties
        string City { get; }
        string Age { set; }
        // string Country { protected get; protected set; } // ERROR: Cannot specify accessibility modifiers for both accessors of the property or indexer 'property/indexer'
        // int AgeCount; // ERROR: Interface cannot contain instance fields
        // IUser() { } // ERROR: Interface cannot containt instance constructors
        // ~IUser() { } // ERROR: Interface cannot containt instance destructors
        string this[string name] { get; set; } // indexers
        void Speak(); // instance methods
        event OnCreated OnUserCreated; // events
        protected string Increment();
        internal string Decrement();

        private void ChangeCount()
        {
            Count = Count + "Teste";
        }

        public void ChangeName()
        {
            Name = Name + "Teste";
        }

        // Static:
        static IUser Instance; // static members
        static IUser() { } // static constructors
        static string Count;
    }

    // C# 8.0 (.NET Core 3.0): interface pode ter implementações padrões
    // Quando implementar a interface, todos membros devem ser públicos, independente se na interface é private ou protected
    public class Administrator : IUser
    {
        public string Name { get; set; }
        public string City { get; }
        public string Age { set { } }
        public string this[string name] { get { return ""; } set { } }
        public void Speak() { }
        public event OnCreated OnUserCreated;

        public string Increment()
        {
            return string.Empty;
        }

        public string Decrement()
        {
            return string.Empty;
        }
    }

    public delegate string OnCreated(string name);
}

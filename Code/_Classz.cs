using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    // Deriva da classe base = membros public, protected e internal, excetos constructors e finalizers
    // Classe static = contém apenas membros estaticos e não pode ser instânciado.

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

    public sealed class Container : Box
    {
        public override void TryGet(string name)
        {

        }
    }

    public class _Classz
    {
        public static void Main(string[] args)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp;

public class _Ref_In_Out
{
    /* both the method definition and the calling method must explicitly use the ref keyword */
    /* Properties are not variables. They're methods, and cannot be passed to ref parameters. */
    /* A better way to think about it is that "ref" means "I want this formal parameter on the callee
     * side to be an alias for a particular variable on the caller side". */
    public static void Main(string[] args)
    {
        Position p = new(10, 10);
        Console.WriteLine(p.x);
        ChangePosition(ref p);
        Console.WriteLine(p.x);
        ChangeX(ref p.x);
        Console.WriteLine(p.x);

        string[] values = new string[2] { "Apple", "Banana" };
        /** ref local variable = used to refer to values returned using return ref **/
        // accessing a value by reference increases performance by avoiding a potentially expensive copy operation
        ref string fruit = ref ReturnRef(values, 0);
        fruit = "BananaModified";

        // beginning with C# 7.3, you can reassign a ref local or ref readonly local variable with the ref assignment operator.
        fruit = ref ReturnRef(values, 1);
        fruit = "AppleModified";

        Console.WriteLine(string.Join(",", values));

        ref readonly string fruitApple = ref ReturnRef(values, 0); // it's assigned to, and it cannot be modified.
        // fruitApple = "teste"; ERROR!

        /// in = cannot be modified by the called method (variables passed as in arguments must be initialized before being passed in a method call)
        /// ref = arguments may be modified
        /// out = arguments must be modified by the called method
        BehaviourIn(in p);
        BehaviourRef(ref p);
        BehaviourOut(out p);
    }

    static ref string ReturnRef(string[] values, int index)
    {
        return ref values[index];
    }

    static void ChangePosition(ref Position p)
    {
        p = new Position(342, 53);
    }

    /* ensures the argument is not modified */
        static void BehaviourIn(in Position p)
    {
        // p = new Position(10, 10); ERRO!
        p.x = 10;
    }

    static void BehaviourRef(ref Position p)
    {
        p = new Position(20, 20); // OK!
        p.x = 10;
    }

    static void BehaviourOut(out Position p)
    {
        p = new Position(10, 10); /* "p" deve ser atribuido, se comentar esta linha, dá erro */
    }

    static void ChangeX(ref int x)
    {
        x = 692;
    }

    public class Position
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

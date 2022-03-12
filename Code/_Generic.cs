using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanced_csharp
{
    public class _Generic
    {
        public static void Main(string[] args)
        {
            Bindable<string> bindable = new Bindable<string>();

            bindable.BindValue((newValue) =>
            {
                Console.WriteLine(newValue);
            });

            bindable.Value = "Teste!";
        }
    }
    // Genéricos ajuda no type safety(segurança de tipos/tipagem), reutilização de código e performance.
    // Genéricos evita boxing e unboxing.
    // Boxing => um mecanismo para converter explicitamente um tipo por valor para um tipo por referência armazenando a variável em System.Object.
    // Unboxing => é o processo de converter de volta o tipo por referência no tipo por valor.
    // Boxing/Unboxing => degradam o desempenho.
    public class Bindable<T>
    {
        private T? _value;
        public T? Value
        {
            get => _value;
            set
            {
                _value = value;
                OnBindValueChanged?.Invoke(value);
            }
        }

        private event OnBindValueChanged<T> OnBindValueChanged;

        public void BindValue(OnBindValueChanged<T>? onChange)
        {
            OnBindValueChanged += onChange;
        }
    }

    public delegate void OnBindValueChanged<T>(T? bindableValue);
}

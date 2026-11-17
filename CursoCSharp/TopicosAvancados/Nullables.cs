using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp.TopicosAvancados {
    internal class Nullables {

        // inicializada por padrão == 0
        static int num3; 
        public static void Executar() {
            // formas de notação
            Nullable<int> num1 = null;
            int? num2 = null; 


            if (num1.HasValue) Console.WriteLine(num1);
            else Console.WriteLine("Não possui valor");

            int valor = num1 ?? 1000; // coloca um valor padrão
            Console.WriteLine(valor);

            bool? booleana = null; 
            bool resultado = booleana.GetValueOrDefault();
            Console.WriteLine(resultado);

            try
            {
                int x = num1.Value;
                int y = num2.Value;
                Console.WriteLine(x + y);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

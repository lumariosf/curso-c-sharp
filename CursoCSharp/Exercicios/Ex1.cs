using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// algoritmo para verificar se um número é impar ou par
namespace CursoCSharp.Exercicios {
    internal class Ex1 {
        static bool IsOdd(int number) {
            return (number % 2 == 1);
        }

        public static void Executar() {
            Console.WriteLine("Insira um número: ");

            // precisa receber como string e depois passar como inteiro
            int number = int.Parse(Console.ReadLine());

            if (!IsOdd(number)) {
                Console.WriteLine("Par");
            } else {
                Console.WriteLine("Impar");
            }
        }
        
    }
}

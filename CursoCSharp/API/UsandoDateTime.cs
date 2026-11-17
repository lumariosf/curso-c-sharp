using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp.API {
    internal class UsandoDateTime {
        public static void Executar() {
            var dateTime = new DateTime(2030, 2, 6);

            Console.WriteLine(dateTime.Day);
            Console.WriteLine(dateTime.Month);
            Console.WriteLine(dateTime.Year);

            // sem hr
            var hoje = DateTime.Today;
            Console.WriteLine(hoje);

            // com hr
            var diaAtual = DateTime.Now;
            Console.WriteLine(diaAtual);
            Console.WriteLine(diaAtual.Hour);
            Console.WriteLine(diaAtual.Minute);
            Console.WriteLine(diaAtual.Second);

            var amanha = diaAtual.AddDays(1);
            Console.WriteLine(amanha);

            var ontem = diaAtual.AddDays(-1);
            Console.WriteLine(ontem);

            // formatação da data 
            Console.WriteLine(diaAtual.ToString("dd"));
            Console.WriteLine(diaAtual.ToString("d"));
            Console.WriteLine(diaAtual.ToString("D"));
            Console.WriteLine(diaAtual.ToString("g"));
            Console.WriteLine(diaAtual.ToString("G"));
            Console.WriteLine(diaAtual.ToString("dd-MM-yyyy HH:mm"));
        }
    }
}

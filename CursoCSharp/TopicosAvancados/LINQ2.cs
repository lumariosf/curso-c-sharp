using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp.TopicosAvancados {
    internal class LINQ2 {
        public static void Executar() {
            var alunos = new List<Aluno>
            {
                new Aluno()
                {
                    Nome = "Pedro",
                    Idade = 24,
                    Nota = 8,
                },
                new Aluno()
                {
                    Nome = "Luma",
                    Idade = 23,
                    Nota = 7,
                },
                new Aluno()
                {
                    Nome = "Ana",
                    Idade = 25,
                    Nota = 9,
                },
                new Aluno()
                {
                    Nome = "Ana",
                    Idade = 20,
                    Nota = 6,
                },
                new Aluno()
                {
                    Nome = "Jorge",
                    Idade = 19,
                    Nota = 4,
                },
                new Aluno()
                {
                    Nome = "Bianca",
                    Idade = 30,
                    Nota = 7,
                },
                new Aluno()
                {
                    Nome = "Marcio",
                    Idade = 30,
                    Nota = 9.9,
                },
            };

            var pedro = alunos.Single(aluno => aluno.Nome.Equals("Pedro"));
            Console.WriteLine(pedro.Nome + " " + pedro.Nota);

            var fulano = alunos.SingleOrDefault(aluno => aluno.Nome.Equals("Fulano"));
            if (fulano == null)
            {
                Console.WriteLine("Aluno Inexistente");
            } else
            {
                Console.WriteLine(fulano.Nome + " " + fulano.Nota);
            }

            // PEGA O PRIMEIRO ELEMENTO
            var ana = alunos.First(aluno => aluno.Nome.Equals("Ana"));
            Console.WriteLine(ana.Nome + " " + ana.Nota);

            // PEGA O ULTIMO
            var outraAna = alunos.Last(aluno => aluno.Nome.Equals("Ana"));
            Console.WriteLine(outraAna.Nome + " " + outraAna.Nota);

            var exemploskip = alunos.Skip(1).Take(3); 
            foreach (var item in exemploskip)
            {
                Console.WriteLine(item.Nome);
            }

            var maiorNota = alunos.Max(aluno => aluno.Nota);
            Console.WriteLine(maiorNota);

            var menorNota = alunos.Min(aluno => aluno.Nota);
            Console.WriteLine(menorNota);

            var somatorioNotas = alunos.Sum(aluno => aluno.Nota);
            Console.WriteLine(somatorioNotas);

            var mediaNotas = alunos.Average(aluno => aluno.Nota);
            Console.WriteLine(mediaNotas);

            // apenas a media dos alunos aprovados
            var mediaAprovados = alunos.Where(a => a.Nota >= 7).Average(a => a.Nota);
            Console.WriteLine(mediaAprovados);
        }
    }
}
 
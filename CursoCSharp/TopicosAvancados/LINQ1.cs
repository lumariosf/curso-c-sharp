using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp.TopicosAvancados {

    public class Aluno {
        public string Nome;
        public int Idade;
        public double Nota; 
    }

    internal class LINQ1 {
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

            // filtrar apenas alunos aprovados
            Console.WriteLine("## Aprovados");

            // gerar uma nova lista de alunos de acordo com a função lambda
            // filter
            var aprovados = alunos.Where(a => a.Nota >= 7).OrderBy(a => a.Nome); 
            foreach (var aluno in aprovados) {
                Console.WriteLine(aluno.Nome);
            }

            Console.WriteLine("\n## Chamada");
            // map
            var chamada = alunos.OrderBy(a => a.Nome).Select(a => a.Nome); 
            foreach (var aluno in chamada)
            {
                // vira uma string deixa de ser objeto
                Console.WriteLine(aluno);
            }

            Console.WriteLine("\n Aprovados Por Idade");
            var aprovadoidade =
                from aluno in alunos
                where aluno.Nota >= 7
                orderby aluno.Idade
                select aluno.Nome; 

            foreach (var aluno in aprovadoidade)
            {
                Console.WriteLine(aluno);
            }
        }
    }
}

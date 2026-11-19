using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoCSharp.TopicosAvancados;

// faça um algoritmo que exiba quantas pessoas possuem mais de 18 anos, O algoritmo deve ler a idade de 10 pessoas
namespace CursoCSharp.Exercicios {
    public class PessoaIdade {
        public string Nome;
        public int Idade;

        public PessoaIdade(string nome, int idade) {
            this.Nome = nome; this.Idade = idade;
        }
    }

    internal class Ex2 {
        public static void Executar() {
            List<PessoaIdade> pessoas = new List<PessoaIdade>();

            for (int i = 0; i < 10; i++) {
                Console.WriteLine($"Insira o nome da Pessoa {i + 1}");
                string nome = Console.ReadLine();

                Console.WriteLine($"Insira a idade da Pessoa {i + 1}");
                int idade = int.Parse(Console.ReadLine());

                PessoaIdade p = new PessoaIdade(nome, idade);
                pessoas.Add(p);
            }

            var pessoas_de_maior = pessoas.Where(a => a.Idade > 18).ToList();
            Console.WriteLine("As {0} pessoas com mais de 18 anos são:", pessoas_de_maior.Count());
            foreach (var pessoa in pessoas_de_maior)
            {
                Console.WriteLine(pessoa.Nome + " " + pessoa.Idade);
            }
        }
    }
}

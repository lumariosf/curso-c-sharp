using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CursoCSharp.Excecoes;
using System.IO;
using CursoCSharp.ClassesEMetodos;

// talvez a melhor opção para o reajuste de salário é ter alguma forma de processar pedido
namespace CursoCSharp.Exercicios {

    // Ex 4
    // criar uma classe person com nome e salário
    // metodo para reajuste de salario
    // metodo para impressão do nome e salario ajustado
    public class Pessoa {
        public string Nome { get; protected set;  }
        public double Salario { get; protected set; }
        public bool SalarioReajustado { get; protected set; }
        
        // para poder printar no ex 9
        public string Funcao { get; protected set;}
     
        public Pessoa(string nome, double salario) {
            this.Nome = nome;
            this.Salario = salario;
            this.SalarioReajustado = false;
            Funcao = "funcionario";
        }

        public virtual void printPessoas() {
            Console.WriteLine($"{Nome} é {Funcao} e tem salário de {Salario}");
        }

        public virtual void reajuste() {
            if (SalarioReajustado) return; 

            if (Salario <= 300) {
                this.Salario *= 1.5; 
            }
            else {
                this.Salario *= 1.3; 
            }

            SalarioReajustado = true; 
        }

        public void printReajuste() {
            reajuste(); 
            Console.WriteLine($"O funcionário {Nome} tem o novo salário reajustado de {Salario}");
        }
   }

    // Ex 9
    // adicionar gerente e coordenador, como método em comum de atualização de salário (gerente 20% e coordenador com 10%). exibir lista com nome, função e salário
    public class Gerente : Pessoa {
        public Gerente(string nome, double salario) : base(nome, salario) {
            Funcao = "gerente";
        }

        public override void reajuste() {
            if (SalarioReajustado) return; 
            Salario *= 1.2;

            SalarioReajustado = true; 
        }
    }

    public class Coordenador : Pessoa {
        public Coordenador(string nome, double salario) : base(nome, salario) {
            Funcao = "coordenador";
        }

        public override void reajuste() {
            if (SalarioReajustado) return;
            Salario *= 1.1;

            SalarioReajustado = true;
        }
    }
    public class SalarioException : Exception {
        public SalarioException() { }

        public SalarioException(string message) : base(message) { }

        public SalarioException(string message, Exception inner) : base(message, inner) { }
    }

    internal class Ex4 {

        // Ex 5
        // printar os salários reajustados
        public static void Ex5(List<Pessoa> funcionarios) {
            Console.WriteLine("\n## Salário com reajuste");
            for (int i = 0; i < funcionarios.Count(); i++)
            {
                Console.Write("[{0}]. ", i + 1);
                funcionarios[i].printReajuste();
            }
        }

        // Ex 6
        // crie uma lista com 10 pessoas e exiba a lista com o nome e o salário delas
        public static void Ex6(List<Pessoa> funcionarios) {
            Console.WriteLine("\n## Exibir atributos das Pessoas");
            for (int i = 0; i < funcionarios.Count(); i++)
            {
                Console.Write("[{0}]. ", i + 1);
                funcionarios[i].printPessoas();
            }
        }

        // Ex 7
        // crie uma lista com 10 pessoas, remova as 3 primeiras pessoas e exiba a lista com o nome e o salário delas
        public static void Ex7(List<Pessoa> funcionarios) {
            funcionarios.RemoveRange(0, 3); 
            Console.WriteLine("\n## Removeu 3 Pessoas");
            for (int i = 0; i < funcionarios.Count(); i++)
            {
                Console.Write("[{0}]. ", i + 1);
                funcionarios[i].printPessoas();
            }
        }

        // Ex 8
        // crie uma lista com 10 pessoas e exiba a lista na ordem inversa
        public static void Ex8(List<Pessoa> funcionarios) {
            Console.WriteLine("\n##Lista na ordem inversa");
            funcionarios.Reverse();
            for (int i = 0; i < funcionarios.Count(); i++)
            {
                Console.Write("[{0}]. ", i + 1);
                funcionarios[i].printPessoas();
            }
        }

        // Ex 9
        // printar informações e salario ajustado
        public static void Ex9(List<Pessoa> funcionarios) {
            Console.WriteLine("\n##Coordenador e Gerente");
            for (int i = 0; i < funcionarios.Count(); i++)
            {
                Console.Write("[{0}]. ", i + 1);
                funcionarios[i].printPessoas();
                funcionarios[i].printReajuste();
            }
        }

        // Ex 10
        // leia a lista de 10 funcionarios e lance uma exceção caso um funcionario tenha um salário de 2000. exiba nome, função e salario
        public static void Ex10(List<Pessoa> funcionarios) {
            Console.WriteLine("\n##Exceção salário 2000");
            for (int i = 0; i < funcionarios.Count(); i++)
            {
                try
                {
                    Console.WriteLine(Salario2000(funcionarios[i]));
                }
                catch (SalarioException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static string Salario2000(Pessoa p) {
            if (p.Salario == 2000)
            {
                throw new SalarioException($"ERRO: {p.Nome} ({p.Funcao}) tem salário de 2000, que não é permitido!");
            }

            return $"{p.Nome} é {p.Funcao} e tem salário de {p.Salario}"; 
        }

        // Desafio
        // leia um arquivo TXT conendo uma lista de pessoas e converta as pessoas desse arquivo para um objeto de lista de pessoas
        // selecione as pessoas que são coordenadores e que tem o salario maior que 100 (LINQ), exiba o nome setor e o salario dessa seleção
        public static void Desafio() {
            Console.WriteLine("\n##Desafio ler arquivo");
            string[] linhas = File.ReadAllLines(@"Exercicios\pessoas.txt");
            List<Pessoa> temp1 = new List<Pessoa>();

            foreach (string linha in linhas)
            {
                string[] partes = linha.Split(';');

                string nome = partes[0].Trim();
                string funcao = partes[1].Trim();
                double salario = double.Parse(partes[2].Trim());

                switch (funcao)
                {
                    case "gerente":
                        Pessoa g = new Gerente(nome, salario);
                        temp1.Add(g);
                        break;
                    case "coordenador":
                        Pessoa c = new Coordenador(nome, salario);
                        temp1.Add(c);
                        break;
                    default:
                        Pessoa p = new Pessoa(nome, salario);
                        temp1.Add(p);
                        break;
                }
            }

            var coordenadores = temp1.OfType<Coordenador>().Where(c => c.Salario > 100).ToList();
            foreach (var c in coordenadores)
            {
                Console.WriteLine($"Nome: {c.Nome} | Setor: {c.Funcao} | Salário: {c.Salario}");
            }
        }



        public static void Executar() {
            // List<Pessoa> funcionarios = new List<Pessoa>();
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"Insira o nome do funcionário {i + 1}");
            //    string nome = Console.ReadLine();

            //    Console.WriteLine($"Insira o salário do funcionário {i + 1}");
            //    double salario = double.Parse(Console.ReadLine());

            //    Pessoa f = new Pessoa(nome, salario); 
            //    funcionarios.Add(f); 
            //}

            List<Pessoa> funcionarios = new List<Pessoa>
            {
                new Pessoa("oi1", 100),
                new Pessoa("oi2", 200),
                new Pessoa("oi3", 300),
                new Pessoa("oi4", 400),
                new Pessoa("oi5", 500),
                new Pessoa("oi6", 600),
                new Pessoa("oi7", 700),
                new Pessoa("oi8", 2000),
                new Pessoa("oi9", 900000),
                new Pessoa("oi10", 100000),
            }; 

            // Ex 5
            // printar os salários reajustados
            Ex5(funcionarios);

            // Ex 6
            // crie uma lista com 10 pessoas e exiba a lista com o nome e o salário delas
            Ex6(funcionarios); 

            // Ex 7
            // crie uma lista com 10 pessoas, remova as 3 primeiras pessoas e exiba a lista com o nome e o salário delas
            Ex7(funcionarios);

            // Ex 8 
            // crie uma lista com 10 pessoas e exiba a lista na ordem inversa
            Ex8(funcionarios);

            // Ex 9
            // printar agora com coordenador e gerente
            List<Pessoa> temp = new List<Pessoa>
            {
                new Pessoa("oi6", 600),
                new Pessoa("oi7", 700),
                new Pessoa("oi8", 2000),
                new Pessoa("oi9", 900000),
                new Pessoa("oi10", 100000),
                new Gerente("fulano", 1200),
                new Coordenador("iooo", 1200),
                new Coordenador("blablabla", 800),
                new Gerente("eita", 10000),
            };
            Ex9(temp);

            // Ex 10
            // leia a lista de 10 funcionarios e lance uma exceção caso um funcionario tenha um salário de 2000. exiba nome, função e salario
            Ex10(temp);

            // Desafio
            // leia um arquivo TXT conendo uma lista de pessoas e converta as pessoas desse arquivo para um objeto de lista de pessoas
            // selecione as pessoas que são coordenadores e que tem o salario maior que 100 (LINQ), exiba o nome setor e o salario dessa seleção
            Desafio(); 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoCSharp.TopicosAvancados {
    internal class Dynamics {
        public static void Executar() {
            // criar um tipo dinamico
            // aceita todo tipo
            dynamic meuObjeto = "teste";
            meuObjeto = 3;
            meuObjeto = 5.89;
            meuObjeto++;
            Console.WriteLine(meuObjeto);

            dynamic aluno = new System.Dynamic.ExpandoObject();
            aluno.nome = "fulano";
            aluno.nota = 8.9;
            aluno.idade = 78;

            Console.WriteLine(aluno.nome + " " + aluno.nota + " " + aluno.idade);
        }
    }
}

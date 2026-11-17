using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace CursoCSharp.API {
    internal class Diretorios {
        public static void Executar() {
            var novoDir = @"~/PastaCSharp".ParseHome();
            var novoDirDestino = @"~/PastaCSharpDestino".ParseHome();
            var dirProjeto = @"~/source/repos/CursoCSharp/CursoCSharp".ParseHome();

            //directory é metodo estaticos
            // n precisa criar instancia
            if (Directory.Exists(novoDir)) {
                // excluir de forma recursiva
                Directory.Delete(novoDir, true); 
            }

            if (Directory.Exists(novoDirDestino))
            {
                Directory.Delete(novoDirDestino, true); 
            }

            Directory.CreateDirectory(novoDir);
            // ver a data de criação do diretório
            Console.WriteLine(Directory.GetCreationTime(novoDir));

            // printar todas as pastas
            Console.WriteLine("\n## Pastas");
            var pastas = Directory.GetDirectories(dirProjeto);
            foreach (var pasta in pastas)
            {
                Console.WriteLine(pasta);
            }

            // printar arquivos 
            Console.WriteLine("\n## Arquivos");
            var arquivos = Directory.GetFiles(dirProjeto);
            foreach (var arquivo in arquivos)
            {
                Console.WriteLine(arquivo);
            }

            // qual a pasta/drive de um diretorio
            Console.WriteLine("\n## Raiz");
            Console.WriteLine(Directory.GetDirectoryRoot(novoDir));

            Directory.Move(novoDir, novoDirDestino);
        }
    }
}

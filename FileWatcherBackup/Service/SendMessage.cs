using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherBackup.Service
{
    public static class SendMessage
    {
        public static void SendWelcomeSystem(bool? clientExist = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("========================================");
            Console.WriteLine("====== AUTO BACKUP PASTA ORI-DEST ======");
            Console.WriteLine("========================================");
            if (!clientExist ?? false)
            {
                Console.WriteLine("\n============= INFORMAÇÕES ==============");
                Console.WriteLine("=== Origem: Pasta a ser monitorada =====");
                Console.WriteLine("=== Destino: Pasta a receber backup ====");
                Console.WriteLine("========================================");

                Console.WriteLine("\n============== OBSERVAÇÃO ==============");
                Console.WriteLine("=== Será salvo um arquivo com o nome ===");
                Console.WriteLine("=== \"fileWatcherBackupPatchs.txt\" ======");
                Console.WriteLine("=== para ser lido ao iniciar novamente =");
                Console.WriteLine("=== o arquivo pode ser editado e a =====");
                Console.WriteLine("=== falta dele será solicitado uma =====");
                Console.WriteLine("=== nova configuração ao iniciar o app =");
                Console.WriteLine("========================================");
            }
            else
            {
                Console.WriteLine("==== AUTO BACKUP - CONFIGURAÇÃO OK  ====");
                Console.WriteLine("====== EM EXECUÇÃO - OBSERVANDO ========");
                Console.WriteLine("========================================");
            }
        }

        public static void SendNotify(string relativePath, string targetPath, bool? catcher = false)
        {
            Console.ForegroundColor = catcher ?? false ? ConsoleColor.Yellow : Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Arquivo de: {relativePath}\nCopiado para: {targetPath}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Observado...");
        }
    }
}

using FileWatcherBackup.Controller.Interface;
using FileWatcherBackup.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherBackup.Controller
{
    public class SaveConfigController : ISaveConfigController
    {
        public bool SavePathsToFile(string sourcePath, string targetPath)
        {

            if (!Directory.Exists(sourcePath) || !Directory.Exists(targetPath))
            {
                string msg = string.IsNullOrWhiteSpace(sourcePath) 
                    ? $"Caminho \"Origem\" não informado"
                    : string.IsNullOrWhiteSpace(targetPath) 
                    ? $"Caminho \"Destino\" não informado"
                    : !Directory.Exists(sourcePath) 
                    ? $"Caminho \"Origem\" não encontrado \nCaminho: {sourcePath}" 
                    : $"Caminho \"Destino\" não encontrado \nCaminho: {targetPath}";

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n========================================");
                Console.WriteLine(msg);
                Console.WriteLine("========================================\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("========================================");
                return false;
            }

            using (StreamWriter writer = new StreamWriter(PathConfigModel.filePath))
            {
                writer.WriteLine(sourcePath);
                writer.WriteLine(targetPath);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Informações salvas em {PathConfigModel.filePath}\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }

        public string[] ReadPathsFromFile(string configFolderPath)
        {
            if (File.Exists(PathConfigModel.filePath))
            {
                return File.ReadAllLines(PathConfigModel.filePath);
            }

            return new string[0];
        }
    }
}

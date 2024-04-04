using FileWatcherBackup.Controller;
using FileWatcherBackup.Controller.Interface;
using FileWatcherBackup.Model;
using FileWatcherBackup.Service;

namespace FileWatcher
{
    public class Program
    {

        static void Main(string[] args) 
        {
            ISaveConfigController _saveConfig = new SaveConfigController();
            IWatcherController _watcher = new WatcherController();

            PathConfigModel.configFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            PathConfigModel.filePath = Path.Combine(PathConfigModel.configFolderPath, "fileWatcherBackupPatchs.txt");

            SendMessage.SendWelcomeSystem(File.Exists(PathConfigModel.filePath));
            if (File.Exists(PathConfigModel.filePath))
            {
                // Lendo as informações do arquivo
                string[] paths = _saveConfig.ReadPathsFromFile(PathConfigModel.configFolderPath);
                if (paths.Length == 2)
                {
                    PathConfigModel.sourcePath = paths[0];
                    PathConfigModel.targetPath = paths[1];
                }
            }
            else
            {
                bool salvo;
                do
                {
                    Console.Write("Origem: ");
                    PathConfigModel.sourcePath = Console.ReadLine();
                    Console.Write("Destino: ");
                    PathConfigModel.targetPath = Console.ReadLine();
                    Console.WriteLine("========================================");
                    salvo = _saveConfig.SavePathsToFile(PathConfigModel.sourcePath, PathConfigModel.targetPath);
                } while (!salvo);
            }

            _watcher.WatchPathBackup();

            Console.WriteLine("Programa em execução. Pressione Ctrl+C para sair.");
            while (true)
            {
                // Mantém o programa em execução
            }
        }
    }
}

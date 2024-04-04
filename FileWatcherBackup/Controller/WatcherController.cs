using FileWatcherBackup.Controller.Interface;
using FileWatcherBackup.Model;
using FileWatcherBackup.Service;

namespace FileWatcherBackup.Controller
{
    public class WatcherController : IWatcherController
    {
        public void WatchPathBackup()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = PathConfigModel.sourcePath;
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.DirectoryName;
            watcher.IncludeSubdirectories = true;
            watcher.Filter = "*.*";
            watcher.Changed += (sender, eventArgs) =>
            {
                string fullPath = eventArgs.FullPath;
                string relativePath = fullPath.Substring(PathConfigModel.sourcePath.Length + 1);
                string destPath = Path.Combine(PathConfigModel.targetPath, relativePath);

                try
                {
                    if (File.Exists(fullPath))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                        File.Copy(fullPath, destPath, true);
                    }
                    else if (Directory.Exists(fullPath))
                    {
                        Directory.CreateDirectory(destPath);
                    }

                    SendMessage.SendNotify(relativePath, PathConfigModel.targetPath);
                }
                catch (IOException ex)
                {
                    SendMessage.SendNotify(relativePath, PathConfigModel.targetPath, true);
                }
            };

            watcher.EnableRaisingEvents = true;
        }
    }
}

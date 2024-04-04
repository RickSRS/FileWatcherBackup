using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcherBackup.Controller.Interface
{
    public interface ISaveConfigController
    {
        bool SavePathsToFile(string sourcePath, string targetPath);
        string[] ReadPathsFromFile(string configFolderPath);
    }
}

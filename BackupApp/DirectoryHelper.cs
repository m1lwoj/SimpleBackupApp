using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BackupApp
{
    public class DirectoryHelper
    {
        public static string GetExternalDrivePath(string driveLabel)
        {
            var drive = DriveInfo.GetDrives().Where(d => d.VolumeLabel == driveLabel).FirstOrDefault();

            if (drive == null)
            {
                throw new DriveNotFoundException($"{driveLabel} external drive not found");
            }

            return drive.Name;
        }

        public static List<string> GetAllFilesFromDirectory(string directory)
        {
            var recursiveSearch = new RecursiveDirectorySearch();
            return recursiveSearch.GetAllFiles(directory);
        }

        public static List<string> GetLibraryFolders(string libraryName)
        {
            var list = new List<string>();
            var userLibraryPath = ShellLibraryFacade.GetUserLibraryPath();
            foreach (var item in ShellLibraryFacade.GetLibraryFolders(libraryName, userLibraryPath))
            {
                list.Add(item);
            }

            return list;
        }
    }
}

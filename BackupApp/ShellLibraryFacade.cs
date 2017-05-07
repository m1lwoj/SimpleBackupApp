using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupApp
{
    /// <summary>
    /// Windows API Code Pack Shell facade
    /// https://www.codeproject.com/articles/65535/windows-libraries-c-quick-reference
    /// </summary>
    public class ShellLibraryFacade
    {
        public static void CreateNewLibrary(string libraryName, string libraryLocationPath, bool overwriteExisting)
        {
            ShellLibrary shellLibrary = new ShellLibrary(libraryName, libraryLocationPath, overwriteExisting);
        }

        public static void AddFolderToLibrary(string libraryName, string folderPath, string folderToAdd)
        {
            using (ShellLibrary shellLibrary = ShellLibrary.Load(libraryName, folderPath, false))
            {
                shellLibrary.Add(folderToAdd);
            }
        }

        public static void RemoveFolderFromLibrary(string libraryName, string folderPath, string folderToRemove)
        {
            using (ShellLibrary shellLibrary = ShellLibrary.Load(libraryName, folderPath, false))
            {
                shellLibrary.Add(folderToRemove);
            }
        }

        public static IEnumerable<string> GetLibraryFolders(string libraryName, string folderPath)
        {
            List<string> libraryDirectories = new List<string>();

            using (ShellLibrary shellLibrary = ShellLibrary.Load(libraryName, folderPath, true))
            {
                foreach (ShellFileSystemFolder folder in shellLibrary)
                {
                    libraryDirectories.Add(folder.Path);
                }
            }

            return libraryDirectories;
        }

        public static string GetUserLibraryPath()
        {
            ICollection<IKnownFolder> allSpecialFolders = KnownFolders.All;
            var librariesFolder = allSpecialFolders.Where(a => a.CanonicalName.Contains("Libraries") && a.Category == FolderCategory.PerUser).FirstOrDefault();

            if (librariesFolder == null)
            {
                throw new FileNotFoundException("Libraries for user not found");
            }

            return librariesFolder.Path;
        }
    }
}

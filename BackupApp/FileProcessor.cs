using System;
using System.Collections.Generic;
using System.IO;

namespace BackupApp
{
    public class FileProcessor
    {
        public double ProcessedData { get; private set; }
        public int ProcessedFiles { get; private set; }
        public float FileErrors { get; private set; }

        private List<string> FilePaths;

        public FileProcessor()
        {
            FilePaths = new List<string>();
        }

        public void LoadDirectoryFiles(string directoryPath)
        {
            FilePaths = DirectoryHelper.GetAllFilesFromDirectory(directoryPath);
        }

        public void LoadLibraryFiles(string libraryName)
        {
            foreach (var directory in DirectoryHelper.GetLibraryFolders(libraryName))
            {
                foreach (var file in DirectoryHelper.GetAllFilesFromDirectory(directory))
                {
                    FilePaths.Add(file);
                }
            }
        }

        public void CopyFilesToExternalDrive(string externalDriveVolumeName)
        {
            foreach (var filePath in FilePaths)
            {
                try
                {
                    Console.WriteLine($"Copying file: {filePath} ");

                    var mainDrive = Directory.GetDirectoryRoot(filePath);
                    var externalDriveFilePath = filePath.Replace(mainDrive, externalDriveVolumeName);
                    FileInfo file = new FileInfo(externalDriveFilePath);
                    file.Directory.Create();
                    File.Copy(filePath, externalDriveFilePath, true);

                    ProcessedData += file.Length.ToMb(4);
                    ProcessedFiles++;
                    Console.WriteLine($"Copied to: {externalDriveFilePath} ({file.Length.ToMb(4)} Mb)");
                }
                catch (Exception ex)
                {
                    FileErrors++;
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

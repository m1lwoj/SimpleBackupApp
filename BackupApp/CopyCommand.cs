using System;

namespace BackupApp
{
    public class CopyCommand
    {
        public void Run(string externalDriveLabel, string copyingLibrary)
        {
            try
            {
                var externalDrivePath = DirectoryHelper.GetExternalDrivePath(externalDriveLabel);
                FileProcessor fileProcessor = new FileProcessor();
                fileProcessor.LoadLibraryFiles(copyingLibrary);

                fileProcessor.CopyFilesToExternalDrive(DirectoryHelper.GetExternalDrivePath(externalDriveLabel));

                DisplayInfo(fileProcessor);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayInfo(FileProcessor fileProcessor)
        {
            Console.WriteLine($"Files processed: {fileProcessor.ProcessedFiles} with size: {fileProcessor.ProcessedData} MB");
            Console.WriteLine($"Errors encountered: {fileProcessor.FileErrors}");
        }
    }
}

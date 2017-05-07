using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupApp
{
    public class RecursiveDirectorySearch
    {
        private List<string> filePaths;

        public RecursiveDirectorySearch()
        {
            filePaths = new List<string>();
        }

        public List<string> GetAllFiles(string directory)
        {
            try
            {
                foreach (string dir in Directory.GetDirectories(directory))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        filePaths.Add(file);
                    }

                    GetAllFiles(dir);
                }

            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return filePaths;
        }
    }
}

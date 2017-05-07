using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine("Missing first argument - external drive volumne");
            }
            else if (string.IsNullOrEmpty(args[1]))
            {
                Console.WriteLine("Missing second argument - library name");
            }
            else
            {
                new CopyCommand().Run(args[0], args[1]);
            }

            Console.ReadLine();
        }
    }
}

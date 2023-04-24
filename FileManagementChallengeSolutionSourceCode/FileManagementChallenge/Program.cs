using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = @"D:\Temp\TestFiles\Source";
            string destination = @"D:\Temp\TestFiles\Destination";

            CopyFiles(source, destination, includeSubfolders: true, flattenStructure: true);

            Console.WriteLine("File Copy Complete");

            Console.ReadLine();
        }

        private static void CopyFiles(string sourceDirectory, string destinationDirectory, 
            bool includeSubfolders, bool flattenStructure)
        {
            SearchOption searchOption;

            if (includeSubfolders)
            {
                searchOption = SearchOption.AllDirectories;
            }
            else
            {
                searchOption = SearchOption.TopDirectoryOnly;
            }

            var fileList = Directory.GetFiles(sourceDirectory, "*", searchOption);

            foreach (string fileToCopy in fileList)
            {
                // D:\Temp\Subfolder\myfile.txt
                // Find what the relative path is - Subfolder1_filename.txt
                // Find the destination
                // Copy
                CopyFile(sourceDirectory, fileToCopy, destinationDirectory, flattenStructure);
            }
        }

        private static void CopyFile(string sourceDirectory, string sourceFile, 
            string destinationDirectory, bool flattenStructure)
        {
            var sourceFolders = sourceDirectory.Split('\\');
            var sourceFileFolders = Path.GetDirectoryName(sourceFile).Split('\\');
            string fileName = Path.GetFileName(sourceFile);
            List<string> subfolders = new List<string>();

            for (int i = sourceFolders.Length; i < sourceFileFolders.Length; i++)
            {
                subfolders.Add(sourceFileFolders[i]);
            }

            if (flattenStructure)
            {
                string newFileName = "";

                foreach (string subfolder in subfolders)
                {
                    newFileName += subfolder + "_";
                }

                newFileName += fileName;

                string destinationFile = Path.Combine(destinationDirectory, newFileName);

                try
                {
                    File.Copy(sourceFile, destinationFile, false);
                }
                catch (IOException)
                {
                    // Ignore this and continue because we don't want to overwrite an existing file
                }
            }
            else
            {
                string newDestination = destinationDirectory;

                foreach (string subfolder in subfolders)
                {
                    newDestination = Path.Combine(newDestination, subfolder);
                }

                Directory.CreateDirectory(newDestination);

                string newFileName = Path.Combine(newDestination, fileName);

                try
                {
                    File.Copy(sourceFile, newFileName, false);
                }
                catch (IOException)
                {
                    // Ignore this and continue because we don't want to overwrite an existing file
                }
            }
        }
    }
}

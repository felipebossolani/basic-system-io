using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Net;

namespace basic_system_io
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ReadWriteFile method:");
            ReadWriteFile();
            Console.WriteLine("\n\n*******************\n\n");
            Console.WriteLine("GetSpecialFolder method:");
            GetSpecialFolder();

            Console.WriteLine("\n\n*******************\n\n");
            Console.WriteLine("ListFiles method:");
            ListFiles();
        }

        static string GetFileInfo(string fileName)
        {
            var info = new FileInfo(fileName);
            return $"{info.FullName} - size: {info.Length} kb";
        }

        static void GetSpecialFolder()
        {
            // special folders
            var docs = Environment.SpecialFolder.MyDocuments;
            var app = Environment.SpecialFolder.CommonApplicationData;
            var prog = Environment.SpecialFolder.ProgramFiles;
            var desk = Environment.SpecialFolder.Desktop;

            // application folder
            var dir = System.IO.Directory.GetCurrentDirectory();

            Console.WriteLine($"docs folder: {docs}\napp folder: {app}\nprog folder: {prog}\ndesktop folder: {desk}\n working folder: {dir}");

            /*
            // isolated storage folder(s)
            var iso = IsolatedStorageFile
                .GetStore(IsolatedStorageScope.Assembly, "Demo")
                .GetDirectoryNames("*");

            Console.WriteLine($"Iso folder: {iso}");
            */
            // manual path
            var temp = new System.IO.DirectoryInfo("c:\temp");

        }

        static void ListFiles()
        {
            foreach(var file in Directory.GetFiles(@"c:\temp"))
            {
                Console.WriteLine(GetFileInfo(file));
            }
        }

        static void ReadWriteFile()
        {
            var dir = Directory.GetCurrentDirectory();
            Console.WriteLine($"Current path: {dir}");

            var file = Path.Combine(dir, "File.txt");
            var content = "How now brown cow?";

            //write file
            File.WriteAllText(file, content);
            Console.WriteLine("File created");
            //read file
            var read = File.ReadAllText("File.txt");
            Console.WriteLine("File read");

            if (read.Equals(content))
            {
                Console.WriteLine("File content and variable content are equals");
            }
        }
    }
}

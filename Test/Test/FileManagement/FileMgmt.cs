using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using log4net;

namespace FileManagement
{
    class FileMgmt
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static String directory = "";

        public static void Opertion()
        {
            Console.WriteLine("Enter directory name");
            directory = Console.ReadLine();
            if (Directory.Exists(directory))
            {
                string[] dirs = Directory.GetFiles(directory);
                Console.WriteLine("The files are avaliable in " + directory + " is:");
                foreach (string dir in dirs)
                {
                    Console.WriteLine(dir);
                }
            }
            else
            {
                Console.WriteLine("directory not avaliable!");
            }
        }
        /// <summary>
        /// upload file
        /// </summary>
        public static void FileUpload()
        {
            Console.WriteLine("Enter filename with directory");
            String s = Console.ReadLine();
            if (File.Exists(s))
            {
                Console.WriteLine("file already avaliable");
            }
            else
            {
                File.Create(s);
            }
        }
        public static void CreateSubFolder()
        {
            Console.WriteLine("Enter Directory");
            String s = Console.ReadLine();
            if (Directory.Exists(s))
            {
                Console.WriteLine("Directory Already avaliable");
            }
            else
            {
                Directory.CreateDirectory(s);
                Console.WriteLine("created Directory");
            }
        }
        /// <summary>
        /// Deleting file
        /// </summary>
        public static void DeleteFile()
        {
            Console.WriteLine("Enter file loction to delete");
            String s = Console.ReadLine();
            if (File.Exists(s))
            {
                File.Delete(s);
                Console.WriteLine("'File deleted");
            }
            else
            {
                Console.WriteLine("File not avaliable!");
            }
        }
        public static void SerachFile()
        {
            Console.WriteLine("Enter file loction");
            String s = Console.ReadLine();
            if (File.Exists(s))
            {
                Console.WriteLine("File is avaliable");
            }
            else
            {
                Console.WriteLine("File not avaliable!");
            }
        }

        static void Main(string[] args)
        {
            Opertion();
            //FileUpload();
            //DeleteFile();
            //SerachFile();
            Console.ReadLine();
        }
    }
}

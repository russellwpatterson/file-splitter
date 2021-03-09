using System;
using System.IO;
using System.Linq;

namespace FileSplitter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Without .txt
			const string filename = "some-file.txt";
            const int itemsPerFile = 200;

            var s = new StreamReader(filename);

            var filenameParts = filename.Split('.');

            var baseFilename = filename;
            var extension = "txt";

            if (filenameParts.Length > 1)
            {
                baseFilename = string.Join(".", filenameParts.Take(filenameParts.Length - 1).ToArray());
                extension = filenameParts[filenameParts.Length - 1];
            }

            var fileId = 1;
            while (s.Peek() != -1)
            {
                var sw = new StreamWriter($"{baseFilename}.{fileId}.{extension}");
                
                for (int i = 0; i < itemsPerFile; i++)
                {
                    if (s.Peek() != -1)
                        sw.WriteLine(s.ReadLine());
                    else
                        break;
                }

                sw.Close();
                fileId++;
            }

            s.Close();
        }
    }
}

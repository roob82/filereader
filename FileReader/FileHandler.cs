using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace FileReader
{
    public class FileHandler
    {
        public int? Run(string path)
        {
            int? matches = null;

            try
            {
                if (!File.Exists(path))
                {
                    throw new IOException($"File does not exist.");
                }

                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);

                // I assume the file Encoding is UTF8
                matches = File.ReadLines(path)
                    .Select(line => Regex.Matches(line, filenameWithoutExtension).Count)
                    .Sum();

            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"IO Exception when reading file {0} - Message: {1}", path, ioEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when reading file {0} - Message: {1}", path, ex.Message);
            }

            return matches;
        }
    }
}